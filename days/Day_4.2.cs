using System.Text.RegularExpressions;

public static class Day_4_2
{
    public static void Run()
    {
        // This word search allows words to be horizontal, vertical, diagonal, written backwards, or even overlapping other words
        // you need to find all of them.

        var path = "/Users/tomasfrechou/Desktop/Workspace/AdventOfCode2024/inputs/Input_Day_4.txt";
        var lines = File.ReadAllLines(path).Select(x => x.ToCharArray().ToList()).ToList();

        var count = 0;
        for (int row = 0; row < lines.Count; row++)
        {
            for (int column = 0; column < lines[row].Count; column++)
            {
                count += PatterMatches(row, column, lines);

            }
        }
        Console.WriteLine($"count: {count}");
    }

    private static int PatterMatches(int r, int c, List<List<char>> lines)
    {
        var matches = 0;

        // M.S
        // .A.
        // M.S
        if (c + 2 < lines[r].Count && r + 2 < lines.Count &&
            lines[r][c] == 'M' && lines[r][c + 2] == 'S' &&
            lines[r + 1][c + 1] == 'A' &&
            lines[r + 2][c] == 'M' && lines[r + 2][c + 2] == 'S')
        {
            matches++;
        }

        // M.M
        // .A.
        // S.S
        if (c + 2 < lines[r].Count && r + 2 < lines.Count &&
            lines[r][c] == 'M' && lines[r][c + 2] == 'M' &&
            lines[r + 1][c + 1] == 'A' &&
            lines[r + 2][c] == 'S' && lines[r + 2][c + 2] == 'S')
        {
            matches++;
        }

        // S.M
        // .A.
        // S.M
        if (c + 2 < lines[r].Count && r + 2 < lines.Count &&
            lines[r][c] == 'S' && lines[r][c + 2] == 'M' &&
            lines[r + 1][c + 1] == 'A' &&
            lines[r + 2][c] == 'S' && lines[r + 2][c + 2] == 'M')
        {
            matches++;
        }

        // S.S
        // .A.
        // M.M
        if (c + 2 < lines[r].Count && r + 2 < lines.Count &&
            lines[r][c] == 'S' && lines[r][c + 2] == 'S' &&
            lines[r + 1][c + 1] == 'A' &&
            lines[r + 2][c] == 'M' && lines[r + 2][c + 2] == 'M')
        {
            matches++;
        }

        return matches;
    }
}

