using System;
using System.Net.Http.Headers;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandConvertRubleToDollar = "1";
            const string CommandConvertDollarToRuble = "2";
            const string CommandConvertRubleToEuro = "3";
            const string CommandConvertEuroToRuble = "4";
            const string CommandConvertEuroToDollar = "5";
            const string CommandConvertDollarToEuro = "6";
            const string CommandExit = "7";
            
            bool isWork = true;
            string userCommand;

            double userWalletRubles = 1000.0;
            double userWalletDollars = 1000.0;
            double userWalletEuros = 1000.0;

            double ratioRubleToDollar = 96.67;
            double ratioDollarToRuble = 0.010345;
            double ratioRubleToEuro = 104.81;
            double ratioEuroToRuble = 0.009541;
            double ratioEuroToDollar = 1.08;
            double ratioDollarToEuro = 0.92629;

            double userAmountToConvert;

            while(isWork)
            {
                Console.WriteLine($"\nВаш баланс в рублях: {userWalletRubles}" +
                    $"\nВаш баланс в долларах: {userWalletDollars}" +
                    $"\nВаш баланс в евро: {userWalletEuros}");
                Console.WriteLine($"\nСписок команд:" +
                    $"\nДля перевода рублей в доллары введите - {CommandConvertRubleToDollar}" +
                    $"\nДля перевода долларов в рубли введите - {CommandConvertDollarToRuble}" +
                    $"\nДля перевода рублей в евро введите - {CommandConvertRubleToEuro}" +
                    $"\nДля перевода евро в рубли введите - {CommandConvertEuroToRuble}" +
                    $"\nДля перевода евро в доллары введите - {CommandConvertEuroToDollar}" +
                    $"\nДля перевода долларов в евро введите - {CommandConvertDollarToEuro}" +
                    $"\nДля выхода из программы введите - {CommandExit}") ;

                Console.Write("\nВведите команду:");
                userCommand = Convert.ToString(Console.ReadLine());

                switch(userCommand)
                {
                    case CommandConvertRubleToDollar:
                        Console.Write("Сколько рублей вы хотите конвертировать в доллары:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());
                        
                        if(userWalletRubles - userAmountToConvert >= 0)
                        {
                            userWalletRubles -=userAmountToConvert;
                            userWalletDollars += userAmountToConvert * ratioDollarToRuble;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                        }
                        break;

                    case CommandConvertDollarToRuble:
                        Console.Write("Сколько долларов вы хотите конвертировать в рубли:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletDollars - userAmountToConvert >= 0)
                        {
                            userWalletDollars -= userAmountToConvert;
                            userWalletRubles += userAmountToConvert * ratioRubleToDollar;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                        }
                        break;

                    case CommandConvertRubleToEuro:
                        Console.Write("Сколько рублей вы хотите конвертировать в евро:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletRubles - userAmountToConvert >= 0)
                        {
                            userWalletRubles -= userAmountToConvert;
                            userWalletEuros += userAmountToConvert * ratioEuroToRuble;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                        }
                        break;

                    case CommandConvertEuroToRuble:
                        Console.Write("Сколько евро вы хотите конвертировать в рубли:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletEuros - userAmountToConvert >= 0)
                        {
                            userWalletEuros -= userAmountToConvert;
                            userWalletRubles += userAmountToConvert * ratioRubleToEuro;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                        }
                        break;

                    case CommandConvertEuroToDollar:
                        Console.Write("Сколько евро вы хотите конвертировать в доллары:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletEuros - userAmountToConvert >= 0)
                        {
                            userWalletEuros -= userAmountToConvert;
                            userWalletDollars += userAmountToConvert * ratioEuroToDollar;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                        }
                        break;

                    case CommandConvertDollarToEuro:
                        Console.Write("Сколько долларов вы хотите конвертировать в евро:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletDollars - userAmountToConvert >= 0)
                        {
                            userWalletDollars -= userAmountToConvert;
                            userWalletEuros += userAmountToConvert * ratioDollarToEuro;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                        }
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Комманда не распознана.");
                        Console.Write("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
