using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Sprint0.UtilityClasses;

namespace Sprint0.Player.State_Machines.States.GameStates
{
    public class GameOverState : IDraw
    {
        private static GameOverState instance;
        public static GameOverState Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new GameOverState();

                }
                return instance;
            }
        }

        private SoundInfo soundInfo;
        ISprite backgroundSprite;
        public ISprite Sprite;
        private String spriteName;
        public Game0 game;

        public GameOverState()
        {
          
            soundInfo = new SoundInfo();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           Game0.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(Game0.Instance.font, GameUtilities.GAMEOVER, new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2), Color.White);
        }


        public void GameOver()
        {
            SoundManager.Instance.StopAllSounds();
          // soundInfo.PlaySound("Content_smb_gameover", false); //DEBUG: cannot find the smb_gameover in the debug file
        }

    }
}
