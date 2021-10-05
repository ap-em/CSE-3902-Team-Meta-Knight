using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Commands
{
    class CEnemyAttack : ICommand
    {
        private IEnemy enemy;
        public CEnemyAttack(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.FireProjectile();
            enemy.SetStateMachineSprite();
        }
    }
}
