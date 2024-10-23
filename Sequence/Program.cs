using System;

namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 5;
            int maxNumber = 103;
            int stepNumber = 7;

            for (int i = startNumber; i <= maxNumber; i += stepNumber) // цикл for позволяет устанавливать стартовое значение, условие и шаг, что идеально подходит к задаче
            {
                Console.WriteLine(i);
            }
        }

    }
}
