using System;

namespace SubarrayRepetitionsNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[30];
            Random random = new Random();
            int minRange = 1;
            int maxRange = 5;
            int countRepetitions = 1;
            int repetitionsNumber = 0;
            int maxCountRepetitions = 0;

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(minRange, maxRange + 1);

            for (int i = 0;i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    countRepetitions++;
                }

                else
                    countRepetitions = 1;

                if(countRepetitions > maxCountRepetitions)
                {
                    repetitionsNumber = numbers[i];
                    maxCountRepetitions = countRepetitions;
                }
            }

            foreach (int i  in  numbers)
            {
                Console.Write(i + ",");
            }

            Console.WriteLine();
            Console.WriteLine($"The number {repetitionsNumber} is repeated {maxCountRepetitions} times in a row.");
        }
    }
}
