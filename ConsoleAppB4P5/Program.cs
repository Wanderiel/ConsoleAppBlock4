using System;

namespace ConsoleAppB4P5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 30;
            int[] numbers = FillArray(new int[size]);

            Console.WriteLine("Дан массив чисел:");

            PrintArray(numbers);

            Console.WriteLine("\nПосле перемешивания:");

            numbers = Shuffle(numbers);

            PrintArray(numbers);

            Console.ReadKey();
        }

        static private int[] FillArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = i;

            return numbers;
        }

        static private void PrintArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                Console.Write($"{numbers[i]} ");

            Console.WriteLine();
        }

        static private int[] Shuffle(int[] numbers)
        {
            Random random = new Random();
            int newIndex;

            for (int i = 0; i < numbers.Length; i++)
            {
                newIndex = random.Next(numbers.Length);
                (numbers[i], numbers[newIndex]) = (numbers[newIndex], numbers[i]);
            }

            return numbers;
        }
    }
}