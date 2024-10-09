using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkOfLegends
{
    internal class UI
    {

        private Player player;
        private Map map;
        private EnemyManager enemyManager;
        private QuestManager questManager;
        public string breaker = "------------------------";
        public string healthStatus;
        public string lastItem;
        public Enemy enemy; 

        public UI(Player p, Map m, EnemyManager em, QuestManager qm)
        {
            player = p;
            map = m;
            enemyManager = em;
            questManager = qm;
        }


        public void LoadStartingScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{================================================================}");
            Console.WriteLine("{================================================================}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            Console.WriteLine("  ##     #     ##    #      ##      ##  ##        ####   ###### ");     
            Console.WriteLine("   ##   ###   ##    # #     ##      ####         ##  ##  ##     ");       
            Console.WriteLine("    ## ## ## ##    #####    ##      ##           ##  ##  ####   ");       
            Console.WriteLine("     ###   ###    ##   ##   ##      ####         ##  ##  ##     ");       
            Console.WriteLine("      #     #    ##     ##  ######  ##  ##        ####   ##     ");       
            Console.WriteLine();
            Console.WriteLine("      ##      ######  ######  ######  ###   ##  ####    ##### ");
            Console.WriteLine("      ##      ##      ##      ##      ## #  ##  ##  #  ##     ");
            Console.WriteLine("      ##      ####    ##  ##  ####    ## ## ##  ##  #   ####  ");
            Console.WriteLine("      ##      ##      ##   #  ##      ##  # ##  ##  #      ## ");
            Console.WriteLine("      ######  ######  ######  ######  ##   ###  ####   #####  ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{================================================================}");
            Console.WriteLine("{================================================================}");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" Reach the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("dragon");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" and destroy him");
            Console.WriteLine();
            Console.Write(" Defeat as many enemies as you can to build up your character and face off against the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("dragon");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Press any key to continue");

            Console.ReadKey();
            Console.Clear();
        }

        
        public void Draw()
        {
            if (player.healthSystem.health == Settings.playerHealth)
            { healthStatus = "Perfect Health"; }

            else if (player.healthSystem.health < Settings.playerHealth && player.healthSystem.health >= Settings.playerHealth*0.75f) // 3/4 of starting health
            { healthStatus = "Healthy"; }

            else if (player.healthSystem.health < Settings.playerHealth*0.75f && player.healthSystem.health >= Settings.playerHealth*0.5f) // 1/2 of starting health
            { healthStatus = "Hurt"; }

            else if (player.healthSystem.health < Settings.playerHealth*0.5f && player.healthSystem.health >= Settings.playerHealth*0.25f) // 1/4 of starting health
            { healthStatus = "Badly Hurt"; }

            else if (player.healthSystem.health < Settings.playerHealth*0.25f && player.healthSystem.health >= 1)
            { healthStatus = "Danger"; }
            else { healthStatus = "Dead"; }


            Console.SetCursorPosition(0, map.cameraHeight + 2);
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.SetCursorPosition(0, map.cameraHeight + 2);

            //Player Stats
            Console.ForegroundColor = ConsoleColor.Blue;  //Re wrote hud into string.formats for ease of use/reading. 
            Console.WriteLine(breaker);
            Console.WriteLine("Player Stats:");           
            Console.WriteLine(string.Format("Health: {0}",player.healthSystem.health));                      
            Console.WriteLine(string.Format("Money: {0}$",player.coins));                                                          
            Console.WriteLine(string.Format("Health Status: {0}",healthStatus));
            Console.WriteLine(string.Format("Attack Power: {0}", player.attack));
            Console.WriteLine(string.Format("last Item Aquired: {0}", lastItem));
            Console.WriteLine(breaker);
            ShowEnemyHUD(enemy);
            //Controls 
            Console.ForegroundColor = ConsoleColor.Red;
            int controlsStartPosY = 0;
            int controlsStartPosX = map.cameraWidth + 5;
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY);
            Console.WriteLine(breaker);
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 1);
            Console.WriteLine("Controls:");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 2);
            Console.WriteLine("W - Move Up");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 3);
            Console.WriteLine("S - Move Down");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 4);
            Console.WriteLine("A - Move Left");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 5);
            Console.WriteLine("D - Move Right");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 6);
            Console.WriteLine("R - Restart Game");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 7);
            Console.WriteLine("ESCAPE - Quit Game");
            Console.SetCursorPosition(controlsStartPosX, controlsStartPosY + 8);
            Console.WriteLine(breaker);

            //Draws QuestLog
            Console.ForegroundColor = ConsoleColor.Blue;
            int questLogStartPosY = map.cameraHeight-4;
            int questLogStartPosX = controlsStartPosX;
            Console.SetCursorPosition(questLogStartPosX, questLogStartPosY);
            Console.WriteLine(breaker);
            Console.SetCursorPosition(questLogStartPosX, questLogStartPosY + 1);
            Console.WriteLine("Quests:");
            Console.SetCursorPosition(questLogStartPosX, questLogStartPosY + 2);
            Console.WriteLine(string.Format("Q1: {0}",questManager.quest1));
            Console.SetCursorPosition(questLogStartPosX, questLogStartPosY + 3);
            Console.WriteLine(string.Format("Q2: {0}",questManager.quest2));
            Console.SetCursorPosition(questLogStartPosX, questLogStartPosY + 4);
            Console.WriteLine(string.Format("Q3: {0}",questManager.quest3));
            Console.SetCursorPosition(questLogStartPosX, questLogStartPosY + 5);
            Console.WriteLine(breaker);
            

            //Legend
            Console.ForegroundColor = ConsoleColor.White;
            int legendStartPosY = map.cameraHeight;
            int legendStartPosX = controlsStartPosX;
            Console.SetCursorPosition(legendStartPosX, legendStartPosY);
            Console.WriteLine(breaker);
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 1);
            Console.WriteLine("Legend:");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 2);
            Console.WriteLine(player.playerChar + " - Player");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 3);
            Console.WriteLine("^ - Mountains");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 4);
            Console.WriteLine("# - Trees");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 5);
            Console.WriteLine("~ - Water");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 6);
            Console.WriteLine("§ - Shop");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 7);
            Console.WriteLine("G - Goblin");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 8);
            Console.WriteLine("O - Orc");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 9);
            Console.WriteLine("{ - Minotaur");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 10);
            Console.WriteLine("D - Dragon");
            Console.SetCursorPosition(legendStartPosX, legendStartPosY + 11);
            Console.WriteLine(breaker);


            Console.CursorVisible = !true;
        }
        public void ShowEnemyHUD(Enemy ey)
        {

            if (ey != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Number of Enemies: " + Enemy.enemyCount);
                Console.WriteLine("");
                Console.WriteLine("Last enemy encountered: " + ey.name);
                Console.WriteLine("Health: " + ey.health + "/" + ey.maxHealth);
                Console.WriteLine("Attack power: " + ey.damage);
                Console.WriteLine(breaker);
                Console.WriteLine("");

            }
        }

        public void ShowWinScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{================================================================}");
            Console.WriteLine("{================================================================}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("");
            Console.WriteLine("  ##     #     ##    #      ##      ##  ##        ####   ###### ");     
            Console.WriteLine("   ##   ###   ##    # #     ##      ####         ##  ##  ##     ");       
            Console.WriteLine("    ## ## ## ##    #####    ##      ##           ##  ##  ####   ");       
            Console.WriteLine("     ###   ###    ##   ##   ##      ####         ##  ##  ##     ");       
            Console.WriteLine("      #     #    ##     ##  ######  ##  ##        ####   ##     ");       
            Console.WriteLine();
            Console.WriteLine("      ##      ######  ######  ######  ###   ##  ####    ##### ");
            Console.WriteLine("      ##      ##      ##      ##      ## #  ##  ##  #  ##     ");
            Console.WriteLine("      ##      ####    ##  ##  ####    ## ## ##  ##  #   ####  ");
            Console.WriteLine("      ##      ##      ##   #  ##      ##  # ##  ##  #      ## ");
            Console.WriteLine("      ######  ######  ######  ######  ##   ###  ####   #####  ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{================================================================}");
            Console.WriteLine("{================================================================}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("{================================================================}");
            Console.WriteLine(string.Format("You won with: \n{0}:Coins \n{1}:Health \n{2}:Remaining Enemies",player.coins,player.healthSystem.health,Enemy.enemyCount));
            Console.WriteLine("{================================================================}");
        }

        public void UpdateHUD(Enemy ey)
        {
            enemy = ey;
        }
    }
}
