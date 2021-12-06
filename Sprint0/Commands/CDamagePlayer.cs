using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Commands
{
    /*Owen Tishenkel 2021 CSE 3902*/
    
    class CDamagePlayer : ICommand
    {
        Rectangle rectangle;
        IMario mario;
        ICollidable collided;
        public CDamagePlayer(IMario mario, ICollidable collided, Rectangle rectangle)
        {
            this.mario = mario;
            this.collided = collided;
        }

        public void Execute()
        {
            if(collided is IEnemy)
            {
                IEnemy enemy = (IEnemy)collided;

                // if we arent a koopa shell always take damage
                if(!enemy.GetStateID().Equals("KoopaShell"))
                {
                    mario.TakeDamage();
                }
                // if we are a koopa shell and we are moving then take damage
                else if(enemy.GetVelocity().X != 0)
                {
                    mario.TakeDamage();
                }
            }
            if(collided is IProjectile)
            {
                IProjectile projectile = (IProjectile)collided;
                if(projectile.SpriteName == "Hammer")
                    mario.TakeDamage();
            }
        }
    }
}
