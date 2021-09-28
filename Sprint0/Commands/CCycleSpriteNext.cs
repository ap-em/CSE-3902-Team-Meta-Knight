using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    /*Owen Tishenkel 2021 CSE 3902*/
    class CCycleSpriteNext : ICommand
    {
        /*sprites is a linked list of every sprite that needs to be cycled through, 
         * the first on the list is the current sprite, when cycled to the next sprite, 
         * the old first sprite should be removed and added onto the end of the list*/
        LinkedList<ISprite> sprites;
        public CCycleSpriteNext(LinkedList<ISprite> sprites)
        {
            /*sprites created outside command so a CCycleSpritePrevious can have the same list*/
            this.sprites = sprites;
            
        }

        public void Execute()
        {
            LinkedListNode<ISprite> oldSprite = sprites.First;
            sprites.RemoveFirst();
            sprites.AddLast(oldSprite);
            
            
        }
    }
}
