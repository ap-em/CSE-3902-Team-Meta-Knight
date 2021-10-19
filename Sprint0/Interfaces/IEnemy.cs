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
        void MoveUp();
        void MoveDown();
        void SetXVelocity(int x);
        void SetYVelocity(int y);
        void NextSprite();
        void PrevSprite();
        void Draw(SpriteBatch spriteBatch);
    }
}
