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
    public class DefaultHUD: IHUDState
    {
        private SpriteFont font;
        private IGameObject gameObject;
        private IHUD HUD;
        public DefaultHUD(IGameObject go, IHUD HUD)
        {
            gameObject = go;
            this.HUD = HUD;
            font = Game0.Instance.Content.Load<SpriteFont>("Font");
        }

        public void Update()
        {
            HUD.SetTimeLeft(HUD.GetTimeLeft() - (float)Game0.Instance.TargetElapsedTime.TotalSeconds);

            //the further we go in the level we get more score
            if(gameObject.Position.X > HUD.GetMaxPlayerPosition())
            {
                HUD.SetScore(HUD.GetScore() + 1);
                HUD.SetMaxPlayerPosition(gameObject.Position.X);
            }
            // if we run out of time we die
            if (HUD.GetTimeLeft() == 0)
            {
                IMario mario = (IMario)gameObject;
                mario.InstantDeath();
            }
        }
        public void Draw(SpriteBatch spriteBatch, ICamera camera)
        {
            int time = (int)HUD.GetTimeLeft();
            //  draw on top left of screen
            spriteBatch.DrawString(font, "TIME LEFT: " + time.ToString(), new Vector2(camera.GetPosition().X, camera.GetPosition().Y), Color.White);

            // draw on top middle of screen
            spriteBatch.DrawString(font, "LIVES: " + HUD.GetLives().ToString(), new Vector2(camera.GetPosition().X + camera.GetViewport().Width / 2, camera.GetPosition().Y), Color.White);
            spriteBatch.DrawString(font, "LEVEL: " + HUD.GetLevel().ToString(), new Vector2(camera.GetPosition().X + camera.GetViewport().Width / 2 + 90, camera.GetPosition().Y), Color.White);
            spriteBatch.DrawString(font, "COINS: " + HUD.GetCoins().ToString(), new Vector2(camera.GetPosition().X + camera.GetViewport().Width /2-100, camera.GetPosition().Y), Color.White);

            //draw on top right of screen
            spriteBatch.DrawString(font, "SCORE: " + HUD.GetScore().ToString(), new Vector2(camera.GetPosition().X + camera.GetViewport().Width - 130, camera.GetPosition().Y), Color.White);
        }
    }
}
