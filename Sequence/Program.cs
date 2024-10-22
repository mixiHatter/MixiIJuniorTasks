using System;
using System.Collections.Generic;

namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>() 
            {5, 12, 19, 26, 33, 40, 47, 54, 61, 68, 75, 82, 89, 96, 103};
            int count = 0;
            int listCell = 0;
            int maxListCell = ints.Count;

            while (listCell < maxListCell) // не смог реализовать данную задачу через цикл for, по этому использовал while
            {
                if (count == ints[listCell])
                {
                    Console.WriteLine(count);
                    listCell++;
                }
                else { count++; }
            } 
        }

    }
}
