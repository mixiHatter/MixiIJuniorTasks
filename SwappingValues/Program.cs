using System;

namespace SwappingValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Васильев";
            string surname = "Вася";
            string buffer;
            Console.WriteLine($"Имя: {name}, фамилия: {surname}.");
            buffer = name;
            name = surname;
            surname = buffer;
            Console.WriteLine($"Имя: {name}, фамилия: {surname}.");

            string firstCup = "кофе";
            string secondCup = "чай";
            Console.WriteLine($"В первой чашке: {firstCup}, а во второй: {secondCup}");
            buffer = firstCup;
            firstCup = secondCup;
            secondCup = buffer;
            Console.WriteLine($"В первой чашке: {firstCup}, а во второй: {secondCup}");
        }
    }
}
