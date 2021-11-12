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
    /*
     * This interface can be used for all blocks, which should just involve replacing the texture.
     */
    public interface ICamera
    {
        public void Update();
        public int GetIndex();
        public Vector2 GetPosition();
        public Matrix GetMatrix();
        public void SetMatrix(Matrix matrix);
        public Viewport GetViewport();
        public void SetViewport(Viewport view);

    }

}