public static class Day_1_1
{
    public static void Run()
    {
        var path = "/Users/tomasfrechou/Desktop/MyConsoleApp/input.txt";
        var lines = File.ReadAllLines(path);

        var a = lines.Select(x => int.Parse(x.Split("   ")[0])).ToList();
        var b = lines.Select(x => int.Parse(x.Split("   ")[1])).ToList();

        a.Sort();
        b.Sort();

        var distance = 0;
        var index = 0;

        foreach (var value in a)
        {
            distance += Math.Abs(value - b[index]);

            index++;
        }

        Console.WriteLine($"Distance: {distance}");
    }
}