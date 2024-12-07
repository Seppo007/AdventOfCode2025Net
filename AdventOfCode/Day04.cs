namespace AdventOfCode;

public sealed class Day04 : BaseDay
{
    private readonly char[][] _matrix;
    
    private readonly int _maxCharIdx;
    private readonly int _maxRowIdx;

    public Day04()
    {
        var input = File.ReadAllText(InputFilePath);

        var rows = input.Split("\r\n");
        _matrix = rows
            .Select(row => row
                .Select(ch => ch)
                .ToArray()
            ).ToArray();

        _maxCharIdx = _matrix[0].Length - 1;
        _maxRowIdx = _matrix.Length - 1;
        
    }

    private int CountXMASFor(int rowIndex, int charIndex)
    {
        // check if starting with X
        if (_matrix[rowIndex][charIndex] != 'X') return 0;

        var count = 0;
        // left to right
        if (charIndex + 3 <= _maxCharIdx && _matrix[rowIndex][charIndex + 1] == 'M' &&
            _matrix[rowIndex][charIndex + 2] == 'A' &&
            _matrix[rowIndex][charIndex + 3] == 'S') count++;
        
        // right to left
        if (charIndex - 3 >= 0 && _matrix[rowIndex][charIndex - 1] == 'M' &&
            _matrix[rowIndex][charIndex - 2] == 'A' &&
            _matrix[rowIndex][charIndex - 3] == 'S') count++;
        
        // top to down
        if (rowIndex + 3 <= _maxRowIdx && _matrix[rowIndex + 1][charIndex] == 'M' &&
            _matrix[rowIndex + 2][charIndex] == 'A' &&
            _matrix[rowIndex + 3][charIndex] == 'S') count++;
        
        // down to top
        if (rowIndex >= 3 && _matrix[rowIndex - 1][charIndex] == 'M' && 
            _matrix[rowIndex - 2][charIndex] == 'A' &&
            _matrix[rowIndex - 3][charIndex] == 'S') count++;
        
        // diagonal down right
        if (charIndex + 3 <= _maxCharIdx && rowIndex + 3 <= _maxRowIdx && _matrix[rowIndex + 1][charIndex + 1] == 'M' && 
            _matrix[rowIndex + 2][charIndex + 2] == 'A' &&
            _matrix[rowIndex + 3][charIndex + 3] == 'S') count++;
        
        // diagonal down left
        if (charIndex - 3 >= 0 && rowIndex + 3 <= _maxRowIdx && _matrix[rowIndex + 1][charIndex - 1] == 'M' && 
            _matrix[rowIndex + 2][charIndex - 2] == 'A' &&
            _matrix[rowIndex + 3][charIndex - 3] == 'S') count++;
        
        // diagonal top left
        if (charIndex - 3 >= 0 && rowIndex - 3 >= 0 && _matrix[rowIndex - 1][charIndex - 1] == 'M' && 
            _matrix[rowIndex - 2][charIndex - 2] == 'A' &&
            _matrix[rowIndex - 3][charIndex - 3] == 'S') count++;
        
        // diagonal top right
        if (charIndex + 3 <= _maxCharIdx && rowIndex - 3 >= 0 && _matrix[rowIndex - 1][charIndex + 1] == 'M' && 
            _matrix[rowIndex - 2][charIndex + 2] == 'A' &&
            _matrix[rowIndex - 3][charIndex + 3] == 'S') count++;
        
        return count;
    }

    private string Part1()
    {
        var xmasCount = 0;

        for (int rowIdx = 0; rowIdx <= _maxRowIdx; rowIdx++)
        {
            for (int charIdx = 0; charIdx <= _maxCharIdx; charIdx++)
            {
                xmasCount += CountXMASFor(rowIdx, charIdx);
            }
        }

        return xmasCount.ToString();
    }

    private string Part2()
    {
        // TODO: Try out using dictionary for each position in the matrix

        return "0";
    }

    public override ValueTask<string> Solve_1() => new(Part1());

    public override ValueTask<string> Solve_2() => new(Part2());
}