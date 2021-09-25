using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0.Sprites.SpriteFactory
{
    public class SpriteFactory
    {
      //  GraphicsDeviceManager GraphicsDeviceManager;

        private readonly string _dataSheet;
        private Texture2D texture;
        private readonly ICollection<SpriteData> _spriteData;
       // ContentManager Content;
        private static SpriteFactory instance = new SpriteFactory(Path.GetFullPath("Sprites\\SpriteFactory\\DataSheet.json"));
        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public SpriteFactory(String fileName)
        {
              _dataSheet = fileName
            
            String jsonString = File.ReadAllText(fileName);
            _spriteData = JsonSerializer.Deserialize<ICollection<SpriteData>>(jsonString);
           
        }

        public void LoadAllTextures(ContentManager content) // Replace with lazy loading in future?
        {
            texture = content.Load<Texture2D>("Zelda"); // name of LoZ spritesheet
            // load texture into variable. the variable will be the name of the sprite
            // SpriteName -> spriteFactory. SpriteName(LeftLink / RightLink) = content.Load<Texture2D>(SpriteSheet(Zelda
        }

        /*
         * We still need to be able to load content, which this does not do.  
         * We could make SpriteFactory inherit a contentmanager class that has the sole purpose of having content in it. 
         * Then, we could just make a loadcontent method there and say "(base).loadContent(name) or whatever. Still figuring it out but this is for the current push.
         */
        public ISprite GetSprite(String spriteName)
        {
            
            SpriteData s = _spriteData.FirstOrDefault(p => p.SpriteName == spriteName); // This returns the wanted Sprite value

            String spriteSheet = s.SpriteSheet;
            int[] data = s.Data; // See DataSheet.json for how this is structured.  Data: Location in sprite sheet(x) // (y) // height(of sprite) // width(of sprite) // row(for frames) // columns (for frames)

            return new AnimatedSprite(texture, data[3] ,data[4]); // // Texture2D texture // int rows // int  columns Data[3] is rows, Data[4] is columns
        }

    }
}
