using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System.IO;
using System.Diagnostics;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Cycle
{
    class CycleStateMachine : ICycleStateMachine
    {
        ICyclable obj;
        public CycleStateMachine(ICyclable obj)
        {
            this.obj = obj;
        }

        public void NextSprite()
        {
            String spriteName = obj.GetSpriteName();
            String newName = spriteName;
            XmlReader reader = XmlReader.Create(Path.GetFullPath("Cycle\\CycleData.xml"));

            if (reader.ReadToFollowing(obj.GetType().Name))
            {
                String objString = reader.ReadElementContentAsString();
                String[] objValues = objString.Split(',');

                for (int i = 0; i < objValues.Length; i++)
                {
                    if (objValues[i].Equals(spriteName))
                    {

                        if (i == objValues.Length - 1)
                        {
                            newName = objValues[0];
                        }
                        else
                        {
                            newName = objValues[i + 1];
                        }
                    }
                }

            }
            else { Debug.WriteLine("Cycle sprite: couldnt find next sprite" + spriteName); }

            Debug.WriteLine(newName);
            obj.SetSprite(newName);
        }

        public void PrevSprite()
        {
            String spriteName = obj.GetSpriteName();
            String newName = spriteName;

            XmlReader reader = XmlReader.Create(Path.GetFullPath("Cycle\\CycleData.xml"));

            if (reader.ReadToFollowing(obj.GetType().Name))
            {
                String objString = reader.ReadElementContentAsString();
                String[] objValues = objString.Split(',');

                for(int i = 0; i < objValues.Length; i++)
                {
                    if(objValues[i].Equals(spriteName))
                    {
                        if(i == 0)
                        {
                            newName = objValues[objValues.Length - 1];
                        }
                        else
                        {
                            newName = objValues[i-1];
                        }
                    }
                }

            }
            else { Debug.WriteLine("Cycle sprite: couldnt find prev sprite" + spriteName); }
            Debug.WriteLine(newName);
            obj.SetSprite(newName);
        }
    }
}