using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Sprites.SpriteFactory
{
    public class SpriteFactory
    {
      //  GraphicsDeviceManager GraphicsDeviceManager;

        private readonly string _dataSheet;
        //private Texture2D[] texture;
       // private Texture2D texture;
        private readonly ICollection<SpriteData> _spriteData;

        private Dictionary<String, SpriteData> SpriteDict;
        private HashSet<String> spriteSheetSet;
        private String spriteSheet;

        ContentManager Content;
        private static SpriteFactory instance;
        public static SpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    
                    instance = new SpriteFactory(Path.GetFullPath("Sprites\\SpriteFactory\\DataSheet.json"), Game0.ContentInstance); // FIXME later because multiple datasheets would not wo
                    
                }
                return instance;
            }
        }

        public SpriteFactory(String fileName, ContentManager content)
        {
            _dataSheet = fileName;
  
            String jsonString = File.ReadAllText(fileName);
            _spriteData = JsonSerializer.Deserialize<ICollection<SpriteData>>(jsonString);
            SpriteDict = new Dictionary<String, SpriteData>();
            spriteSheetSet = new HashSet<String>();
            Content = content;

            foreach (SpriteData sprite in _spriteData) // Constructs dictionary
            {
                SpriteDict.Add(sprite.SpriteName, sprite); // can replace sprite with sprite.Data[] if i want array instead
                spriteSheetSet.Add(sprite.SpriteSheet);
            }
        }
        
        public Texture2D LoadTexture(String spriteSheet)
        {
            return Content.Load<Texture2D>(spriteSheet);
        }

        
        public ISprite GetSprite(String spriteName)
        {
          //  Debug.WriteLine(spriteName);
            SpriteData s = SpriteDict.GetValueOrDefault(spriteName);
              spriteSheet = s.SpriteSheet;
            
            
            Texture2D texture = LoadTexture(spriteSheet);

            int[] data = s.Data; // Data: height(of sprite) // width(of sprite) // total frames
            int[] x = s.DataX;   // DataX: Location in sprite sheet(x)
            int[] y = s.DataY;   // DataY: Location in sprite sheet(y)
            return new AnimatedSprite(texture, x , y, data[0], data[1], data[2]); 
        }

    }
}

