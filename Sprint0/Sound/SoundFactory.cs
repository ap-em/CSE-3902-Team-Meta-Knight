using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0
{
    public class SoundFactory
    {
        private ContentManager content;
        private static SoundFactory _instance;
        public static SoundFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SoundFactory(Game0.ContentInstance);
                }
                return _instance;
            }
        }
        public SoundFactory(ContentManager contentInstance)
        {
            content = contentInstance;
        }
        public SoundEffect GetSoundEffect(string name)
        {
            return (content.Load<SoundEffect>(name));
        }

    }
}
