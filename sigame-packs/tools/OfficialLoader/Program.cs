using SIPackages;
using System.Text.Json;

using var stream = File.OpenRead(args[0]);
using var doc = SIDocument.Load(stream);
using var buildInfo = JsonDocument.Parse(File.ReadAllText(args[1]));
var expected = buildInfo.RootElement;
int questions = 0, images = 0, audio = 0, aliases = 0;
if (doc.Package.Rounds.Count != expected.GetProperty("rounds").GetInt32() ||
    doc.Package.Rounds.Any(r => r.Themes.Count != expected.GetProperty("themes_per_round").GetInt32()))
    throw new InvalidDataException("Unexpected game board");
int roundIndex = 0;
foreach (var round in doc.Package.Rounds)
{
    int priceStep = round.Themes[0].Questions[0].Price;
    roundIndex++;
    foreach (var theme in round.Themes)
    {
        if (!theme.Questions.Select(q => q.Price).SequenceEqual(Enumerable.Range(1, 5).Select(n => n * priceStep)))
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
}
if (questions != expected.GetProperty("questions").GetInt32() ||
    images != expected.GetProperty("images").GetInt32() ||
    audio != expected.GetProperty("audio").GetInt32() || doc.Package.Version < 5)
    throw new InvalidDataException($"Import mismatch: questions={questions}; images={images}; audio={audio}; format={doc.Package.Version}");
Console.WriteLine($"Official SIPackages 7.14.0: imported SIQ 4 as {doc.Package.Version}; " +
    $"{roundIndex} rounds, {questions} questions, {images} images, {audio} audio files, {aliases} accepted answers. PASS");
