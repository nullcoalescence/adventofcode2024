namespace adventofcode2024.day2;

public class Day2Part1 : IDay
{
    private int _totalSafeReports;
    
    public void Run()
    {
        _totalSafeReports = 0;
        
        foreach (var line in File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input/day2.txt")))
        {
            // Part 1
            var levels = Array.ConvertAll(line.Split(" "), int.Parse);

            // Safe conditions
            bool isLevelsDecreasing = false;
            bool isLevelsIncreasing = false;
            bool isLevelsAdjacent = false;
            
            // Check if levels are in a decreasing order
            for (int i = 0; (i < levels.Length - 1); i++)
            {
                if (levels[i] > levels[i + 1])
                {
                    isLevelsDecreasing = true;
                }
                else
                {
                    isLevelsDecreasing = false;
                    break;
                }
            }

            // Check if levels are in an increasing order
            if (!isLevelsDecreasing) // yay optimization for shitty code that could be written way better anyways
            {
                for (int i = 0; (i < levels.Length - 1); i++)
                {
                    if (levels[i] < levels[i + 1])
                    {
                        isLevelsIncreasing = true;
                    }
                    else
                    {
                        isLevelsIncreasing = false;
                        break;
                    }
                }
            }

            // Check to see if distance between levels is between 1 - 3
            for (int i = 0; (i < levels.Length - 1); i++)
            {
                var distance = Math.Abs(levels[i] - levels[i + 1]);

                if (distance is >= 1 and <= 3)
                {
                    isLevelsAdjacent = true;
                }
                else
                {
                    isLevelsAdjacent = false;
                    break;
                }
            }
            
            // Validate if safe
            if ((isLevelsDecreasing || isLevelsIncreasing) && isLevelsAdjacent)
            {
                _totalSafeReports++;
            }
        }
        
        Console.WriteLine($"Part 1 - Total Safe Report {_totalSafeReports}");
    }
}