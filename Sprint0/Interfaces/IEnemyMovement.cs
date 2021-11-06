using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Interfaces
{
    public interface IEnemyMovement
    {
        public Vector2 Position { get; set; }

        void Update();
        void Move();
        void MoveRight();
        void MoveLeft();
        String GetDirection();
        void SetXVelocity(float x);
        void SetYVelocity(float y);
        float GetXVelocity();
        float GetYVelocity();
        Vector2 GetLocation();
        public bool GetGrounded();

        public void SetGrounded(bool grounded);
    }
}
