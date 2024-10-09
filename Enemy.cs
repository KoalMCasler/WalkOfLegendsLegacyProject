using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;


namespace WalkOfLegends
{

    internal abstract class Enemy
    {
        public char Char;
        public float health;
        public int maxHealth;
        public int damage;
        public string dir;
        public string name;
        public int posX;
        public int posY;
        protected bool isDead;
        public static int enemyCount;
        public Map map;
        public Player player;
        public HealthSystem healthSystem;

        public Enemy()
        {
            //this.map = map; removed this as it is unessicary for enemies.
            //this.player = player;
            healthSystem = new HealthSystem(health);
        }

        public abstract void Update();

        public abstract void Draw();
    }
}
