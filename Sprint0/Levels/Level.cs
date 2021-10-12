using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Blocks;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using System.IO;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0
{
    class Level
    {
        //change this to a list of gameobject later
        private Vector2[] positions = new Vector2[100];
        private IGameObject[] gameObjects = new IGameObject[100];
        private int numOfObjects = 0;

        private static Level instance;
        public static Level Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new Level();

                }
                return instance;
            }
        }
        public void CreateObj(Vector2 position, String objType, String spriteName)
        {
            //CHANGE THIS TO NOT USE SPRINT0.BLOCKS.
            Type t = Type.GetType("Sprint0.Blocks." + objType);
            Type[] types = { typeof(string), typeof(Vector2) };
            object[] param = { spriteName };

            ConstructorInfo constructorInfoObj = t.GetConstructor(types);


            gameObjects[numOfObjects] = (IGameObject)constructorInfoObj.Invoke(param);
            gameObjects[numOfObjects].position = position;

            GameObjectManager.Instance.AddToObjectList(this);

            numOfObjects++;
        }
        /* this Draw is for testing, this should be moved to gameObjectManager later */
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < numOfObjects; i++)
            {
                gameObjects[i].Draw(spriteBatch);
            }
        }
        public void Update()
        {

        }
    }
}
