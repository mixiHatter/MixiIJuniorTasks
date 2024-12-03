using System;

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

            SpawnPlayer(map, player, wall);

            while (true)
            {
                Console.Clear();
                ShowMap(map);

                Console.ReadKey();
            }
        }

        static void ShowMap(char[,] map)
        {
            for(int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] SpawnPlayer(char[,] map, char player, char wall)
        {
            bool isVisiblePlayer = false;

            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[i,j] != wall && isVisiblePlayer !=true)
                    {
                        map[i,j] = player;
                        isVisiblePlayer = true;
                    }
                }
            }

            return map;
        }
    }
}