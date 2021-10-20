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
            //Here for implementation of collisions when neccesary
            ICommand collision;
            foreach (IGameObject go in gameObjects)
            {
                /*
                 * Here, use the gameobjects position and possibly sprite (size?) data to see if they collide with anything
                 * This should be done by passing this info to a map manager type class that has position to block type data
                 * 
                 * If there is a collision we should have a data table with commands similar to what was shown in lecture, 
                 * we can then use reflection to create these commands and execute them.
                 */
                //Get the surronding blocks of whatever the game object is.
                IGameObject[] levelCollides = Level.Instance.GetCollidables(go.Position);
                Rectangle goRec = new Rectangle(new Point((int)go.Position.X, (int)go.Position.Y), new Point(16, 16));
                //Go through each colliding block
                foreach (IGameObject block in levelCollides)
                {
                    //Check if the block the object is colliding with actually exists
                    if(block != null)
                    {
                        Rectangle blockRec = new Rectangle(new Point((int)block.Position.X, (int)block.Position.Y), new Point(14, 14));
                        if (goRec.Intersects(blockRec))
                        {
                            collision = new CCollide(block,go);
                        }


                    }
                }
                /*blocks[0] = gameObjects[(int)Math.Round(position.X - 1)][(int)Math.Round(position.Y + 1)];
            blocks[1] = gameObjects[(int)Math.Round(position.X)][(int)Math.Round(position.Y + 1)];
            blocks[2] = gameObjects[(int)Math.Round(position.X + 1)][(int)Math.Round(position.Y + 1)];
            blocks[3] = gameObjects[(int)Math.Round(position.X - 1)][(int)Math.Round(position.Y)];
            blocks[4] = gameObjects[(int)Math.Round(position.X + 1)][(int)Math.Round(position.Y)];
            blocks[5] = gameObjects[(int)Math.Round(position.X - 1)][(int)Math.Round(position.Y - 1)];
            blocks[6] = gameObjects[(int)Math.Round(position.X)][(int)Math.Round(position.Y - 1)];
            blocks[7] = gameObjects[(int)Math.Round(position.X + 1)][(int)Math.Round(position.Y - 1)];*/
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
