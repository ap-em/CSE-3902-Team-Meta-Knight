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
using Sprint0.Levels;


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
        public int currentLevel = 2;
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
            StartTheme();
            SetupReader(levelNumber);
            switch (levelNumber){
                 case 1:
                    Background.Instance.ChangeBackground("1-1", new Rectangle(0, 0, 6750, 600));
                    break;
                case 2:
                    Background.Instance.ChangeBackground("Very_Black_screen", new Rectangle(-1000, -1000, 6000, 6000));
                    break;
            }
               

        }
        public void StartTheme()
        {
            // can possibly make xml later to create sound based on levelNumber
            soundInfo.StopLoopedSound(currentSoundtrack);
            soundInfo.PlaySound(currentSoundtrack, true);
        }
        public void StopTheme()
        {
            /*
             * If we ever have more sounds played by this sound info, this might be changed to
             * stop all sounds.
             */
            soundInfo.StopLoopedSound(currentSoundtrack);
        }
        public void SetupReader(int levelNumber)
        {
            currentLevel = levelNumber;

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
                
                int xSpawnPoints = Convert.ToInt32(objValues[2]);
                int ySpawnPoints = Convert.ToInt32(objValues[3]);

                String objType = objValues[4];
                String spriteName = objValues[5];


                //start spawning at xPos end at xPos + number of spawn points
                for(int x = xPos; x < xPos + xSpawnPoints; x++)
                {
                    SpawnObject(x, yPos, objType, spriteName);
                }
                //start spawning at yPos end at yPos + number of spawn points
                for (int y = yPos; y < yPos + ySpawnPoints; y++)
                {
                    SpawnObject(xPos, y, objType, spriteName);
                }
            }
            reader.Close();
        }
        public void SpawnObject(int xPos, int yPos, String objType, String spriteName)
        {
            Vector2 pos = new Vector2(xPos, yPos);

            //if we already have a enough marios just reset their position
            if (objType == "Sprint0.Mario" && GameObjectManager.Instance.marios.Count > 0)
            {
                pos = Level.Instance.BlockToWorldSpace(pos);
                GameObjectManager.Instance.marios[0].Reset(pos);
            }
            else
            {
                Level.Instance.CreateObj(pos, objType, spriteName);
            }
        }
    }
}
