namespace adventofcode2024.day2;

public class Day2Part2 : IDay
{
    private int _totalSafeReports;
    
    // Part 2
    // Lazy solution for duplicating var names and scoping bullshit - make a new file for part 2 lol.
    // Same logic but have a counter for 'problem' scenarios
    // If counter goes over 1 -> not safe
    // If counter <= 1 -> safe
    
    public void Run()
    {
        _totalSafeReports = 0;

        int indexToRemove = -1;
        
        foreach (var line in File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input/day2.txt")))
        {
            // Part 2
            var levels = Array.ConvertAll(line.Split(" "), int.Parse);

            foreach (var number in levels)
            {
                
            }
            // Loop thru levels array, each time removing 1 number
            var levelsWithOneMissing = levels.ToList();
            levelsWithOneMissing.RemoveAt(indexToRemove);

            // Safe conditions
            bool isLevelsDecreasing = false;
            bool isLevelsIncreasing = false;
            bool isLevelsAdjacent = false;

            int problemScenarios = 0;
            
            // Problem numbers
            int problemDecreasing = -1;
            
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
                // reset problemScenario counter if we end up in this branch
                problemScenarios = 0;
                
                for (int i = 0; (i < levels.Length - 1); i++)
                {
                    if (levels[i] < levels[i + 1])
                    {
                        isLevelsIncreasing = true;
                    }
                    else
                    {
                        problemScenarios++;
                        if (problemScenarios > 1)
                        {
                            isLevelsIncreasing = false;
                            break;
                        }
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
                    problemScenarios++;
                    if (problemScenarios > 1)
                    {
                        isLevelsAdjacent = false;
                        break;
                    }
                }
            }
            
            // Validate if safe
            if (problemScenarios >= 1 && (isLevelsDecreasing || isLevelsIncreasing) && isLevelsAdjacent)
            {
                _totalSafeReports++;
            }
        }
        
        Console.WriteLine($"Part 2 - Total Safe Report {_totalSafeReports}");
    }
    

}