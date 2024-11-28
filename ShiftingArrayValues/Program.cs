using System;

namespace ShiftingArrayValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            Random random = new Random();
            int minRange = 0;
            int maxRange = 10;
            int userInput;
            int bufer = 0;

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(minRange, maxRange + 1);

            foreach (int number in numbers)
                Console.Write(number + ",");

            Console.WriteLine();
            userInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 0;i < userInput;i++)
            {
                for(int j = 0; j < numbers.Length - 1;j++)
                {
                    bufer = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = bufer;
                }
            }

            foreach (int number in numbers)
                Console.Write(number + ",");
        }
    }
}
