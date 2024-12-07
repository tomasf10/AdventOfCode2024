using System.Data;

public static class Day_6_2
{
    public static void Run()
    {
        var path = "./inputs/Input_Day_6.txt";
        var map = File.ReadAllLines(path).Select(x => x.ToCharArray().ToList()).ToList();
        var initialPosition = FindInitialPosition(map);

        var count = 0;

        for (int row = 0; row < map.Count; row++)
        {
            for (int column = 0; column < map[row].Count; column++)
            {
                map = File.ReadAllLines(path).Select(x => x.ToCharArray().ToList()).ToList();

                if (!(initialPosition.Item1 == row && initialPosition.Item2 == column))
                {
                    map[row][column] = 'O';

                    NewMethod(map, initialPosition, row, column, ref count);
                }
            }
        }

        Console.WriteLine($"count: {count}");
    }

    private static void NewMethod(List<List<char>> map, (int, int) guardInitialPosition, int row, int column, ref int count)
    {
        var orientation = Orientation.North;
        var position = guardInitialPosition;
        var nextPosition = position;

        var points = new List<(int, int)>();

        while (true)
        {
            var currentValue = map[position.Item1][position.Item2];

            var icon = '|';
            switch (orientation)
            {
                case Orientation.North:
                    {
                        nextPosition = (position.Item1 - 1, position.Item2);
                        break;
                    }
                case Orientation.East:
                    {
                        nextPosition = (position.Item1, position.Item2 + 1);
                        icon = '-';
                        break;
                    }
                case Orientation.South:
                    {
                        nextPosition = (position.Item1 + 1, position.Item2);
                        break;
                    }
                case Orientation.West:
                    {
                        nextPosition = (position.Item1, position.Item2 - 1);
                        icon = '-';
                        break;
                    }
            }

            var isLoop = IsLoop(points);
            if (nextPosition.Item1 < 0 || nextPosition.Item1 >= map.Count || nextPosition.Item2 < 0 || nextPosition.Item2 >= map[0].Count || isLoop)
            {
                if (isLoop)
                {
                    // PrintMap(map);
                    count++;
                    File.WriteAllLines($"./outputs/output_{row}_{column}.txt", map.Select(x => string.Join("", x)));
                }
                break;
            }

            while (map[nextPosition.Item1][nextPosition.Item2] == '#' || map[nextPosition.Item1][nextPosition.Item2] == 'O')
            {
                if (currentValue == '+' || currentValue == '|' || currentValue == '-')
                {
                    if (currentValue == '+' && !points.Any(x => x.Item1 == position.Item1 && x.Item2 == position.Item2))
                    {
                        points.Add(position);
                    }
                }
                else
                {
                    points.Clear();
                }


                icon = '+';
                switch (orientation)
                {
                    case Orientation.North:
                        {
                            nextPosition = (position.Item1, position.Item2 + 1);
                            orientation = Orientation.East;
                            break;
                        }
                    case Orientation.East:
                        {
                            nextPosition = (position.Item1 + 1, position.Item2);
                            orientation = Orientation.South;
                            break;
                        }
                    case Orientation.South:
                        {
                            nextPosition = (position.Item1, position.Item2 - 1);
                            orientation = Orientation.West;
                            break;
                        }
                    case Orientation.West:
                        {
                            nextPosition = (position.Item1 - 1, position.Item2);
                            orientation = Orientation.North;
                            break;
                        }
                }
            }

            if ((map[position.Item1][position.Item2] == '+' && icon == '-') ||
            (map[position.Item1][position.Item2] == '+' && icon == '|') ||
            (map[position.Item1][position.Item2] == '|' && icon == '-') ||
             (map[position.Item1][position.Item2] == '-' && icon == '|'))
            {
                icon = '+';
            }

            map[position.Item1][position.Item2] = icon;


            position = nextPosition;

            // PrintMap(map);
        }
    }

    private static bool IsLoop(List<(int, int)> points)
    {

        var isLoop = points.Count >= 2;

        if (isLoop)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (i + 1 == points.Count)
                {
                    isLoop = isLoop && (points[i].Item1 == points[0].Item1 || points[i].Item2 == points[0].Item2);
                }
                else
                {
                    isLoop = isLoop && (points[i].Item1 == points[i + 1].Item1 || points[i].Item2 == points[i + 1].Item2);
                }

                if (!isLoop)
                {
                    break;
                }
            }
        }

        return isLoop;

    }

    private static (int, int) FindInitialPosition(List<List<char>> map)
    {
        var position = (0, 0); // (row, column)
        for (int row = 0; row < map.Count; row++)
        {
            for (int column = 0; column < map[row].Count; column++)
            {
                var value = map[row][column];
                if (value == '^')
                {
                    position = (row, column);

                }
            }
        }

        return position;
    }

    private static void PrintMap(List<List<char>> map)
    {
        Console.WriteLine("  " + string.Join("", Enumerable.Range(0, map.Count)));
        var row = 0;

        foreach (var item in map)
        {
            Console.WriteLine($"{row.ToString()[0]} " + string.Join("", item));
            row++;
        }
        Console.WriteLine();

    }
}