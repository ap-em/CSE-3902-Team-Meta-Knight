using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Blocks;
using Sprint0.Enemies;
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
        private int maxRowLength = 1000;
        private int maxNumberOfRows = 100;
        private int[] rowLength = new int[100];

        private IGameObject[][] gameObjects = new IGameObject[1000][];

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
            for(int i = 0; i < maxRowLength; i++)
            {
                gameObjects[i] = new IGameObject[maxNumberOfRows];
            }
        }
        public void CreateObj(Vector2 position, String objType, String spriteName)
        {
            int rowIndex = (int)position.Y;
            int columnIndex = (int)position.X;
            position = BlockToWorldSpace(position);

            Type t = Type.GetType(objType);
            Type[] types = { typeof(string), typeof(Vector2) };
            object[] param = { spriteName, position };

            ConstructorInfo constructorInfoObj = t.GetConstructor(types);

            //this should be changed in the future so that gameObjectManager holds blocks instead
            //GameObjectManager.Instance.AddToObjectList((IGameObject)constructorInfoObj.Invoke(param));
            // add blocks to array
           if (objType.Equals("Sprint0.Blocks.Block"))
            {
                gameObjects[columnIndex][rowIndex] = (IGameObject)constructorInfoObj.Invoke(param);
            }
            // add player, enemy, etc. to gameObject manager
            else
            {
               GameObjectManager.Instance.AddToObjectList((IGameObject)constructorInfoObj.Invoke(param));
            } 

        }
        //draws all the blocks that player should be able to see
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            
            position = WorldToBlockSpace(position);

            int xPos = (int)position.X;
            int yPos = (int)position.Y;

            // draw only the blocks available on the screen
            for(int x = xPos - 25; x < xPos+25; x++)
            {
                for (int y = yPos - 20; y < yPos + 20; y++)
                {
                    //make sure object is bounds of array
                    if (x < 0) x = 0;
                    else if (x > 998) x = 998;
                    if (y < 0) y = 0;
                    else if (y > 99) y = 99;
                    if (gameObjects[x][y] != null)
                    {
                        gameObjects[x][y].Draw(spriteBatch);
                    }
                }
            }
            
            
        }
        //returns the gameobjects that the are collidable from the given position
        public IGameObject[] GetCollidables(Vector2 position, Vector2 size)
        {


            int width = (int)Math.Round(size.X / 32);
            int height = (int)Math.Round(size.Y / 32);

            if(width == 0)
            {
                width = 1;
            }
            if(height == 0)
            {
                height = 1;
            }


            position = WorldToBlockSpace(position);

            IGameObject[] blocks = new IGameObject[8];

            // 99 rows and 999 columns
            if (position.Y < 1) position.Y = 1;
            else if (position.Y > 98) position.Y = 99;
            if (position.X < 1) position.X = 1;
            else if (position.X > 998) position.X = 998;

            blocks[0] = gameObjects[(int)Math.Round(position.X - width)][(int)Math.Round(position.Y + height)];
            blocks[1] = gameObjects[(int)Math.Round(position.X)][(int)Math.Round(position.Y + height)];
            blocks[2] = gameObjects[(int)Math.Round(position.X + width)][(int)Math.Round(position.Y + height)];
            blocks[3] = gameObjects[(int)Math.Round(position.X - width)][(int)Math.Round(position.Y)];
            blocks[4] = gameObjects[(int)Math.Round(position.X + width)][(int)Math.Round(position.Y)];
            blocks[5] = gameObjects[(int)Math.Round(position.X - width)][(int)Math.Round(position.Y - height)];
            blocks[6] = gameObjects[(int)Math.Round(position.X)][(int)Math.Round(position.Y - height)];
            blocks[7] = gameObjects[(int)Math.Round(position.X + 1)][(int)Math.Round(position.Y - height)];
            
            return blocks;
        }
        public Vector2 WorldToBlockSpace(Vector2 position)
        {
            return new Vector2(position.X / 32, position.Y / 32);
        }
        public Vector2 BlockToWorldSpace(Vector2 pos)
        {
            return new Vector2(pos.X * 32, pos.Y * 32);
        }
        public void Reset()
        {
            for (int i = 0; i < maxNumberOfRows; i++)
            {
                Array.Clear(gameObjects[i], 0, gameObjects[i].Length);
                rowLength[i] = 0;
            }
            /*
            for (int i = 0; i < maxRowLength; i++)
            {
                gameObjects[i] = new IGameObject[maxNumberOfRows];
            }
            */
            LevelFactory.Instance.CreateLevel(1);
        }
    }
}
