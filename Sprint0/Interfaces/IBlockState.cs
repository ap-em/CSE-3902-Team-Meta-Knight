using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
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
    /*
     * This interface can be used for all blocks, which should just involve replacing the texture.
     */
   public interface IBlockState
    {
        void PrevBlock();
        void NextBlock();
        void Draw(SpriteBatch spriteBatch);
    }
}
