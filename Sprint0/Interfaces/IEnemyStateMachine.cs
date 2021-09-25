using System;
using System.Collections.Generic;
using System.Text;

/*
 * Alexander Clayton CSE 3902 09/15/2021
 */
namespace Sprint0.Interfaces
{
   public interface IEnemyStateMachine
    {
        void Update();
        void PrevEnemy();
        void NextEnemy();
        void SetFireProjectileSprite();
        void SetSprite();
    }
}
