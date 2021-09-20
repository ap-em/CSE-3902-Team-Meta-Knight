using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Interfaces.Player
{
    public interface IPlayer
    {
        // This will control the player
        void Update();
        void Draw(SpriteBatch spritebatch, Vector2 location); // idk if we still need this yet
    }
}
