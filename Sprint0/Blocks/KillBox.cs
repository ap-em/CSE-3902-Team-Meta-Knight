using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.UtilityClasses;
using System;

namespace Sprint0.Blocks
{
    class KillBox : IGameObject, ICollidable
    {
        //Killbox's location and value should be set based on level data and never moved
        private Vector2 location = new Vector2(GameUtilities.initialBlockPosX, GameUtilities.initialBlockPosY);
        public Vector2 Position { get => location; set => location=value; }
        //Killbox needs a sprite to implement game object and icollidable, this should never be used
        public ISprite Sprite => throw new NotImplementedException();

        public void Draw(SpriteBatch spriteBatch)
        {
            //Kill Box should never be drawn, if this is being used something is going wrong with GameObjectManager
        }
        //enemy kill overload, should insta kill the enemy, called when colliding with the enemy
        public void Kill(IEnemy enemy)
        {

        }
        //Mario kill overload, should insta kill mario, called when colliding with mario
        public void Kill(IMario mario)
        {

        }



    }
}
