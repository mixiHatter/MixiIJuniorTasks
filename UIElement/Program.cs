﻿using System;

namespace UIElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mana = 0;
            int healthPoint = 0;
            int positionXMana = 60;
            int sizeBar;

            Console.WriteLine("Введите кол-во жизни: ");
            healthPoint = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длину бара: ");
            sizeBar = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            GetDrawBar(healthPoint, sizeBar);

            Console.WriteLine();
            Console.WriteLine("Введите кол-во маны: ");
            mana = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длину бара: ");
            sizeBar = Convert.ToInt32(Console.ReadLine());

            GetDrawBar(mana, sizeBar, positionXMana);

            Console.ReadKey();
        }

        static void GetDrawBar(int fill, int sizeBar, int positionX = 30, int positionY = 0)
        {
            char havePoint = '#';
            char freePont = '_';
            double maxProcent = 100;
            double oneProcentBar = Convert.ToDouble(sizeBar) / maxProcent;

            if (fill > maxProcent)
                fill = Convert.ToInt32(maxProcent);

            int fillProcent = Convert.ToInt32(Convert.ToDouble(fill) * oneProcentBar);
            int freeBar = Convert.ToInt32(Convert.ToDouble(sizeBar) - fillProcent);

            char DrawBar(char symbol, double length)
            {
                for (int i = 1; i <= length; i++)
                    Console.Write(symbol);
                return symbol;
            }

            Console.SetCursorPosition(positionX, positionY);
            Console.Write("[");
            DrawBar(havePoint, fillProcent);
            DrawBar(freePont, freeBar);
            Console.Write("]");
        }
    }
}
