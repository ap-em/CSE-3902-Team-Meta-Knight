using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0.Interfaces
{
   public interface IProjectile
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void Move();
        int GetFuseTime();
        void UpBounce(Rectangle rectangle);
    }
}
