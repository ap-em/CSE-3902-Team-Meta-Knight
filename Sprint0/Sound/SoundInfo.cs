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

        public SoundInfo()
        {
            soundEffects = new Dictionary<string, SoundEffect>();
            soundInstances = new Dictionary<string, SoundEffectInstance>();
        }

        public void PlaySound(string soundName, bool loop)
        {
            /*
             * Check if we have a SoundEffect object for that soundeffect, if not, load it in from SoundFactory
             * and add to our dictionary of SoundEffects
             */
            if (!soundEffects.ContainsKey(soundName))
            {
                soundEffects.Add(soundName,SoundFactory.Instance.GetSoundEffect(soundName));
            }

            /*
             * We only ever want one instance of a looping sound so there are no duplicate dictionary entries, 
             * so if the user wants a looping sound, make sure it isnt already playing.
             * If it isn't already playing, play it and store the soundeffect instance.
             */
            if (loop)
            {
                if (!soundInstances.ContainsKey(soundName))
                {
                    SoundEffect se;
                    soundEffects.TryGetValue(soundName, out se);
                    SoundEffectInstance sei = se.CreateInstance();
                    sei.IsLooped = true;
                    sei.Play();
                    soundInstances.Add(soundName, sei);
                }
                else
                {
                    Debug.WriteLine("ERROR: Already playing this looped sound, cannot have multiple of the same looped sound at once!");
                }
            }
            else
            {
                SoundEffect se;
                soundEffects.TryGetValue(soundName, out se);
                if (se!=null)
                {
                    se.Play();
                }
                else
                {
                    Debug.WriteLine("ERROR: Sound effect not present in list");
                }
            }
           
        }
        public void StopLoopedSound(string soundName)
        {
            SoundEffectInstance sei;
            soundInstances.TryGetValue(soundName, out sei);
            sei.Stop();
            soundInstances.Remove(soundName);

        }
    }
}
