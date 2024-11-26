using System;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string userInput;
            int[] userNumbers = new int[0];
            int sum = 0;

            while (isWork)
            {
                foreach (int i in userNumbers)
                    Console.Write(i + ",");

                Console.WriteLine();
                userInput = Console.ReadLine();

                if (userInput == "sum")
                {
                    foreach(int i in userNumbers)
                        sum += i;

                    Console.WriteLine(sum);
                    Console.ReadKey();
                }

                else if (userInput == "exit") 
                    isWork = false;

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
