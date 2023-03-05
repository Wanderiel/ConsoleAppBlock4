using System;

namespace ConsoleAppB4P3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumber();

            Console.WriteLine(number);

            Console.ReadKey();
        }

        static private int GetNumber()
        {
            int number;

            Console.Write("Введите число: ");

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Введите число: ");
            }

            return number;
        }
    }
}