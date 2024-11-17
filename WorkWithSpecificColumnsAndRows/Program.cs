using System;

namespace WorkWithSpecificColumnsAndRows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[3, 3];
            Random random = new Random();
            int randomMin = 1;
            int randomMax = 10;
            int summSecondRow = 0;
            int productFirstColumn;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for(int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = random.Next(randomMin, randomMax);
                    Console.Write(numbers[i,j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                summSecondRow += numbers[1, i];
            }

            productFirstColumn = numbers[0, 0];

            for (int i = 1; i < numbers.GetLength(0); i++)
            {
                productFirstColumn *= numbers[i, 0];
            }

            Console.WriteLine($"summ of second row = {summSecondRow}\nproduct of first column = {productFirstColumn}");
        }
    }
}
