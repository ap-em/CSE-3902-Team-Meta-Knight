using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0
{
    /*
     * Game object manager keeps track of all the game objects (moving, collision causing entities), in order to update and draw them all,
     * as well as taking care of detecting their collisions
     */
    public class GameObjectManager
    {
        public List<IProjectile> projectiles = new List<IProjectile>();
        public List<IProjectile> projectileRemovalQueue = new List<IProjectile>();
        public List<IProjectile> projectileInsertQueue = new List<IProjectile>();
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

        public void AddToObjectList(IGameObject gameObject)
        {
            gameObjectInsertQueue.Add(gameObject);
        }
        public void RemoveFromObjectList(IGameObject gameObject)
        {
            gameObjectRemovalQueue.Add(gameObject);
        }
        public void AddToProjectileList(IProjectile projectile)
        {
            projectileInsertQueue.Add(projectile);
        }
        public void RemoveFromProjectileList(IProjectile projectile)
        {
            projectileRemovalQueue.Add(projectile);
        }

        public void AddObjects()
        {
            foreach (IGameObject go in gameObjectInsertQueue)
            {
                gameObjects.Add(go);
            }
            foreach (IProjectile projectile in projectileInsertQueue)
            {
                projectiles.Add(projectile);
            }

            gameObjectInsertQueue.Clear();
            projectileInsertQueue.Clear();
        }
        public void RemoveObjects()
        {
            foreach (IGameObject go in gameObjectRemovalQueue)
            {
                gameObjects.Remove(go);
            }
            foreach (IProjectile projectile in projectileRemovalQueue)
            {
                projectiles.Remove(projectile);
            }

            gameObjectRemovalQueue.Clear();
            projectileRemovalQueue.Clear();
        }
        public void UpdateGameObjects()
        {
            AddObjects();
            RemoveObjects();
            foreach (IGameObject go in gameObjects)
            {
                go.Update();
            }
            foreach(IProjectile projectile in projectiles)
            {
                projectile.Update();
            }
        }
        
        public void DrawGameObjects(SpriteBatch spriteBatch)
        {
            foreach (IGameObject go in gameObjects)
            {
                if (go.ToString().Equals("Sprint0.Mario"))
                {
                    //draw the surround blocks around mario
                    Level.Instance.Draw(spriteBatch, go.Position);
                }
                go.Draw(spriteBatch);
            }
            foreach(IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        public void DetectCollisions()
        {
            
            foreach (IGameObject go in gameObjects)
            {
                /*
                 * Here, use the gameobjects position and possibly sprite (size?) data to see if they collide with anything
                 * This should be done by passing this info to a map manager type class that has position to block type data
                 * 
                 * If there is a collision we should have a data table with commands similar to what was shown in lecture, 
                 * we can then use reflection to create these commands and execute them.
                 */
                //Handles collision with the level as it differs somewhat to other collisions
                LevelCollision(go);

                //Non-block collisions should be working based on wheather the object is within a certain height first,
                //essentially basing it on rows
                EntityCollision(go);
                
            }
        }

        /*Handles Level Collision for DetectCollisions method*/
        private void LevelCollision(IGameObject go)
        {
            //Here for implementation of collisions when neccesary
            ICommand collision;
            //Get the surronding blocks of whatever the game object is as blocks are not added to the game object list on creation.
            IGameObject[] levelCollides = Level.Instance.GetCollidables(go.Position);
            Rectangle goRec = new Rectangle(new Point((int)go.Position.X, (int)go.Position.Y), new Point(go.Sprite.width, go.Sprite.height));
            //Go through each colliding block
            foreach (IGameObject block in levelCollides)
            {
                //Check if the block the object is colliding with actually exists
                if (block != null)
                {
                    //Create Rectangle for block and check to see if game object rectangle intersects with it
                    Rectangle blockRec = new Rectangle(new Point((int)block.Position.X, (int)block.Position.Y), new Point(block.Sprite.width, block.Sprite.height));
                    if (goRec.Intersects(blockRec))
                    {
                        //Determine collision side based on how much it's intersecting in either dimension
                        String collisionSide ="";
                        Rectangle collisionRec = Rectangle.Intersect(goRec, blockRec);
                        if (collisionRec.X <= collisionRec.Y)
                        {
                            if (collisionRec.Top == blockRec.Top)
                            {
                                collisionSide = "Top";
                            }
                            else
                            {
                                collisionSide = "Bottom";
                            }
                        }
                        else
                        {
                            if (collisionRec.Right == blockRec.Right)
                            {
                                collisionSide = "Right";
                            }
                            else
                            {
                                collisionSide = "Left";
                            }
                        }
                        
                        //Create the correct collision command based on the block and the game object and the side its collding most with
                        collision = new CCollide(block, go, collisionSide);
                        //Execute the correct response to interfering with personal space
                        collision.Execute();
                    }


                }
            }
        }

        private void EntityCollision(IGameObject go)
        {
            //Here for implementation of collisions when neccesary
            ICommand collision;
            //Rectangle for go we are looking at
            Rectangle goRec = new Rectangle(new Point((int)go.Position.X, (int)go.Position.Y), new Point(go.Sprite.width, go.Sprite.height));
            //Check each entity in gameObjects
            foreach (IGameObject entity in gameObjects)
            {
                if (!entity.Equals(go))
                {
                    //If the entity is within 10 heights of the game object we are looking at, check if it intersects
                    if(entity.Position.Y>(goRec.Y+goRec.Height*5) && entity.Position.Y < (goRec.Y+ goRec.Height*5))
                    {
                        //create an entity rec for the collision here so we don't use up time creating one for every possible entity
                        Rectangle entityRec = new Rectangle(new Point((int)entity.Position.X, (int)entity.Position.Y), new Point(entity.Sprite.width, entity.Sprite.height));
                        //Do they collide?
                        if (goRec.Intersects(entityRec))
                        {
                            //Determine collision side based on how much it's intersecting in either dimension
                            String collisionSide = "";
                            Rectangle collisionRec = Rectangle.Intersect(goRec, entityRec);
                            if (collisionRec.X <= collisionRec.Y)
                            {
                                if (collisionRec.Top == entityRec.Top)
                                {
                                    collisionSide = "Top";
                                }
                                else
                                {
                                    collisionSide = "Bottom";
                                }
                            }
                            else
                            {
                                if (collisionRec.Right == entityRec.Right)
                                {
                                    collisionSide = "Right";
                                }
                                else
                                {
                                    collisionSide = "Left";
                                }
                            }
                           
                            //Create the correct collision command based on the entity and the game object and the side its collding most with
                            collision = new CCollide(entity, go, collisionSide);
                            //Execute the correct response to interfering with personal space
                            collision.Execute();
                        }
                    }
                }
            }

        }
        public void RemoveAllObjects()
        {
            gameObjectRemovalQueue.Clear();
            projectileRemovalQueue.Clear();
            foreach(IGameObject go in gameObjects)
            {
                gameObjectRemovalQueue.Add(go);
            }
            foreach(IProjectile projectile in projectiles)
            {
                projectileRemovalQueue.Add(projectile);
            }
        }
    }

   
}
