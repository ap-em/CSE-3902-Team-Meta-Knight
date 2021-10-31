using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CFireUpBounce : ICommand
    {
        public string direction;
        public IProjectile projectile;
        public Rectangle rectangle;
        public CFireUpBounce(IProjectile projectile, Rectangle rectangle)
        {
            this.projectile = projectile;
            this.rectangle = rectangle;
        }

        public void Execute()
        {
            projectile.UpBounce(rectangle);
        }
    }
}
