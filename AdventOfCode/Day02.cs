namespace AdventOfCode;

public sealed class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    private string Part1()
    {
        var levels = ExtractInputIntoIntLevels(_input);
        var safeLevels = 0;

        foreach (var level in levels)
        {
            var isSafe = true;
            var increasing = level[1] > level[0];

            for (var i = 1; i < level.Length; i++)
            {
                if (ViolatesRestrictions(level[i], level[i - 1], increasing))
                {
                    isSafe = false;
                    break;
                }
            }

            if (isSafe) safeLevels++;
        }

        return safeLevels.ToString();
    }

    private int[][] ExtractInputIntoIntLevels(string input) => _input
        .Split('\n')
        .Select(level =>
            level.Split(" ")
                .Select(int.Parse)
                .ToArray()
        )
        .ToArray();

    private bool ViolatesRestrictions(int value, int predecessor, bool increasingLevel) =>
        value > predecessor && !increasingLevel ||
        value < predecessor && increasingLevel ||
        Math.Abs(value - predecessor) == 0 ||
        Math.Abs(value - predecessor) > 3;

    private string Part2()
    {
        var levels = ExtractInputIntoIntLevels(_input);
        var safeLevels = 0;

        foreach (var level in levels)
        {
            var isSafe = true;
            
            for (var i = 0; i < level.Length; i++)
            {
                isSafe = true;
                
                var levelAsList = level.ToList();
                levelAsList.RemoveAt(i);
                
                var increasing = levelAsList[1] > levelAsList[0];
                
                for (var j = 1; j < levelAsList.Count; j++)
                {
                    if (ViolatesRestrictions(levelAsList[j], levelAsList[j - 1], increasing))
                    {
                        isSafe = false;
                        break;
                    }
                }
                
                if(isSafe) break;
            }

            if (isSafe) safeLevels++;
        }

        return safeLevels.ToString();
    }

    public override ValueTask<string> Solve_1() => new(Part1());

    public override ValueTask<string> Solve_2() => new(Part2());
}