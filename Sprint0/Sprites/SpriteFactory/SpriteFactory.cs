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
        //private Texture2D[] texture;
        private Texture2D texture;
        private readonly ICollection<SpriteData> _spriteData;

        private Dictionary<String, SpriteData> SpriteDict;
        private HashSet<String> spriteSheetSet;
        private String spriteSheet = "Zelda";

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
            _dataSheet = fileName;
            
            String jsonString = File.ReadAllText(fileName);
            _spriteData = JsonSerializer.Deserialize<ICollection<SpriteData>>(jsonString);
            SpriteDict = new Dictionary<String, SpriteData>();
            spriteSheetSet = new HashSet<String>();

            foreach (SpriteData sprite in _spriteData) // Constructs dictionary
            {
                SpriteDict.Add(sprite.SpriteName, sprite); // can replace sprite with sprite.Data[] if i want array instead
                spriteSheetSet.Add(sprite.SpriteSheet);
            }
        }

        //Alex Contreras - Maybe just get rid of LoadAllTextures and have GetSprite do it all?
        
        public void LoadAllTextures(ContentManager content, String spriteSheet) // Replace with lazy loading in future?
        {

            texture = content.Load<Texture2D>(spriteSheet);
           /*
            for (int i = 0; i < spriteSheetSet.Count; i++)
            {
                texture[i] = content.Load<Texture2D>(spriteSheetSet.)
            }
           */
         }
        

        /*
         * We still need to be able to load content, which this does not do.  
         * We could make SpriteFactory inherit a contentmanager class that has the sole purpose of having content in it. 
         * Then, we could just make a loadcontent method there and say "(base).loadContent(name) or whatever. Still figuring it out but this is for the current push.
         */
        
        public ISprite GetSprite(ContentManager content, String spriteName)
        {
            
            SpriteData s = _spriteData.FirstOrDefault(p => p.SpriteName == spriteName); // This returns the wanted Sprite value

            spriteSheet = s.SpriteSheet;
            LoadAllTextures(content, spriteSheet);

            int[] data = s.Data; // Data: Location in sprite sheet(x) // (y) // height(of sprite) // width(of sprite) // row(for frames) // columns (for frames)


            return new AnimatedSprite(texture, data[4] ,data[5], data[3], data[2]); // // Texture2D texture // int rows // int  columns Data[4] is rows, Data[] is columns
        }

    }
}

