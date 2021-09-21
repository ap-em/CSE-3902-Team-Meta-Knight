using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Interfaces.Enemy
{
    public interface IEnemy
    {
        // We do not need an IEnemyState since the player does not control enemies.
        void ChangeDirection();
        void Update();
        void TakeDamage();
        void Draw(SpriteBatch spritebatch, Vector2 location);
    }
}
