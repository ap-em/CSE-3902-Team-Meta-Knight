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

        public List<IGameObject> gameObjects = new List<IGameObject>();
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
            gameObjects.Add(gameObject);
        }
        public void RemoveFromObjectList(IGameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }

        public void UpdateGameObjects()
        {
            foreach (IGameObject go in gameObjects)
            {
                go.Update();
            }
        }
        
        public void DrawGameObjects(SpriteBatch spriteBatch)
        {
            foreach (IGameObject go in gameObjects)
            {
                if (go.ToString().Equals("Sprint0.Link"))
                {
                    Level.Instance.Draw(spriteBatch, go.Position);
                }
                go.Draw(spriteBatch);
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
    }
}
