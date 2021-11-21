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
    class Timer
    {
        private ElapsedEventHandler method;
        private int milliseconds; 
        public Timer(int milliseconds, ElapsedEventHandler method)
        {
            this.milliseconds = milliseconds;
            this.method = method;

        }
        public void StartTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();

            timer.Interval = milliseconds;

            timer.Elapsed += method;

            timer.AutoReset = false;

            timer.Enabled = true;
        }
    }
}