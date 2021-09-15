using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface ISprite
    { 
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Update();
        void UpdateDirection(int direction);
    }
}
