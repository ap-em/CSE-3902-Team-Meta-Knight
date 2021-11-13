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
    public class GoombaNormalState : IEnemyState
    {
        private IEnemy enemy;

        public GoombaNormalState(IEnemy enemy)
        {
            this.enemy = enemy;

        }
        public void TakeDamage()
        {
            enemy.SetHealth(enemy.GetHealth() - 1);
            enemy.SetXVelocity(0);
            enemy.SetCurrentState(new GoombaSquashedState());
            enemy.SetRemovalTimer(GameUtilities.goombaRemovalTimer);
        }

        public void MoveRight()
        {
            enemy.SetXVelocity(GameUtilities.goombaSpeed);
        }

        public void MoveLeft()
        {
            enemy.SetXVelocity(-GameUtilities.goombaSpeed);
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
            enemy.SetXVelocity(GameUtilities.goombaSpeed);
        }

        public void LeftBounce(Rectangle rectangle)
        {
            enemy.Position = new Vector2(enemy.Position.X - rectangle.Width, enemy.Position.Y);
            enemy.SetXVelocity(-GameUtilities.goombaSpeed);
        }

        public void BigUpBounce(Rectangle rectangle)
        {

        }

    }
}

