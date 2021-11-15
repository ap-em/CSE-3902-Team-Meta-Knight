using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using Sprint0.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.HUD
{
    public class GameOverScreen: IHUDState
    {
        private SpriteFont font;
        private IGameObject gameObject;
        private IHUD HUD;
        private double gameOverTime = 0;
        public GameOverScreen(IGameObject go, IHUD HUD)
        {
            gameObject = go;
            this.HUD = HUD;
            font = Game0.Instance.Content.Load<SpriteFont>("Font");
        }

        public void Update()
        {
            // wait a few seconds then reset game
            gameOverTime += Game0.Instance.TargetElapsedTime.TotalSeconds;
            if (gameOverTime >= GameUtilities.gameOverTimerFinish)
            {
                gameOverTime = 0;
                new CResetGame((IMario)gameObject).Execute();
            }    
        }
        public void Draw(SpriteBatch spriteBatch, ICamera camera)
        {
           spriteBatch.DrawString(font, "GAMEOVER: ", new Vector2(camera.GetPosition().X + camera.GetViewport().Width/ 2, camera.GetPosition().Y + camera.GetViewport().Height / 2), Color.White);
        }
    }
}
