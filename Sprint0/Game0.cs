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
        public IBlock block;
        private KeyboardController kbController;
        private MouseController mouseController;

        public Game0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            block = new Block(this);

            kbController = new KeyboardController();
            // Initialize kb contoller 
            // Will make a setup / initialize method for better encapsulation.
            kbController.RegisterCommand(Keys.Escape, new Quit(this));
            kbController.RegisterCommand(Keys.D1, new CFixedSprite(this));
            kbController.RegisterCommand(Keys.D2, new CAnimatedFixedSprite(this));
            kbController.RegisterCommand(Keys.D3, new CMovingStaticSprite(this));
            kbController.RegisterCommand(Keys.D4, new CAnimatedMovingSprite(this));

            kbController.RegisterCommand(Keys.T, new CCyclePreviousBlock(this));
            kbController.RegisterCommand(Keys.Y, new CCycleNextBlock(this));

            // Initialize mouse controller
            int rWidth = graphics.PreferredBackBufferWidth; // This is the width of the whole screen
            int rHeight = graphics.PreferredBackBufferHeight;

            // rectangles are definde as Rectangle(height, width, x, y)
            mouseController = new MouseController(this);
            mouseController.RegisterCommand(new Rectangle(0, 0, rWidth / 2, rHeight / 2), new CFixedSprite(this)); // upper left, fixed static
            mouseController.RegisterCommand(new Rectangle(rWidth / 2 , 0, rWidth / 2, rHeight / 2), new CAnimatedFixedSprite(this)); // upper right, animated fixed
            mouseController.RegisterCommand(new Rectangle(0, rHeight / 2, rWidth / 2, rHeight / 2), new CMovingStaticSprite(this)); // bottom left, one frame up/dpown
            mouseController.RegisterCommand(new Rectangle(rWidth / 2, rHeight / 2, rWidth / 2, rHeight / 2), new CAnimatedMovingSprite(this)); //Bottom right, one frame up/down
            // Sets frame cap at 30fps


            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 30.0f);

            base.Initialize();
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

            kbController.Update();
            mouseController.Update();
            sprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            sprite.Draw(spriteBatch, new Vector2(400, 240));
            spriteBatch.DrawString(this.font, "Credits \nProgram Made By: Alex Clayton\n Sprites From: https://www.spriters-resource.com/nes/legendofzelda/", new Vector2(200, 200), Color.White);
            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
