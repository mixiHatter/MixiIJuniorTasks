using System;
using System.ComponentModel;

namespace Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = new string[] {"1", "2", "3"};
            string[] array2 = new string[] { "A", "B", "C" };
            string text = "The";

            array2 = text.Split(null);

            foreach (string item in array2)
                Console.WriteLine(item + ",");
        }
    }
}
