using System.Data;

public static class Day_5_2
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
            if (!Day_5_1.Validate(update, rules))
            {
                var fixedUpdate = FixedUpdate(update, rules);

                var index = fixedUpdate.Count / 2;
                sum.Add(fixedUpdate[index]);

                count++;
            }
        }

        Console.WriteLine($"Count: {count}");
        Console.WriteLine($"Sum: {string.Join(" + ", sum)} = {sum.Sum()}");

    }

    private static List<int> FixedUpdate(List<int> line, Dictionary<int, List<int>> rules)
    {
        var fixedUpdate = new List<int>();

        for (int i = 0; i < line.Count; i++)
        {
            var value = line[i];
            if (rules.TryGetValue(value, out var numbersAhead))
            {
                var index = 0;
                var test = fixedUpdate;

                while (!test.TrueForAll(e => numbersAhead.Contains(e)))
                {
                    test = fixedUpdate.Slice(index + 1, fixedUpdate.Count - index - 1);
                    index++;
                }
                fixedUpdate.Insert(index, value);
            }
        }

        return fixedUpdate;
    }
}

