using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.UtilityClasses;
using System.Timers;


/*Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston*/


namespace Sprint0.Timers
{
    public sealed class TimerManager
    {
        private Dictionary<IGameObject, List<ITimer>> timerInsertQueue = new Dictionary<IGameObject, List<ITimer>>();
        private Dictionary<IGameObject, List<ITimer>> timersRemovalQueue = new Dictionary<IGameObject, List<ITimer>>();
        private Dictionary<IGameObject, List<ITimer>> timers = new Dictionary<IGameObject, List<ITimer>>();
        private List<IGameObject> objectRemovalList = new List<IGameObject>();
        private static TimerManager instance;
        public static TimerManager Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new TimerManager();

                }
                return instance;
            }
        }
        public TimerManager()
        {

        }
        public void AddToTimerList(IGameObject go, ITimer timer)
        {
            // if gameObject is in queue already just add the timer to the list
            if (timerInsertQueue.ContainsKey(go))
            {
                timerInsertQueue.GetValueOrDefault(go).Add(timer);
            }
            // if gameObject isnt in queue add it to the queue with a new list of timers
            else
            {
                List<ITimer> list = new List<ITimer>();
                list.Add(timer);
                timerInsertQueue.Add(go, list);
            }
        }
        public void AddTimers()
        {
            foreach(KeyValuePair<IGameObject, List<ITimer>> KeyValuePair in timerInsertQueue)
            {

                // if timer contains gameObject key then add all the timers to that key
                if(timers.ContainsKey(KeyValuePair.Key))
                {
                    foreach (ITimer timer in KeyValuePair.Value)
                    {
                        timers.GetValueOrDefault(KeyValuePair.Key).Add(timer);
                    }
                }
                // if timer doesn't contain key add a new instance of key, value
                else
                {
                    timers.Add(KeyValuePair.Key, KeyValuePair.Value);
                }
            }

            timerInsertQueue.Clear();
        }
        public void RemoveAllObjectTimers(IGameObject go)
        {
            objectRemovalList.Add(go);

        }
        public void RemoveFromTimerList(IGameObject go, ITimer timer)
        {
            // if the gameObject is already in queue add the timer to the list
            if(timersRemovalQueue.ContainsKey(go))
            {
                timersRemovalQueue.GetValueOrDefault(go).Add(timer);
            }
            // if gameObject isnt in queue add it to the queue with a new list of timers
            else
            {
                List<ITimer> list = new List<ITimer>();
                list.Add(timer);
                timersRemovalQueue.Add(go, list);
            }
        }
        public void RemoveTimers()
        {

            foreach(IGameObject go in objectRemovalList)
            {
                if(timers.ContainsKey(go))
                {
                    timers.Remove(go);
                }
                if(timersRemovalQueue.ContainsKey(go))
                {
                    timersRemovalQueue.Remove(go);
                }
            }

            foreach (KeyValuePair<IGameObject, List<ITimer>> KeyValuePair in timersRemovalQueue)
            {
                // if timer contains gameObject key then remove all the timers from that key
                if (timers.ContainsKey(KeyValuePair.Key))
                {
                    // foreach timer in list remove from timers
                    foreach (ITimer timer in KeyValuePair.Value)
                    {
                        timers.GetValueOrDefault(KeyValuePair.Key).Remove(timer);
                    }
                }
            }

            timersRemovalQueue.Clear();
        }
        public void Update(GameTime gameTime)
        {
            AddTimers();
            foreach(List<ITimer> timerList in timers.Values)
            {
                foreach(ITimer timer in timerList)
                {
                    timer.Update(gameTime);
                }
            }
            RemoveTimers();
        }
    }
}