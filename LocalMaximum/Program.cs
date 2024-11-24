using System;

namespace LocalMaximum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxRange = 100;
            int arrayLength = 30;
            int[] array = new int[arrayLength];

            GetArray(array, array.Length, maxRange);

            if (array[0] > array[1])
                Console.WriteLine($"{array[0]} > {array[1]}");
            else
                Console.WriteLine($"{array[0]} < {array[1]}");

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (i == array.Length - 1)
                {
                }

                else if (array[i] > array[i - 1] && array[i] > array[i + 1])
                {
                    Console.WriteLine($"{array[i - 1]} < {array[i]} > {array[i + 1]}");
                }
            }

            if (array[array.Length - 1] > array[array.Length - 2])
                Console.WriteLine($"{array[array.Length - 1]} > {array[array.Length - 2]}");
            else
                Console.WriteLine($"{array[array.Length - 1]} < {array[array.Length - 2]}");
        }

        static void GetArray(int[] array, int lengthArray, int maxRange, int minRange = 0)
        {
            Random random = new Random();

            for (int i = 0; i < lengthArray; i++)
                array[i] = random.Next(minRange, maxRange++);
        }
    }
}
