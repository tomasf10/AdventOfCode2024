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

        var sum = new List<Int128>();

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

        Console.WriteLine($"Sum: {string.Join(" + ", sum)}");
    }

    private static Int128 TestPermutations(Line line, List<List<char>> permutations)
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

    private static Int128 NewMethod(Line line, List<char> permutation)
    {
        var index = 0;
        long result = 0;

        var operation = string.Empty;
        try
        {
            foreach (var value in permutation)
            {
                operation += line.Values[index];

                result = long.Parse(new DataTable().Compute(operation, null).ToString());

                if (result > line.Result)
                {
                    break;
                }


                operation += " " + value + " ";
                index++;
            }
            operation += line.Values.Last();

            result = long.Parse(new DataTable().Compute(operation, null).ToString());


            return result;
        }
        catch (Exception)
        {
            Console.WriteLine($"ERROR: result {line.Result}: {operation}");
            throw;
        }

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

