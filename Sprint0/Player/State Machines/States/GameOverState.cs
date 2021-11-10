using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace Sprint0.Player.State_Machines.States.GameStates
{
    public class GameOverState : IDraw
    {

        private SoundInfo soundInfo;
        ISprite backgroundSprite;
        public ISprite Sprite;
        private String spriteName;
        public Game0 game;

        public GameOverState(string spriteName)
        {
            this.spriteName = spriteName;
            soundInfo = new SoundInfo();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
           // game.GraphicsDevice.Clear(Color.Black);
          //  spriteBatch.DrawString(game.font, "Lose", new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2), Color.White);
        }


        public void GameOver()
        {
            SoundManager.Instance.StopAllSounds();
            soundInfo.PlaySound("smb_gameover", false);
        }

    }
}
