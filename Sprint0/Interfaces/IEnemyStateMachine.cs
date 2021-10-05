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
        void FireProjectile();
        void SetSprite();
    }
}
