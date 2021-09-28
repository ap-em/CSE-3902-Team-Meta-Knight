using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class LinkHealthStateMachine
    {
        public enum LinkHealth { full, half, none };
        public LinkHealth currentHealth = LinkHealth.full;
        public void TakeDamage()
        {
            switch (currentHealth)
            {
                case LinkHealth.full:
                    currentHealth = LinkHealth.half;
                    break;
                case LinkHealth.half:
                    currentHealth = LinkHealth.none;
                    break;
                case LinkHealth.none:
                    break;
                default:
                    break;
            }
        }

    }
}
