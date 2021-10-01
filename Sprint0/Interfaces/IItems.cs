using System;
using System.Collections.Generic;
using System.Text;

/*
 * Alexander Clayton CSE 3902 09/15/2021
 * Modified by Owen Tishenkel CSE 3902 9/25/2021
 * Modified again by Owen Tishenkel CSE 3902 10/1/2021
 */
namespace Sprint0.Interfaces
{
    /*
     * This interface can be used for the compass, map, key, heart container, trifroce, boomerang, bow, etc. Items that are toggled to be able to use once unlocked.
     * This interface can be used for the compass, map, key, heart container, trifroce, boomerang, bow, etc. Items that are toggled to be able to use once unlocked.
     */
   public interface IItems
    {
        void Update();
        void PrevItem();
        void NextItem();
        void setSprite();
        void Draw();
        void Move(int x, int y);
    }
}
