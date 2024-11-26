using System;

namespace ShiftingArrayValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            Random random = new Random();
            int minRange = 0;
            int maxRange = 10;
            int userInput = Convert.ToInt32(Console.ReadLine());
            int bufer = 0;

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(minRange, maxRange + 1);

            if (userInput > 0)
            {
                for (int i = 0; i < numbers.Length - userInput; i++)
                {
                    bufer = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = bufer;
                }
            }

            foreach (int number in numbers)
                Console.Write(number + ",");
        }
    }
}
