
// Class invarient:
// -- Quirky Guard is an extension of Guard Class
// -- Quirk Guard blocks(x) will have some quirky behavior as x will not be used to determine which shield will be used

// Other functionalities of QuirkyGuard is the same as Guard, to learn more, plese check Guard's class invarient 

using System;
namespace P5
{
	public class QuirkyGuard: Guard, iGuard
	{
		int quirkFactor;

        // precondition: appropriate shieldArray
        // postcondition: none 
        public QuirkyGuard(int[] shieldArray): base(shieldArray)
		{
			quirkFactor = shields.Length % 5;
		}


        // precondition: appropriate x value
        // postcondition: alive could become false, could make blocking() true  
        public override void block(int x)
        {
            base.block(quirkFactor);
			quirkFactor++;
        }
    }
}

// Implementation Invarient:
/* QuirkyGuard(int[] shieldArray) - is almost exactly the same as the normal Guard 
 * - it just has the quirkFactor which is used to determine which shield to use in block 
 * - quirkFactor is determined by using modulo of 5 on the length of the shield array 
 * **/

/* block(x) has the same functionality as guard's block(x )
 * - but to determine the position of which shield to use, x is not used and quirkFactor is used to determine it instead 
 * - quirkFactor increments each call 
 * **/
