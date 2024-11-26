using System;

namespace SortingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[20];
            Random random = new Random();
            int minRange = 0;
            int maxRange = 10;
            int clipboard = 0;

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(minRange, maxRange + 1);

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        clipboard = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = clipboard;
                    }
                }
            }

            foreach (int number in numbers)
                Console.Write(number + ",");
        }
    }
}
