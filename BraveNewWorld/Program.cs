using System;
using System.Diagnostics.Eventing.Reader;

namespace BraveNewWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new char[,] {
                                      { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                                      { '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
                                      };
            char[,] mapActive = new char[map.GetLength(0), map.GetLength(1)];
            int mapSize;
            char way = ' ';
            char player = '@';
            char wall = '#';
            int[] playerPosition;
            bool isPlaying = true;

            mapSize = map.Length;
            playerPosition = GetPositionToSpawnPlayer(map, wall);
            Array.Copy(map, mapActive, mapSize);

            while (isPlaying)
            {
                Console.Clear();

                DrawUnit(mapActive, player, playerPosition);
                ShowMap(mapActive);

                ConsoleKeyInfo playerKey = Console.ReadKey();

                PlayerKeyPressed(ref isPlaying, playerKey, mapActive, wall, way, player, ref playerPosition);
            }
        }

        static void ShowMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static int[] GetPositionToSpawnPlayer(char[,] mapActive, char wall)
        {
            int coordinateY = 0;
            int coordinateX = 1;

            bool playerIsSpawn = false;
            int[] playerPosition = new int[2];

            for (int i = 0; i < mapActive.GetLength(1); i++)
            {
                for (int j = 0; j < mapActive.GetLength(0); j++)
                {
                    if (mapActive[i, j] != wall && playerIsSpawn == false)
                    {
                        playerPosition[coordinateY] = i;
                        playerPosition[coordinateX] = j;

                        playerIsSpawn = true;
                    }
                }
            }

            return playerPosition;
        }

        static void DrawUnit(char[,] mapActive, char newUnit, int[] playerPosition)
        {
            int coordinateY = 0;
            int coordinateX = 1;

            mapActive[playerPosition[coordinateY], playerPosition[coordinateX]] = newUnit;
        }

        static void PlayerKeyPressed(ref bool isPlaying, ConsoleKeyInfo playerKey, char[,] mapActive, char wall, char way, char player, ref int[] playerPosition)
        {
            const ConsoleKey CommandKeyUp = ConsoleKey.W;
            const ConsoleKey CommandKeyDown = ConsoleKey.S;
            const ConsoleKey CommandKeyLeft = ConsoleKey.A;
            const ConsoleKey CommandKeyRight = ConsoleKey.D;

            int coordinateY = 0;
            int coordinateX = 1;
            int step = 1;

            int[] newPlayerPosition = new int[2];
            Array.Copy(playerPosition, newPlayerPosition, 2);

            switch (playerKey.Key)
            {
                case CommandKeyUp:
                    newPlayerPosition[coordinateY] = playerPosition[coordinateY] - step;

                    if (CanMove(mapActive, wall, newPlayerPosition))
                        PlayerMove(mapActive, player, way, playerPosition, newPlayerPosition, playerKey.Key);
                    break;

                case CommandKeyDown:
                    newPlayerPosition[coordinateY] = playerPosition[coordinateY] + step;

                    if (CanMove(mapActive, wall, newPlayerPosition))
                        PlayerMove(mapActive, player, way, playerPosition, newPlayerPosition, playerKey.Key);
                    break;

                case CommandKeyLeft:
                    newPlayerPosition[coordinateX] = playerPosition[coordinateX] - step;

                    if (CanMove(mapActive, wall, newPlayerPosition))
                        PlayerMove(mapActive, player, way, playerPosition, newPlayerPosition, playerKey.Key);
                    break;

                case CommandKeyRight:
                    newPlayerPosition[coordinateX] = playerPosition[coordinateX] + step;

                    if (CanMove(mapActive, wall, newPlayerPosition))
                        PlayerMove(mapActive, player, way, playerPosition, newPlayerPosition, playerKey.Key);
                    break;

                case ConsoleKey.Escape:
                    isPlaying = false;
                    break;

                default:
                    break;
            }
        }

        static int[] PlayerMove(char[,] mapActive, char player, char way, int[] playerPosition, int[] newPlayerPosition, ConsoleKey playerKey)
        {
            int coordinateY = 0;
            int coordinateX = 1;

            DrawUnit(mapActive, way, playerPosition);

            if (playerKey == ConsoleKey.W || playerKey == ConsoleKey.S)
                playerPosition[coordinateY] = newPlayerPosition[coordinateY];
            else if (playerKey == ConsoleKey.A || playerKey == ConsoleKey.D)
                playerPosition[coordinateX] = newPlayerPosition[coordinateX];

            DrawUnit(mapActive, player, playerPosition);

            return playerPosition;
        }

        static bool CanMove(char[,] mapActive, char wall, int[] playerPosition)
        {
            int coordinateY = 0;
            int coordinateX = 1;

            if (mapActive[playerPosition[coordinateY], playerPosition[coordinateX]] == wall)
                return false;

            return true;
        }
    }
}