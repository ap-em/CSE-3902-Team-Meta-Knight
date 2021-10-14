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

            reader.ReadToFollowing("Levels");

            reader.ReadToFollowing("Level" + LevelNumber);

            int rowIndex = 0;
            
            // read rows
            while (reader.ReadToFollowing("row" + rowIndex))
            {
                // read objects
                ReadObjects(reader.ReadSubtree(), rowIndex);
                rowIndex++;
            }
        }
        public void ReadObjects(XmlReader reader, int rowIndex)
        {
            while (reader.ReadToFollowing("obj"))
            {
                //get strings
                String objString = reader.ReadElementContentAsString();
                String[] objValues = objString.Split(',');

                //convert strings to ints
                int xPos = Convert.ToInt32(objValues[0]);
                int yPos = Convert.ToInt32(objValues[1]);
                int numOfObj = Convert.ToInt32(objValues[2]);

                // create the number of objects specified by the second field in the xml obj element
                for(int i=0;i<numOfObj;i++)
                {
                    Vector2 pos = new Vector2(xPos, yPos);
                    //convert position to worldspace
                    pos = BlockToWorldSpace(pos);

                    Level.Instance.CreateObj(pos, rowIndex,objValues[3], objValues[4]);

                    //xPos += 1 to keep spawning objects to the right
                    xPos += 1;
                }
            }
            reader.Close();
        }

        public Vector2 BlockToWorldSpace(Vector2 pos)
        {
            return new Vector2(pos.X * 32, pos.Y * 32);
        }
    }
}
