using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Reflection;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0
{
    sealed public class NameToStateMapping
    {
        Dictionary<String, String> spriteNameToStateName = new Dictionary<String, String>();
        Dictionary<String, int> spriteNameToHealth = new Dictionary<String, int>();
        private static NameToStateMapping instance;
        public static NameToStateMapping Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new NameToStateMapping();

                }
                return instance;
            }
        }

        public NameToStateMapping()
        {
            CreateDictionarys();
        }
        public void CreateDictionarys()
        {
            XmlReader reader = XmlReader.Create(Path.GetFullPath("Enemies\\EnemySpriteToStateMapping.xml"));

            while (reader.ReadToFollowing("MapInstance"))
            {
                //get sprite name
                reader.ReadToFollowing("SpriteName");
                String spriteName = reader.ReadElementContentAsString();
                //get state name
                reader.ReadToFollowing("StateName");
                String stateName = reader.ReadElementContentAsString();
                //get health
                reader.ReadToFollowing("Health");
                int health = reader.ReadElementContentAsInt();

                spriteNameToStateName.Add(spriteName, stateName);
                spriteNameToHealth.Add(spriteName, health);
            }
            reader.Close();
        }
        public IEnemyState GetState(String spriteName, IEnemy enemy)
        {
            return CreateState(spriteNameToStateName.GetValueOrDefault(spriteName), enemy);
        }
        public IEnemyState CreateState(String stateName, IEnemy enemy)
        {
            Type t = Type.GetType(stateName);
            Type[] types = { typeof(IEnemy) };
            object[] param = { enemy };

            ConstructorInfo constructorInfoObj = t.GetConstructor(types);

            return (IEnemyState)constructorInfoObj.Invoke(param);
        }
        public int GetHealth(String spriteName)
        {
            return spriteNameToHealth.GetValueOrDefault(spriteName);
        }
    }
}
