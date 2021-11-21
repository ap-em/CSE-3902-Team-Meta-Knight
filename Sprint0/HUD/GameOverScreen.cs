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
        private IGameObject gameObject;
        public GameOverScreen(IGameObject go, IHUD HUD)
        {
            gameObject = go;
            font = Game0.Instance.Content.Load<SpriteFont>("Font");

            //reset after 5 seconds
            Timer resetTimer = new Timer(2000, ResetGame);
            resetTimer.StartTimer();
        }

        public void Update()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch, ICamera camera)
        {
           spriteBatch.DrawString(font, "GAMEOVER: ", new Vector2(camera.GetPosition().X + camera.GetViewport().Width/ 2, camera.GetPosition().Y + camera.GetViewport().Height / 2), Color.White);
        }
        public void ResetGame(Object source, System.Timers.ElapsedEventArgs e)
        {
            new CResetGame((IMario)gameObject).Execute();
        }
    }
}
