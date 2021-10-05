using Microsoft.Xna.Framework;
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
   public interface IMouseController
    {
        void Update();
        void SetZeroXVelocityCommand(ICommand command);
        void SetZeroYVelocityCommand(ICommand command);
        void RegisterCommand(Rectangle rectangle, ICommand command);
    }
}
