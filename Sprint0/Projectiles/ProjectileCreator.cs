using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Enemies;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System.IO;
using Sprint0.Sprites.SpriteFactory;

/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
/*OWEN HUSTON - 9/22/2021 */


namespace Sprint0
{
    public class ProjectileCreator 
    {
        private Vector2 velocity = new Vector2(0,0);
        private int fuseTime = 30;
        private static ProjectileCreator instance;
        public static ProjectileCreator Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new ProjectileCreator();

                }
                return instance;
            }
        }

        public ProjectileCreator()
        {

        }
        public void CreateProjectile(String spriteName, String direction, Vector2 position)
        {
            XmlReader reader = XmlReader.Create(Path.GetFullPath("Projectiles\\ProjectileData.xml"));

            if (reader.ReadToFollowing(spriteName))
            {
                String objString = reader.ReadElementContentAsString();
                String[] objValues = objString.Split(',');


//objectValues from xml = [fusetime, projectile sprite name, left, xVelocity, yVelocity, right, xvel, yvel .. ]

                fuseTime = Convert.ToInt32(objValues[0]);
                spriteName = objValues[1];

                for(int i=0;i<objValues.Length;i++)
                {
                    if(objValues[i].Equals(direction))
                    {
                        velocity = new Vector2(Convert.ToInt32(objValues[i + 1]), Convert.ToInt32(objValues[i + 2]));
                    }
                }

            }
            else { Debug.WriteLine("couldnt find object name to create projectile"); }

            GameObjectManager.Instance.AddToObjectList(
                new Projectile(SpriteFactory.Instance.GetSprite(spriteName),
                    position, (int)velocity.X, (int)velocity.Y, fuseTime),1,1);

        }
  
    }
}
