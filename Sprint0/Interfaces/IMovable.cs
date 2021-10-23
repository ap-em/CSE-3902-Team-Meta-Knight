using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public interface IMovable
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; }
        public void Update();
        public bool GetGrounded();
        public void SetGrounded(bool grounded);
        public void Draw(SpriteBatch spritebatch);
    }
}
