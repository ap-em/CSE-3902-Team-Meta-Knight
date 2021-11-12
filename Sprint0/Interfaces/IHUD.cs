using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Interfaces
{
   public  interface IHUD
    {
        void Update();
        void draw(SpriteBatch batch, SpriteFont font);
    }
}
