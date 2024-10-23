using System;

namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 5; i <= 103; i += 7) // цикл for позволяет устанавливать стартовое значение, условие и шаг, что идеально подходит к задаче
            {
                Console.WriteLine(i);
            }
        }

    }
}
