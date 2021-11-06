using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Interfaces
{
    public interface IEnemy
    {

        void Update();
        void FireProjectile();
        void SetSprite(String spriteName);
        String GetSpriteName();
        void MoveRight();
        void MoveLeft();
        void SetXVelocity(float x);
        void SetYVelocity(float y);
        void Draw(SpriteBatch spriteBatch);
        void TakeDamage();
        String GetHealth();
    }
}
