using System.Text.RegularExpressions;

namespace AdventOfCode;

public sealed class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }
    
    private int Part1()
    {
        var inputArrAsInts = Regex.Matches(_input, @"\d+")
            .Select(entry => int.Parse(entry.Value))
            .ToArray();

        var leftSide = inputArrAsInts
            .Where((_, index) => index % 2 == 0)
            .ToArray()
            .Order();
        var rightSide = inputArrAsInts
            .Where((_, index) => index % 2 != 0)
            .ToArray()
            .Order();

        return leftSide
            .Zip(rightSide, (left, right) => Math.Abs(left - right))
            .ToArray()
            .Sum();
    }

    public override ValueTask<string> Solve_1() => new(Part1().ToString());

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}
