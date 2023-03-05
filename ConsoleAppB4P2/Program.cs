using System;

namespace SpecialBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string HealthBarColorCommand = "1";
            const string ManaBarColorCommand = "2";

            int percent = 50;

            ConsoleColor color = ConsoleColor.Yellow;
            ConsoleColor colorRed = ConsoleColor.Red;
            ConsoleColor colorBlue = ConsoleColor.Blue;

            Console.WriteLine("Программа рисует специальный бар.\n" +
                "Сейчас доступно только два:" +
                $"\n{HealthBarColorCommand}. Здоровье" +
                $"\n{ManaBarColorCommand}. Мана");

            Console.Write("\nКакой бар вы хотите отобразить:");

            switch (Console.ReadLine())
            {
                case HealthBarColorCommand:
                    color = colorRed;
                    break;

                case ManaBarColorCommand:
                    color = colorBlue;
                    break;

                default:
                    Console.WriteLine("Нераспознанный ввод, отрисовка будет с тандартном цвете.");
                    Console.ReadKey();
                    break;
            }

            GetPosition(out int positionTop, out int positionLeft);

            Console.Write("\nВведите процент заполнения: ");

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                percent = value;

                if (percent < 0)
                    percent *= -1;
            }
            else
            {
                Console.WriteLine("\nНераспознаный ввод, будет использовано заполнение на " +
                    $"{percent}%");
            }

            Console.Clear();

            DrawBar(positionTop, positionLeft, percent, color);

            Console.ReadKey();
        }

        static private void GetPosition(out int positionTop, out int positionLeft)
        {
            positionTop = 0;
            positionLeft = 0;

            Console.Write("\nВведите позицию по вертикали: ");

            if (int.TryParse(Console.ReadLine(), out int top))
            {
                positionTop = GetCorrectCoordinate(top);

                Console.Write("Введите позицию по горизонтали: ");

                if (int.TryParse(Console.ReadLine(), out int left))
                    positionLeft = GetCorrectCoordinate(left);
                else
                    Console.WriteLine("\nНераспознаный ввод, будет выполнена отрисовка в стандартной позиции");
            }
            else
            {
                Console.WriteLine("\nНераспознаный ввод, будет выполнена отрисовка в стандартной позиции");
            }
        }

        static private int GetCorrectCoordinate(int number)
        {
            int correct = 15;

            if (number < 0)
                number *= -1;

            if (number > correct)
                number %= correct;

            Console.WriteLine($"Ввод скоординирован в начение {number}");

            return number;
        }

        static private void DrawBar(int positionTop, int positionLeft,
            int percent, ConsoleColor color)
        {
            int length = 30;
            int fullPercent = 100;

            if (Math.Abs(percent) > fullPercent)
                percent %= fullPercent;

            int fullPoint = length * percent / fullPercent;
            int emptyPoint = length - fullPoint;
            char symbol1 = '█';
            char symbol2 = '~';

            Console.SetCursorPosition(positionTop, positionLeft);

            Console.Write("[");

            Console.ForegroundColor = color;
            Console.Write(new string(symbol1, fullPoint) + new string(symbol2, emptyPoint));
            Console.ResetColor();

            Console.Write("]");
        }
    }
}