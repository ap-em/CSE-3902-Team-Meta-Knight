using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Sprint0.Timers;
using Sprint0.UtilityClasses;
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
        private MarioHealth intialHealth = MarioHealth.full;
        private MarioHealth currentHealth = MarioHealth.full;
        private MarioHealth previousHealth = MarioHealth.full;
        private bool invincibility = false;


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
                case MarioHealth.none:
                    return "Dead";
                default:
                    return "Full";
            }
        }
        public void ResetHealth()
        {
            currentHealth = intialHealth;
        }
        public void TakeDamage()
        {
            if (!invincibility)
            {

                //invincibility for some time after taking damage
                invincibility = true;

                //do a state transition for 1000 milliseconds
                Timer damageStateTimer = new Timer(1000, DamageStateTransition);
                damageStateTimer.StartTimer();

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
            }
        }
        //Instant Death used for the KillBox under the pit
        public void InstantDeath()
        {
            currentHealth = MarioHealth.none;
        }
        public void StarPower()
        {
            //invisible for some time after star power
            invincibility = true;

            //remove object after 10000 milliseconds
            Timer invincibilityTimer = new Timer(10000, StarPowerTransition);
            invincibilityTimer.StartTimer();

            previousHealth = currentHealth;
            currentHealth = MarioHealth.star;
        }

        public void MushroomPower()
        {
            if (currentHealth == MarioHealth.half)
            {
                previousHealth = currentHealth;
                currentHealth = MarioHealth.full;
            }
        }
        public void FirePower()
        {
            previousHealth = currentHealth;
            currentHealth = MarioHealth.fire;
        }
        public void Update()
        {

        }
        public void DamageStateTransition(Object source, System.Timers.ElapsedEventArgs e)
        {
            invincibility = false;

            if (currentHealth == MarioHealth.fireDamaged)
            {
                // go to new health after taking damage animation
                currentHealth = MarioHealth.full;
                mario.OnStateChange();
            }
            else if (currentHealth == MarioHealth.fullDamaged)
            {
                // go to new health after taking damage animation
                currentHealth = MarioHealth.half;
                mario.OnStateChange();
            }
        }
        public void StarPowerTransition(Object source, System.Timers.ElapsedEventArgs e)
        {
            invincibility = false;
            currentHealth = previousHealth;
        }
    }
}
