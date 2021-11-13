using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class PauseScreen
    {
        public bool isPaused;
        private SpriteFont font;
        public PauseScreen()
        {
            isPaused = false;
            font = Game0.Instance.Content.Load<SpriteFont>("Font");
            
        }
        public void Draw(SpriteBatch spriteBatch,ICamera camera)
        {
            if (isPaused)
            {
                spriteBatch.DrawString(font, "GAME PAUSED", new Vector2(camera.GetPosition().X+(camera.GetViewport().Width / 2)-(font.MeasureString("GAME PAUSED").X/2), (camera.GetViewport().Height/2)),Color.White);
            }

        }
        public void TogglePause()
        {
            isPaused = !isPaused;
            SoundManager.Instance.TogglePauseAllSounds();
        }
    }
}
