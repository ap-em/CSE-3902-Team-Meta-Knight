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
        /*TODO: convert sprites/positions to gameObjects*/

        private int maxRowLength = 1000;
        private int maxNumberOfRows = 100;
        private int[] rowLength = new int[100];

        private IGameObject[][] gameObjects = new IGameObject[100][];

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
        public Level()
        {
            //add space for gameObjects on each row
            for(int i = 0; i < maxNumberOfRows; i++)
            {
                gameObjects[i] = new IGameObject[maxRowLength];
            }
        }
        public void CreateObj(Vector2 position, int rowIndex, String objType, String spriteName)
        {
            
            Type t = Type.GetType(objType);
            Type[] types = { typeof(string), typeof(Vector2) };
            object[] param = { spriteName, position };

            ConstructorInfo constructorInfoObj = t.GetConstructor(types);


            gameObjects[rowIndex][rowLength[rowIndex]] = (IGameObject)constructorInfoObj.Invoke(param);

            GameObjectManager.Instance.AddToObjectList(gameObjects[rowIndex][rowLength[rowIndex]]);
            
            rowLength[rowIndex] += 1;
        }
        /* this Draw is for testing, this should be moved to gameObjectManager later */
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int row = 0; row < 100; row++)
            {
                for (int i = 0; i < rowLength[row]; i++)
                {
                    gameObjects[row][i].Draw(spriteBatch);
                }
            }
        }
        public void Update()
        {

        }
    }
}
