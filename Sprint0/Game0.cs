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
        public IMario currentDrawingMario;
        public Dictionary<IMario, int> marios = new Dictionary<IMario, int>();
        public List<IMario> marioRemovalQueue = new List<IMario>();
        public List<IMario> marioInsertQueue = new List<IMario>();
        public Texture2D background;
        public SoundInfo soundInfo;

        public bool isPaused;
        public static string currentSoundtrack;
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
            Content.RootDirectory = "Content";
            ContentInstance = Content;
            IsMouseVisible = true;
            soundInfo = new SoundInfo();
            currentSoundtrack = "OverworldTheme";
            storedGameTime = 0.0f;
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
        public void TogglePause()
        {

        }

        public void AddPlayerToList(IMario mario)
        {
            marioInsertQueue.Add(mario);
        }
        public void RemovePlayerFromList(IMario mario)
        {
            marioRemovalQueue.Add(mario);
        }
        //only add one player at a time
        public void AddPlayers()
        {
            int count = marios.Count;
            int i = 0;

            foreach(IMario mario in marioInsertQueue)
            {
                marios.Add(mario, count + i);
                i++;
            }
            //update cameras when we add a player
            if (i > 0)
            {
                foreach (IMario mario in marios.Keys)
                {
                    Debug.WriteLine(marios.GetValueOrDefault(mario));
                    mario.GetCamera().SetIndex(marios.GetValueOrDefault(mario));
                    mario.GetCamera().UpdateViews(marios.Count);
                    mario.SetKeyboard(ControllerLoader.Instance.SetUpPlayerKeyboard(mario, marios.GetValueOrDefault(mario)));
                }
            }
            marioInsertQueue.Clear();
        }
        public void RemovePlayers()
        {
            foreach (IMario mario in marioRemovalQueue)
            {
                marios.Remove(mario);
            }
            marioRemovalQueue.Clear();
        }
        protected override void Update(GameTime gameTime)
        {
            RemovePlayers();
            AddPlayers();
            base.Update(gameTime);
            GameObjectManager.Instance.UpdateGameObjects();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (IMario mario in marios.Keys)
            {
                tempView = GraphicsDevice.Viewport;
                currentDrawingMario = mario;
                GraphicsDevice.Viewport = mario.GetCamera().ViewPort;
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, mario.GetCamera().ViewMatrix);
                GameObjectManager.Instance.DrawGameObjects(spriteBatch);
                spriteBatch.End();
                GraphicsDevice.Viewport = tempView;
            }

            base.Draw(gameTime);
        }
    }
}