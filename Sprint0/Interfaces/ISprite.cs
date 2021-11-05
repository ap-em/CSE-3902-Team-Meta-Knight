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
namespace Sprint0
{
    public interface ISprite
    {
        // Outdated and only keeping here as a reference
        public int width { get; }
        public int height { get; }

        void Update();
        void Draw(SpriteBatch spritebatch, Vector2 location);
    }
}
