using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    class EnemyHealthStateMachine
    {
        private enum enemyHealth { full, half, dead};
        private enemyHealth health;
        private Enemy enemy;
        public EnemyHealthStateMachine(Enemy enemyRef)
        {
            enemy = enemyRef;
            health = enemyHealth.half;
            if (enemy.enemyType == "Goomba")
            {
                health = enemyHealth.half;
            }
            else if(enemy.enemyType == "Koopa")
            {
                health = enemyHealth.full;
            }
        }
        public void TakeDamage()
        {
            switch (health)
            {
                case enemyHealth.full:
                    health = enemyHealth.half;
                    break;
                case enemyHealth.half:
                    health = enemyHealth.dead;
                    enemy.objectRemovalTimer = 8;
                    break;
                case enemyHealth.dead:
                    //No 
                    break;
                default:
                    break;
            }
            enemy.SetSprite(enemy.enemyType);
        }
        public String GetHealth()
        {
            switch (health)
            {
                case enemyHealth.full:
                    return "Full";
                case enemyHealth.half:
                    return "Half";
                case enemyHealth.dead:
                    return "Dead";
                default:
                    return "Full";
            }
        }
    }
}
