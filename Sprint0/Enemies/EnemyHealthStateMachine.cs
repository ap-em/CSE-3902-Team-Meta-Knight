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
            health = enemyHealth.half;
            enemy = enemyRef;
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
                    GameObjectManager.Instance.RemoveFromObjectList(enemy);
                    
                    break;
                case enemyHealth.dead:
                    //No 
                    break;
                default:
                    break;
            }
        }
    }
}
