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
    class Timer: ITimer
    {
        private Action method;
        private int milliseconds;
        private int timePassed = 0;
        private IGameObject go;
        public IGameObject GameObject { get => go; }
        public String methodName { get => method.Method.Name; }
        public Timer(IGameObject go, int milliseconds, Action method)
        {
            this.go = go;
            this.milliseconds = milliseconds;
            this.method = method;

        }
        public void Update(GameTime gameTime)
        {
            timePassed += gameTime.ElapsedGameTime.Milliseconds;

            if (timePassed >= milliseconds)
            {
                method();
                TimerManager.Instance.RemoveFromTimerList(go, this);
            }
        }
    }
}