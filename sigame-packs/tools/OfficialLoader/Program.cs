using SIPackages;
using SIPackages.Core;
using System.Text.Json;

using var stream = File.OpenRead(args[0]);
using var doc = SIDocument.Load(stream);
using var buildInfo = JsonDocument.Parse(File.ReadAllText(args[1]));
var expected = buildInfo.RootElement;
int questions = 0, images = 0, audio = 0, aliases = 0, finalRounds = 0, finalQuestions = 0;
int expectedFinals = expected.TryGetProperty("final_rounds", out var finals) ? finals.GetInt32() : 0;
if (doc.Package.Rounds.Count != expected.GetProperty("rounds").GetInt32())
    throw new InvalidDataException("Unexpected game board");
int roundIndex = 0;
foreach (var round in doc.Package.Rounds)
{
    bool isFinal = round.Type == RoundTypes.Final;
    if (isFinal)
    {
        finalRounds++;
        if (round != doc.Package.Rounds[^1] || round.Themes.Count != 1 || round.Themes[0].Questions.Count != 1)
            throw new InvalidDataException("Final must be last with exactly one question");
    }
    else if (round.Themes.Count != expected.GetProperty("themes_per_round").GetInt32())
        throw new InvalidDataException("Unexpected standard round board");
    int priceStep = round.Themes[0].Questions[0].Price;
    roundIndex++;
    foreach (var theme in round.Themes)
    {
        var prices = isFinal ? new[] { 0 } : Enumerable.Range(1, 5).Select(n => n * priceStep);
        if (!theme.Questions.Select(q => q.Price).SequenceEqual(prices))
            throw new InvalidDataException("Unexpected prices");
        foreach (var question in theme.Questions)
        {
            questions++;
            if (isFinal)
            {
                finalQuestions++;
                if (question.TypeName != QuestionTypes.StakeAll)
                    throw new InvalidDataException("Final did not import as a stake-for-all question");
            }
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
    audio != expected.GetProperty("audio").GetInt32() || doc.Package.Version < 5 ||
    finalRounds != expectedFinals || finalQuestions != expectedFinals)
    throw new InvalidDataException($"Import mismatch: questions={questions}; images={images}; audio={audio}; format={doc.Package.Version}");
Console.WriteLine($"Official SIPackages 7.14.0: imported SIQ 4 as {doc.Package.Version}; " +
    $"{roundIndex} rounds, {questions} questions, {images} images, {audio} audio files, {aliases} accepted answers; " +
    $"{finalRounds} final round(s), {finalQuestions} stake-for-all question(s). PASS");
