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
            
            if (!LevelFactory.Instance.soundInfo.StopLoopedSound(LevelFactory.Instance.currentSoundtrack))
            {
                LevelFactory.Instance.soundInfo.PlaySound(LevelFactory.Instance.currentSoundtrack, true);
            }
            
        }
    }
}
