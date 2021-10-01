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
        public IItems item;
        public ILinkState linkstate;
        private IKeyboardController enemyKeyboard;
        private IKeyboardController playerKeyboard;
        /*private IMouseController mouseController; not needed for Sprint 2 */
        private ArrayList keyboardControllerList;
        public static ContentManager ContentInstance;
        public Game0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ContentInstance = Content;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            block = new Block();
            enemy = new Enemy();
            link = new Link();

            enemyKeyboard = new EnemyController();
            SetUpEnemyKeyboard(enemyKeyboard, enemy);

            playerKeyboard = new KeyboardController();
            SetUpPlayerKeyboard(playerKeyboard);
            
            //No need for mouse controller for Sprint 2
            /* 
            mouseController = new MouseController(this);
            SetUpMouse();
            */
            keyboardControllerList = new ArrayList();
            keyboardControllerList.Add(enemyKeyboard);
            keyboardControllerList.Add(playerKeyboard);

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 30.0f);

            base.Initialize();
        }
        private void SetUpPlayerKeyboard(IKeyboardController keyboard)
        {
            keyboard.RegisterCommand(Keys.Q, new Quit(this));
            keyboard.RegisterCommand(Keys.R, new CReset(this));

            keyboard.RegisterCommand(Keys.W, new CMovePlayerUp(this));
            keyboard.RegisterCommand(Keys.A, new CMovePlayerLeft(this));
            keyboard.RegisterCommand(Keys.S, new CMovePlayerDown(this));
            keyboard.RegisterCommand(Keys.D, new CMovePlayerRight(this));

            keyboard.RegisterCommand(Keys.Up, new CMovePlayerUp(this));
            keyboard.RegisterCommand(Keys.Left, new CMovePlayerLeft(this));
            keyboard.RegisterCommand(Keys.Down, new CMovePlayerDown(this));
            keyboard.RegisterCommand(Keys.Right, new CMovePlayerRight(this));

            //need to create a primary attack ilink, but only ilink is link, so link here for now
            keyboard.RegisterCommand(Keys.Z, new CPlayerPrimaryAttack(link,this));
            keyboard.RegisterCommand(Keys.N, new CPlayerSecondaryAttack(link, this));

            keyboard.RegisterCommand(Keys.E, new CDamagePlayer(linkstate));

            //need to be able to use all items from number keys, need commands for this
            //keyboard.RegisterCommand(Keys.D1, new CItem1(item, this));
            //keyboard.RegisterCommand(Keys.D2, new Citem2(item, this)); 
            //keyboard.RegisterCommand(Keys.D3, new Citem3(item, this));

            keyboard.RegisterCommand(Keys.U, new CCyclePlayerItemPrevious(item));
            keyboard.RegisterCommand(Keys.I, new CCyclePlayerItemNext(item));


            keyboard.RegisterCommand(Keys.T, new CCyclePreviousBlock(block));
            keyboard.RegisterCommand(Keys.Y, new CCycleNextBlock(block));

            keyboard.RegisterCommand(Keys.O, new CCyclePreviousEnemy(enemy));
            keyboard.RegisterCommand(Keys.P, new CCycleNextEnemy(enemy));

            keyboard.RegisterReleasableKey(Keys.W, new CZeroPlayerYVelocity(this,"Up"));
            keyboard.RegisterReleasableKey(Keys.S, new CZeroPlayerYVelocity(this,"Down"));
            keyboard.RegisterReleasableKey(Keys.A, new CZeroPlayerXVelocity(this,"Left"));
            keyboard.RegisterReleasableKey(Keys.D, new CZeroPlayerXVelocity(this, "Right"));

            keyboard.RegisterReleasableKey(Keys.Up, new CZeroPlayerYVelocity(this,"Up"));
            keyboard.RegisterReleasableKey(Keys.Down, new CZeroPlayerYVelocity(this,"Down"));
            keyboard.RegisterReleasableKey(Keys.Left, new CZeroPlayerXVelocity(this, "Left"));
            keyboard.RegisterReleasableKey(Keys.Right, new CZeroPlayerXVelocity(this, "Right"));
            

        }
        private void SetUpEnemyKeyboard(IKeyboardController keyboard, IEnemy enemy)
        {
            keyboard.RegisterCommand(Keys.W, new CMoveEnemyUp(enemy));
            keyboard.RegisterCommand(Keys.A, new CMoveEnemyLeft(enemy));
            keyboard.RegisterCommand(Keys.S, new CMoveEnemyDown(enemy));
            keyboard.RegisterCommand(Keys.D, new CMoveEnemyRight(enemy));
            keyboard.RegisterCommand(Keys.Space, new CEnemyAttack(enemy));

            keyboard.RegisterReleasableKey(Keys.W, new CZeroEnemyYVelocity(enemy));
            keyboard.RegisterReleasableKey(Keys.S, new CZeroEnemyYVelocity(enemy));
            keyboard.RegisterReleasableKey(Keys.A, new CZeroEnemyXVelocity(enemy));
            keyboard.RegisterReleasableKey(Keys.D, new CZeroEnemyXVelocity(enemy));

            //            keyboard.SetZeroXVelocityCommand(new CZeroEnemyYVelocity(enemy));
            //            keyboard.SetZeroYVelocityCommand(new CZeroEnemyXVelocity(enemy));
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
            foreach(IKeyboardController controller in keyboardControllerList)
            {
                controller.Update();
            }

            //no need for mouse for sprint 2
            /*
            mouseController.Update();
            */

            //Might want to do something similar to controller update, with enemies and sprites -- although this is a job for game object manager - which hasn't been implmeneted yet
            /*
            foreach(ISprite sprite in SpriteList)
            {
                sprite.Update();
            }
            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Update();
            }
            */
            link.Update();
            enemy.Update();
            ProjectileController.Instance.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //These calls don't seem to be doing anything -- should implment with spriteFactory in some way
            enemy.Draw(spriteBatch);
            link.Draw(spriteBatch);
            ProjectileController.Instance.Draw(spriteBatch);
            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
