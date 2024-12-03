using System.Text.RegularExpressions;

namespace AdventOfCode;

public sealed class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }
    
    private string Part1()
    {
        var (leftList, rightList) = GetLeftAndRightList();
        
        return leftList
            .Zip(rightList, (left, right) => Math.Abs(left - right))
            .ToArray()
            .Sum()
            .ToString();
    }

    private string Part2()
    {
        var (leftList, rightList) = GetLeftAndRightList();

        var sum = 0;
        foreach (var leftEntry in leftList)
        {
            sum += leftEntry * rightList.Count(right => right == leftEntry);
        }
        
        return sum.ToString();
    }

    private Tuple<int[], int[]> GetLeftAndRightList()
    {
        var inputArrAsInts = Regex.Matches(_input, @"\d+")
            .Select(entry => int.Parse(entry.Value))
            .ToArray();

        var leftList = inputArrAsInts
            .Where((_, index) => index % 2 == 0)
            .Order()
            .ToArray();
        var rightList = inputArrAsInts
            .Where((_, index) => index % 2 != 0)
            .Order()
            .ToArray();
        
        return Tuple.Create(leftList, rightList);
    }
    
    public override ValueTask<string> Solve_1() => new(Part1());

    public override ValueTask<string> Solve_2() => new(Part2());
}
