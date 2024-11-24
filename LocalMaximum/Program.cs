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

            GetArray(ref array, array.Length, maxRange);

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    if (array[i] > array[i + 1])                    
                        Console.WriteLine($"{array[i]} > {array[i + 1]}");
                    else
                        Console.WriteLine($"{array[i]} < {array[i + 1]}");
                }

                else if (i == array.Length - 1)
                {
                    if (array[i] > array[i - 1] )
                        Console.WriteLine($"{array[i]} > {array[i - 1]}");
                    else
                        Console.WriteLine($"{array[i]} < {array[i - 1]}");
                }

                else if (array[i] > array[i - 1] && array[i] > array[i + 1])
                {
                    Console.WriteLine($"{array[i - 1]} < {array[i]} > {array[i + 1]}");
                }
            }

        }

        static int[] GetArray(ref int[] array, int lengthArray, int maxRange, int minRange = 0)
        {
            Random random = new Random();

            for (int i = 0; i < lengthArray; i++)
                array[i] = random.Next(minRange, maxRange++);

            return array;
        }
    }
}
