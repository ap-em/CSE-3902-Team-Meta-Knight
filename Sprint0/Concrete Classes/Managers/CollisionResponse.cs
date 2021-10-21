using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Sprint0
{
    /*
     * Uses a 2 level dictionary to return 
     */

    public class CollisionResponse
    {
        public Dictionary<String, ICommand> MoverResponse;
        public Dictionary<String, ICommand> TargetResponse;
        public CollisionResponse()
        {
            MoverResponse = new Dictionary<String, ICommand>();
            TargetResponse = new Dictionary<String, ICommand>();

            XmlReader reader = XmlReader.Create(Path.GetFullPath("Levels\\LevelsData.xml"));

            reader.ReadToFollowing("Levels");

          //  reader.ReadToFollowing("Level" + LevelNumber);

            reader = reader.ReadSubtree();

            int rowIndex = 0;

            // read rows
            while (reader.ReadToFollowing("row"))
            {
                // read objects
                ConstructDictionary(reader.ReadSubtree());
                rowIndex++;
            }
            reader.Close();

        }
        public void ConstructDictionary(XmlReader reader)
        {
            while (reader.ReadToFollowing("obj"))
            {
                //get strings
                String objString = reader.ReadElementContentAsString();
                String[] objValues = objString.Split(',');

                //convert strings to ints
                String keyVal = objValues[0];
                String m = objValues[1];
                String t = objValues[2];
                // Need to use reflection here to get the right value for the command
                Type mType = Type.GetType(m);
                Type tType = Type.GetType(t);
                Type[] types = { typeof(string), typeof(Vector2) };
                object[] param = { spriteName, position };

                ConstructorInfo constructorInfoObj = t.GetConstructor(types);

                //this should be changed in the future so that gameObjectManager holds blocks instead

                // add blocks to array
                if (objType.Equals("Sprint0.Blocks.Block"))
                {
                    gameObjects[rowLength[rowIndex]][rowIndex] = (IGameObject)constructorInfoObj.Invoke(param);
                }
                // add player, enemy, etc. to gameObject manager
                else
                {
                    GameObjectManager.Instance.AddToObjectList((IGameObject)constructorInfoObj.Invoke(param));
                }
                MoverResponse.Add(keyVal, mover);
                TargetResponse.Add(keyVal, target);
                // create the number of objects specified by the second field in the xml obj element
                for (int i = 0; i < numOfObj; i++)
                {
                    Vector2 pos = new Vector2(xPos, yPos);

                }
            }
            reader.Close();
        }
    }
}
