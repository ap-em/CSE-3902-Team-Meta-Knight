using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint0
{
    public class FrameCounter
    {
        public FrameCounter()
        {

        }

        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }
        public float AverageFramesPerSecond { get; private set; }
        public float CurrentFramesPerSecond { get; private set; }

        public const int MAXIMUM_SAMPLES = 100;

        private Queue<float> sampleBuffer = new Queue<float>();

        private SpriteFont font;

        public void LoadContent()
        {
            font = Game0.Instance.Content.Load<SpriteFont>("Font");
        }

        public void Draw(SpriteBatch spritebatch, ICamera camera)
        {
            var fps = string.Format("FPS: {0}", (int)AverageFramesPerSecond);
            spritebatch.DrawString(font, fps, new Vector2(camera.GetPosition().X + camera.GetViewport().Width / 4, camera.GetPosition().Y), Color.Black);
        }
        public void Update(float deltaTime)
        {
            CurrentFramesPerSecond = 1.0f / deltaTime;

            sampleBuffer.Enqueue(CurrentFramesPerSecond);

            if (sampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                sampleBuffer.Dequeue();
                AverageFramesPerSecond = sampleBuffer.Average(i => i);
            }
            else
            {
                AverageFramesPerSecond = CurrentFramesPerSecond;
            }

            TotalFrames++;
            TotalSeconds += deltaTime;

        }
    }
}
