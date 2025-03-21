
// Class invarient:
// -- One Skip Guard is an extension of Guard Class
// -- One Skip Guard blocks(x) will have skip k position of shields
// -- k is determined based on the shield Array

// Other functionalities of QuirkyGuard is the same as Guard, to learn more, plese check Guard's class invarient 

using System;
namespace P5
{
	public class OneSkipGuard: Guard
	{
		int skipFactor;

		// precondition: appropriate shieldArray
		// postcondition: none 
		public OneSkipGuard(int[] shieldArray): base(shieldArray)
		{
			skipFactor = shieldArray[0];
		}

        // precondition: appropriate x value
        // postcondition: alive could become false, could make blocking() true  
        public override void block(int x)
        {
            base.block(x + skipFactor);
        }
    }
}


// Implementation Invarient:
/* OneSkipGuard(int[] shieldArray) - is almost exactly the same as the normal Guard 
 * - it just has the skipFactor which is used to determine which offset of the position of the shield to use in block 
 * - skipFactor is determined by using the first item of the shieldArray 
 * - skipFactor will not increment or change but will stay the same 
 * **/

/* block(x) has the same functionality as guard's block(x )
 * - but to determine the position of which shield to use, x is not used and quirkFactor is used to determine it instead 
 * - quirkFactor increments each call 
 * **/
