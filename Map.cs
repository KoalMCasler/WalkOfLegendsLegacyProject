using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Reflection.Emit;
using System.Security.Policy;

namespace WalkOfLegends
{
    internal class Map
    {
        static string[] mapFile;
        static string[] shopFile;
        public char[,] map;
        public char[,] shopMap;
        public int cameraWidth = Settings.cameraWidth;
        public int cameraHeight = Settings.cameraHeight;
        public int width;
        public int height;
        private Player player;
        private ShopManager shopManager;
        private GameManager gameManager;
        
        public Map(Player p, GameManager gm)
        {
            player = p;
            gameManager = gm;
        }

        public void assignShopManager(ShopManager shop)
        {
            shopManager = shop;
        }

        public void Draw()
        {
            if(gameManager.isShopOpen)
            {
                DisplayShop();
                shopManager.ShopInput();
            }
            else
            {
                DisplayMap();
            }
        }

        public void StartMap()
        {
            mapFile = File.ReadAllLines(@"Map1.txt");

            shopFile = File.ReadAllLines(@"shopMap.txt");

            map = new char[mapFile.Length, mapFile[0].Length];
            shopMap = new char[shopFile.Length,shopFile[0].Length];

            width = map.GetLength(1);
            height = map.GetLength(0);

            if (cameraWidth > width)
            {
                cameraWidth = width;
            }
            if (cameraHeight > height)
            {
                cameraHeight = height;
            }

            MakeMap();
            MakeShop();

            map[player.posX, player.posY] = player.playerChar;

            Console.SetCursorPosition(0, 0);
            Console.Clear();
        }


        public void MakeMap()
        {
            for (int i = 0; i < mapFile.Length; i++)
            {
                for (int j = 0; j < mapFile[0].Length; j++)
                {
                    map[i, j] = mapFile[i][j];
                }
            }
        }

        public void MakeShop()
        {
            for (int i = 0; i < shopFile.Length; i++)
            {
                for (int j = 0; j < shopFile[0].Length; j++)
                {
                    shopMap[i, j] = shopFile[i][j];
                }
            }
        }




        /// <summary>
        /// Shoes shop menu when shop input is made
        /// </summary>
        public void DisplayShop()
        {
            Console.CursorVisible = false;

            ConsoleColor[,] colors = new ConsoleColor[cameraHeight, cameraWidth];
            char[,] tempMap = new char[cameraHeight, cameraWidth];

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("+");
            Console.WriteLine(new string('-', cameraWidth) + "+");

            for (int row = 0; row < cameraHeight; row++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");

                for (int col = 0; col < cameraWidth; col++)
                {
                    int mapRow = row;
                    int mapCol = col;

                    if (mapRow >= 0 && mapRow < height && mapCol >= 0 && mapCol < width)
                    {
                        tempMap[row, col] = shopMap[mapRow, mapCol];
                    }
                    else
                    {
                        tempMap[row, col] = '^';
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(tempMap[row, col]);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("+");
            Console.WriteLine(new string('-', cameraWidth) + "+");

        }

        /// <summary>
        /// Draws map, and creates a temporary, smaller map that displays based on the players position
        /// </summary>
        public void DisplayMap()
        {
            Console.CursorVisible = false;

            int startX = Math.Max(0, player.posX - cameraWidth / 2);
            int startY = Math.Max(0, player.posY - cameraHeight / 2);

            ConsoleColor[,] colors = new ConsoleColor[cameraHeight, cameraWidth];
            char[,] tempMap = new char[cameraHeight, cameraWidth];

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("+");
            Console.WriteLine(new string('-', cameraWidth) + "+");

            for (int row = 0; row < cameraHeight; row++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");

                for (int col = 0; col < cameraWidth; col++)
                {
                    int mapRow = startY + row;
                    int mapCol = startX + col;

                    if (mapRow >= 0 && mapRow < height && mapCol >= 0 && mapCol < width)
                    {
                        tempMap[row, col] = map[mapRow, mapCol];
                        colors[row, col] = GetTileColor(map[mapRow, mapCol]);
                    }
                    else
                    {
                        tempMap[row, col] = '^';
                        colors[row, col] = ConsoleColor.White;
                    }

                    Console.ForegroundColor = colors[row, col];
                    Console.Write(tempMap[row, col]);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("+");
            Console.WriteLine(new string('-', cameraWidth) + "+");

            //UI.ShowHUD();
        }

        public ConsoleColor GetTileColor(char tile)
        {
            switch (tile)
            {
                case '`': return ConsoleColor.Black;
                case '~': return ConsoleColor.Cyan;
                case 'P': return ConsoleColor.Blue;
                case '#': return ConsoleColor.Green;
                case 'G': return ConsoleColor.Yellow;
                case 'D': return ConsoleColor.Red;
                case '!': return ConsoleColor.DarkRed;
                case '$': return ConsoleColor.Gray;
                case '§': return ConsoleColor.Red;
                case '*': return ConsoleColor.Gray;
                case 'M': return ConsoleColor.Magenta;
                case '7': return ConsoleColor.White;
                case 'O': return ConsoleColor.DarkYellow;
                case '^': return ConsoleColor.DarkGray;
                case '@': return ConsoleColor.Blue;
                default: return ConsoleColor.White; 
            }
        }


    }
}
