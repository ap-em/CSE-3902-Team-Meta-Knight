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
using Sprint0.UtilityClasses;


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
        private int maxRowLength = GameUtilities.maxRowLength;
        private int maxNumberOfRows = GameUtilities.maxNumberOfRows;

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
            /*
             * used for debuging collidable objects around player
            IGameObject[] b = GetCollidables(position, new Vector2(32, 64));

            for(int i = 0; i<b.Length;i++)
            {
                if (b[i] != null)
                {
                    b[i].Draw(spriteBatch);
                }
            }
            */

            
            position = WorldToBlockSpace(position);

            int xPos = (int)position.X;
            int yPos = (int)position.Y;

            // draw only the blocks available on the screen
            for(int x = xPos - GameUtilities.blockOnScreenX; x < xPos+GameUtilities.blockOnScreenX; x++)
            {
                for (int y = yPos - GameUtilities.blockOnScreenY; y < yPos + GameUtilities.blockOnScreenY; y++)
                {
                    //make sure object is bounds of array
                    if (x < 0) x = 0;
                    else if (x > GameUtilities.boundryX) x = GameUtilities.boundryX;
                    if (y < 0) y = 0;
                    else if (y >  GameUtilities.boundryY) y =  GameUtilities.boundryY;
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

            int width = (int)Math.Round(size.X / GameUtilities.worldSpacesScale);
            int height = (int)Math.Round(size.Y / GameUtilities.worldSpacesScale);

            if(width == 0)
            {
                width = 1;
            }
            if(height == 0)
            {
                height = 1;
            }


            position = WorldToBlockSpace(position);

            /*stay in bounds of array*/
            if (position.X - width < 1)
            {
                position.X = width;
            }
            if (position.Y - height < 1)
            {
                position.Y = height;
            }


            IGameObject[] blocks = new IGameObject[8];

            /*check blocks 1 above and y + height to check below objects feet*/


            blocks[0] = gameObjects[(int)Math.Round(position.X - width)][(int)Math.Round(position.Y + height)];
            blocks[1] = gameObjects[(int)Math.Round(position.X)][(int)Math.Round(position.Y + height)];
            blocks[2] = gameObjects[(int)Math.Round(position.X + width)][(int)Math.Round(position.Y + height)];
            blocks[3] = gameObjects[(int)Math.Round(position.X - width)][(int)Math.Round(position.Y)];
            blocks[4] = gameObjects[(int)Math.Round(position.X + width)][(int)Math.Round(position.Y)];
            blocks[5] = gameObjects[(int)Math.Round(position.X - width)][(int)Math.Round(position.Y - 1)];
            blocks[6] = gameObjects[(int)Math.Round(position.X)][(int)Math.Round(position.Y - 1)];
            blocks[7] = gameObjects[(int)Math.Round(position.X + 1)][(int)Math.Round(position.Y - 1)];
            
            return blocks;
        }
        public IGameObject[] GetBlocksToLeft(Vector2 position, int width)
        {
            IGameObject[] blocks = new IGameObject[3];

            blocks[0] = gameObjects[(int)Math.Round(position.X - width)][(int)Math.Round(position.Y - 1)];
            blocks[1] = gameObjects[(int)Math.Round(position.X - width)][(int)Math.Round(position.Y)];
            blocks[2] = gameObjects[(int)Math.Round(position.X - width)][(int)Math.Round(position.Y + 1)];

            return blocks;
        }
        public IGameObject[] GetBlocksToRight(Vector2 position, int width)
        {
            IGameObject[] blocks = new IGameObject[3];

            blocks[0] = gameObjects[(int)Math.Round(position.X + width)][(int)Math.Round(position.Y - 1)];
            blocks[1] = gameObjects[(int)Math.Round(position.X + width)][(int)Math.Round(position.Y)];
            blocks[2] = gameObjects[(int)Math.Round(position.X + width)][(int)Math.Round(position.Y + 1)];

            return blocks;
        }
        public Vector2 WorldToBlockSpace(Vector2 position)
        {
            return new Vector2((int)Math.Round(position.X / GameUtilities.worldSpacesScale), (int)Math.Round(position.Y / GameUtilities.worldSpacesScale));
        }
        public Vector2 BlockToWorldSpace(Vector2 pos)
        {
            return new Vector2(pos.X * GameUtilities.worldSpacesScale, pos.Y *GameUtilities.worldSpacesScale );
        }
        public void Reset()
        {
            for (int i = 0; i < maxNumberOfRows; i++)
            {
                Array.Clear(gameObjects[i], 0, gameObjects[i].Length);
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
