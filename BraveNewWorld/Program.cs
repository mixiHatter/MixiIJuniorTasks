using System;

namespace BraveNewWorld
{
    internal class Program
    {
        static int coordinateY = 0;
        static int coordinateX = 1;

        static void Main(string[] args)
        {
            char[,] staticMap = new char[,] {
                                      { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                                      { '#', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#'},
                                      { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#'},
                                      { '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', 'X', '#'},
                                      { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}};

            int[] playerCoordinates = {0, 0};
            bool isPlaying = true;
            char wall = '#';
            char player = '@';
            char exit = 'X';

            playerCoordinates = GetPositionToSpawnPlayer(staticMap, wall);

            while (isPlaying)
            {
                GenerationActiveMap(staticMap, out char[,] dynamicMap);
                Event(staticMap, playerCoordinates, exit, ref isPlaying);

                Console.Clear();
                
                DrawPlayer(dynamicMap, playerCoordinates, player);
                DrawMap(dynamicMap);

                playerCoordinates = PlayerPressedKey(staticMap, playerCoordinates, wall, exit, Console.ReadKey(), ref isPlaying);
            }
        }

        static void GenerationActiveMap(char[,] map, out char[,] newMap)
        {
            char[,] generationMap = new char[map.GetLength(coordinateY), map.GetLength(coordinateX)];
            Array.Copy(map, generationMap, map.Length);

            newMap = generationMap;
        }

        static int[] GetPositionToSpawnPlayer(char[,] mapActive, char wall)
        {
            bool playerIsSpawn = false;
            int[] playerPosition = new int[2];

            if (playerIsSpawn == false)
            {
                for (int i = 0; i < mapActive.GetLength(coordinateX); i++)
                {
                    for (int j = 0; j < mapActive.GetLength(coordinateY); j++)
                    {
                        if (mapActive[i, j] != wall && playerIsSpawn == false)
                        {
                            playerPosition[coordinateY] = i;
                            playerPosition[coordinateX] = j;

                            playerIsSpawn = true;
                        }
                    }
                }
            }

            return playerPosition;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(coordinateX); i++)
            {
                for (int j = 0; j < map.GetLength(coordinateY); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void DrawPlayer(char[,] map, int[] coordinates, char player)
        {
            map[coordinates[coordinateY], coordinates[coordinateX]] = player;
        }

        static bool CanMove(char[,] map, char wall, int[] playerCoordinates)
        {
            bool can = false;

            if (map[playerCoordinates[coordinateY], playerCoordinates[coordinateX]] != wall)
                can = true;
            return can;
        }

        static int[] PlayerPressedKey(char[,] map, int[] playerCoordinates, char wall, char exit, ConsoleKeyInfo playerKey, ref bool isPlaying)
        {
            const ConsoleKey CommandKeyUp = ConsoleKey.W;
            const ConsoleKey CommandKeyDown = ConsoleKey.S;
            const ConsoleKey CommandKeyLeft = ConsoleKey.A;
            const ConsoleKey CommandKeyRight = ConsoleKey.D;
            const ConsoleKey CommandKeyEscape = ConsoleKey.Escape;

            int[] nextPlayerCoordinates = new int[2];
            Array.Copy(playerCoordinates, nextPlayerCoordinates, playerCoordinates.Length);

            int step = 1;

            switch (playerKey.Key)
            {
                case CommandKeyUp:
                    nextPlayerCoordinates[coordinateY] = nextPlayerCoordinates[coordinateY] - step;
                    break;

                case CommandKeyDown:
                    nextPlayerCoordinates[coordinateY] = nextPlayerCoordinates[coordinateY] + step;
                    break;

                case CommandKeyLeft:
                    nextPlayerCoordinates[coordinateX] = nextPlayerCoordinates[coordinateX] - step;
                    break;

                case CommandKeyRight:
                    nextPlayerCoordinates[coordinateX] = nextPlayerCoordinates[coordinateX] + step;
                    break;

                case CommandKeyEscape:
                    isPlaying = false;
                    break;
            }

            if (CanMove(map, wall, nextPlayerCoordinates) == true)
                playerCoordinates = nextPlayerCoordinates;

            return playerCoordinates;
        }

        static void Event (char[,] map, int[] playerCoordinates, char exit, ref bool isPlaying)
        {
            if (map[playerCoordinates[coordinateY], playerCoordinates[coordinateX]] == exit)
            {
                Console.Clear();
                Console.WriteLine("Map completed!");
                isPlaying = false;
                Console.ReadKey();
            }
        }
    }
}