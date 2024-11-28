using System;

namespace UIElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mana = 0;
            int healthPoint = 0;
            int positionXMana = 60;

            while (true)
            {
                Console.WriteLine("Введите кол-во жизни: ");
                healthPoint = Convert.ToInt32(Console.ReadLine());

                GetDrowBar(healthPoint);

                Console.WriteLine();
                Console.WriteLine("Введите кол-во маны: ");
                mana = Convert.ToInt32(Console.ReadLine());

                GetDrowBar(mana, positionXMana);
                
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        static void GetDrowBar(int fill, int positionX = 30, int positionY = 0)
        {
            char havePoint = '#';
            char freePont = '_';

            Console.SetCursorPosition(positionX, positionY);
            Console.Write("[");

            for (int i = 1; i <= 10;  i++)
            {
                if (fill / 10 >= i)
                    Console.Write(havePoint);
                else
                    Console.Write(freePont);
            }

            Console.Write("]");
        }
    }
}
