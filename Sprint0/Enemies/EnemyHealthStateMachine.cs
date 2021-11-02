using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    class EnemyHealthStateMachine
    {
        private enum enemyHealth { alive, dead};
        private enemyHealth health;
        private Enemy enemy;
        public EnemyHealthStateMachine(Enemy enemyRef)
        {
            health = enemyHealth.alive;
            enemy = enemyRef;
        }
        public void TakeDamage()
        {
            switch (health)
            {
                case enemyHealth.alive:
                    health = enemyHealth.dead;
                    /*
                     * What functions need to be called here to kill the enemy?
                     */
                    break;
                case enemyHealth.dead:
                    //No op
                    break;
                default:
                    break;
            }
        }
    }
}
