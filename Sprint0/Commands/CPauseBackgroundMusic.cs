using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Commands
{
    class CPauseBackgroundMusic : ICommand
    {
        public CPauseBackgroundMusic(IMario mario)
        {

        }
        public void Execute()
        {
            
            if (!Game0.Instance.soundInfo.StopLoopedSound(Game0.currentSoundtrack))
            {
                Game0.Instance.soundInfo.PlaySound(Game0.currentSoundtrack, true);
            }
            
        }
    }
}
