using System.Data;

public static class Day_10_1
{
    public static void Run()
    {
        var path = "./inputs/Input_Day_10.txt";
        var map = File.ReadAllLines(path).Select(x => x.ToCharArray().Select(y => int.Parse(y.ToString())).ToList()).ToList();

        var bases = new List<(int, int)>();
        var tops = new List<(int, int)>();
        for (int row = 0; row < map.Count; row++)
        {
            for (int column = 0; column < map[0].Count; column++)
            {
                var value = map[row][column];

                if (value == 0)
                {
                    bases.Add((row, column));
                }
                if (value == 9)
                {
                    tops.Add((row, column));
                }
            }
        }

        Console.WriteLine($"bases: {bases.Count} | tops: {tops.Count}");

        var sum = new List<int>();
        foreach (var basee in bases)
        {
            var score = 0;
            foreach (var top in tops)
            {
                if (Math.Abs(basee.Item1 - top.Item1) < 10 && Math.Abs(basee.Item2 - top.Item2) < 10)
                {

                    if (IsRechable(basee, top, map))
                    {
                        // Console.WriteLine($"top ({top.Item1}, {top.Item2}) is on range on base ({basee.Item1}, {basee.Item2})");
                        score++;
                    }
                }
            }

            sum.Add(score);
        }

        Console.WriteLine($"SUM: {string.Join(" + ", sum)} = [{sum.Sum()}]");
    }

    public static bool IsRechable((int, int) currentNode, (int, int) top, List<List<int>> map)
    {

        var result = currentNode.Item1 == top.Item1 && currentNode.Item2 == top.Item2;
        var nextSteps = GetNextNodes(currentNode, map);

        foreach (var step in nextSteps)
        {
            result = result || IsRechable(step, top, map);
        }

        return result;
    }

    private static List<(int, int)> GetNextNodes((int, int) basee, List<List<int>> map)
    {
        var currentValue = map[basee.Item1][basee.Item2];
        var nextValue = currentValue + 1;

        var result = new List<(int, int)>();
        if (basee.Item1 > 0)
        {
            var top = (basee.Item1 - 1, basee.Item2);
            if (map[top.Item1][top.Item2] == nextValue && nextValue < 10)
            {
                result.Add(top);
            }
        }
        if (basee.Item1 < map.Count - 1)
        {
            var bottom = (basee.Item1 + 1, basee.Item2);
            if (map[bottom.Item1][bottom.Item2] == nextValue && nextValue < 10)
            {
                result.Add(bottom);
            }
        }
        if (basee.Item2 > 0)
        {
            var left = (basee.Item1, basee.Item2 - 1);
            if (map[left.Item1][left.Item2] == nextValue && nextValue < 10)
            {
                result.Add(left);
            }
        }
        if (basee.Item2 < map[0].Count - 1)
        {
            var right = (basee.Item1, basee.Item2 + 1);
            if (map[right.Item1][right.Item2] == nextValue && nextValue < 10)
            {
                result.Add(right);
            }
        }

        return result;
    }
}