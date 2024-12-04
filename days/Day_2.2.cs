public static class Day_2_2
{
    public static void Run()
    {
        var path = "./inputs/Input_Day_2.txt";
        var lines = File.ReadAllLines(path);

        var reports = lines.Select(x => x.Split(" ").Select(y => int.Parse(y)).ToList()).ToList();
        Console.WriteLine($"reports: {reports.Count}");

        var safeReports = 0;
        foreach (var report in reports)
        {
            if (IsSafe(report))
            {
                safeReports++;
            }
            else
            {
                for (int i = 0; i < report.Count; i++)
                {
                    var copy = report.ToList();
                    copy.RemoveAt(i);
                    if (IsSafe(copy))
                    {
                        safeReports++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"safeReports: {safeReports}");
    }

    public static bool IsSafe(List<int> report)
    {
        var index = 0;

        var result1 = true;
        var result2 = true;
        foreach (var currentLevel in report)
        {
            if (index < report.Count - 1)
            {
                var nextLevel = report[index + 1];

                var diffOk = Math.Abs(currentLevel - nextLevel) >= 1 && Math.Abs(currentLevel - nextLevel) <= 3;

                result1 = result1 && currentLevel > nextLevel && diffOk;
                result2 = result2 && currentLevel < nextLevel && diffOk;

                index++;
            }
        }

        return result1 || result2;
    }
}