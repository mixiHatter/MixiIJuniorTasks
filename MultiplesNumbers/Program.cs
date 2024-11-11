using System;

namespace MultiplesNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minRandom = 10;
            int maxRandom = 26;
            int number = random.Next(minRandom, maxRandom);
            int minRange = 50;
            int maxRange = 150;
            int countMultiples = 0;

            Console.WriteLine($"Random droped number: {number}.");

            for (int i = number; i <= maxRange; i += number)
            {
                if(i >= minRange)
                {
                    countMultiples++;
                }
            }

            Console.WriteLine($"{countMultiples} multiples of {number} in the range from {minRange} to {maxRange}.");
            Console.ReadKey();
        }
    }
}
