using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    class IdleSprite : ISprite
    {
        public Texture2D Texture;
        private int horizontalDirection = 0;
        private int x = 180;
        private int y = 52;
        private int width = 16;
        private int height = 32;

        public IdleSprite(Texture2D texture)
        {
            Texture = texture;
        }
        public void UpdateDirection(int direction)
        {
            horizontalDirection = direction;
        }
        public void Update()
        {
            if (horizontalDirection > 0) x = 209;
            else x = 180;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            Rectangle sourceRectangle = new Rectangle(x,y,width,height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width,height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
