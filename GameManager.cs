using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalkOfLegends
{
    internal class GameManager
    {

        public static Map map;
        public static Player player;
        public static EnemyManager enemyManager;
        public static ItemManager itemManager;
        public static UI ui;
        private QuestManager questManager;
        private ShopManager shopManager;
        public static bool gameOver;
        public bool isShopOpen;

        public void Play()
        {
            //Init
            player = new Player(this);
            map = new Map(player,this);
            enemyManager = new EnemyManager(player, map);
            gameOver = false;
            map.StartMap();
            questManager = new QuestManager(player);
            ui = new UI(player, map, enemyManager, questManager);
            ui.LoadStartingScreen();
            itemManager = new ItemManager(player, map, ui);
            player.SetStuff(map, enemyManager, ui, itemManager);
            shopManager = new ShopManager(player, map, ui);
            map.assignShopManager(shopManager);
            map.DisplayMap();
            isShopOpen = false;

            enemyManager.PlaceGoblins(10);
            enemyManager.PlaceOrcs(30);
            enemyManager.PlaceMinotaurs(7);
            enemyManager.PlaceDragons(1);

            itemManager.PlaceInvincibility(10);
            //itemManager.PlaceFreeze(10);


            while (gameOver == false)
            {
                if (player.healthSystem.health <= 0)
                {
                    gameOver = true;
                }

                //Update
                GetInput();
                itemManager.UpdateItems();
                player.Update(input);
                player.CheckForShop(); // will not function anywhare else. 
                questManager.Update();
                enemyManager.UpdateEnemies();
                //Draw
                itemManager.DrawItems();
                enemyManager.DrawEnemies();
                player.Draw();
                map.Draw();
                ui.Draw();
            }
            if (gameOver == true && !player.hasKilledDragon)
            {
                Console.Clear();
                Console.WriteLine("Game Over, try again");
            }
            else if(gameOver == true && player.hasKilledDragon)
            {
                Console.Clear();
                ui.ShowWinScreen();
                Console.ReadKey(true);
            }

        }

        public void GetInput()
        {
            input = Console.ReadKey(true);
        }

        private ConsoleKeyInfo input;
    }

}
