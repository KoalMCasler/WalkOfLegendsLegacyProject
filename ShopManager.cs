using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkOfLegends
{
    internal class ShopManager
    {
        private Player player;

        private ConsoleKeyInfo shopInput;

        private ItemFreeze freeze;

        private Map map;

        private UI uI;

        public ShopManager(Player p, Map m, UI u)
        {
            player = p;
            map = m;
            uI = u;
        }
        /// <summary>
        /// Takes in seperate input from player movement to use shop function. 
        /// </summary>
        public void ShopInput()
        {
            shopInput = Console.ReadKey(true);
            switch(shopInput.Key)
            {
                case ConsoleKey.P:
                    UpPlayerDamage();
                    break;
                case ConsoleKey.H:
                    UpPlayerHealth();
                    break;
                case ConsoleKey.F:
                    BuyFreeze();
                    break;
                default:break;
            }
        }
        /// <summary>
        /// Used to inscrese player damage by set value found in settings. 
        /// </summary>
        void UpPlayerDamage()
        {
            if(player.coins >= Settings.shopDamageCost)
            {
                player.attack += Settings.shopDamageValue;
                player.coins -= Settings.shopDamageCost;
            }
        }
        /// <summary>
        /// Used to increase player health by set value found in settings. 
        /// </summary>
        void UpPlayerHealth()
        {
            if(player.coins >= Settings.shopHealthCost)
            {
                player.healthSystem.Heal(Settings.shopHealthValue);
                player.coins -= Settings.shopHealthCost;
            }
        }

        void BuyFreeze()
        {
            if(player.coins >= Settings.freezeCost)
            {
                player.coins -= Settings.freezeCost;
                freeze = new ItemFreeze(map,player,uI);
                freeze.DoYourJob();
                freeze = null;

            }
        }
    }
}
