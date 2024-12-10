namespace adventofcode2024.day1;

public class Day1 : IDay
{
    private List<int> _column1;
    private List<int> _column2;
    private List<int> _totals;
    private List<int> _similarityScores;

    public void Run()
    {
        _column1 = new List<int>();
        _column2 = new List<int>();
        _totals = new List<int>();
        _similarityScores = new List<int>();

        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input/day1.txt");
        var columnSeperator = "   ";

        // Part 1

        foreach (var line in File.ReadLines(path))
        {
            _column1.Add(int.Parse(line.Split(columnSeperator)[0]));
            _column2.Add(int.Parse(line.Split(columnSeperator)[1]));
        }

        _column1.Sort();
        _column2.Sort();

        for (int i = 0; i < _column1.Count; i++)
        {
            var distance = Math.Abs(_column1[i] - _column2[i]);

            _totals.Add(distance);
        }

        var total = _totals.Sum();
        Console.WriteLine($"Part 1 - Total distance: {total}");

        // Part 2
        foreach (var t in _column1)
        {
            int numberOfInstances = _column2
                .FindAll(n => n == t)
                .Count;

            _similarityScores.Add(t * numberOfInstances);
        }

        var totalSimilarityScore = _similarityScores.Sum();
        Console.WriteLine($"Part 2 - Total Similarity Score: {totalSimilarityScore}");
    }
}