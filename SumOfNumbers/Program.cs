using System;

namespace SumOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int number = rand.Next(0, 101);
            int sumNumbers = 0;

            Console.WriteLine(number);
            for (int i = 0; i <= number; i++) 
            {
                if(i % 3 == 0 || i % 5 == 0) 
                {
                    sumNumbers+=i;
                    Console.WriteLine(sumNumbers);
                }
            }
        }
    }
}
