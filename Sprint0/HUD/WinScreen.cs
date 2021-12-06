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
    public class WinScreen : IHUDState
    {
        private SpriteFont font;
        private Texture2D background;
        private IGameObject gameObject;

        private SoundInfo soundInfo;
        
        public WinScreen(IGameObject go, IHUD HUD)
        {
            soundInfo = new SoundInfo();
            gameObject = go;
            font = Game0.Instance.Content.Load<SpriteFont>("Font");

            background = Game0.Instance.Content.Load <Texture2D>("GameoverSMB");

        }

        public void Update()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch, ICamera camera)
        {
            soundInfo.PlaySound("smb_gameover", false);
            spriteBatch.Draw(background, new Rectangle(-1000, -1000, 7750, 5000), Color.Black);
           spriteBatch.DrawString(font, "CREDITS ", new Vector2(camera.GetPosition().X + camera.GetViewport().Width/ 2 - 50, camera.GetPosition().Y + camera.GetViewport().Height / 2), Color.White);
        }
        public void ResetGame()
        {
            new CResetGame((IMario)gameObject).Execute();
        }
    }
}
