using System;

namespace LargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[10, 10];
            Random random = new Random();
            int randomMin = 1;
            int randomMax = 101;
            int largestElement;
            int stub = 0;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = random.Next(randomMin, randomMax);
                    Console.Write(numbers[i, j]);
                    Console.Write(",");
                }
                Console.WriteLine();
            }

            largestElement = numbers[0, 0];

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if(largestElement < numbers[i, j])
                    {
                        largestElement = numbers[i, j];
                    }
                }
            }

            Console.WriteLine($"Laragest element: {largestElement}");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if(largestElement == numbers[i,j])
                    {
                        numbers[i, j] = stub;
                    }
                    Console.Write(numbers[i, j]);
                    Console.Write(",");
                }

                Console.WriteLine();
            }
        }
    }
}
