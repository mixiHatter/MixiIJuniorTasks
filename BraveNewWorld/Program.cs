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
            char[,] map = new char[,] { 
                                      { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
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
            char wall = '#';

            ShowPlayer(map, player, wall);

            while (true)
            {
                Console.Clear();
                ShowMap(map);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                Move(map, player, pressedKey);
            }
        }

        static void ShowMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                    Console.Write(map[i, j]);

                Console.WriteLine();
            }
        }

        static char[,] ShowPlayer(char[,] map, char player, char wall)
        {
            bool visiblePlayer = false;

            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[i, j] != wall && visiblePlayer != true)
                    {
                        map[i, j] = player;
                        visiblePlayer = true;
                    }
                }

            }

            return map;
        }

        static void Move(char[,] map, char player, ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.KeyChar == 'w')
                MoveUp(map, player);
            else if(pressedKey.KeyChar == 'd')
                MoveDown(map, player);
        }

        static void MoveDown(char[,] map, char player, char wall)
        {
            map.GetLength(1);
        }

        static void MoveUp(char[,] map, char player, char wall)
        {

        }
    }
}
