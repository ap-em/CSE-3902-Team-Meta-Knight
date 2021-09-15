using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    class WalkSprite : ISprite
    {
        public Texture2D Texture;
        private int width = 16;
        private int height = 32;
        private int x = 150;
        private int y = 52;
        private int currentFrame;
        private int totalFrames;
        // wait some time between frames
        private int timeWaited = 0;
        private int waitTime = 5;
        private int horizontalDirection = 0;


        public WalkSprite(Texture2D texture)
        {
            Texture = texture;
            currentFrame = 0;
            totalFrames = 3;
        }
        public void FaceRight()
        {
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                x = 299;
            }
            else if (currentFrame == 1)
            {
                x = 239;
            }
            else if (currentFrame == 2)
            {
                x = 270;
            }
            timeWaited = 0;
        }
        public void FaceLeft()
        {
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                x = 90;
            }
            else if (currentFrame == 1)
            {
                x = 150;
            }
            else if (currentFrame == 2)
            {
                x = 120;
            }
            timeWaited = 0;
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
