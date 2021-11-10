using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.UtilityClasses
{
    public static class Score
    {
        public static int marioScore = 0;

        public static int coins = 0;
        public static int lives = 3;
        public static int enemyKilledPoint = 50;
        private static int coinScore = 20;
        private static int itemScore = 100;
        private static int poleScore = 500;
        private const int COINFORLIFE = 100;

        public static void AddCoin()
        {
            coins++;
            marioScore += coinScore;
            if (coins >= COINFORLIFE)
            {
                lives++;
                coins -= COINFORLIFE;
            }
        }

        public static void AdditemScore()
        {
            marioScore += itemScore;
        
        }
        public static void Addlives()
        {
            lives++;
        }
        public static void loseLives()
        {
            lives--;
        }
        public static void AddPoleScore()
        {
            marioScore += poleScore ;
        }


    }
    
}
