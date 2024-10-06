using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkOfLegends;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class ShopManager
    {
        private Player player;

        private ConsoleKeyInfo shopInput;

        public ShopManager(Player p)
        {
            player = p;
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
    }
}
