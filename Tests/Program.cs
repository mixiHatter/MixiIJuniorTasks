using System;

namespace Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] testInt = new int[] { 1, 2, 3 };
            int userInput = 3;
            int bufer = 0;

            for (int i = userInput - 1; i < testInt.Length - 1; i++)
            {
                bufer = testInt[i];
                testInt[i] = testInt[i + 1];
                testInt[i + 1] = bufer;
            }

            int[] newInt = new int[testInt.Length - 1];
            for (int i = 0; i < newInt.Length; i++)
            {
                newInt[i] = testInt[i];
            }

            testInt = newInt;

            foreach (int item in testInt)
                Console.Write(item + ",");
        }
    }
}
