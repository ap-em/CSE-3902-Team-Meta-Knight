using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    class EnemyHealthStateMachine
    {
        private int health;
        public EnemyHealthStateMachine(int health)
        {
            this.health = health;
        }

        public int GetHealth()
        {
            return health;
        }
        public void SetHealth(int health)
        {
            this.health = health;
        }
    }
}
