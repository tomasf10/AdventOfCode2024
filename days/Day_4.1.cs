public static class Day_4_1
{
    public static void Run()
    {
        // This word search allows words to be horizontal, vertical, diagonal, written backwards, or even overlapping other words
        // you need to find all of them.

        var path = "./inputs/Input_Day_4.txt";
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
        // lines[r][c] == 'X' && lines[R][C] == 'M' && lines[R][C] == 'A' && lines[R][C] == 'S'

        var matches = 0;

        // vertical - bottom to top
        if (r - 3 >= 0 && lines[r][c] == 'X' && lines[r - 1][c] == 'M' && lines[r - 2][c] == 'A' && lines[r - 3][c] == 'S')
        {
            matches++;
        }

        // diagonal - bottom to top (right)
        if (c + 3 < lines[r].Count && r - 3 >= 0 &&
            lines[r][c] == 'X' && lines[r - 1][c + 1] == 'M' && lines[r - 2][c + 2] == 'A' && lines[r - 3][c + 3] == 'S')
        {
            matches++;
        }

        // horizontal - left to right
        if (c + 3 < lines[r].Count && lines[r][c] == 'X' && lines[r][c + 1] == 'M' && lines[r][c + 2] == 'A' && lines[r][c + 3] == 'S')
        {
            matches++;
        }

        // diagonal - top to bottom (right)
        if (c + 3 < lines[r].Count && r + 3 < lines.Count &&
            lines[r][c] == 'X' && lines[r + 1][c + 1] == 'M' && lines[r + 2][c + 2] == 'A' && lines[r + 3][c + 3] == 'S')
        {
            matches++;
        }

        // vertical - top to bottom
        if (r + 3 < lines.Count && lines[r][c] == 'X' && lines[r + 1][c] == 'M' && lines[r + 2][c] == 'A' && lines[r + 3][c] == 'S')
        {
            matches++;
        }

        // diagonal - top to bottom (left)
        if (c - 3 >= 0 && r + 3 < lines.Count &&
            lines[r][c] == 'X' && lines[r + 1][c - 1] == 'M' && lines[r + 2][c - 2] == 'A' && lines[r + 3][c - 3] == 'S')
        {
            matches++;
        }

        // horizontal - right to left
        if (c - 3 >= 0 && lines[r][c] == 'X' && lines[r][c - 1] == 'M' && lines[r][c - 2] == 'A' && lines[r][c - 3] == 'S')
        {
            matches++;
        }

        // diagonal - bottom to top (left)
        if (c - 3 >= 0 && r - 3 >= 0 &&
            lines[r][c] == 'X' && lines[r - 1][c - 1] == 'M' && lines[r - 2][c - 2] == 'A' && lines[r - 3][c - 3] == 'S')
        {
            matches++;
        }

        return matches;
    }
}