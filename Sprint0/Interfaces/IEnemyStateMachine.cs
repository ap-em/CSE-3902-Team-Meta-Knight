using System;
using System.Collections.Generic;
using System.Text;

/*
 * Alexander Clayton CSE 3902 09/15/2021
 */
namespace Sprint0.Interfaces
{
    /*
     * This interface can be used for all blocks, which should just involve replacing the texture.
     */
   public interface IEnemyStateMachine
    {
        void Update();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void FireProjectile();
        void PrevEnemy();
        void NextEnemy();
    }
}
