using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    /*
     * A game object is defined as an object in the game that is moving, which will cause collisions.
     */
    public interface ICollidable
    {
        public void UpBounce(Rectangle rectangle);
        public void DownBounce(Rectangle rectangle);
        public void RightBounce(Rectangle rectangle);
        public void LeftBounce(Rectangle rectangle);
    }
}
