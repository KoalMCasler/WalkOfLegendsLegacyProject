using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkOfLegends
{
    internal class HealthSystem
    {


        public float health;

        public HealthSystem(float health)
        {
            this.health = health;
        }

        public void TakeDamage(int hit)
        {
            health -= hit;
        }

        public void Heal(int heal)
        {
            health += heal;
        }



    }
}
