using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using Sprint0.Timers;
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
        private Texture2D background;
        private IGameObject gameObject;

        private SoundInfo soundInfo;
        
        public GameOverScreen(IGameObject go, IHUD HUD)
        {
            soundInfo = new SoundInfo();
            gameObject = go;
            font = Game0.Instance.Content.Load<SpriteFont>("Font");
            
            //reset after 5 seconds
            Timer resetTimer = new Timer(2000, ResetGame);
            resetTimer.StartTimer();

            background = Game0.Instance.Content.Load <Texture2D>("GameoverSMB");

        }

        public void Update()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch, ICamera camera)
        {
            soundInfo.StopLoopedSound(LevelFactory.Instance.currentSoundtrack); // this isn't stopping the background music for some reason? i think that StopLoopedSound() needs to be fixed as it's returning false here
            soundInfo.PlaySound("smb_gameover", false);
            spriteBatch.Draw(background, new Rectangle(0, 0, 6750, 600), Color.Black);
           spriteBatch.DrawString(font, "GAMEOVER ", new Vector2(camera.GetPosition().X + camera.GetViewport().Width/ 2, camera.GetPosition().Y + camera.GetViewport().Height / 2), Color.White);
        }
        public void ResetGame(Object source, System.Timers.ElapsedEventArgs e)
        {
            new CResetGame((IMario)gameObject).Execute();
        }
    }
}
