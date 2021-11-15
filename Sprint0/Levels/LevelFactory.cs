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


namespace Sprint0
{
    sealed public class LevelFactory 
    {
        public int currentLevel = 1;
        private static LevelFactory instance;
        public SoundInfo soundInfo;
        public String currentSoundtrack = "OverworldTheme";
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
            soundInfo = new SoundInfo();
        }
        public void CreateLevel(int levelNumber)
        {
            // can possibly make xml later to create sound based on levelNumber
            soundInfo.StopLoopedSound(currentSoundtrack);
            soundInfo.PlaySound(currentSoundtrack, true);
            SetupReader(levelNumber);
        }
        public void SetupReader(int levelNumber)
        {

            XmlReader reader = XmlReader.Create(Path.GetFullPath("Levels\\LevelsData.xml"));

            reader.ReadToFollowing("Levels");

            reader.ReadToFollowing("Level" + levelNumber);

            reader = reader.ReadSubtree();

            int rowIndex = 0;

            // read rows
            while (reader.ReadToFollowing("row"))
            {
                // read objects
                ReadObjects(reader.ReadSubtree());
                rowIndex++;
            }
            reader.Close();
        }
        public void ReadObjects(XmlReader reader)
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

                    //if we already have a enough marios just reset their positions
                    if(objValues[3] == "Sprint0.Mario" && GameObjectManager.Instance.marios.Count > i)
                    {
                        pos = Level.Instance.BlockToWorldSpace(pos);
                        GameObjectManager.Instance.marios[i].Reset(pos);
                    }
                    else {
                        Level.Instance.CreateObj(pos, objValues[3], objValues[4]);
                    }

                    //xPos += 1 to keep spawning objects to the right
                    xPos += 1;
                }
            }
            reader.Close();
        }
    }
}
