using Sprint0.Controllers;
using Sprint0.Enemies;
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
    class CResetEnemy : ICommand
    {

        /*TODO: Find a way to remove the enemy keyboard from controller list in Game0 before creating a new one*/

        Game0 game;
        IKeyboardController enemyKeyboard;
        public CResetEnemy(Game0 game)
        {
            enemyKeyboard = new EnemyController();
            this.game = game;
        }

        public void Execute()
        {
            game.RemoveKeyboard(game.enemy.GetKeyboard());
            game.enemy = new Enemy();
            game.SetUpEnemyKeyboard(enemyKeyboard, game.enemy);
        }
    }
}
