using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Sprites
{
    public class SpriteController
    {
        GraphicsDeviceManager GraphicsDeviceManager;

        //private SpriteBatch spriteBatch;


        //  private NMStaticSprite ssGoldDoggo; // Static Sprite gold doggo

        //private ContentManager content;

        private Texture2D goldDoggo;
        private Texture2D mario;
        private Texture2D smiley;
        private Texture2D link;

        private static SpriteController instance = new SpriteController();

        public static SpriteController Instance
        {
            get
            {
                return instance;
            }
        }

        public SpriteController()//GraphicsDeviceManager graphicsDeviceManager) // : (base.graphicsDeviceManager)
        {
            //  GraphicsDeviceManager = graphicsDeviceManager;
        }

        public void LoadAllTextures(ContentManager content)
        {
            goldDoggo = content.Load<Texture2D>("GoldDoggo"); // Static non-moving Sprite
            mario = content.Load<Texture2D>("Mario");
            smiley = content.Load<Texture2D>("SmileyWalk"); // Animated fixed sprite
            link = content.Load<Texture2D>("Link");
        }

        public ISprite CreateGoldDoggo()
        {
            return new GoldDoggo(goldDoggo, 1, 1); // texture / rows / columns

        }
        public ISprite CreateAnimatedFixedSprite()
        {
            return new AnimatedFixedSprite(smiley, 4, 4); 
        }

        public ISprite CreateMovingStaticSprite()
        {
            return new MovingStaticSprite(link, 1, 6);
        }
        public ISprite CreateAnimatedMovingSprite()
        {
            return new AnimatedMovingSprite(link, 1, 6);
        }
    }
}