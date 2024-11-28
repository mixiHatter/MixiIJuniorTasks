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
            int sizeBar;
            while (true)
            {
                Console.WriteLine("Введите кол-во жизни: ");
                healthPoint = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите длину бара: ");
                sizeBar = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                GetDrowBar(healthPoint, sizeBar);

                Console.WriteLine();
                Console.WriteLine("Введите кол-во маны: ");
                mana = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите длину бара: ");
                sizeBar = Convert.ToInt32(Console.ReadLine());

                GetDrowBar(mana, sizeBar, positionXMana);
                
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        static void GetDrowBar(int fill, int sizeBar, int positionX = 30, int positionY = 0)
        {
            char havePoint = '#';
            char freePont = '_';

            Console.SetCursorPosition(positionX, positionY);
            Console.Write("[");

            if (sizeBar < fill)
                fill = fill / sizeBar;

            for (int i = 1; i <= fill; i++)
                Console.Write(havePoint);

            for(int i = 1;i <= sizeBar - fill; i++)
                Console.Write(freePont);

            Console.Write("]");
        }
    }
}
