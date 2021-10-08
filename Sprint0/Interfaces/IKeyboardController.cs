using Microsoft.Xna.Framework.Input;
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
 * Alexander Clayton CSE 3902 09/02/2021
 */
namespace Sprint0.Interfaces
{
    /*
     * This controller implements any and all controllers needed for the game.
     * Keyboard
     * Mouse
     * 
     */
   public interface IKeyboardController
    {
        void Update();
        void RegisterCommand(Keys key, ICommand command);
        void RegisterHoldableKey(Keys key, ICommand command);
        void RegisterReleasableKey(Keys key, ICommand command);
    }
}
