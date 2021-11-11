using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Sprint0.UtilityClasses;
using Sprint0.Controllers;
namespace Sprint0
{
    /*
     * Game object manager keeps track of all the game objects (moving, collision causing entities), in order to update and draw them all,
     * as well as taking care of detecting their collisions
     */
    sealed public class GameObjectManager
    {
        private int maxRowLength = 1000;
        private int maxNumberOfRows = 100;
        private IBlock[][] staticGameObjects = new IBlock[1000][];
        public List<IMario> marios = new List<IMario>();
        public List<ICollidable> collidableGameObjects = new List<ICollidable>();
        public List<IDraw> drawableGameObjects= new List<IDraw>();
        public List<IUpdate> updateableGameObjects = new List<IUpdate>();
        public List<IMovable> movableGameObjects = new List<IMovable>();
        public List<IGameObject> gameObjects = new List<IGameObject>();
        public List<IGameObject> gameObjectRemovalQueue = new List<IGameObject>();
        public List<IGameObject> gameObjectInsertQueue = new List<IGameObject>();
        private static GameObjectManager instance;
        public static GameObjectManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObjectManager();
                }
                return instance;
            }
        }
        public GameObjectManager()
        {
            //add space for static objects on each row
            for (int i = 0; i < maxRowLength; i++)
            {
                staticGameObjects[i] = new IBlock[maxNumberOfRows];
            }
        }
        public void AddToObjectList(IGameObject gameObject, int column, int row)
        {
            //add static gameObjects to array
            if(gameObject is IBlock)
            {
                staticGameObjects[column][row] = (IBlock)gameObject;

                if(gameObject is IDynamicBlock)
                    gameObjectInsertQueue.Add(gameObject);
            }
            else
            {
                //add gameObjects to list
                gameObjectInsertQueue.Add(gameObject);
            }
        }
        public void RemoveFromObjectList(IGameObject gameObject)
        {
            gameObjectRemovalQueue.Add(gameObject);
            
        }

        public void AddObjects()
        {
            foreach (IGameObject go in gameObjectInsertQueue)
            {
                if (go is IMovable)
                {
                    movableGameObjects.Add((IMovable)go);
                }
                if(go is IDraw)
                {
                    drawableGameObjects.Add((IDraw)go);
                }
                if(go is IUpdate)
                {
                    updateableGameObjects.Add((IUpdate)go);
                }
                if (go is IMario)
                {
                    marios.Add((IMario)go);
                }
                // need this because dynamic blocks collide in level collision not entity collision
                if (go is ICollidable && !(go is IDynamicBlock))
                {
                    collidableGameObjects.Add((ICollidable)go);
                }
                gameObjects.Add(go);
            }

            gameObjectInsertQueue.Clear();
        }
        public void RemoveObjects()
        {
            foreach (IGameObject go in gameObjectRemovalQueue)
            {
                if(go is IMovable && movableGameObjects.Contains((IMovable)go))
                {
                    movableGameObjects.Remove((IMovable)go);
                }
                if (go is IDraw && drawableGameObjects.Contains((IDraw)go))
                {
                    drawableGameObjects.Remove((IDraw)go);
                }
                if (go is IUpdate && updateableGameObjects.Contains((IUpdate)go))
                {
                    updateableGameObjects.Remove((IUpdate)go);
                }
                if (go is IMario && marios.Contains((IMario)go))
                {
                    marios.Remove((IMario)go);
                }
                if (go is ICollidable && collidableGameObjects.Contains((ICollidable)go))
                {
                    collidableGameObjects.Remove((ICollidable)go);
                }
                gameObjects.Remove(go);
            }

            gameObjectRemovalQueue.Clear();
        }
        public void RemoveAllObjects()
        {
            gameObjectRemovalQueue.Clear();
            foreach (IGameObject go in gameObjects)
            {
                gameObjectRemovalQueue.Add(go);
            }
            for (int i = 0; i < maxNumberOfRows; i++)
            {
                Array.Clear(staticGameObjects[i], 0, staticGameObjects[i].Length);
            }
        }
        public void UpdateGameObjects()
        {
            AddObjects();
            foreach (IUpdate go in updateableGameObjects)
            {
                go.Update();
            }
            CollisionDetection.Instance.DetectCollisions();
            RemoveObjects();
        }
        public void DrawGameObjects(SpriteBatch spriteBatch)
        {   
            foreach (IDraw go in drawableGameObjects)
            {
                go.Draw(spriteBatch);
            }
        }
        public void DrawStaticGameObjects(SpriteBatch spriteBatch, ICamera camera)
        {

            Vector2 position = Level.Instance.WorldToBlockSpace(camera.GetPosition());
            int xPos = (int)position.X;
            int yPos = (int)position.Y;


            Viewport viewport = camera.GetViewport();

            //viewport divided by block size = how many blocks we can have on screen
            // +1 to draw one outside of screen space
            viewport.Width /= 32;
            viewport.Width++;
            viewport.Height /= 32;
            viewport.Height++;


                // draw only the blocks available on the screen
            for (int x = xPos; x < xPos + viewport.Width; x++)
            {
                for (int y = yPos; y < yPos + viewport.Height; y++)
                {
                    //make sure object is bounds of array
                    if (x < 0) x = 0;
                    else if (x > 998) x = 998;
                    if (y < 0) y = 0;
                    else if (y > 99) y = 99;
                    if (staticGameObjects[x][y] != null)
                    {
                        //dynamic blocks get drawn from drawable list
                        if(!(staticGameObjects[x][y] is IDynamicBlock))
                        staticGameObjects[x][y].Draw(spriteBatch);
                    }
                }
            }
        }
        public List<IBlock> GetCollidables(Vector2 position, Vector2 size)
        {
            int width = (int)(size.X / 32);
            int height = (int)(size.Y / 32);

            if (width == 0)
            {
                width = 1;
            }
            if (height == 0)
            {
                height = 1;
            }


            position = Level.Instance.WorldToBlockSpace(position);

            /*stay in bounds of array*/
            if (position.X - width < 1)
            {
                position.X = width;
            }
            if (position.Y - height < 1)
            {
                position.Y = height;
            }


            List<IBlock> blocks = new List<IBlock>();


            //add blocks directly above and below object

            blocks.Add(staticGameObjects[(int)Math.Round(position.X)][(int)Math.Round(position.Y - 1)]);
             blocks.Add(staticGameObjects[(int)Math.Round(position.X)][(int)Math.Round(position.Y + height)]);

            //add blocks to the left and right of object

            int xIndex = -1;
            int yIndex = height;
            while (xIndex <= width)
            {
                if (xIndex != 0)
                {
                    yIndex = height;
                    while (yIndex > -1)
                    {
                        blocks.Add(staticGameObjects[(int)Math.Round(position.X + xIndex)][(int)Math.Round(position.Y + yIndex)]);
                        yIndex--;
                    }
                }
                xIndex++;
            }

            //if a dynamic block isnt being drawn then dont collide
            for(int i = 0; i<blocks.Count;i++)
            {
                if(blocks[i] is IDynamicBlock && !drawableGameObjects.Contains((IDraw)blocks[i]))
                {
                    blocks[i] = null;
                }
            }


            return blocks;
        }
    }
}
