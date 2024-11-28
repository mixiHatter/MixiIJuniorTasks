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
                isConvertCorrect = ReadInt(Console.ReadLine(), out int number, out string answer);

                Console.WriteLine(answer);
            }
        }

        static bool ReadInt(string text, out int number, out string answer)
        {
            bool result = int.TryParse(text, out var convertNumber);
            number = convertNumber;

            if (result == true)
                answer = "Number: " + number;
            else
                answer = "Repeat the input";

            return result;
        }
    }
}
