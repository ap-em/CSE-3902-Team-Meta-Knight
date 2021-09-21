using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Alex Clayton 09/15/21
namespace Sprint0.Interfaces.Player
{
    public interface ILinkState
    {
        // Interface for Link's sprite state
        void ChangeDirection();
        void Update();
        void TakeDamage(); // This would update Link's state since his sword beam depends on being full health
        void Draw(SpriteBatch spritebatch, Vector2 location);
    }
}
