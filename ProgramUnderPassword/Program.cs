using System;

namespace ProgramUnderPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "qwerty123";
            string secretText = "U are the best";
            string userText;
            int tryCount = 2;

            for (int i = tryCount; i >= 0; i--)
            {
                Console.Write("Введите пароль: ");
                userText = Console.ReadLine();

                if (userText == password)
                {
                    Console.WriteLine(secretText);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Пароль не верный!");
                }
            }
        }
    }
}
