using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    /*
     * A game object is defined as an object in the game that is moving, which will cause collisions.
     */
    public interface IGameObject
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; }
        public void Update();

        public void Draw(SpriteBatch spritebatch);
    }
}
