﻿using Microsoft.Xna.Framework;
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

            //No need for mouse controller for Sprint 2
            /* 
            mouseController = new MouseController(this);
            SetUpMouse();
            */

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 30.0f);

            base.Initialize();
        }
        public IKeyboardController SetUpPlayerKeyboard(ILink link)
        {
            IKeyboardController keyboard = new KeyboardController();
            keyboard.ClearController();

            keyboard.RegisterCommand(Keys.Q, new Quit(link));
            keyboard.RegisterCommand(Keys.R, new CReset(link));

            keyboard.RegisterCommand(Keys.A, new CMovePlayerLeft(link));
            keyboard.RegisterCommand(Keys.D, new CMovePlayerRight(link));

            keyboard.RegisterCommand(Keys.Left, new CMovePlayerLeft(link));
            keyboard.RegisterCommand(Keys.Right, new CMovePlayerRight(link));

            //need to create a primary attack ilink, but only ilink is link, so link here for now
            keyboard.RegisterCommand(Keys.Z, new CPlayerPrimaryAttack(link));
            keyboard.RegisterCommand(Keys.N, new CPlayerPrimaryAttack(link));

            keyboard.RegisterCommand(Keys.E, new CDamagePlayer(link));

            keyboard.RegisterHoldableKey(Keys.Space, new CPlayerJump(link));

            keyboard.RegisterReleasableKey(Keys.W, new CZeroPlayerYVelocity(link));
            keyboard.RegisterReleasableKey(Keys.S, new CZeroPlayerYVelocity(link));
            keyboard.RegisterReleasableKey(Keys.A, new CZeroPlayerXVelocity(link));
            keyboard.RegisterReleasableKey(Keys.D, new CZeroPlayerXVelocity(link));

            keyboard.RegisterReleasableKey(Keys.Up, new CZeroPlayerYVelocity(link));
            keyboard.RegisterReleasableKey(Keys.Down, new CZeroPlayerYVelocity(link));
            keyboard.RegisterReleasableKey(Keys.Left, new CZeroPlayerXVelocity(link));
            keyboard.RegisterReleasableKey(Keys.Right, new CZeroPlayerXVelocity(link));

            return keyboard;
        }
        public IKeyboardController SetUpEnemyKeyboard(IEnemy enemy)
        {
            IKeyboardController keyboard = new EnemyController();

            keyboard.ClearController();
            keyboard.RegisterCommand(Keys.W, new CMoveEnemyUp(enemy));
            keyboard.RegisterCommand(Keys.A, new CMoveEnemyLeft(enemy));
            keyboard.RegisterCommand(Keys.S, new CMoveEnemyDown(enemy));
            keyboard.RegisterCommand(Keys.D, new CMoveEnemyRight(enemy));
            keyboard.RegisterCommand(Keys.Space, new CEnemyAttack(enemy));

            keyboard.RegisterReleasableKey(Keys.W, new CZeroEnemyYVelocity(enemy));
            keyboard.RegisterReleasableKey(Keys.S, new CZeroEnemyYVelocity(enemy));
            keyboard.RegisterReleasableKey(Keys.A, new CZeroEnemyXVelocity(enemy));
            keyboard.RegisterReleasableKey(Keys.D, new CZeroEnemyXVelocity(enemy));

            return keyboard;
        }
        /* No need for mouse for Sprint 2
        private void SetUpMouse()
        {
           
            
            int rWidth = graphics.PreferredBackBufferWidth; // This is the width of the whole screen
            int rHeight = graphics.PreferredBackBufferHeight;

            mouseController.RegisterCommand(new Rectangle(0, 0, rWidth / 2, rHeight / 2), new CFixedSprite(this)); // upper left, fixed static
            mouseController.RegisterCommand(new Rectangle(rWidth / 2, 0, rWidth / 2, rHeight / 2), new CAnimatedFixedSprite(this)); // upper right, animated fixed
            mouseController.RegisterCommand(new Rectangle(0, rHeight / 2, rWidth / 2, rHeight / 2), new CMovingStaticSprite(this)); // bottom left, one frame up/dpown
            mouseController.RegisterCommand(new Rectangle(rWidth / 2, rHeight / 2, rWidth / 2, rHeight / 2), new CAnimatedMovingSprite(this)); //Bottom right, one frame up/down
            
        } */
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //no need for fonts for Sprint 2
            /*
            font = Content.Load<SpriteFont>("font"); // Will use a similar "load all textures" method in the future for this to support multiple fonts. Can use commands to switch betewen fonts too.
            */

            ISprite enemySprite, blockSprite;

            //Not yet in datasheet just showing how the block and enemy/npc would be called
            /*
            enemySprite = SpriteFactory.Instance.GetSprite(Content, "Bat");
            blockSprite = SpriteFactory.Instance.GetSprite(Content, "Block1");
            */
        }

        protected override void Update(GameTime gameTime)
        {
            ProjectileController.Instance.Update();
            base.Update(gameTime);
            GameObjectManager.Instance.UpdateGameObjects();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            ProjectileController.Instance.Draw(spriteBatch);
            GameObjectManager.Instance.DrawGameObjects(spriteBatch);

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}