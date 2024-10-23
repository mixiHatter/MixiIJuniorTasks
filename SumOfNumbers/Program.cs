using System;

namespace SumOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxRandomNumber = 101;
            int number = random.Next(0, maxRandomNumber);
            int sumNumbers = 0;
            int multiple1 = 3;
            int multiple2 = 5;

            Console.WriteLine(number);

            for (int i = 0; i <= number; i++)
            {
                if(i % multiple1 == 0 || i % multiple2 == 0)
                {
                    sumNumbers+=i;
                    Console.WriteLine(sumNumbers);
                }
            }
        }
    }
}
