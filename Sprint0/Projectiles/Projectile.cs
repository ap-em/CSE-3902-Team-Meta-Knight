using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Enemies;
using Microsoft.Xna.Framework.Graphics;


/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0
{
    public class Projectile : IProjectile
    {
        private int fuseTime;
        private ISprite sprite;
        private int XVelocity;
        private int YVelocity;
        private Vector2 location;
        public Projectile(ISprite sprite, 
            Vector2 location, int XVelocity, int YVelocity, int fuseTime)
        {
            this.sprite = sprite;
            this.XVelocity = XVelocity;
            this.YVelocity = YVelocity;
            this.fuseTime = fuseTime;
            this.location = location;
        }
        public int GetFuseTime()
        {
            return fuseTime;
        }
        public void Move()
        {
            location = new Vector2(location.X + XVelocity, location.Y + YVelocity);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Update()
        {
            fuseTime--;
        }
    }
}
