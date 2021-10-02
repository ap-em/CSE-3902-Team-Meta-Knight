using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0
{
    class LinkHealthStateMachine
    {
        public enum LinkHealth { full, half, none };
        public LinkHealth currentHealth = LinkHealth.full;

        public String GetHealth()
        {
            switch (currentHealth)
            {
                case LinkHealth.full:
                    return "Full";
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
            Debug.WriteLine("TakeDamage called");
            switch (currentHealth)
            {
                case LinkHealth.full:
                    currentHealth = LinkHealth.half;
                    Debug.WriteLine("half health");
                    break;
                case LinkHealth.half:
                    currentHealth = LinkHealth.none;
                    Debug.WriteLine("no health");
                    break;
                case LinkHealth.none:
                    break;
                default:
                    break;
            }
        }

    }
}