using System;

namespace NameOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string symbol;
            string name;

            Console.Write("Введите желаемый символ: ");
            symbol = Console.ReadLine();
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            for(int i = 0; i < name.Length + 2; i++)
            {
                Console.Write(symbol);
            }

            Console.WriteLine($"\n{symbol}{name}{symbol}");

            for (int i = 0; i < name.Length + 2; i++)
            {
                Console.Write(symbol);
            }
        }
    }
}
