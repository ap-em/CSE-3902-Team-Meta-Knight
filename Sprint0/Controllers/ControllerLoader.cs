using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Commands;
using System.Collections;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Diagnostics;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Controllers
{
    sealed class ControllerLoader
    {
        private static ControllerLoader instance;
        public static ControllerLoader Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new ControllerLoader();

                }
                return instance;
            }
        }

        public ControllerLoader()
        {

        }
        public IKeyboardController SetUpPlayerKeyboard(IMario mario,  int index)
        {
            IKeyboardController keyboard = new KeyboardController();
            XmlReader reader = XmlReader.Create(Path.GetFullPath("Controllers\\KeyboardBindings.xml"));

            reader.ReadToFollowing("PlayerKeyboard" + index);

            reader = reader.ReadSubtree();
            ReadPlayerKeys(reader, mario, keyboard);

            reader.Close();
            return keyboard;
        }
        public IKeyboardController SetUpEnemyKeyboard(IEnemy enemy)
        {
            IKeyboardController keyboard = new EnemyController();
            
            keyboard.ClearController();
            XmlReader reader = XmlReader.Create(Path.GetFullPath("Controllers\\KeyboardBindings.xml"));

            reader.ReadToFollowing("EnemyKeyboard");

            reader = reader.ReadSubtree();
            ReadEnemyKeys(reader, enemy, keyboard);

            reader.Close();
            return keyboard;
        }
        public void ReadPlayerKeys(XmlReader reader, IMario mario, IKeyboardController keyboard)
        {
            while (reader.ReadToFollowing("key"))
            {
                String objString = reader.ReadElementContentAsString();
                String[] objValues = objString.Split(',');

                Type t = Type.GetType(objValues[1]);
                Type[] types = { Type.GetType(mario.ToString()) };
                object[] param = { mario };

                ConstructorInfo constructorInfoObj = t.GetConstructor(types);

                ICommand command = (ICommand)constructorInfoObj.Invoke(param);

                
                //parse string to key
                Keys key = (Keys)Enum.Parse(typeof(Keys), objValues[0]);
                
                if (objValues[2].Equals("pressable"))
                {
                    keyboard.RegisterCommand(key, command);
                }
                else if (objValues[2].Equals("holdable"))
                {
                    keyboard.RegisterHoldableKey(key, command);
                }
                else if (objValues[2].Equals("releasable"))
                {
                    keyboard.RegisterReleasableKey(key, command);
                }
            }
            reader.Close();
        }
        public void ReadEnemyKeys(XmlReader reader, IEnemy enemy, IKeyboardController keyboard)
        {
            while (reader.ReadToFollowing("key"))
            {
                String objString = reader.ReadElementContentAsString();
                String[] objValues = objString.Split(',');

                Type t = Type.GetType(objValues[1]);
                Type[] types = { Type.GetType(enemy.ToString()) };
                object[] param = { enemy };

                ConstructorInfo constructorInfoObj = t.GetConstructor(types);

                ICommand command = (ICommand)constructorInfoObj.Invoke(param);

                //parse string to key
                Keys key = (Keys)Enum.Parse(typeof(Keys), objValues[0]);

                if(objValues[2].Equals("pressable"))
                {
                    keyboard.RegisterCommand(key, command);
                }
                else if(objValues[2].Equals("holdable"))
                {
                    keyboard.RegisterHoldableKey(key, command);
                }
                else if(objValues[2].Equals("releasable"))
                {
                    keyboard.RegisterReleasableKey(key, command);
                }

            }
            reader.Close();
        }
    }
}
