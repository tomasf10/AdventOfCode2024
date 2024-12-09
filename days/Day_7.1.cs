using System.Data;

public static class Day_7_1
{
    public static void Run()
    {
        var path = "./inputs/Input_Day_7.txt";
        var lines = File.ReadAllLines(path).Select(x => new Line
        {
            Result = int.Parse(x.Substring(0, x.IndexOf(":"))),
            Values = x.Substring(x.IndexOf(":") + 2).Split(" ").Select(y => int.Parse(y)).ToList()
        });

        var sum = new List<int>();

        foreach (var line in lines)
        {
            var permutations = GetPermutations(line.Values.Count - 1);

            try
            {
                sum.Add(TestPermutations(line, permutations));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }

        Console.WriteLine($"Sum: {string.Join(" + ", sum)} = {sum.Sum()}");
    }

    private static int TestPermutations(Line line, List<List<char>> permutations)
    {
        foreach (var permutation in permutations)
        {
            var result = NewMethod(line, permutation);

            if (result == line.Result)
            {
                return result;
            }
        }

        throw new Exception("No permutation is valid");
    }

    private static int NewMethod(Line line, List<char> permutation)
    {
        var result = 0;

        for (int i = 0; i < permutation.Count; i++)
        {
            var currentValue = line.Values[i];
            var nextValue = line.Values[i + 1];

            if (permutation[i] == '+')
            {
                result += currentValue + nextValue;
            }
            else if (permutation[i] == '*')
            {
                result += currentValue * nextValue;
            }

            if (result > line.Result)
            {
                break;
            }
        }

        return result;
    }

    private static List<List<char>> GetPermutations(int taken)
    {
        var values = new char[] { '+', '*' };

        var result = PermutationsWithRepetition(values, taken);

        return result;
    }

    private static List<List<char>> PermutationsWithRepetition(char[] elements, int r)
    {
        if (r == 0) return new List<List<char>> { new List<char>() };

        var partialResults = PermutationsWithRepetition(elements, r - 1);
        var results = new List<List<char>>();

        foreach (var partial in partialResults)
        {
            foreach (var element in elements)
            {
                var newList = new List<char>(partial) { element };
                results.Add(newList);
            }
        }

        return results;
    }
}

internal class Line
{
    public int Result { get; set; }
    public List<int>? Values { get; set; }
}

