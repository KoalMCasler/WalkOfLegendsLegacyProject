using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;


namespace FirstPlayable_CalebWolthers_22012024
{

    internal abstract class Enemy
    {
        public char Char;
        public int health;
        public int maxHealth;
        public int damage;
        public string dir;
        public string name;
        public int posX;
        public int posY;
        protected bool isDead;
        public static int enemyCount;
        private Map map;
        private Player player;
        public HealthSystem healthSystem;

        public Enemy(Map map, Player player)
        {
            this.map = map;
            this.player = player;
            healthSystem = new HealthSystem(health);
        }

        public abstract void Update();

        public abstract void Draw();
    }
}
