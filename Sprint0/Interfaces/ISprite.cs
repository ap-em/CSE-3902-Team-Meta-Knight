using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    public interface ISprite
    {
        // Outdated and only keeping here as a reference
        void Update();
        void Draw(SpriteBatch spritebatch, Vector2 location);
    }
}
