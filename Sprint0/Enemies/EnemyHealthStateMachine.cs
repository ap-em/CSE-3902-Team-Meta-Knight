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
        private SoundInfo soundInfo;
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
            soundInfo = new SoundInfo();
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
                    /*
                    * This means we should have an enemy heath state machine interface with seperate machines for each enemy type
                    * Will do later!
                     */
                    switch (enemy.enemyType)
                    {
                        case "Koopa":
                            soundInfo.PlaySound("koopadeath", false);
                            break;
                        case "Goomba":
                            soundInfo.PlaySound("goombadeath", false);
                            break;
                        default:
                            break;
                    }
                    break;
                case enemyHealth.dead:
                    //No 
                    break;
                default:
                    break;
            }
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
