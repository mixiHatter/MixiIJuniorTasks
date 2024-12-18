﻿using System;

namespace ParenthesisExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine(); ;
            char openingBrecket = '(';
            char closingBrecket = ')';
            int maxDepth = 0;
            int depth = 0;
            bool isCorrect = true;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == openingBrecket)
                {
                    depth++;

                    if (depth > maxDepth)
                        maxDepth = depth;
                }
                else if (text[i] == closingBrecket)
                {
                    depth--;

                    if (depth < 0)
                        isCorrect = false;
                }
            }

            if (depth == 0 && isCorrect)
                Console.WriteLine($"{text} - строка корректная и максимум глубины равняется {maxDepth}.");
            else
                Console.WriteLine($"{text} - строка некорректная.");
        }
    }
}
