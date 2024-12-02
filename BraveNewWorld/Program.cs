using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveNewWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new char[,] { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                                      { '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', '#', ' ', '#'},
                                      { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#'},
                                      { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };
            char player = '@';

            ShowMap(map);

            Console.ReadKey();
        }

        static void ShowMap(char[,] map)
        {
            for(int i = 0; i < map.GetLength(1); i++)
            {
                for(int j = 0; j < map.GetLength(0); j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
