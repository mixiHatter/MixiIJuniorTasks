using System;
using static System.Net.Mime.MediaTypeNames;

namespace UIElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mana;
            int healthPoint;
            int positionXHealthPoint = 30;
            int positionXMana = 60;
            int sizeBar;

            Console.WriteLine("Введите кол-во жизни: ");
            healthPoint = ReadInt((Console.ReadLine()));
            Console.WriteLine("Введите длину бара: ");
            sizeBar = ReadInt((Console.ReadLine()));
            Console.Clear();

            Console.SetCursorPosition(positionXHealthPoint, 0);
            Console.WriteLine(GetDrawBar(healthPoint, sizeBar));

            Console.WriteLine();
            Console.WriteLine("Введите кол-во маны: ");
            mana = ReadInt((Console.ReadLine()));
            Console.WriteLine("Введите длину бара: ");
            sizeBar = ReadInt((Console.ReadLine()));

            Console.SetCursorPosition(positionXMana, 0);
            Console.WriteLine(GetDrawBar(mana, sizeBar));
            

            Console.ReadKey();
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
        
        static string DrawBar(char symbol, double length)
        {
            string text = string.Empty;
            for (int i = 1; i <= length; i++)
                text += symbol;

            return text;
        }

        static string GetDrawBar(int fill, int sizeBar)
        {
            string text = string.Empty;
            char havePoint = '#';
            char freePont = '_';
            char openingBracket = '[';
            char closingBracket = ']';
            double maxProcent = 100;
            double oneProcentOfSizeBar = Convert.ToDouble(sizeBar) / maxProcent;

            if (fill > maxProcent)
                fill = Convert.ToInt32(maxProcent);
            else if (fill < 0)
                fill = 0;

            int fillProcent = Convert.ToInt32(Convert.ToDouble(fill) * oneProcentOfSizeBar);
            int freeBar = Convert.ToInt32(Convert.ToDouble(sizeBar) - fillProcent);

            text += openingBracket + DrawBar(havePoint, fillProcent) + DrawBar(freePont, freeBar) + closingBracket;

            return text;
        }
    }
}
