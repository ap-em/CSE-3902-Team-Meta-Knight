﻿using Sprint0.Interfaces;
using Sprint0.Interfaces.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class CDamagePlayer : ICommand
    {
        ILinkState playerState;
        public CDamagePlayer(ILinkState playerState) 
        {
            this.playerState = playerState;
            
        }
        public void Execute()
        {
            playerState.TakeDamage();
        }
    }
}