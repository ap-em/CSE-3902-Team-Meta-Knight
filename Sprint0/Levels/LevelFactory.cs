using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using System.IO;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0.Blocks
{
    class LevelFactory 
    {

        private static LevelFactory instance;
        public static LevelFactory Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new LevelFactory();

                }
                return instance;
            }
        }

        public LevelFactory()
        {

        }
        public void CreateLevel(int LevelNumber)
        {

            XmlReader reader = XmlReader.Create(Path.GetFullPath("Levels\\LevelsData.xml"));
            String objType;
            Vector2 pos;
            String objString;
            String[] objValues;

            reader.ReadToFollowing("Levels");

            reader.ReadToFollowing("Level" + LevelNumber);

            while (reader.ReadToFollowing("obj"))
            {

                objString = reader.ReadElementContentAsString();
                objValues = objString.Split(',');

                pos = new Vector2(Convert.ToInt32(objValues[0]), Convert.ToInt32(objValues[1]));

                Level.Instance.CreateObj(pos, objValues[2], objValues[3]);
            }
        }
    }
}
