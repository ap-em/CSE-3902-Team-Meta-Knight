using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0
{
    public class SoundInfo
    {
        Dictionary<string,SoundEffect> soundEffects;
        Dictionary<string, SoundEffectInstance> soundInstances;
        private bool isPaused;

        public SoundInfo()
        {
            soundEffects = new Dictionary<string, SoundEffect>();
            soundInstances = new Dictionary<string, SoundEffectInstance>();
            isPaused = false;
            SoundManager.Instance.AddSound(this);
        }

        public void PlaySound(string soundName, bool loop)
        {
            /*
             * Check if we have a SoundEffect object for that soundeffect, if not, load it in from SoundFactory
             * and add to our dictionary of SoundEffects
             */
            if (!soundEffects.ContainsKey(soundName))
            {
                soundEffects.Add(soundName, SoundFactory.Instance.GetSoundEffect(soundName));
            }

            /*
             * We only ever want one instance of a looping sound so there are no duplicate dictionary entries, 
             * so if the user wants a looping sound, make sure it isnt already playing.
             * If it isn't already playing, play it and store the soundeffect instance.
             */

            if (!soundInstances.ContainsKey(soundName))
            {
                SoundEffect se;
                soundEffects.TryGetValue(soundName, out se);
                SoundEffectInstance sei = se.CreateInstance();
                if (loop)
                {
                    sei.IsLooped = true;
                }
                sei.Play();
                soundInstances.Add(soundName, sei);
            }
            else
            {
                SoundEffectInstance sei;
                soundInstances.TryGetValue(soundName, out sei);
                if (sei != null)
                {
                    sei.Play();
                }
            }
        }
            
           
        
        public bool StopLoopedSound(string soundName)
        {
            SoundEffectInstance sei;
            if(soundInstances.TryGetValue(soundName, out sei))
            {
                sei.Stop();
                soundInstances.Remove(soundName);
                return true;
            }
            return false;
        }
        public void ToggleSoundPause()
        {
            foreach (KeyValuePair<string, SoundEffectInstance> seiPair in soundInstances)
            {
                if (isPaused)
                {
                    if (seiPair.Value.State.Equals(SoundState.Paused))
                    {
                        seiPair.Value.Resume();
                    }
                }
                else
                {
                    if (seiPair.Value.State.Equals(SoundState.Playing))
                    {
                        seiPair.Value.Pause();
                    }
                }
            }
            isPaused = !isPaused;
        }
        public void StopAllSounds()
        {
            foreach (KeyValuePair<string, SoundEffectInstance> seiPair in soundInstances)
            {
                seiPair.Value.Stop();
            }
        }
    }
}
