using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using Sprint0.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Sprint0
{

    sealed public class CollisionDetection
    {
        private static CollisionDetection instance;
        public static CollisionDetection Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new CollisionDetection();

                }
                return instance;
            }
        }
        public CollisionDetection()
        {

        }
        public void DetectCollisions()
        {
            // list of collidables to get rid of double checking collisions
            // collidable gets removed after first check
            List<ICollidable> collidables = new List<ICollidable>();
            collidables.AddRange(GameObjectManager.Instance.collidableGameObjects);
            foreach (IMovable go in GameObjectManager.Instance.movableGameObjects)
            {
                collidables.Remove((ICollidable)go);
                LevelCollision(go);
                EntityCollision(go, collidables);
            }
        }

        /*Handles Level Collision for DetectCollisions method*/
        private void LevelCollision(IMovable go)
        {
            //Get the surronding blocks of whatever the game object is as blocks are not added to the game object list on creation.
            List<IBlock> levelCollides = GameObjectManager.Instance.GetCollidables(new Vector2((int)Math.Round(go.Position.X), (int)Math.Round(go.Position.Y)), new Vector2(go.Sprite.width * GameUtilities.dimensionScale, go.Sprite.height * GameUtilities.dimensionScale));

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
                    Rectangle blockRec = new Rectangle((int)Math.Round(block.Position.X), (int)Math.Round(block.Position.Y), block.Sprite.width * GameUtilities.dimensionScale, block.Sprite.height * GameUtilities.dimensionScale);
                    Rectangle goRec = new Rectangle((int)Math.Round(go.Position.X), (int)Math.Round(go.Position.Y), go.Sprite.width * GameUtilities.dimensionScale, go.Sprite.height * GameUtilities.dimensionScale);

                    if (goRec.Intersects(blockRec))
                    {
                        //Determine collision side based on how much it's intersecting in either dimension
                        String collisionSide = GameUtilities.emptyString;
                        Rectangle collisionRec = Rectangle.Intersect(goRec, blockRec);

                        if (!go.GetGrounded())
                        {
                            collisionSide = GetInAirCollision(collisionRec, blockRec);
                        }
                        else
                        {
                            collisionSide = GetGroundedCollision(collisionRec, blockRec);
                        }

                        CollisionResponse.Instance.CollisionOccurrence((IGameObject)go, (IGameObject)block, collisionSide, collisionRec);
                    }
                }
            }
        }

        private void EntityCollision(IMovable go, List<ICollidable> collidables)
        {
            //Rectangle for go we are looking at
            Rectangle goRec = new Rectangle((int)go.Position.X, (int)go.Position.Y, go.Sprite.width * GameUtilities.dimensionScale, go.Sprite.height * GameUtilities.dimensionScale);
            //Check each entity in gameObjects
            foreach (ICollidable entity in collidables)
            {
                Rectangle entityRec = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, entity.Sprite.width * GameUtilities.dimensionScale, entity.Sprite.height * GameUtilities.dimensionScale);
 
                //Do they collide?
                if (goRec.Intersects(entityRec))
                {
                    Rectangle collisionRec = Rectangle.Intersect(goRec, entityRec);

                    String collisionSide = GetGroundedCollision(collisionRec, entityRec);

                    CollisionResponse.Instance.CollisionOccurrence((IGameObject)go, (IGameObject)entity, collisionSide, collisionRec);

                }
            }
        }
        public String GetGroundedCollision(Rectangle collisionRec, Rectangle entityRec)
        {
            String collisionSide = GameUtilities.emptyString;
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
            return collisionSide;
        }
        public String GetInAirCollision(Rectangle collisionRec, Rectangle entityRec)
        {
            String collisionSide = GameUtilities.emptyString;
            if (collisionRec.Width >= collisionRec.Height - GameUtilities.bias)
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
            return collisionSide;
        }
    }
}