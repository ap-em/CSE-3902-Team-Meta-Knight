
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
namespace Sprint0.UtilityClasses
{
   public static class GameUtilities
    {
        public static Game game { get; set; }
        public static GameObjectManager gameObjectManager { get; set; }
        public static string emptyString = "";
        // magic number from GameObjectManager
        public static int dimensionScale = 2;
        public static int bias = 16;
        public static int backgroundWidth = 6450;
        public static int backgroundHeight = 600;
        public static string left = "Left";
        public static string right = "Right";
        public static string top = "Top";
        public static string bottom = "Bottom";
        public static string worldOneOne = "1-1";

        // magic number in Game0
        public static float timeSpan = 1/30.0f;
        public static int marioInitialPosX = 50;
        public static int marioInitialPosY = 200;
        public static string marioSpriteName= "Sprint0.Mario";

        // magic number in Block
        public static int initialBlockPosX=200;
        public static int initialBlockPosY=200;

        // magic number in camera
        public const int upTransition = 140;

        //magic number in EnemyController
        public static int waitTime = 50;

        //magic number in Goomba
        public static int goombaHearts = 1;
        public static int goombaSpeed = 1;
        public static int goombaRemovalTimer = 7;

        //magic number in hammerbro
        public static int hammerVelocityX = 5;
        public static int hammerVelocityY = 20;
        public static int hammerFuse = 150;

        //magic number in Koopa
        public static int koopaHearts = 1;
        public static int koopaSpeed = 1;
        public static int shellSpeed = 10;

        //magic number in item classes
        public static int itemPosX = 100;
        public static int itemPosY = 200;
        public static int coinVal = 200;
        public static int coinLifeExchangeVal = 100;


        //magic number in level classes
        public static int maxRowLength = 1000;
        public static int maxNumberOfRows = 100;
        public static int boundryX = 998;
        public static int boundryY = 99;
        public static int worldSpacesScale = 32;
        public static int blockOnScreenX = 25;
        public static int blockOnScreenY = 20;

        //magic number in mario state machine
        public static int upperBounceValue = 14;
        public static Vector2 fireBallPosition = new Vector2(3,20);
        public static int fireBallVelocityX = 15;
        public static int fuseTime = 75;
        public static  int currentMaxJumpTime = 5;
        public static  int maxJumpTime = 10;
        public static int maxTimeFlagTurn = 10;
        public static int timeToEndingDeletion = 25;
        public static int Vx = 7;
        public static float VxF = 7f;
        public static int Vy = 10;
        public static float VairX = 7f;
        public static float VairY = -7f;
        public static float gravity = 9.8f;
        public static int invinsibleTimer = 20;
        public static int invinsibleTimerStar = 250;
        public static int invinsibleTimerTakeDamage = 50;
        //to do : gravity part here

        //mario class
        public static int initialPosX= 100;
        public static int initialPosY = 100;


        //magic number for hud
         public static int gameOverTimerFinish = 3500;

    }
}
