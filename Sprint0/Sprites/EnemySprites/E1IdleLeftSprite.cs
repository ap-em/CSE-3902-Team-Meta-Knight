using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Sprites.EnemySprites
{
    class E1IdleLeftSprite : ISprite
    {
        private Texture2D Texture;
        private int currentFrame;
        private int totalFrames;
        private int x=30, y=0;
        private int timeWaited = 0;

        public E1IdleLeftSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            currentFrame = 1;
            totalFrames = rows * columns;
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            int width = 16;
            int height = 16;

            Rectangle sourceRectangle = new Rectangle(x, y, width, height);  // Source rectangle is the sprite taken off the sprite sheet
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height); // Destnation rectangle is where you want to put the sprite.

            spritebatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            if ((currentFrame != totalFrames) && timeWaited % 10 ==0)
            {
                timeWaited = 0;
                currentFrame++;
                y += 30;
            }
            else
            {
                if (timeWaited % 10 == 0)
                {
                    timeWaited = 0;
                    currentFrame = 1;
                    y = 0;
                }
            }
            timeWaited++;
        }
    }
}
