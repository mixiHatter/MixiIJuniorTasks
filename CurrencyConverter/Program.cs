﻿using System;
using System.Net.Http.Headers;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string userCommand;

            const string CommandConvertRubleToDollar = "1";
            const string CommandConvertDollarToRuble = "2";
            const string CommandConvertRubleToEuro = "3";
            const string CommandConvertEuroToRuble = "4";
            const string CommandConvertEuroToDollar = "5";
            const string CommandConvertDollarToEuro = "6";
            const string CommandExit = "7";

            double userWalletRubles = 1000.0;
            double userWalletDollars = 1000.0;
            double userWalletEuros = 1000.0;

            double ratioRubleAndDollar = 96.64;
            double ratioRubleAndEuro = 104.38;
            double ratioEuroAndDollar = 1.08;

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
                            userWalletDollars += userAmountToConvert / ratioRubleAndDollar;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                            break;
                        }
                        break;

                    case CommandConvertDollarToRuble:
                        Console.Write("Сколько долларов вы хотите конвертировать в рубли:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletDollars - userAmountToConvert >= 0)
                        {
                            userWalletDollars -= userAmountToConvert;
                            userWalletRubles += userAmountToConvert * ratioRubleAndDollar;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                            break;
                        }
                        break;

                    case CommandConvertRubleToEuro:
                        Console.Write("Сколько рублей вы хотите конвертировать в евро:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletRubles - userAmountToConvert >= 0)
                        {
                            userWalletRubles -= userAmountToConvert;
                            userWalletEuros += userAmountToConvert / ratioRubleAndEuro;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                            break;
                        }
                        break;

                    case CommandConvertEuroToRuble:
                        Console.Write("Сколько евро вы хотите конвертировать в рубли:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletEuros - userAmountToConvert >= 0)
                        {
                            userWalletEuros -= userAmountToConvert;
                            userWalletRubles += userAmountToConvert * ratioRubleAndEuro;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                            break;
                        }
                        break;

                    case CommandConvertEuroToDollar:
                        Console.Write("Сколько евро вы хотите конвертировать в доллары:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletEuros - userAmountToConvert >= 0)
                        {
                            userWalletEuros -= userAmountToConvert;
                            userWalletDollars += userAmountToConvert * ratioEuroAndDollar;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                            break;
                        }
                        break;

                    case CommandConvertDollarToEuro:
                        Console.Write("Сколько долларов вы хотите конвертировать в евро:");
                        userAmountToConvert = Convert.ToDouble(Console.ReadLine());

                        if (userWalletDollars - userAmountToConvert >= 0)
                        {
                            userWalletDollars -= userAmountToConvert;
                            userWalletEuros += userAmountToConvert / ratioEuroAndDollar;
                        }
                        else
                        {
                            Console.WriteLine("На вашем балансе недостаточно средств.");
                            break;
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
