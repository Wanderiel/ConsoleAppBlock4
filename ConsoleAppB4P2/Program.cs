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
            int maxPercent = 100;

            ConsoleColor color = ConsoleColor.Yellow;
            ConsoleColor colorRed = ConsoleColor.Red;
            ConsoleColor colorBlue = ConsoleColor.Blue;

            Console.WriteLine("Программа рисует специальный бар." +
                "Любой выбор и ввод может быть скорректирован\n" +
                "Сейчас доступно только два:" +
                $"\n{HealthBarColorCommand}. Здоровье" +
                $"\n{ManaBarColorCommand}. Мана");

            Console.Write("\nКакой бар вы хотите отобразить: ");

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
                    break;
            }

            GetPosition(out int positionTop, out int positionLeft);

            Console.Write("Введите процент заполнения: ");

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                percent = GetCorrectNumber(value, maxPercent);
            }
            else
            {
                Console.WriteLine("Нераспознаный ввод, будет использовано заполнение на " +
                    $"{percent}%");
            }

            Console.Write("\nВсе данные собраны. Для отображения бара нажмите любую клавишу...");
            Console.ReadKey();

            Console.Clear();

            DrawBar(positionTop, positionLeft, percent, maxPercent, color);

            Console.ReadKey();
        }

        private static void GetPosition(out int positionTop, out int positionLeft)
        {
            positionTop = 0;
            positionLeft = 0;

            Console.Write("Введите позицию по вертикали: ");

            if (int.TryParse(Console.ReadLine(), out int top))
            {
                positionTop = GetCorrectNumber(top);

                Console.Write("Введите позицию по горизонтали: ");

                if (int.TryParse(Console.ReadLine(), out int left))
                    positionLeft = GetCorrectNumber(left);
                else
                    Console.WriteLine("Нераспознаный ввод, будет выполнена отрисовка в стандартной позиции");
            }
            else
            {
                Console.WriteLine("Нераспознаный ввод, будет выполнена отрисовка в стандартной позиции");
            }
        }

        private static int GetCorrectNumber(int number, int correct = 30)
        {
            if (Math.Abs(number) > correct)
                number %= correct;

            if (number < 0)
                number = correct + number;

            Console.WriteLine($"Приянто в значение {number}");

            return number;
        }

        private static void DrawBar(int positionTop, int positionLeft,
            int percent, int maxPercent, ConsoleColor color)
        {
            int length = 30;

            int fullPoint = length * percent / maxPercent;
            int emptyPoint = length - fullPoint;
            char symbol1 = '█';
            char symbol2 = '~';

            Console.SetCursorPosition(positionLeft, positionTop);

            Console.Write("[");

            Console.ForegroundColor = color;
            Console.Write(new string(symbol1, fullPoint) + new string(symbol2, emptyPoint));
            Console.ResetColor();

            Console.Write("]");
        }
    }
}