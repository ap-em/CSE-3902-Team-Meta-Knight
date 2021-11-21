using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using Sprint0.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Sprint0.HUD
{
    public class GameOverScreen: IHUDState
    {
        private SpriteFont font;
        private Texture2D background;
        private IGameObject gameObject;
        private IHUD HUD;
        private double gameOverTime = 0;
        private SoundInfo soundInfo;
        public GameOverScreen(IGameObject go, IHUD HUD)
        {
            soundInfo = new SoundInfo();
            gameObject = go;
            this.HUD = HUD;
            font = Game0.Instance.Content.Load<SpriteFont>("Font");
            background = Game0.Instance.Content.Load <Texture2D>("GameoverSMB");

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
            soundInfo.StopLoopedSound(LevelFactory.Instance.currentSoundtrack); // this isn't stopping the background music for some reason? i think that StopLoopedSound() needs to be fixed as it's returning false here
            soundInfo.PlaySound("smb_gameover", false);
            spriteBatch.Draw(background, new Rectangle(0, 0, 6750, 600), Color.Black);
           spriteBatch.DrawString(font, "GAMEOVER ", new Vector2(camera.GetPosition().X + camera.GetViewport().Width/ 2, camera.GetPosition().Y + camera.GetViewport().Height / 2), Color.White);
        }
    }
}
