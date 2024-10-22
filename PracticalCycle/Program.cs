using System;

namespace PracticalCycle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userText;
            int userCountRepeats;

            Console.Write("Вы хотите сказать: ");
            userText = Convert.ToString(Console.ReadLine());
            Console.Write("Сколько раз вы хотите это сказать: ");
            userCountRepeats = Convert.ToInt32(Console.ReadLine());

            while (userCountRepeats > 0) 
            {
                Console.WriteLine(userText);
                userCountRepeats--;
            }
        }
    }
}
