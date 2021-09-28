using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Interfaces
{
    public interface IEnemy
    {
        // We do not need an IEnemyState since the player does not control enemies.
        void Update();
        void Move(int x, int y);
        void SetDirection(String direction);
        void SetStateMachineSprite();
        void FireProjectile();
        void SetXVelocity(int x);
        void SetYVelocity(int y);
        void NextEnemy();
        void PrevEnemy();
        void Draw();
    }
}
