using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Threading.Tasks;


namespace Sprint0.HUD
{
    class ScoringSystem
    {
       
        private int score = 0;
        private IMario mario;
        protected Vector2 marioPos
        {
            get
            {
                if (mario == null)
                    return new Vector2( 0, 0);
                return mario.Position;
            }
        }
        public static ScoringSystem gameScore = new ScoringSystem();
        private ScoringSystem()
        {
            
        }
        public static ScoringSystem PlayerScore()
        {
            return gameScore;
        }
        public void RegisterMario(IMario mario)
        {
            
            this.mario = mario;
        }
        public void ResetScore()
        {
            score = 0;
        }
        protected void AddToScore(int scoreAdd)
        {
            score += scoreAdd;
        }
        public static void AddBreakBlockPoints()
        {

        }
        public static void AddCollectCoinPoints()
        {

        }
        public static void AddTouchPolePoints()
        {

        }
        public static void AddStompingEnemyPoints()
        {

        }
        public static void AddKillEnemyPoints()
        {

        }

        public static void CreateScoreAnimation()
        {
           
        }
    }
   
}
