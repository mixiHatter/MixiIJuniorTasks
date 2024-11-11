using System;

namespace DegreeTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minRandom = 1;
            int maxRandom = 150;
            int number = random.Next(minRandom, maxRandom);
            int numberDegree = 2;
            int degree = 1;

            Console.WriteLine($"Random dropped number: {number}");

            while(numberDegree < number)
            {
                numberDegree += numberDegree;
                degree++;
            }
            
            Console.WriteLine($"{number} > {numberDegree}, which is 2 to the power of {degree}");
        }
    }
}
