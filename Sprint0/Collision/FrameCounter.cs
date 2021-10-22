using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collision
{
    class FrameCounter
    {
        public FrameCounter() { }

        public long TotalFrames { get; set; }
        public float AvgFPS { get; set; }
        public float CurrentFPS { get; set; }
        public float DroppedFrames { get; set; }

        void Update(float dt)
        {

        }


    }
}
