using System;

namespace UIElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mana = 0;

            while (true)
            {
                mana = Convert.ToInt32(Console.ReadLine());
                GetDrowBar(mana);
            }
        }
        
        static void GetDrowBar(int fill)
        {
            char havePoint = '|';
            char freePont = '_';

            for(int i = 1; i <= 10;  i++)
            {
                if (fill >= i)
                    Console.Write(havePoint);
                else
                    Console.Write(freePont);

            }
            Console.WriteLine();
        }
    }
}
