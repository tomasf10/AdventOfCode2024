public static class Day_2_1
{
    public static void Run()
    {
        var path = "./inputs/Input_Day_2.txt";
        var reports = File.ReadAllLines(path).Select(x => x.Split(" ").Select(y => int.Parse(y)).ToArray());


        var safeReports = 0;

        foreach (var report in reports)
        {
            var index = 0;

            var result1 = true;
            var result2 = true;
            foreach (var currentLevel in report)
            {
                if (index < report.Length - 1)
                {
                    var nextLevel = report[index + 1];

                    var diffOk = Math.Abs(currentLevel - nextLevel) >= 1 && Math.Abs(currentLevel - nextLevel) <= 3;

                    result1 = result1 && currentLevel > nextLevel && diffOk;
                    result2 = result2 && currentLevel < nextLevel && diffOk;

                    index++;
                }
            }

            if (result1 || result2)
            {
                safeReports++;
            }
        }

        Console.WriteLine($"safeReports: {safeReports}");
    }
}