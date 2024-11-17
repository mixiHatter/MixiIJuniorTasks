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
            int arrayRow = 1;
            int arrayColumn = 0;
            int summSecondRow = 0;
            int productFirstColumn = 1;

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
                summSecondRow += numbers[arrayRow, i];
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                productFirstColumn *= numbers[i, arrayColumn];
            }

            Console.WriteLine($"summ of {++arrayRow} row = {summSecondRow}\nproduct of {++arrayColumn} column = {productFirstColumn}");
        }
    }
}
