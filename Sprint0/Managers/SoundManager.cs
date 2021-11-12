using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    sealed public class SoundManager
    {
        /*
         * The sound manager is never used to play specific sounds, only to keep track of everyone
         * who is using SoundInfos, this is because sometimes we need to affect all sounds at once
         * so we need a centralized object that knows about all sounds going on. Other than these 
         * specific operations on all sounds at once, only the object itself cares about it sounds
         * to avoid coupling.
         */
        private static SoundManager instance;
        private List<SoundInfo> activeSounds;
        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundManager();
                }
                return instance;
            }
        }

        public SoundManager()
        {
            activeSounds = new List<SoundInfo>();
        }
        public void AddSound(SoundInfo soundInfo)
        {
            activeSounds.Add(soundInfo);
        }
        public void TogglePauseAllSounds()
        {
            foreach (SoundInfo soundInfo in activeSounds)
            {
                soundInfo.ToggleSoundPause();
            }
        }
        public void StopAllSounds()
        {
            foreach (SoundInfo soundInfo in activeSounds)
            {
                soundInfo.StopAllSounds();
            }
        }
        
    }
}
