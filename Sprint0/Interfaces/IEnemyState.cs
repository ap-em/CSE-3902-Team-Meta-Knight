using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.SpriteFactory;
using Sprint0.Controllers;
using Sprint0.UtilityClasses;

namespace Sprint0.Interfaces
{
    public interface IEnemyState
    {
        public String GetStateID();
        public void TakeDamage();
        public void GetKicked(Rectangle rec);
        public void MoveRight();
        public void MoveLeft();
        public void SetXVelocity(float x);
        public void SetYVelocity(float y);
        public Vector2 GetVelocity();
        public void Update();
        public void SetGrounded(bool grounded);
        public void UpBounce(Rectangle rectangle);
        public void DownBounce(Rectangle rectangle);
        public void RightBounce(Rectangle rectangle);
        public void LeftBounce(Rectangle rectangle);
        public void BigUpBounce(Rectangle rectangle);
    }
}

