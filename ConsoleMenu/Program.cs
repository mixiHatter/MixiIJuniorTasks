using System;

namespace ConsoleMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            
            const string CommandEchoText = "1";
            const string CommandSecretText = "2";
            const string CommandRandomNumber = "3";
            const string CommandClearConsole = "4";
            const string CommandExitProgramm = "5";
            
            string userText;
            string userTextEcho;
            Random random = new Random();
            int minRandom = 1;
            int maxRandom = 101;
            int randomNumber;

            while (isWork)
            {
                Console.WriteLine($"Для дублирования вашего текста введите - {CommandEchoText}" +
                    $"\nДля вывода секретиков введите - {CommandSecretText}" +
                    $"\nДля вывода случайного числа введите - {CommandRandomNumber}" +
                    $"\nДля очистки консоли введите - {CommandClearConsole}" +
                    $"\nДля выхода из программы введите - {CommandExitProgramm}");

                Console.Write("Введите команду: ");
                userText = Convert.ToString(Console.ReadLine());

                switch (userText)
                {
                    case CommandEchoText:
                        Console.Write("Введите текст для дублирования:");
                        userTextEcho = Console.ReadLine();
                        Console.WriteLine(userTextEcho);
                        break;
                        
                    case CommandSecretText:
                        Console.Clear();
                        Console.WriteLine("\"Компилятору все равно, как написан код. \r\nЕму не нужна мудрость в глазах кодера, чтобы всё это понять.\"\r\n@Почти В.Цой");
                        Console.ReadKey();
                        break;
                        
                    case CommandRandomNumber:
                        randomNumber = random.Next(minRandom, maxRandom);
                        Console.WriteLine(randomNumber);
                        break;
                        
                    case CommandClearConsole:
                        Console.Clear();
                        break;
                        
                    case CommandExitProgramm:
                        isWork = false;
                        break;
                        
                    default:
                        Console.WriteLine("Команда не распознана.");
                        break;
                }
            }
        }
    }
}
