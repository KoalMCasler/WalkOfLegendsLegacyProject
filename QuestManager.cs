using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WalkOfLegends;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class QuestManager
    {
        private Player player;

        public string quest1; 

        public string quest2;

        public string quest3;

        private string completedText;

        public QuestManager(Player p)
        {
            player = p;
            quest1 = "Kill 10 enemies!";
            quest2 = "Hold 250$ at one time.";
            quest3 = "Kill the Dragon!";
            completedText = "Completed!                    "; // Extra space used to clear old text for each area. 
        }

        public void Update()
        {
            UpdateQuests();
        }

        void UpdateQuests()
        {
            if(player.killCount >= 10)
            {
                quest1 = completedText;
            }
            if(player.coins >= 250)
            {
                quest2 = completedText;
            }
            if(player.hasKilledDragon)
            {
                quest3 = completedText;
            }
        }
    }
}
