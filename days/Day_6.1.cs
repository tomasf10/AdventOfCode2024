using System.Data;

public static class Day_6_1
{
    public static void Run()
    {
        var path = "./inputs/Input_Day_6.txt";
        var map = File.ReadAllLines(path).Select(x => x.ToCharArray().ToList()).ToList();

        var guard = Orientation.North;
        var position = (0, 0); // (row, column)

        // Find initial position
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

        var count = 1;
        var nextPosition = (0, 0);
        while (true)
        {
            switch (guard)
            {
                case Orientation.North:
                    {
                        nextPosition = (position.Item1 - 1, position.Item2);
                        break;
                    }
                case Orientation.East:
                    {
                        nextPosition = (position.Item1, position.Item2 + 1);
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
                        break;
                    }
            }


            if (nextPosition.Item1 < 0 || nextPosition.Item1 >= map.Count || nextPosition.Item2 < 0 || nextPosition.Item2 >= map[0].Count)
            {
                break;
            }

            if (map[nextPosition.Item1][nextPosition.Item2] == '#')
            {
                switch (guard)
                {
                    case Orientation.North:
                        {
                            nextPosition = (position.Item1, position.Item2 + 1);
                            guard = Orientation.East;
                            break;
                        }
                    case Orientation.East:
                        {
                            nextPosition = (position.Item1 + 1, position.Item2);
                            guard = Orientation.South;
                            break;
                        }
                    case Orientation.South:
                        {
                            nextPosition = (position.Item1, position.Item2 - 1);
                            guard = Orientation.West;
                            break;
                        }
                    case Orientation.West:
                        {
                            nextPosition = (position.Item1 - 1, position.Item2);
                            guard = Orientation.North;
                            break;
                        }
                }
            }

            if (map[nextPosition.Item1][nextPosition.Item2] == '.')
            {
                map[nextPosition.Item1][nextPosition.Item2] = 'X';
                count++;
            }

            position = nextPosition;
        }

        Console.WriteLine($"Movements: {count}");

        File.WriteAllLines("output_1.txt", map.Select(x => string.Join("", x)));
    }
}

internal enum Orientation
{
    North,
    East,
    South,
    West,
}