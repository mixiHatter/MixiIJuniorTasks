using System;
using System.Collections.Generic;

namespace ExplanatoryDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordExit = "exit";
            bool isWork = true;

            do
            {
                Console.Clear();

                Console.SetCursorPosition(70, 0);
                Console.WriteLine($"{wordExit} - что бы выйти.");

                Console.SetCursorPosition(0, 1);
                Console.Write("Введите название коллекции, что бы узнать его описание: ");
                
                string userInput = Convert.ToString(Console.ReadLine());

                СheckingWord(userInput.ToLower(), wordExit, ref isWork);
            }
            while (isWork);
        }

        static void СheckingWord(string word, string wordExit, ref bool isWork)
        {
            Dictionary<string, string> cSharpCollections = new Dictionary<string, string>()
            {
                {"list", "простейший список однотипных объектов. Класс List типизируется типом, объекты которого будут хранится в списке."},
                {"queue", "обычная очередь, которая работает по алгоритму FIFO (\"первый вошел - первый вышел\")."},
                {"stack", "коллекция, которая использует алгоритм LIFO (\"последний вошел - первый вышел\")."},
                {"dictionary", "cловарь. Хранит объекты, которые представляют пару ключ-значение. \nКласс словаря Dictionary<K, V> типизируется двумя типами: \nпараметр K представляет тип ключей, а параметр V предоставляет тип значений."}
            };

            Console.Clear();

            if (cSharpCollections.ContainsKey(word))
            {
                Console.WriteLine($"{word} - {cSharpCollections[word]}");
            }

            else if (word == wordExit)
            {
                isWork = false;
                Console.WriteLine("Выход выполнен.");
            }

            else
            {
                Console.WriteLine($"Значения слова {word} - не найдено");
            }

            Console.SetCursorPosition(0, 5);
            Console.WriteLine("Нажмите любую клавишу, что бы продолжить:");
            Console.ReadKey();
        }
    }
}
