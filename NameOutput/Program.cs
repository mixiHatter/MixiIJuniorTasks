using System;

namespace NameOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string symbol;
            string middleLine = "";
            string symbols = "";
            string name;

            Console.Write("Введите желаемый символ: ");
            symbol = Console.ReadLine();
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            middleLine = symbol + name + symbol;

            for(int i = 0; i < middleLine.Length; i++)
            {
                symbols += symbol;
            }

            Console.WriteLine($"{symbols}\n{middleLine}\n{symbols}");
        }
    }
} 
