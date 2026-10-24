using SIPackages;

using var stream = File.OpenRead(args[0]);
using var doc = SIDocument.Load(stream);
int questions = 0, images = 0, audio = 0, aliases = 0;
if (doc.Package.Rounds.Count != 1 || doc.Package.Rounds[0].Themes.Count != 6)
    throw new InvalidDataException("Unexpected game board");
foreach (var round in doc.Package.Rounds)
foreach (var theme in round.Themes)
{
    if (!theme.Questions.Select(q => q.Price).SequenceEqual(new[] { 100, 200, 300, 400, 500 }))
        throw new InvalidDataException("Unexpected prices");
    foreach (var question in theme.Questions)
    {
        questions++;
        if (question.Right.Count == 0 || question.Right.Any(string.IsNullOrWhiteSpace))
            throw new InvalidDataException("Missing answer");
        aliases += question.Right.Count;
        foreach (var item in question.GetContent())
        {
            if (item.Type != "image" && item.Type != "audio") continue;
            if (!item.IsRef) throw new InvalidDataException("External media");
            var collection = item.Type == "image" ? doc.Images : doc.Audio;
            var file = collection.GetFile(item.Value)
                ?? throw new InvalidDataException("Missing media: " + item.Value);
            using var mediaStream = file.Stream;
            if (mediaStream.ReadByte() < 0) throw new InvalidDataException("Empty media");
            if (item.Type == "image") images++; else audio++;
        }
    }
}
if (questions != 30 || images != 10 || audio != 15 || doc.Package.Version < 5)
    throw new InvalidDataException($"Import mismatch: questions={questions}; images={images}; audio={audio}; format={doc.Package.Version}");
Console.WriteLine($"Official SIPackages 7.14.0: imported SIQ 4 as {doc.Package.Version}; " +
    $"{questions} questions, {images} images, {audio} audio files, {aliases} accepted answers. PASS");
