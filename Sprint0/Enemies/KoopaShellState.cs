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
        private IEnemy enemy;

        public KoopaShellState(IEnemy enemy)
        {
            this.enemy = enemy;

        }
        public void TakeDamage()
        {
            // if shell isnt moving start moving when we hit it
            if (enemy.GetVelocity().X == 0)
            {
                if(enemy.GetDirection() == GameUtilities.right)
                {
                    enemy.SetXVelocity(GameUtilities.shellSpeed);
                }
                else
                {
                    enemy.SetXVelocity(-GameUtilities.shellSpeed);
                }
            }
            // if shell is moving, stop moving
            else
            {
                enemy.SetXVelocity(0);
            }
            Debug.WriteLine(enemy.GetVelocity());
        }

        public void MoveRight()
        {

        }

        public void MoveLeft()
        {

        }


        public void UpBounce(Rectangle rectangle)
        {
            enemy.SetGrounded(true);
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y - rectangle.Height);
        }

        public void DownBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y + rectangle.Height);
            
        }

        public void RightBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X + rectangle.Width, enemy.Position.Y);
            enemy.SetXVelocity(GameUtilities.shellSpeed);
        }

        public void LeftBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X - rectangle.Width, enemy.Position.Y);
            enemy.SetXVelocity(-GameUtilities.shellSpeed);
        }

        public void BigUpBounce(Rectangle rectangle)
        {

        }

    }
}

