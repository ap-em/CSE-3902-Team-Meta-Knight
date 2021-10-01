using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


namespace Sprint0.Interfaces
{
   public interface IProjectileController
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
