using System;

namespace ConsoleAppB4P4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "level01.txt";

            char[,] map = FillMap(path);

            int trueScore = PrintMap(map);

            string result = Play(map, trueScore);

            Console.Clear();
            Console.WriteLine(result);

            Console.ReadKey();
        }

        static private char[,] FillMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[file.Length, file[0].Length];

            for (int i = 0; i < file.Length; i++)
                for (int j = 0; j < file[i].Length; j++)
                    map[i, j] = file[i][j];

            return map;
        }

        static private int PrintMap(char[,] map)
        {
            char treasure = '$';
            int score = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);

                    if (map[i, j] == treasure)
                        score++;
                }

                Console.WriteLine();
            }

            return score;
        }

        static private string Play(char[,] map, int trueScore)
        {
            Random random = new Random();

            const ConsoleKey UpCommand = ConsoleKey.UpArrow;
            const ConsoleKey DownCommand = ConsoleKey.DownArrow;
            const ConsoleKey LeftCommand = ConsoleKey.LeftArrow;
            const ConsoleKey RigthCommand = ConsoleKey.RightArrow;
            const ConsoleKey ExitCommand = ConsoleKey.Escape;

            bool isWork = true;

            char wall = '#';
            char user = '@';
            char treasure = '$';
            char shadow = ' ';

            string result = "Благодарим за игру";

            int score = 0;
            int minRamdom = 2;
            int positionX = 0;
            int positionY = random.Next(minRamdom, map.GetLength(0));

            while (isWork)
            {
                positionX = random.Next(minRamdom, map.GetLength(1));

                if (map[positionY, positionX] == shadow)
                    isWork = false;
            }

            PritnScore(score, minRamdom + map.GetLength(1));

            Console.CursorVisible = false;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(user);

            isWork = true;

            while (isWork)
            {
                int shiftY = 0;
                int shiftX = 0;

                ConsoleKeyInfo consoleKey = Console.ReadKey();

                switch (consoleKey.Key)
                {
                    case UpCommand:
                        shiftY--;
                        break;

                    case DownCommand:
                        shiftY++;
                        break;

                    case LeftCommand:
                        shiftX--;
                        break;

                    case RigthCommand:
                        shiftX++;
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;
                }

                if (positionY + shiftY < 0 || positionX + shiftX < 0)
                    continue;

                if (map[positionY + shiftY, positionX + shiftX] != wall)
                {
                    Console.SetCursorPosition(positionX, positionY);
                    Console.Write(shadow);

                    positionY += shiftY;
                    positionX += shiftX;

                    Console.SetCursorPosition(positionX, positionY);
                    Console.Write(user);
                }

                if (map[positionY, positionX] == treasure)
                {
                    PritnScore(++score, minRamdom + map.GetLength(1));

                    map[positionY, positionX] = shadow;
                }

                if (score == trueScore)
                {
                    Console.SetCursorPosition(0, minRamdom + map.GetLength(0));
                    result = $"Победа! Собраны все сокровища! Ваши очки: {score}";
                    isWork = false;
                }
            }

            return result;
        }

        static private void PritnScore(int score, int positionLeft)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(positionLeft, 0);
            Console.Write($"Score: {score}");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}