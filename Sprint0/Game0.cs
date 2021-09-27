using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Sprint0;
using Sprint0.Controllers;
using Sprint0.Sprites;
using Sprint0.Commands;
using Sprint0.Blocks;
using Sprint0.Interfaces;
using System;
using System.Collections;

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
        public ILink link;
        public IEnemy enemy;
        public IBlock block;
        private EnemyController enemyKeyboard;
        private IKeyboardController playerKeyboard;
        private IMouseController mouseController;
        private ArrayList keyboardControllerList;

        public Game0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            block = new Block();
            enemy = new Enemy();
            link = new Link();
            enemyKeyboard = new EnemyController();
            SetUpEnemyKeyboard(enemyKeyboard, enemy);
            enemyKeyboard.SetAvailableKeys();

            playerKeyboard = new KeyboardController();
            SetUpPlayerKeyboard(playerKeyboard);
            
            mouseController = new MouseController(this);
            SetUpMouse();

            keyboardControllerList = new ArrayList();
            keyboardControllerList.Add(enemyKeyboard);
            keyboardControllerList.Add(playerKeyboard);

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 30.0f);

            base.Initialize();
        }
        private void SetUpPlayerKeyboard(IKeyboardController keyboard)
        {
            keyboard.RegisterCommand(Keys.Escape, new Quit(this));
            keyboard.RegisterCommand(Keys.D1, new CFixedSprite(this));
            keyboard.RegisterCommand(Keys.D2, new CAnimatedFixedSprite(this));
            keyboard.RegisterCommand(Keys.D3, new CMovingStaticSprite(this));
            keyboard.RegisterCommand(Keys.D4, new CAnimatedMovingSprite(this));

            /*
            keyboard.RegisterCommand(Keys.W, new CMovePlayerUp(this));
            keyboard.RegisterCommand(Keys.A, new CMovePlayerLeft(this));
            keyboard.RegisterCommand(Keys.S, new CMovePlayerDown(this));
            keyboard.RegisterCommand(Keys.D, new CMovePlayerRight(this));
            
            keyboard.SetZeroXVelocityCommand(new CZeroPlayerYVelocity(this));
            keyboard.SetZeroYVelocityCommand(new CZeroPlayerXVelocity(this));
            */
        }
        private void SetUpEnemyKeyboard(IKeyboardController keyboard, IEnemy enemy)
        {
            keyboard.RegisterCommand(Keys.O, new CCycleNextEnemy(enemy));
            keyboard.RegisterCommand(Keys.P, new CCyclePreviousEnemy(enemy));

            keyboard.RegisterCommand(Keys.W, new CMoveEnemyUp(enemy));
            keyboard.RegisterCommand(Keys.A, new CMoveEnemyLeft(enemy));
            keyboard.RegisterCommand(Keys.S, new CMoveEnemyDown(enemy));
            keyboard.RegisterCommand(Keys.D, new CMoveEnemyRight(enemy));
            keyboard.RegisterCommand(Keys.Space, new CEnemyAttack(enemy));

            keyboard.SetZeroXVelocityCommand(new CZeroEnemyYVelocity(enemy));
            keyboard.SetZeroYVelocityCommand(new CZeroEnemyXVelocity(enemy));
        }
        private void SetUpMouse()
        {
            int rWidth = graphics.PreferredBackBufferWidth; // This is the width of the whole screen
            int rHeight = graphics.PreferredBackBufferHeight;

            mouseController.RegisterCommand(new Rectangle(0, 0, rWidth / 2, rHeight / 2), new CFixedSprite(this)); // upper left, fixed static
            mouseController.RegisterCommand(new Rectangle(rWidth / 2, 0, rWidth / 2, rHeight / 2), new CAnimatedFixedSprite(this)); // upper right, animated fixed
            mouseController.RegisterCommand(new Rectangle(0, rHeight / 2, rWidth / 2, rHeight / 2), new CMovingStaticSprite(this)); // bottom left, one frame up/dpown
            mouseController.RegisterCommand(new Rectangle(rWidth / 2, rHeight / 2, rWidth / 2, rHeight / 2), new CAnimatedMovingSprite(this)); //Bottom right, one frame up/down

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadAllTextures(Content); // Functions as sprite factory
            font = Content.Load<SpriteFont>("font"); // Will use a similar "load all textures" method in the future for this to support multiple fonts. Can use commands to switch betewen fonts too.
            sprite = SpriteFactory.Instance.CreateGoldDoggo();
            //  SpriteController

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(IKeyboardController controller in keyboardControllerList)
            {
                controller.Update();
            }
            mouseController.Update();
            sprite.Update();
            enemy.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            sprite.Draw(spriteBatch, new Vector2(400, 240));
            enemy.Draw();
            link.Draw(spriteBatch);
            spriteBatch.DrawString(this.font, "Credits \nProgram Made By: Alex Clayton\n Sprites From: https://www.spriters-resource.com/nes/legendofzelda/", new Vector2(200, 200), Color.White);
            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
