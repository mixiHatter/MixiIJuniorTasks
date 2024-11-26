using System;

namespace Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Никогда не ошибается тот, кто ничего не делает";
            string[] words = text.Split(' ');

            foreach (string word in words)
                Console.WriteLine(word);
        }
    }
}
