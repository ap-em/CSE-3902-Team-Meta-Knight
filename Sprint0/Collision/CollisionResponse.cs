using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Sprint0
{
    /*
     * Uses 2 dictionaries to return 
     */

    public class CollisionResponse
    {
        private static CollisionResponse instance;
        public static CollisionResponse Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new CollisionResponse();

                }
                return instance;
            }
        }
        public CollisionResponse()
        {
        }
        public void Response(IGameObject collider, IGameObject collided, String direction)
        {
            XmlReader reader = XmlReader.Create(Path.GetFullPath("Collision\\CollisionData.xml"));

            if (reader.ReadToFollowing(collider.ToString()))
            {
                reader = reader.ReadSubtree();
                if (reader.ReadToFollowing(direction))
                {
                    reader = reader.ReadSubtree();
                    if (reader.ReadToFollowing(collided.ToString()))
                    {
                        //get strings
                        String objString = reader.ReadElementContentAsString();
                        String[] objValues = objString.Split(',');

                        Type t1 = Type.GetType(objValues[0]);
                        Type[] types1 = { Type.GetType(collider.ToString()) };
                        object[] param1 = { collider };

                        ConstructorInfo constructorInfoObj1 = t1.GetConstructor(types1);

                        ICommand command1 = (ICommand)constructorInfoObj1.Invoke(param1);

                        command1.Execute();

                        Type t2 = Type.GetType(objValues[1]);
                        Type[] types2 = { Type.GetType(collided.ToString()) };
                        object[] param2 = { collided };

                        ConstructorInfo constructorInfoObj2 = t2.GetConstructor(types2);

                        ICommand command2 = (ICommand)constructorInfoObj2.Invoke(param2);

                        command2.Execute();

                    }
                }

            }
            reader.Close(); // Closes the local reader for the object
        }
    }
}
