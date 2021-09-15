using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    class CrouchSprite : ISprite
    {
        public Texture2D Texture;
        private int width = 16;
        private int height = 32;
        private int x = 0;
        private int y = 47;
        private int currentFrame;
        private int totalFrames;
        private int timeWaited = 0;
        private int waitTime = 10;
        private int horizontalDirection = 0;

        public CrouchSprite(Texture2D texture)
        {
            Texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void FaceRight()
        {
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                x = 209;
                y = 52;
            }
            else
            {
                x = 389;
                y = 47;
            }
        }
        public void FaceLeft()
        {
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                x = 180;
                y = 52;
            }
            else
            {
                x = 0;
                y = 47;
            }
        }
        public void UpdateDirection(int direction)
        {
            horizontalDirection = direction;
        }
        public void Update()
        {
            if (timeWaited > waitTime || timeWaited == 0)
            {
                currentFrame++;
                if (horizontalDirection > 0) FaceRight();
                else FaceLeft();
                timeWaited = 0;
            }
            timeWaited++;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(x, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
