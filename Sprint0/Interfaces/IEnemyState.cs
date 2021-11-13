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
/*
 * Alexander Clayton CSE 3902 09/15/2021
 */
namespace Sprint0.Interfaces
{
    public interface IEnemyState
    {

        public void TakeDamage();

        public void MoveRight();
        public void MoveLeft();

        public void UpBounce(Rectangle rectangle);

        public void DownBounce(Rectangle rectangle);

        public void RightBounce(Rectangle rectangle);
        public void LeftBounce(Rectangle rectangle);

        public void BigUpBounce(Rectangle rectangle);
    }
}
