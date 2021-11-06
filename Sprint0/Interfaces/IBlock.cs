using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/

/*
 * Alexander Clayton CSE 3902 09/15/2021
 */
namespace Sprint0.Interfaces
{
   public interface IBlock
    {
        void Draw(SpriteBatch spriteBatch);
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; }
    }
}
