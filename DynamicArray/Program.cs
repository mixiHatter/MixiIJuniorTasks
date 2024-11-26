using System;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string commandExit = "exit";
            string commandSum = "sum";
            bool isWork = true;
            string userInput;
            int[] userNumbers = new int[0];
            int sum = 0;

            while (isWork)
            {
                foreach (int number in userNumbers)
                    Console.Write(number + ",");

                Console.WriteLine();
                userInput = Console.ReadLine();

                if (userInput == commandSum)
                {
                    foreach(int i in userNumbers)
                        sum += i;

                    Console.WriteLine(sum);
                    sum = 0;
                    Console.ReadKey();
                }
                else if (userInput == commandExit)
                {
                    isWork = false;
                }

                else
                {
                    int[] arrayExtension = new int[userNumbers.Length + 1];

                    for(int i = 0;i < userNumbers.Length; i++)
                    {
                        arrayExtension[i] = userNumbers[i];
                    }

                    arrayExtension[userNumbers.Length] = Convert.ToInt32(userInput);
                    userNumbers = arrayExtension;
                }

                Console.Clear();
            }
        }
    }
}
