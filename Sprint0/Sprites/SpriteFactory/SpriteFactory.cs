using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;
using Sprint0.Sprites;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.SpriteFactory
{
    public class SpriteFactory
    {
        GraphicsDeviceManager GraphicsDeviceManager;

        private readonly string _dataSheet;
        private Texture2D texture;

        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public SpriteFactory(String fileName) 
        {
              _dataSheet = fileName;
        }

        // pass in name of sprite in CreateSpriteFactoryReader

        public SpriteFactoryReader CreateSpriteFactoryReader(String fileName)
        {
            return new SpriteFactoryReader(_dataSheet);
        }

        public LoadAllTextures(void LoadAllTextures(ContentManager content)
        {
            //goldDoggo = content.Load<Texture2D>("GoldDoggo"); // Static non-moving Sprite
          //  mario = content.Load<Texture2D>("Mario");
        //    smiley = content.Load<Texture2D>("SmileyWalk"); // Animated fixed sprite
      //      link = content.Load<Texture2D>("Link");

            // have list of all in a datasheet?
            // load texture into variable. the variable will be the name of the sprite
            // SpriteName -> spriteFactory. SpriteName(LeftLink / RightLink) = content.Load<Texture2D>(SpriteSheet(Zelda))

            // Technically we can do everything in animated sprite class



        }

    }
}
