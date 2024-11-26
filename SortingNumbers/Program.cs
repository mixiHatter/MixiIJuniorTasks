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

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(minRange, maxRange + 1);

            foreach (int number in numbers)
                Console.Write(number + ",");


        }
    }
}
