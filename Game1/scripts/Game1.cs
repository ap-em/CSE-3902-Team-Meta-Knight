using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Texture2D marioSprite;
        private SpriteFont font;

        public ISprite mario;
        public Vector2 position;

        private ArrayList controllerList;
        
        public MovementController characterController;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            characterController = new MovementController(this);
        }

        protected override void Initialize()
        {
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new MouseController(this));

            position = new Vector2(graphics.GraphicsDevice.Viewport.Width/2, graphics.GraphicsDevice.Viewport.Height/2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            marioSprite = Content.Load<Texture2D>("images/mario_sprite");
            font = Content.Load<SpriteFont>("fonts/Credits");

            mario = new IdleSprite(marioSprite);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            characterController.Update();
            mario.Update();
            base.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            mario.Draw(spriteBatch, position);
            spriteBatch.DrawString(font, "Credits\nProgram Made By: Owen Huston\nSprites From: https://www.mariomayhem.com/downloads/sprites/super_mario_bros_sprites.php", new Vector2(0, 300), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
