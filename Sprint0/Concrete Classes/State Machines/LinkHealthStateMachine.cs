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
    class LinkHealthStateMachine
    {
        private ILink link;
        private enum LinkHealth { star, fire, fireDamaged, full, fullDamaged, half, none };
        private LinkHealth currentHealth = LinkHealth.full;
        private LinkHealth previousHealth = LinkHealth.full;
        private int invinsibleTimer = 20;


        public LinkHealthStateMachine(ILink link)
        {
            this.link = link;
        }

        public String GetHealth()
        {
            switch (currentHealth)
            {
                case LinkHealth.star:
                    return "Star";
                case LinkHealth.fire:
                    return "Fire";
                case LinkHealth.fireDamaged:
                    return "FireDamaged";
                case LinkHealth.full:
                    return "Full";
                case LinkHealth.fullDamaged:
                    return "FullDamaged";
                case LinkHealth.half:
                    return "Half";
 //               case LinkHealth.none:
 //                   return "none";
                default:
                    return "Full";
            }
        }
        public void TakeDamage()
        {
            if (invinsibleTimer <= 0)
            {
                //invinsible for a few frames after taking damage
                invinsibleTimer = 20;
                switch (currentHealth)
                {
                    case LinkHealth.star:
                        currentHealth = LinkHealth.star;
                        break;
                    case LinkHealth.fire:
                        currentHealth = LinkHealth.fireDamaged;
                        break;
                    case LinkHealth.full:
                        currentHealth = LinkHealth.fullDamaged;
                        break;
                    case LinkHealth.half:
                        currentHealth = LinkHealth.none;
                        break;
                    case LinkHealth.none:
                        break;
                    default:
                        break;
                }
                link.OnStateChange();
            }
        }
        public void StarPower()
        {
            invinsibleTimer = 100;
            previousHealth = currentHealth;
            currentHealth = LinkHealth.star;
            link.OnStateChange();
        }
        public void Update()
        {
            if (invinsibleTimer > 0)
            {
                invinsibleTimer--;
            }
            if(invinsibleTimer == 0) 
            {
                if (currentHealth == LinkHealth.star)
                {
                    // go back to previous health after star power
                    currentHealth = previousHealth;
                    link.OnStateChange();
                }
                else if(currentHealth == LinkHealth.fireDamaged)
                {
                    // go to new health after taking damage animation
                    currentHealth = LinkHealth.full;
                    link.OnStateChange();
                }
                else if(currentHealth == LinkHealth.fullDamaged)
                {
                    // go to new health after taking damage animation
                    currentHealth = LinkHealth.half;
                    link.OnStateChange();
                }
            }
        }
    }
}
