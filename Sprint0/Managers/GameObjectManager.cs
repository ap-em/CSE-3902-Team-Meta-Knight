using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Sprint0.UtilityClasses;



namespace Sprint0
{
    /*
     * Game object manager keeps track of all the game objects (moving, collision causing entities), in order to update and draw them all,
     * as well as taking care of detecting their collisions
     */
    public class GameObjectManager
    {
        private int maxRowLength = 1000;
        private int maxNumberOfRows = 100;
        private IBlock[][] staticGameObjects = new IBlock[1000][];
        //Scales dimensions of sprites for collision to accuratelly reflect their real size in game
        private static int dimensionScale = 2;

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
                    Game0.Instance.AddPlayerToList((IMario)go);
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
                if (go is IMario)
                {
                    Game0.Instance.RemovePlayerFromList((IMario)go);
                }
                if (go is ICollidable && collidableGameObjects.Contains((ICollidable)go))
                {
                    collidableGameObjects.Remove((ICollidable)go);
                }
                if (go is IDynamicBlock)
                {
   //                 staticGameObjects[(int)(go.Position.X / 32)][(int)(go.Position.Y / 32)] = null;
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
            RemoveObjects();
            foreach (IUpdate go in updateableGameObjects)
            {
                go.Update();
            }
            DetectCollisions(); 
        }
        public void DrawGameObjects(SpriteBatch spriteBatch)
        {
            if(Game0.Instance.currentDrawingMario != null)
            DrawStaticGameObjects(spriteBatch, Game0.Instance.currentDrawingMario.Position);
            
            foreach (IDraw go in drawableGameObjects)
            {
                go.Draw(spriteBatch);
            }
        }
        public void DrawStaticGameObjects(SpriteBatch spriteBatch, Vector2 position)
        {
            Texture2D background = Game0.Instance.Content.Load<Texture2D>("1-1");
            spriteBatch.Draw(background, new Rectangle(0, 0, 6450, 600), Color.White);
                
                 // used for debuging collidable objects around player
                 /*
                List<IBlock> b = GetCollidables(position, new Vector2(32, 48));

                for(int i = 0; i<b.Count;i++)
                {
                    if (b[i] != null)
                    {
                        b[i].Draw(spriteBatch);
                    }
                }
                 */
                
            
            position = Level.Instance.WorldToBlockSpace(position);
            int xPos = (int)position.X;
            int yPos = (int)position.Y;

                // draw only the blocks available on the screen
            for (int x = xPos - 25; x < xPos + 25; x++)
            {
                for (int y = yPos - 20; y < yPos + 20; y++)
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

            int width = (int)Math.Round(size.X / 32);
            int height = (int)Math.Round(size.Y / 32);

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

        public void DetectCollisions()
        {
            foreach (IMovable go in movableGameObjects)
            {
                LevelCollision(go);
                EntityCollision(go);
            }
        }

        /*Handles Level Collision for DetectCollisions method*/
        private void LevelCollision(IMovable go)
        {
            //Here for implementation of collisions when neccesary
            ICommand collision;
            //Get the surronding blocks of whatever the game object is as blocks are not added to the game object list on creation.
            List<IBlock> levelCollides = GetCollidables(new Vector2 ((int)Math.Round(go.Position.X), (int)Math.Round(go.Position.Y)), new Vector2(go.Sprite.width * dimensionScale, go.Sprite.height * dimensionScale));
            
            //Go through each colliding block
            foreach (IBlock block in levelCollides)
            {

                //set gravity if block below gameobject is null
                if (block == levelCollides[1] && levelCollides[1] == null)
                {
                    go.SetGrounded(false);
                }

                //Check if the block the object is colliding with actually exists
                if (block != null)
                {
                    //Create Rectangle for block and check to see if game object rectangle intersects with it
                    Rectangle blockRec = new Rectangle((int)Math.Round(block.Position.X), (int)Math.Round(block.Position.Y), block.Sprite.width * dimensionScale, block.Sprite.height * dimensionScale);
                    Rectangle goRec = new Rectangle((int)Math.Round(go.Position.X), (int)Math.Round(go.Position.Y), go.Sprite.width * dimensionScale, go.Sprite.height * dimensionScale);

                    if (goRec.Intersects(blockRec))
                    {
                        //Determine collision side based on how much it's intersecting in either dimension
                        String collisionSide =GameUtilities.emptyString;
                        Rectangle collisionRec = Rectangle.Intersect(goRec, blockRec);


                        if (collisionRec.Top == blockRec.Top)
                        {
                            collisionSide = GameUtilities.top;

                            /* we want it to prefer top of block when its moving downward */
                            /* to prevent falling through the ground */
                            if (!go.GetGrounded())
                            {
                                if (collisionRec.Width < collisionRec.Height - GameUtilities.bias)
                                {
                                    if (collisionRec.Right == blockRec.Right)
                                    {
                                        collisionSide = GameUtilities.right;
                                    }
                                    else
                                    {
                                        collisionSide = GameUtilities.left;
                                    }
                                }
                            }
                            else
                            {
                                if (collisionRec.Width < collisionRec.Height)
                                {
                                    if (collisionRec.Right == blockRec.Right)
                                    {
                                        collisionSide = GameUtilities.right;
                                    }
                                    else
                                    {
                                        collisionSide = GameUtilities.left;
                                    }
                                }
                            }
                        }
                        else if (collisionRec.Bottom == blockRec.Bottom)
                        {
                            collisionSide = GameUtilities.bottom;
                            if (!go.GetGrounded())
                            {
                                if (collisionRec.Width < collisionRec.Height - GameUtilities.bias)
                                {
                                    if (collisionRec.Right == blockRec.Right)
                                    {
                                        collisionSide = GameUtilities.right;
                                    }
                                    else
                                    {
                                        collisionSide = GameUtilities.left;
                                    }
                                }
                            }
                            else
                            {
                                if (collisionRec.Width < collisionRec.Height)
                                {
                                    if (collisionRec.Right == blockRec.Right)
                                    {
                                        collisionSide = GameUtilities.right;
                                    }
                                    else
                                    {
                                        collisionSide =  GameUtilities.left;
                                    }
                                }
                            }
                        }
                        else if (collisionRec.Right == blockRec.Right)
                        {
                            collisionSide = GameUtilities.right;
                        }
                        else if (collisionRec.Right == blockRec.Right)
                        {
                            collisionSide = GameUtilities.left;
                        }
                        //Create the correct collision command based on the block and the game object and the side its collding most with
                        collision = new CCollide((IGameObject)block, (IGameObject)go, collisionSide, collisionRec);
                        //Execute the correct response to interfering with personal space
                        collision.Execute();
                    }
                }
            }
        }

        private void EntityCollision(IMovable go)
        {
            //Here for implementation of collisions when neccesary
            ICommand collision;
            //Rectangle for go we are looking at
            Rectangle goRec = new Rectangle((int)go.Position.X, (int)go.Position.Y, go.Sprite.width*dimensionScale, go.Sprite.height*dimensionScale);
            //Check each entity in gameObjects
            foreach (ICollidable entity in collidableGameObjects)
            {
                if (!entity.Equals(go))
                {
                    //If the entity is within 5 heights of the game object we are looking at, check if it intersects
                    if(entity.Position.Y>(goRec.Y-goRec.Height*5) && entity.Position.Y < (goRec.Y+ goRec.Height*5))
                    {
                        //create an entity rec for the collision here so we don't use up time creating one for every possible entity
                        Rectangle entityRec = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, entity.Sprite.width*dimensionScale, entity.Sprite.height*dimensionScale);
                        //Do they collide?
                        if (goRec.Intersects(entityRec))
                        {
                            //Determine collision side based on how much it's intersecting in either dimension
                            String collisionSide = GameUtilities.emptyString;
                            Rectangle collisionRec = Rectangle.Intersect(goRec, entityRec);
                            if (collisionRec.Width >= collisionRec.Height)
                            {
                                if (collisionRec.Top == entityRec.Top)
                                {
                                    collisionSide = GameUtilities.top;
                                }
                                else
                                {
                                    collisionSide = GameUtilities.bottom;
                                }
                            }
                            else
                            {
                                if (collisionRec.Right == entityRec.Right)
                                {
                                    collisionSide = GameUtilities.right;
                                }
                                else
                                {
                                    collisionSide = GameUtilities.left;
                                }
                            }
                           
                            //Create the correct collision command based on the entity and the game object and the side its collding most with
                            collision = new CCollide((IGameObject)entity, (IGameObject)go, collisionSide,collisionRec);
                            //Execute the correct response to interfering with personal space
                            collision.Execute();
                        }
                    }
                }
            }
        }
    }
}
