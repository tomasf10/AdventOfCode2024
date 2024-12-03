public static class Day_2_1
{
    public static void Run()
    {
        var path = "/Users/tomasfrechou/Desktop/MyConsoleApp/input2.txt";
        var reports = File.ReadAllLines(path).Select(x => x.Split(" ").Select(y => int.Parse(y)).ToArray());


        var safeReports = 0;

        foreach (var report in reports) {
            var index = 0;

            var result1 = true;
            var result2 = true;
            foreach (var value in report) {
                if (index < report.Length - 1) {
                    var next = report[index + 1];

                    result1 = value > next && Math.Abs(value - next) >= 1 && Math.Abs(value - next) <= 3;
                    result2 = value < next && Math.Abs(value - next) >= 1 && Math.Abs(value - next) <= 3;

                    index++;
                }    
            }

            if (result1 && result2) {
                safeReports++;
            }
        }

        Console.WriteLine($"safeReports: {safeReports}");
    }
}