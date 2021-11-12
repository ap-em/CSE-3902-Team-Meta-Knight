using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.UtilityClasses;
using System;

namespace Sprint0.Blocks
{
    class KillBox : IGameObject, ICollidable, IKillBox
    {
        private ISprite sprite;
        private String spriteName;
        //Killbox's location and value should be set based on level data and never moved
        private Vector2 location = new Vector2(GameUtilities.initialBlockPosX, GameUtilities.initialBlockPosY);
        public Vector2 Position { get => location; set => location=value; }
        //Killbox needs a sprite to implement game object and icollidable
        public ISprite Sprite => sprite;
        public KillBox(string spriteName, Vector2 position)
        {
            location = position;
            this.spriteName = spriteName;
            sprite = SpriteFactory.Instance.GetSprite(spriteName);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Kill Box should never be drawn, if this is being used something is going wrong with GameObjectManager
        }
        //enemy kill overload, should insta kill the enemy, called when colliding with the enemy
        public void Kill(IEnemy enemy)
        {
            enemy.InstantDeath();
        }
        //Mario kill overload, should insta kill mario, called when colliding with mario
        public void Kill(IMario mario)
        {
            mario.InstantDeath();
        }
    }
}
