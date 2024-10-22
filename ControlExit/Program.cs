using System;

namespace ControlExit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string programExit = "exit";
            string userText;

            Console.WriteLine($"Для выхода нужно ввести {programExit}");
            do
            {
                Console.Write("Введите текст: ");
                userText = Console.ReadLine();
                Console.WriteLine(userText);
            }
            while (userText != programExit);
            Console.WriteLine("Program is end");
        }
    }
}
