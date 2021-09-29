using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Enemies;


/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0
{
    public class ProjectileController : IProjectileController
    {

        private List<IProjectile> projectiles;

        private static ProjectileController instance = new ProjectileController();
        public static ProjectileController Instance
        {
            get
            {
                return instance;
            }
        }

        public ProjectileController()
        {
            projectiles = new List<IProjectile>();
        }
        public void RemoveProjectile(IProjectile projectile)
        {
            projectiles.Remove(projectile);
        }
        public void AddProjectile(IProjectile projectile)
        {
            projectiles.Add(projectile);
        }
        public void Update()
        {
            // remove unused projectiles
            for(int i=0;i<projectiles.Count;i++)
            {
                if (projectiles[i].GetFuseTime() <= 0) RemoveProjectile(projectiles[i]);
            }
            // move current projectiles
            for(int i=0;i<projectiles.Count;i++)
            {
                projectiles[i].Update();
            }
        }
    }
}
