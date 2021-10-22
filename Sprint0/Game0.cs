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
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 30.0f);

            base.Initialize();
        }
        public IKeyboardController SetUpPlayerKeyboard(IMario mario)
        {
            IKeyboardController keyboard = new KeyboardController();
            keyboard.ClearController();

            keyboard.RegisterCommand(Keys.Q, new Quit(mario));
            keyboard.RegisterCommand(Keys.R, new CReset(mario));

            keyboard.RegisterCommand(Keys.A, new CMovePlayerLeft(mario));
            keyboard.RegisterCommand(Keys.D, new CMovePlayerRight(mario));

            keyboard.RegisterCommand(Keys.Left, new CMovePlayerLeft(mario));
            keyboard.RegisterCommand(Keys.Right, new CMovePlayerRight(mario));

            //need to create a primary attack imario, but only imario is mario, so mario here for now
            keyboard.RegisterCommand(Keys.Z, new CPlayerPrimaryAttack(mario));
            keyboard.RegisterCommand(Keys.N, new CPlayerPrimaryAttack(mario));

            keyboard.RegisterCommand(Keys.E, new CDamagePlayer(mario));

            keyboard.RegisterHoldableKey(Keys.Space, new CPlayerJump(mario));

            keyboard.RegisterReleasableKey(Keys.A, new CZeroPlayerXVelocity(mario));
            keyboard.RegisterReleasableKey(Keys.D, new CZeroPlayerXVelocity(mario));

            keyboard.RegisterReleasableKey(Keys.Left, new CZeroPlayerXVelocity(mario));
            keyboard.RegisterReleasableKey(Keys.Right, new CZeroPlayerXVelocity(mario));

            return keyboard;
        }
        public IKeyboardController SetUpEnemyKeyboard(IEnemy enemy)
        {
            IKeyboardController keyboard = new EnemyController();

            keyboard.ClearController();

            keyboard.RegisterCommand(Keys.A, new CMoveEnemyLeft(enemy));
            keyboard.RegisterCommand(Keys.D, new CMoveEnemyRight(enemy));

            keyboard.RegisterReleasableKey(Keys.A, new CZeroEnemyXVelocity(enemy));
            keyboard.RegisterReleasableKey(Keys.D, new CZeroEnemyXVelocity(enemy));

            return keyboard;
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GameObjectManager.Instance.UpdateGameObjects();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            GameObjectManager.Instance.DrawGameObjects(spriteBatch);
            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}