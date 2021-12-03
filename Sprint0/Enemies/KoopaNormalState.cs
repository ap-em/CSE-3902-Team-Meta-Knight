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
    public class KoopaNormalState : IEnemyState
    {
        private String ID = "KoopaNormal";
        private IEnemy enemy;
        private Vector2 velocity;
        private bool grounded;

        public KoopaNormalState(IEnemy enemy)
        {
            this.enemy = enemy;

        }
        public String GetStateID()
        {
            return ID;
        }
        public void TakeDamage()
        {
            enemy.SetHealth(enemy.GetHealth() - 1);
            enemy.SetCurrentState(new KoopaShellState(enemy));
        }
        public void GetKicked(Rectangle rec)
        {

        }

        public void MoveRight()
        {
            enemy.SetDirection(GameUtilities.right);
            velocity.X = GameUtilities.koopaSpeed;
        }

        public void MoveLeft()
        {
            enemy.SetDirection(GameUtilities.left);
            velocity.X = -GameUtilities.koopaSpeed;
        }


        public void UpBounce(Rectangle rectangle)
        {
            grounded = true;
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y - rectangle.Height);
        }

        public void DownBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y + rectangle.Height);

        }

        public void RightBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X + rectangle.Width, enemy.Position.Y);
            velocity.X = GameUtilities.koopaSpeed;
            enemy.SetDirection(GameUtilities.right);
        }

        public void LeftBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X - rectangle.Width, enemy.Position.Y);
            velocity.X = -GameUtilities.koopaSpeed;
            enemy.SetDirection(GameUtilities.left);
        }

        public void BigUpBounce(Rectangle rectangle)
        {

        }

        public void SetXVelocity(float x)
        {
            velocity.X = x;
        }

        public void SetYVelocity(float y)
        {
            velocity.Y = y;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public bool GetGrounded()
        {
            return grounded;
        }

        public void SetGrounded(bool grounded)
        {
            if (grounded == false)
                velocity.Y = GameUtilities.gravity;
            else
                velocity.Y = 0;
            this.grounded = grounded;
        }

        public void Update()
        {
            enemy.Move(velocity);
        }
    }
}


