using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Text.Json;

namespace Sprint0.Sprites.SpriteFactory
{
    public class SpriteFactory
    {
        GraphicsDeviceManager GraphicsDeviceManager;

        private readonly string _dataSheet;
        private Texture2D texture;

        public static SpriteDataArray spriteData; // This is an array that contains all of the different sprites
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
            // parse it here?
            String jsonString = File.ReadAllText(_dataSheet);
            spriteData = JsonSerializer.Deserialize<SpriteDataArray>(jsonString);
           
        }

        public void LoadAllTextures(ContentManager content)
        {
            //goldDoggo = content.Load<Texture2D>("GoldDoggo"); // Example of how to load

            // have list of all in a datasheet?
            // load texture into variable. the variable will be the name of the sprite
            // SpriteName -> spriteFactory. SpriteName(LeftLink / RightLink) = content.Load<Texture2D>(SpriteSheet(Zelda))

            // Technically we can do everything in animated sprite class
        }
        public ISprite GetSprite(String sprite)
        {
            // Texture2D texture // int rows // int 
            String spriteNme = spriteData.Value[0].SpriteName;
            String sprName = spriteData.Value1.FindIndex(sprite);
            return new AnimatedFixedSprite(texture, rows, columns);
            // return new AnimatedFixedSprite(new SpriteFactoryReader(_datasheet));
        }

    }
}
