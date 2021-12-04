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
    public class KoopaShellState : IEnemyState
    {
        private String ID = "KoopaShell";
        private IEnemy enemy;
        private Vector2 velocity = new Vector2(0, GameUtilities.gravity);
        public KoopaShellState(IEnemy enemy)
        {
            this.enemy = enemy;
            enemy.SetSprite("Koopa");
        }
        public String GetStateID()
        {
            return ID;
        }
        public void TakeDamage()
        {
            ToggleVelocity(1);
        }
        public void GetKicked(Rectangle rec)
        {
            Rectangle enemyRec = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y, enemy.Sprite.width * GameUtilities.dimensionScale, enemy.Sprite.height * GameUtilities.dimensionScale);

            // if enemy is hit on left side kick the shell to the right, else kick to the left
            if (rec.Left == enemyRec.Left)
            {
                ToggleVelocity(1);
                enemy.SetDirection(GameUtilities.right);
            }
            else
            {
                ToggleVelocity(-1);
                enemy.SetDirection(GameUtilities.left);
            }

        }
        public void ToggleVelocity(int direction)
        {

            // if shell isnt moving start moving when we hit it
            if (velocity.X == 0)
            {
                velocity.X = GameUtilities.shellSpeed * direction;
            }
            // if shell is moving, stop moving
            else
            {
                velocity.X = 0;
            }
        }

        public void MoveRight()
        {

        }

        public void MoveLeft()
        {
            
        }


        public void UpBounce(Rectangle rectangle)
        {
            enemy.Grounded = true;
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y - rectangle.Height);
        }

        public void DownBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y + rectangle.Height);

        }

        public void RightBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X + rectangle.Width, enemy.Position.Y);
            velocity.X = GameUtilities.shellSpeed;
        }

        public void LeftBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X - rectangle.Width, enemy.Position.Y);
            velocity.X = -GameUtilities.shellSpeed;
        }

        public void BigUpBounce(Rectangle rectangle)
        {

        }

        public void SetXVelocity(float x)
        {

        }

        public void SetYVelocity(float y)
        {

        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public void SetGrounded(bool grounded)
        { 
            enemy.Grounded = grounded;
        }

        public void Update()
        {
            enemy.Move(velocity);
        }
    }
}



