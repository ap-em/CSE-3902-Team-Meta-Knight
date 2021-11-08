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
            if (!Game0.Instance.soundInfo.StopLoopedSound("OverworldTheme"))
            {
                Game0.Instance.soundInfo.PlaySound("OverworldTheme", true);
            }
            
        }
    }
}
