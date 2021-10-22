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

        public Dictionary<String, ICommand> MoverResponse;
        public Dictionary<String, ICommand> TargetResponse;
        Type mType;
        Type tType;
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
            MoverResponse = new Dictionary<String, ICommand>();
            TargetResponse = new Dictionary<String, ICommand>();

            XmlReader reader = XmlReader.Create(Path.GetFullPath("Collision\\CollisionData.xml"));

            reader.ReadToFollowing("Collision");
            while (reader.ReadToFollowing("row"))
            {
             ConstructDictionary(reader.ReadSubtree());
            }
            reader.Close(); // Closes the reader for the XML document

        }
        public void ConstructDictionary(XmlReader reader)
        {
            while (reader.ReadToFollowing("obj"))
            {
                Console.Write("Building Dictionary");
                //get strings
                String objString = reader.ReadElementContentAsString();
                String[] objValues = objString.Split(',');

                //convert strings to ints
                String obj1 = objValues[0];
                String obj2 = objValues[1];
                String direction = objValues[2];
                String command1 = objValues[3];
                String command2 = objValues[4];
                // Need to use reflection here to get the commands
                mType = Type.GetType(command1);
                tType = Type.GetType(command2);

               // var test1 = typeof(mType);
                var mParams = mType.GetConstructors();
                var tParams = tType.GetConstructors();
                Type[] types = { typeof(ICommand) };

                ConstructorInfo cInfoM = mType.GetConstructor(types);
                ConstructorInfo cInfoT = tType.GetConstructor(types);

                //ConstructorInfo cInfoT = tType.GetConstructor(types);
                object mover = Activator.CreateInstance(mType);
                object target = Activator.CreateInstance(tType);
                //object mover = cInfoM.Invoke(new object[] )
                MoverResponse.Add(obj1+direction, (ICommand) mover);
                TargetResponse.Add(obj2+direction, (ICommand) target);
            }
            reader.Close(); // Closes the local reader for the object
        }

        public void CollisionOccurrence(IGameObject collider, IGameObject collided, String direction)
        {
            MoverResponse[collider.ToString() + direction].Execute();
            TargetResponse[collided.ToString() + direction].Execute();
        }
    }
}
