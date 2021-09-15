using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    class JumpSprite : ISprite
    {

        public Texture2D Texture;
        private int x = 359, y = 52, width = 16, height = 32;
        private int horizontalDirection = 0;

        public JumpSprite(Texture2D texture)
        {
            Texture = texture;
        }
        public void UpdateDirection(int direction)
        {
            horizontalDirection = direction;
        }
        public void Update()
        {
            if (horizontalDirection > 0) x = 359;
            else x = 30;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            Rectangle sourceRectangle = new Rectangle(x, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
