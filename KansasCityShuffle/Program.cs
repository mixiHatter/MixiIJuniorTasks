using System;

namespace KansasCityShuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[10];
            int minRange = 0;
            int maxRange = 10;

            for(int i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(minRange, maxRange);

            foreach(int number in numbers)
                Console.Write(number + ",");

            Shuffle(ref numbers);
            Console.WriteLine();

            foreach (int number in numbers)
                Console.Write(number + ",");
        }

        static void Shuffle(ref int[] numbers)
        {
            Random random = new Random();
            int minRange = 0;
            int maxRange = numbers.Length - 1;
            int bufer = 0;
            int newIndex;

            for(int i = 0;i < numbers.Length; i++)
            {
                newIndex = random.Next(minRange,maxRange);
                bufer = numbers[i];
                numbers[i] = numbers[newIndex];
                numbers[newIndex] = bufer;
            }
                
        }
    }
}
