using System;

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

            ConsoleKeyInfo keyUp = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);
            ConsoleKeyInfo keyDown = new ConsoleKeyInfo('s', ConsoleKey.S, false, false, false);
            ConsoleKeyInfo keyLeft = new ConsoleKeyInfo('a', ConsoleKey.A, false, false, false);
            ConsoleKeyInfo keyRight = new ConsoleKeyInfo('d', ConsoleKey.D, false, false, false);

            mapSize = map.Length;
            playerPosition = GetPositionToSpawnPlayer(map, wall);
            Array.Copy(map, mapActive, mapSize);

            while (true)
            {
                Console.Clear();

                ShowPlayer(mapActive, player, playerPosition);
                ShowMap(mapActive);

                ConsoleKeyInfo playerKey = Console.ReadKey();

                playerPosition = PlayerMove(mapActive, wall, playerPosition, playerKey, keyUp, keyDown, keyLeft, keyRight);

                Array.Copy(map, mapActive, mapSize);
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

        static void ShowPlayer(char[,] mapActive, char player, int[] playerPosition)
        {
            mapActive[playerPosition[0],playerPosition[1]] = player;
        }

        static int[] PlayerMove(char[,] mapActive, char wall, int[] playerPosition, ConsoleKeyInfo playerKey, ConsoleKeyInfo keyUp, ConsoleKeyInfo keyDown, ConsoleKeyInfo keyRight, ConsoleKeyInfo keyLeft)
        {
            bool barrierIsAbsent;
            int[] newPlayerPosition = new int[2];
            Array.Copy(playerPosition, newPlayerPosition, 2);

            if (playerKey == keyUp) 
                newPlayerPosition[0] = playerPosition[0] - 1;
            else if (playerKey == keyDown)
                newPlayerPosition[0] = playerPosition[0] + 1;
            else if (playerKey == keyLeft)
                newPlayerPosition[1] = playerPosition[1] + 1;
            else if (playerKey == keyRight)
                newPlayerPosition[1] = playerPosition[1] - 1;

            barrierIsAbsent = WallCheck(mapActive, wall, newPlayerPosition);

            if (barrierIsAbsent)
            {
                playerPosition[0] = newPlayerPosition[0];
                playerPosition[1] = newPlayerPosition[1];
            }

            return playerPosition;
        }

        static bool WallCheck (char[,] mapActive, char wall, int[] playerPosition)
        {
            if (mapActive[playerPosition[0], playerPosition[1]] == wall)
                return false;

            return true;
        }
        
    }
}