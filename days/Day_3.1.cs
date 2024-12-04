using System.Text.RegularExpressions;

public static class Day_3_1
{
    public static void Run()
    {
        //  mul(X,Y), where X and Y are each 1-3 digit numbers. For instance, mul(44,46) multiplies 44 by 46 to get a result of 2024. Similarly, mul(123,4) would multiply 123 by 4.
        // However, because the program's memory has been corrupted, there are also many invalid characters that should be ignored, even if they look like part of a mul instruction. Sequences like mul(4*, mul(6,9!, ?(12,34), or mul ( 2 , 4 ) do nothing.

        var path = "./inputs/Input_Day_3.txt";
        var lines = File.ReadAllLines(path);

        var sum = 0;
        foreach (var line in lines)
        {
            string pattern = @"mul\(\d{1,3},\d{1,3}\)";

            MatchCollection matches = Regex.Matches(line, pattern);

            foreach (Match match in matches)
            {
                var value = Mul(match.Value);
                Console.WriteLine($"value: {value}");

                sum += value;
            }
        }

        Console.WriteLine($"sum: {sum}");
    }

    public static int Mul(string mul)
    {
        var values = mul.Replace("mul(", "").Replace(")", "").Split(",");

        return int.Parse(values[0]) * int.Parse(values[1]);
    }
}