using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Alex Clayton 09/15/21
namespace Sprint0.Interfaces.Player
{
    public interface ILink
    {
        // Interface for items that link has such as his Sword, arrows, boomerang, bombs, blue candle, etc.
        // These would be like commands in a way, since having it seleceted and pressing A, for example, would cause Link to attack with his sword, executing the sword attack.
        void Update();
        void Execute();
        void Draw(SpriteBatch spritebatch, Vector2 location);
    }
}
