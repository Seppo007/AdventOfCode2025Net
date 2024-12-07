using System.Text.RegularExpressions;

namespace AdventOfCode;

public sealed class Day03 : BaseDay
{
    private readonly string _input;

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    private string[] ValidMulsFromInput()
    {
        const string validMulsRegex = @"mul\(\d+\,\d+\)";
        var validMulsMatch = Regex.Matches(_input, validMulsRegex);

        return validMulsMatch.Select(entry => entry.Value).ToArray();
    }

    private int EvaluateMul(string mulString)
    {
        var startIndex = mulString.IndexOf('(') + 1;
        var length = mulString.IndexOf(')') - startIndex;

        var mulStringValues = mulString.Substring(startIndex, length).Split(',');
        var mulIntValues = mulStringValues.Select(str => int.Parse(str)).ToArray();

        return mulIntValues[0] * mulIntValues[1];
    }

    private string Part1()
    {
        var validMulsArray = ValidMulsFromInput();

        return validMulsArray.Aggregate(0, (current, mul) => current += EvaluateMul(mul)).ToString();
    }

    private string Part2()
    {
        return "";
    }

    public override ValueTask<string> Solve_1() => new(Part1());

    public override ValueTask<string> Solve_2() => new(Part2());
}