using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Sprint0;
using Sprint0.Controllers;
using Sprint0.Sprites;
using Sprint0.Commands;
using Sprint0.Blocks;
using Sprint0.Interfaces;
using Sprint0.Enemies;
using System;
using Sprint0.Sprites.SpriteFactory;
using System.Collections;
using Microsoft.Xna.Framework.Content;
using Sprint0.Items;
using Sprint0.UtilityClasses;
using System.Collections.Generic;
using System.Diagnostics;

/*
 * Alex Clayton 2021 CSE 3902
 */
namespace Sprint0
{
    public class Game0 : Game
    {
        public Viewport tempView;
        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public ISprite sprite;
        public SpriteFont font;
        public static ContentManager ContentInstance;
        public Texture2D background;
        public SoundInfo soundInfo;
        public bool isPaused;

        private static Game0 instance;
        public static Game0 Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new Game0();

                }
                return instance;
            }
        }

        public Game0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ContentInstance = Content;
            IsMouseVisible = true;
            soundInfo = new SoundInfo();
        }

        protected override void Initialize()
        {
            LevelFactory.Instance.CreateLevel(1);

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(GameUtilities.timeSpan);

            soundInfo.PlaySound("OverworldTheme", true);
            isPaused = false;

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
        }
        public void Pause()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GameObjectManager.Instance.UpdateGameObjects();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.FromNonPremultiplied(92,148,252,255));

            foreach (IMario mario in GameObjectManager.Instance.marios.Keys)
            {
                tempView = GraphicsDevice.Viewport;
                GameObjectManager.Instance.currentDrawingMario = mario;
                GraphicsDevice.Viewport = mario.GetCamera().ViewPort;
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, GameObjectManager.Instance.currentDrawingMario.GetCamera().ViewMatrix);
                GameObjectManager.Instance.DrawGameObjects(spriteBatch);
                spriteBatch.End();
                GraphicsDevice.Viewport = tempView;
            }

            base.Draw(gameTime);
        }
    }
}