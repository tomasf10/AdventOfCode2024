public static class Day_1_2
{
    public static void Run()
    {
        var path = "/Users/tomasfrechou/Desktop/MyConsoleApp/input.txt";
        var lines = File.ReadAllLines(path);

        var a = lines.Select(x => int.Parse(x.Split("   ")[0])).ToList();
        var b = lines.Select(x => int.Parse(x.Split("   ")[1])).ToList();

        a.Sort();

        var similarity = 0;
        var index = 0;

        foreach (var value in a) {
            var x  = b.Count(x => x == value);
            similarity += value * (x);

            index++;
        }

        Console.WriteLine($"Distance: {similarity}");
    }
}