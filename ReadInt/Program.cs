using System;

namespace ReadInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadInt(Console.ReadLine()));
        }

        static int ReadInt(string text)
        {
            bool result = int.TryParse(text, out var convertNumber);

            while (result == false)
            {
                Console.WriteLine("Введите повторно:");

                result = int.TryParse(Console.ReadLine(), out var number);
                convertNumber = number;
            }

            return convertNumber;
        }
    }
}
