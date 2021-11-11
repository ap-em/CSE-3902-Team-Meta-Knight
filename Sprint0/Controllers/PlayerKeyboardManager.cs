using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using Sprint0.Commands;
using System.Collections;
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
    sealed class PlayerKeyboardManager 
    {
        public  Dictionary<IGameObject, IKeyboardController> keyboardList = new Dictionary<IGameObject, IKeyboardController>();
        public Dictionary<IGameObject, IKeyboardController> insertQueue = new Dictionary<IGameObject, IKeyboardController>();
        public Dictionary<IGameObject, IKeyboardController> removalQueue= new Dictionary<IGameObject, IKeyboardController>();
        private static PlayerKeyboardManager instance;
        public static PlayerKeyboardManager Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new PlayerKeyboardManager();

                }
                return instance;
            }
        }

        public PlayerKeyboardManager()
        {

        }
        public void CreateKeyboard(IGameObject go)
        {
            IKeyboardController keyboard = ControllerLoader.Instance.SetUpPlayerKeyboard((IMario)go,
                keyboardList.Count + insertQueue.Count - removalQueue.Count);
           
            insertQueue.Add(go, keyboard);    
        }
        public IKeyboardController GetKeyboard(IGameObject go)
        {
            return keyboardList.GetValueOrDefault(go);
        }
        public void AddKeyboards()
        {
            foreach(IGameObject go in insertQueue.Keys)
            {
                keyboardList.Add(go, insertQueue.GetValueOrDefault(go));
            }
            insertQueue.Clear();
        }
        public void AddToRemovalQueue(IGameObject go)
        {
            removalQueue.Add(go, keyboardList.GetValueOrDefault(go));
        }
        public void RemoveKeyboards()
        {
            foreach (IGameObject go in removalQueue.Keys)
            {
                keyboardList.Remove(go);
            }
            removalQueue.Clear();
        }
        public void RemoveAllKeyboards()
        {
            removalQueue.Clear();
            insertQueue.Clear();
            foreach (IGameObject go in keyboardList.Keys)
            {
                removalQueue.Add(go, keyboardList.GetValueOrDefault(go));
            }
        }

        public void Update()
        {
            AddKeyboards();
            foreach(IKeyboardController keyboard in keyboardList.Values)
            {
                keyboard.Update();
            }
            RemoveKeyboards();
        }
    }
}
