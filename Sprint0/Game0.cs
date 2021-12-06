using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Sprint0;
using Sprint0.Controllers;
using Sprint0.Sprites;
using Sprint0.Commands;
using Sprint0.Blocks;
using Sprint0.HUD;
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
using Sprint0.Timers;
using Sprint0.Levels;

/*
 * Team MetaKnight 2021 CSE 3902
 */
namespace Sprint0
{
    sealed public class Game0 : Game
    {
        private Viewport tempView;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private FrameCounter frameCounter;
        public static ContentManager ContentInstance;
        public Texture2D background;
        public bool isPaused;
        public static float storedGameTime;


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
           frameCounter = new FrameCounter();
            Content.RootDirectory = "Content";
            ContentInstance = Content;
            IsMouseVisible = true;
            storedGameTime = 0.0f;
        }

        protected override void Initialize()
        {
            LevelFactory.Instance.CreateLevel(LevelFactory.Instance.currentLevel);
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(GameUtilities.timeSpan);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            frameCounter.LoadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            PlayerKeyboardManager.Instance.Update();
            if (!isPaused)
            {
                GameObjectManager.Instance.UpdateGameObjects();
                CameraManager.Instance.Update();
                HUDManager.Instance.Update();
                TimerManager.Instance.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.FromNonPremultiplied(92,148,252,255));
            foreach (ICamera camera in CameraManager.Instance.cameras.Values)
            {
                tempView = GraphicsDevice.Viewport;
                GraphicsDevice.Viewport = camera.GetViewport();
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetMatrix());
                Background.Instance.Draw(spriteBatch);
                GameObjectManager.Instance.DrawStaticGameObjects(spriteBatch, camera);
                GameObjectManager.Instance.DrawGameObjects(spriteBatch);
                HUDManager.Instance.Draw(spriteBatch, camera);
                frameCounter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                frameCounter.Draw(spriteBatch, camera);
                GraphicsDevice.Viewport = tempView;
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}