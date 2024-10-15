using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace workWithStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            string zodiacSign;
            string profession;

            Console.Write("Ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Ваш возраст: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ваш знак зодиака: ");
            zodiacSign = Console.ReadLine();
            Console.Write("Ваша профессия: ");
            profession = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}, Вам {age} лет, Ваш знак зодиака {zodiacSign} и вы работаете {profession}.");
        }
    }
}
