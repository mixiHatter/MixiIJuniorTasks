using System;

namespace LocalMaximum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxRange = 100;
            int arrayLength = 30;
            int[] numbers = new int[arrayLength];
            GetFullArrayRandomNumbers(numbers, numbers.Length, maxRange);
            int lastIndex = numbers.Length - 1;

            if (numbers[0] > numbers[1])
                Console.WriteLine($"{numbers[0]}");
                
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                {
                    Console.WriteLine($"{numbers[i]}");
                }
            }

            if (numbers[lastIndex] > numbers[lastIndex - 1])
                Console.WriteLine($"{numbers[lastIndex]}");
        }

        static void GetFullArrayRandomNumbers(int[] array, int lengthArray, int maxRange, int minRange = 0)
        {
            Random random = new Random();

            for (int i = 0; i < lengthArray; i++)
                array[i] = random.Next(minRange, maxRange + 1);
        }
    }
}
