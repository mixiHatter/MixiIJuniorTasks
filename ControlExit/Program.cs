using System;

namespace ControlExit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userText;
            string programmExit = "exit";

            Console.WriteLine($"Для выхода нужно ввести {programmExit}");
            Console.Write("Введите текст: ");
            userText = Console.ReadLine();
            while (userText != programmExit)
            {
                Console.WriteLine(userText);
                Console.Write("Введите текст: ");
                userText = Console.ReadLine();
            }
        }
    }
}
