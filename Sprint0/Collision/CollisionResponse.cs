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
        public Dictionary<String, List<String>> MoverResponse;
        public Dictionary<String, List<String>> TargetResponse;
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
            MoverResponse = new Dictionary<String, List<String>>();
            TargetResponse = new Dictionary<String, List<String>>();

            XmlReader reader = XmlReader.Create(Path.GetFullPath("Collision\\CollisionData.xml"));

            while (reader.ReadToFollowing("collisionInstance"))
            {
                ConstructDictionary(reader.ReadSubtree());
            }
            reader.Close(); // Closes the reader for the XML document

        }
        public void ConstructDictionary(XmlReader reader)
        {
            String obj1 = "";
            String obj2String = "";
            String[] obj2Array = null;
            String direction = "";
            String obj1CommandString = "";
            String obj2CommandString = "";
            List<String> obj1commands = new List<String>();
            List<String> obj2commands = new List<String>();

            //get object1
            if (reader.ReadToFollowing("obj1"))
                obj1 = reader.ReadElementContentAsString();

            //get list of collided objects that share the same collision response
            if (reader.ReadToFollowing("obj2"))
            {
                obj2String = reader.ReadElementContentAsString();
                obj2Array = obj2String.Split(",");
            }

            // get direction
            if (reader.ReadToFollowing("direction"))
                direction = reader.ReadElementContentAsString();

            // get list of commands that apply to obj1
            if (reader.ReadToFollowing("obj1Command"))
            {
                obj1CommandString = reader.ReadElementContentAsString();

                String[] commands = obj1CommandString.Split(",");
                for (int i = 0; i < commands.Length; i++)
                {
                    obj1commands.Add(commands[i]);
                }
            }

            //get list of commmands that apply to obj2
            if (reader.ReadToFollowing("obj2Command"))
            {
                obj2CommandString = reader.ReadElementContentAsString();

                String[] commands = obj2CommandString.Split(",");
                for (int i = 0; i < commands.Length; i++)
                {
                    obj2commands.Add(commands[i]);
                }
            }

            // for each object in list of collided objects
            // add key and corresponding command
            for(int i = 0; i < obj2Array.Length; i++)
            {
                MoverResponse.Add(obj1 + obj2Array[i] + direction, obj1commands);
                TargetResponse.Add(obj2Array[i] + obj1 + direction, obj2commands);
            }
            reader.Close();
        }
        public void CollisionOccurrence(IGameObject collider, IGameObject collided, String direction, Rectangle rectangle)
        {
            List<String> commandNames1 = new List<String>();
            List<String> commandNames2 = new List<String>();

            // get command1
            // if command get value with direction fails try getting directionless command
            if (MoverResponse.TryGetValue((collider.ToString() + collided.ToString() + direction), out commandNames1)
                || MoverResponse.TryGetValue((collider.ToString() + collided.ToString()), out commandNames1))
            {
                foreach (String commandName in commandNames1)
                {

                    Type t1 = Type.GetType(commandName);
                    Type[] types1 = { Type.GetType(collider.ToString()), Type.GetType(collided.ToString()), typeof(Rectangle) };
                    object[] param1 = { collider, collided, rectangle };

                    ConstructorInfo constructorInfoObj1 = t1.GetConstructor(types1);

                    ICommand command1 = (ICommand)constructorInfoObj1.Invoke(param1);

                    command1.Execute();
                }

            }

            // get command2
            // if command get value with direction fails try getting directionless command
            if (TargetResponse.TryGetValue((collided.ToString() + collider.ToString() + direction), out commandNames2)
                || TargetResponse.TryGetValue((collided.ToString() + collider.ToString()), out commandNames2))
            {
                foreach (String commandName in commandNames2)
                {
                    Type t2 = Type.GetType(commandName);
                    Type[] types2 = { Type.GetType(collided.ToString()), Type.GetType(collider.ToString()), typeof(Rectangle) };
                    object[] param2 = { collided, collider, rectangle };

                    ConstructorInfo constructorInfoObj2 = t2.GetConstructor(types2);

                    ICommand command2 = (ICommand)constructorInfoObj2.Invoke(param2);

                    command2.Execute();
                }
            }
        }
    }
}