using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Media;

using Sprint0.Interfaces;

namespace Sprint0.Player.State_Machines.States.GameStates
{
   public class GameOverStates: IGameState
    {
        private Game0 game;
        private SoundInfo soundInfo;
        public Interfaces.GameStates Type
        {
            get
            {
                return Interfaces.GameStates.GameOver;
            }
        }
        public GameOverStates(Game0 game)
        {
            this.game = game;

            //stop play other sounds
            soundInfo.PlaySound("smb_gameover", false);
        }

        public void GameOver()
        {

        }

        public void Pause()
        {

        }

        public void Proceed()
        {
            // draw title sprite.
        }
    }
}
