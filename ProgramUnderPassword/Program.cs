using System;

namespace ProgramUnderPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string password = "qwerty123";
            string secretText = "U are the best";
            string userText;
            int tryCount = 3;

            while (isWork)
            {
                Console.Write("Введите пароль: ");
                userText = Console.ReadLine();

                if(userText == password)
                {
                    Console.WriteLine(secretText);
                    break;
                }
                else if (tryCount <= 1)
                {
                    isWork = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Пароль неверный!");
                    Console.WriteLine($"У вас осталось {tryCount - 1} попыток");
                    tryCount--;
                }
            }
        }
    }
}
