using System;

namespace ReadInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isConvertCorrect = false;

            while (isConvertCorrect == false)
            {
                isConvertCorrect = ReadInt(Console.ReadLine(), out int number);

                if (isConvertCorrect == true)
                    Console.WriteLine($"Number: {number}");
                else
                    Console.WriteLine("Repeat the input");
            }
        }

        static bool ReadInt(string text, out int number)
        {
            bool result = int.TryParse(text, out var convertNumber);
            number = convertNumber;

            return result;
        }
    }
}
