using System.Data;

public static class Day_5_1
{
    public static void Run()
    {
        var path = "./inputs/Input_Day_5.1.txt";
        var rules = File.ReadAllLines(path)
            .Select(x => x.Split('|').Select(y => int.Parse(y)).ToList())
            .GroupBy(x => x[0]).ToDictionary(x => x.Key, x => x.Select(y => y[1]).Order().ToList());

        path = "./inputs/Input_Day_5.2.txt";
        var updates = File.ReadAllLines(path).Select(x => x.Split(',').Select(y => int.Parse(y)).ToList()).ToList();

        var count = 0;
        var sum = new List<int>();

        foreach (var update in updates)
        {
            if (Validate(update, rules))
            {
                var index = update.Count / 2;
                sum.Add(update[index]);

                count++;
            }
        }

        Console.WriteLine($"Count: {count}");
        Console.WriteLine($"Sum: {string.Join(" + ", sum)} = {sum.Sum()}");
    }

    public static bool Validate(List<int> line, Dictionary<int, List<int>> rules)
    {
        var result = true;

        for (int i = 0; i < line.Count - 1; i++)
        {
            var value = line[i];
            if (rules.TryGetValue(value, out var rule))
            {
                var test = line.Slice(i + 1, line.Count - i - 1);

                if (!test.TrueForAll(e => rule.Contains(e)))
                {
                    Console.WriteLine($"Line does not comply with the rules.");
                    result = false;
                    break;
                }
            }
        }

        return result;
    }
}

