﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkOfLegends
{

    internal class EnemyGoblin : Enemy
    {
        private int nextPosX;
        private int nextPosY;
        private int lastPosX;
        private int lastPosY;
        //private Player player;
        //private Map map; All removed as not neaded, all covered by derived class.
        //public HealthSystem healthSystem;

        public EnemyGoblin(Map gameMap, Player activePlayer)
        {
            map = gameMap;
            player = activePlayer;
            maxHealth = Settings.goblinHealth;
            health = maxHealth;
            name = Settings.goblinName;
            Char = Settings.goblinChar;
            damage = Settings.goblinDamage;
            enemyCount += 1;//fixes enemy count on HUD.
            dir = "down";
            isDead = false;
            //healthSystem = new HealthSystem(health);
        }


        public override void Update()
        {
            if (Char != '`')
            {
                //Up
                if (dir == "up")
                {
                    Move(0, -1, "down");
                }
                //Down
                else if (dir == "down")
                {
                    Move(0, 1, "up");
                }
            }
        }

        public override void Draw()
        {
            map.map[lastPosY, lastPosX] = '`';
            map.map[posY, posX] = Char;
        }


        public void Move(int nextX, int nextY, string nextDir)
        {
            nextPosX = posX + nextX;
            nextPosY = posY + nextY;
            bool isWithinBounds = nextPosX >= 0 && nextPosX < map.width && nextPosY >= 0 && nextPosY < map.height;
            lastPosY = posY;
            lastPosX = posX;

            if (isWithinBounds)
            {
                if (health >  0)
                {
                    //Colides with player 
                    if (nextPosX == player.posX && nextPosY == player.posY)
                    {
                        player.healthSystem.TakeDamage(damage);
                        nextPosY = lastPosY;
                        nextPosX = lastPosX;
                    }
                    else if (map.map[nextPosY, nextPosX] == '`')
                    {
                        posX = nextPosX;
                        posY = nextPosY;
                    }
                    else
                    {
                        nextPosY = lastPosY;
                        nextPosX = lastPosX;
                        dir = nextDir; 
                    }
                }
                else 
                {
                    Die();
                }
            }
        }

        public void Die()
        {
            if (isDead == false)
            {
                player.coins += damage;
                player.killCount += 1;
            }
            health = 0;
            map.map[posY, posX] = '`';
            Char = '`';
            map.DisplayMap();
            isDead = true;
            enemyCount -= 1;//fixes enemy count on HUD.
            //enemyCount--;
        }


    }
}
/*

        public EnemyGoblin()
        {
            enemyName = Settings.goblinName;
            enemyChar = Settings.goblinChar;
            enemyHealth = Settings.goblinHealth;
            enemyDamage = Settings.goblinDamage;
            enemyDir = Settings.goblinDir;

            enemyMinX = Settings.goblinMinX;
            enemyMaxX = Settings.goblinMaxX;
            enemyMinY = Settings.goblinMinY;
            enemyMaxY = Settings.goblinMaxY;
        }


        //Bounces vertically
        public override void Update(Enemy ey)
        {
            if (ey.enemyChar != '`')
            {
                //Up
                if (ey.enemyDir == "up")
                {
                    EnemyMove(ey, 0, -1, "down");
                }
                //Down
                else if (ey.enemyDir == "down")
                {
                    EnemyMove(ey, 0, 1, "up");
                }
            }
        }



    }
    
} 
*/