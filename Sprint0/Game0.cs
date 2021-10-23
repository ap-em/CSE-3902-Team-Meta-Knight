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

/*
 * Alex Clayton 2021 CSE 3902
 */
namespace Sprint0
{
    public class Game0 : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public ISprite sprite;
        public SpriteFont font;
        public static ContentManager ContentInstance;
        public ICamera camera;
        public Mario mario;

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
        }

        protected override void Initialize()
        {
            LevelFactory.Instance.CreateLevel(1);
            CreatePlayer();
            camera = mario.camera;
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 30.0f);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public void CreatePlayer()
        {
            mario = new Mario("Sprint0.Mario", new Vector2(80, 300));
            GameObjectManager.Instance.AddToObjectList(mario);
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GameObjectManager.Instance.UpdateGameObjects();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.ViewMatrix);
            GameObjectManager.Instance.DrawGameObjects(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}