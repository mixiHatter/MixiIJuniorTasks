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
            char player = '@';
            char wall = '#';
            int[] playerPosition;

            mapSize = map.Length;
            playerPosition = GetPositionToSpawnPlayer(map, wall);
            Array.Copy(map, mapActive, mapSize);

            while (true)
            {
                Console.Clear();

                DrawUnit(mapActive, player, playerPosition);
                ShowMap(mapActive);

                ConsoleKeyInfo playerKey = Console.ReadKey();

                playerPosition = PlayerMoveCheck(playerKey, mapActive, wall, playerPosition);
            }
        }

        static void ShowMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }
        }

        static int[] GetPositionToSpawnPlayer(char[,] mapActive, char wall)
        {
            bool playerIsSpawn = false;
            int[] playerPosition = new int[2];

            for (int i = 0; i < mapActive.GetLength(1); i++)
            {
                for (int j = 0; j < mapActive.GetLength(0); j++)
                {
                    if (mapActive[i,j] != wall && playerIsSpawn == false)
                    {
                        playerPosition[0] = i;
                        playerPosition[1] = j;

                        playerIsSpawn = true;
                    }
                }
            }

            return playerPosition;
        }

        static void DrawUnit(char[,] mapActive, char newUnit, int[] playerPosition)
        {
            mapActive[playerPosition[0],playerPosition[1]] = newUnit;
        }

        static int[] PlayerMoveCheck(ConsoleKeyInfo playerKey, char[,] mapActive, char wall, int[] playerPosition)
        {
            ConsoleKeyInfo keyUp = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);
            ConsoleKeyInfo keyDown = new ConsoleKeyInfo('s', ConsoleKey.S, false, false, false);
            ConsoleKeyInfo keyLeft = new ConsoleKeyInfo('a', ConsoleKey.A, false, false, false);
            ConsoleKeyInfo keyRight = new ConsoleKeyInfo('d', ConsoleKey.D, false, false, false);

            int[] newPlayerPosition = new int[2];
            Array.Copy(playerPosition, newPlayerPosition, 2);

            switch (playerKey.Key)
            {
                case ConsoleKey.W:
                    newPlayerPosition[0] = playerPosition[0] - 1;

                    if (isPassagewayAvailible(mapActive, wall, newPlayerPosition))
                        PlayerMove(mapActive, playerPosition, newPlayerPosition, playerKey.Key);
                    break; 

                case ConsoleKey.S:
                    newPlayerPosition[0] = playerPosition[0] + 1;

                    if (isPassagewayAvailible(mapActive, wall, newPlayerPosition))
                        PlayerMove(mapActive, playerPosition, newPlayerPosition, playerKey.Key);
                    break;

                case ConsoleKey.A:
                    newPlayerPosition[1] = playerPosition[1] - 1;

                    if (isPassagewayAvailible(mapActive, wall, newPlayerPosition))
                        PlayerMove(mapActive, playerPosition, newPlayerPosition, playerKey.Key);
                    break;

                case ConsoleKey.D:
                    newPlayerPosition[1] = playerPosition[1] + 1;

                    if (isPassagewayAvailible(mapActive, wall, newPlayerPosition))
                        PlayerMove(mapActive, playerPosition, newPlayerPosition, playerKey.Key);
                    break;

                default:
                    break;
            }

            return playerPosition;
        }

        static int[] PlayerMove(char[,] mapActive, int[] playerPosition, int[] newPlayerPosition, ConsoleKey playerKey)
        {
            DrawUnit(mapActive, ' ', playerPosition);

            switch (Convert.ToChar(playerKey))
            {
                case 'W':
                    playerPosition[0] = newPlayerPosition[0];
                    break;

                case 'S':
                    playerPosition[0] = newPlayerPosition[0];
                    break;

                case 'A':
                    playerPosition[1] = newPlayerPosition[1];
                    break;

                case 'D':
                    playerPosition[1] = newPlayerPosition[1];
                    break;
            }

            return playerPosition;
        }

        static bool isPassagewayAvailible (char[,] mapActive, char wall, int[] playerPosition)
        {
            if (mapActive[playerPosition[0], playerPosition[1]] == wall)
                return false;

            return true;
        }
        
    }
}