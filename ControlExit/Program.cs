using System;

namespace ControlExit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userText = "None";

            while(userText != "exit")
            {
                Console.WriteLine("work");
                userText = Console.ReadLine();
            }
        }
    }
}
