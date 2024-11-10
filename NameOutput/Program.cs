using System;
using System.Linq.Expressions;

namespace NameOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string symbol;
            string symbols = "";
            string name;

            Console.Write("Введите желаемый символ: ");
            symbol = Console.ReadLine();
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            for(int i = 0; i < name.Length + 2; i++)
            {
                symbols += symbol;
            }

            Console.WriteLine($"{symbols}\n{symbol}{name}{symbol}\n{symbols}");
        }
    }
}
