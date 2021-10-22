using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
/*
Alex Clayton
Alex Contreras
Jared Israel
Leon Cai
Owen Tishenkel
Owen Huston
*/
namespace Sprint0
{
    class MarioHealthStateMachine
    {
        private IMario mario;
        private enum MarioHealth { star, fire, fireDamaged, full, fullDamaged, half, none };
        private MarioHealth currentHealth = MarioHealth.full;
        private MarioHealth previousHealth = MarioHealth.full;
        private int invinsibleTimer = 20;


        public MarioHealthStateMachine(IMario mario)
        {
            this.mario = mario;
        }

        public String GetHealth()
        {
            switch (currentHealth)
            {
                case MarioHealth.star:
                    return "Star";
                case MarioHealth.fire:
                    return "Fire";
                case MarioHealth.fireDamaged:
                    return "FireDamaged";
                case MarioHealth.full:
                    return "Full";
                case MarioHealth.fullDamaged:
                    return "FullDamaged";
                case MarioHealth.half:
                    return "Half";
//                case MarioHealth.none:
//                    return "Dead";
                default:
                    return "";
            }
        }
        public void TakeDamage()
        {
            if (invinsibleTimer <= 0)
            {
                //invinsible for a few frames after taking damage
                invinsibleTimer = 30;
                switch (currentHealth)
                {
                    case MarioHealth.star:
                        currentHealth = MarioHealth.star;
                        break;
                    case MarioHealth.fire:
                        currentHealth = MarioHealth.fireDamaged;
                        break;
                    case MarioHealth.full:
                        currentHealth = MarioHealth.fullDamaged;
                        break;
                    case MarioHealth.half:
                        currentHealth = MarioHealth.none;
                        break;
                    case MarioHealth.none:
                        break;
                    default:
                        break;
                }
                mario.OnStateChange();
            }
        }
        public void StarPower()
        {
            invinsibleTimer = 100;
            previousHealth = currentHealth;
            currentHealth = MarioHealth.star;
            mario.OnStateChange();
        }
        public void Update()
        {
            if (invinsibleTimer >= 0)
            {
                invinsibleTimer--;
            }
            if(invinsibleTimer == 0) 
            {
                if (currentHealth == MarioHealth.star)
                {
                    // go back to previous health after star power
                    currentHealth = previousHealth;
                    mario.OnStateChange();
                }
                else if(currentHealth == MarioHealth.fireDamaged)
                {
                    // go to new health after taking damage animation
                    currentHealth = MarioHealth.full;
                    mario.OnStateChange();
                }
                else if(currentHealth == MarioHealth.fullDamaged)
                {
                    // go to new health after taking damage animation
                    Debug.WriteLine("working");
                    currentHealth = MarioHealth.half;
                    mario.OnStateChange();
                }
            }
        }
    }
}
