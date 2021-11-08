using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.UtilityClasses;

/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0.Enemies
{
    public class EnemyMovement : IEnemyMovement
    {
        private Vector2 location;
        private String direction = GameUtilities.left;
        private float XVelocity = 0;
        private float YVelocity = 0;
        private Enemy enemy;
        public bool grounded = false;

        public Vector2 Position { get => location; set => location = value; }

        public EnemyMovement(Enemy enemy, Vector2 location)
        {
            this.enemy = enemy;
            this.location = location;
        }
        public String GetDirection()
        {
            return direction;
        }
        public void Move()
        {
            //koopa flies at full health
            if (enemy.enemyType == "Koopa" && enemy.GetHealth() == "Full")
                YVelocity = 0;

            location = new Vector2(location.X + XVelocity, location.Y + YVelocity);
        }
        public void MoveRight()
        {
            direction = GameUtilities.right;
            XVelocity = 1;
        }
        public void MoveLeft()
        {
            direction = GameUtilities.left;
            XVelocity = -1;
        }
        public float GetXVelocity()
        {
            return XVelocity;
        }
        public void SetXVelocity(float x)
        {
            XVelocity = x;
        }
        public float GetYVelocity()
        {
            return YVelocity;
        }
        public void SetYVelocity(float y)
        {
            YVelocity = y;
        }
        public Vector2 GetLocation()
        {
            return location;
        }
        public bool GetGrounded()
        {
            return grounded;
        }

        public void SetGrounded(bool grounded)
        {
            if (grounded == false)
                YVelocity = GameUtilities.gravity;
            else
                YVelocity = 0;
            this.grounded = grounded;
        }
        public void Update()
        {

        }
    }
}
