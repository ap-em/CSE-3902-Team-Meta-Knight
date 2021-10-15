using Sprint0.Controllers;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
    /*Owen Tishenkel 2021 CSE 3902*/
    class CResetPlayer : ICommand
    {

        /*gameHere provides access to game for the purposes of reseting many of the things that it contains*/
        Game0 gameHere;
        IKeyboardController keyboard;
        
        /*CReset Player is a subcommand for CReset which resets player location and health to the initial value.*/
        public CResetPlayer(Game0 game)
        {
            gameHere = game;
            keyboard = new KeyboardController();
        }

        public void Execute()
        {

            gameHere.RemoveKeyboard(gameHere.link.GetKeyboard());
            GameObjectManager.Instance.RemoveFromObjectList((IGameObject)gameHere.link);
            gameHere.link = new Link();
            gameHere.SetUpPlayerKeyboard(keyboard);
        }
    }
}
