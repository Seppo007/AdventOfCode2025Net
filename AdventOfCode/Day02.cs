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
        var levelStrings = _input.Split('\n');
        var levels = levelStrings
            .Select(level =>
                level.Split(" ")
                    .Select(int.Parse)
                    .ToArray()
            )
            .ToArray();

        var safeLevels = 0;

        foreach (var level in levels)
        {
            var isSafe = true;
            var increasing = level[1] > level[0];
            for (var i = 1; i < level.Length; i++)
            {
                if (
                    (level[i] > level[i - 1] && !increasing || level[i] < level[i - 1] && increasing) ||
                    Math.Abs(level[i] - level[i - 1]) == 0 || 
                    Math.Abs(level[i] - level[i - 1]) > 3
                )
                {
                    isSafe = false;
                    break;
                }
            }
            if (isSafe) safeLevels++;
        }

        return safeLevels.ToString();
    }

    private string Part2()
    {
        return "";
    }

    public override ValueTask<string> Solve_1() => new(Part1());

    public override ValueTask<string> Solve_2() => new(Part2());
}