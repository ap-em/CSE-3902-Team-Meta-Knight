using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Enemies;
using Microsoft.Xna.Framework.Graphics;

/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0
{
    public class Projectile : IProjectile, IGameObject, IDraw, IUpdate, IMovable, ICollidable, IBounce
    {
        private int fuseTime;
        private ISprite sprite;
        private float XVelocity;
        private float YVelocity;
        private Vector2 position;
        private bool grounded = false;
        private float gravity = 5f;
        public Vector2 Position { get => this.position; set => throw new NotImplementedException(); }

        public ISprite Sprite => sprite;
        public Projectile(ISprite sprite, 
            Vector2 location, float XVelocity, float YVelocity, int fuseTime)
        {
            this.sprite = sprite;
            this.XVelocity = XVelocity;
            this.YVelocity = YVelocity;
            this.fuseTime = fuseTime;
            this.position = location;
        }
        public int GetFuseTime()
        {
            return fuseTime;
        }
        public bool GetGrounded()
        {
            return grounded;
        }
        public void SetGrounded(bool grounded)
        {
            this.grounded = grounded;
        }
        public void Move()
        {
            if(!grounded)
            {
                position = new Vector2(position.X + XVelocity, position.Y + YVelocity + gravity);
            }
            else 
            {
                position = new Vector2(position.X + XVelocity, position.Y + YVelocity);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
        public void UpBounce(Rectangle rec)
        {
            position = new Vector2(position.X, position.Y - rec.Height);
            //lower velocity and inverse direction
            YVelocity = (YVelocity + 0.5f) * -1;
        }
        public void Update()
        {
            Move();
            if (fuseTime < 0) GameObjectManager.Instance.RemoveFromObjectList(this);
            fuseTime--;
        }

        public void DownBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void RightBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void LeftBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void BigUpBounce(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }
    }
}
