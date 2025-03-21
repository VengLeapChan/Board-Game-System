using System;
namespace P5

// Class invarient:
// -- Infantry class is an extension of Fighter class and shares a lot of similar functionity
// -- Infantry object is able to reset and get its original artillery array and artilery size
// if it calls reset()
// -- reset() provides resets the artillery array, artillery size, and changes its state to active
// -- reset() only works for objects that are alive
// -- move(x, y) allows objects to move to location x,y on the board
// -- move(x, y) does not allow the move to the reverse direction in consequtive moves
// -- shift(p) allows the range of the Infantry object to be set to p
// -- p must be within the range of MAX_ATTACK_RANGE
// -- Other functionalities are the same as Fighter object, please review Fighter class for more information 
// -- constuctor takes in the same things as constructor of fighter class 
{
    public class Infantry : Fighter
    {
        private int previousRow, previousColumn;
        private int[] previousArray;
        private int previousArrSize;

        public Infantry(int health, int attackRange, int[] artilleryPower, int rowPlacement, int columnPlacement) : base(health, attackRange, artilleryPower, rowPlacement, columnPlacement)
        {
            previousRow = -1;
            previousColumn = -1;
            previousArray = currentArtillery();
            previousArrSize = currentArtSize();
        }

        // precondition: valid x and y
        // postcondition: could become inactive if used move incorrectly 
        public override void move(int x, int y)
        {
            if (previousRow == -1 & previousColumn == -1)
            {
                previousRow = currentRow();
                previousColumn = currentCol();
                base.move(x, y);
            }
            else
            {
                int currentXToPreviousX = currentRow() - previousRow;
                int currentXToFutureX = currentRow() - x;
                int currentYToPreviousY = currentCol() - previousColumn;
                int currentYToFutureY = currentCol() - y;

                if (currentXToPreviousX == 0 && currentXToFutureX == 0)
                {
                    if (Math.Sign(currentYToPreviousY) == Math.Sign(currentYToFutureY))
                    {
                        incrementInvalid();
                        checkActive();
                    }
                    else
                    {
                        previousRow = currentRow();
                        previousColumn = currentCol();
                        base.move(x, y);
                    }
                }
                else
                {
                    float cToFSlope = (float)currentYToFutureY / currentXToFutureX;
                    float cToPSlope = (float)currentYToPreviousY / currentXToPreviousX;

                    if (cToFSlope == cToPSlope)
                    {
                        if (Math.Sign(currentYToPreviousY) == Math.Sign(currentYToFutureY) && Math.Sign(currentXToPreviousX) == Math.Sign(currentXToFutureX))
                        {
                            incrementInvalid();
                            checkActive();
                        }
                        else
                        {
                            previousRow = currentRow();
                            previousColumn = currentCol();
                            base.move(x, y);
                        }

                    }
                    else
                    {
                        previousRow = currentRow();
                        previousColumn = currentCol();
                        base.move(x, y);
                    }

                }

            }
        }

        // precondition: None
        // postcondition: None
        public override void shift(int p)
        {
            setRange(p);
        }

        // precondition: None
        // postcondition: state could become active if object is still alive
        public override void reset()
        {
            if (isAlive())
            {
                updateArtillery((int[])previousArray.Clone());
                updateArtSize(previousArrSize);
                makeActive();
            }
        }
    }
}


// Implementation invarient
/* constructor: takes in the same parameters as the parent class 
 * -- adds new variables: previousRow, previousColumn, previousArray, previousArrSize
 * to be used as a backup for reset
 * 
 * move(x, y): is overriden from the parent class's method 
 * -- if you try to move an object back to the same direction as where it previously was 
 * it will increment invalidMove
 * 
 * shift(p): changes the range of the infantry object to p (if p is within bounds)
 * 
 * reset(): resets objects back to its previous active state, giving it original artillery array and size back
 * -- clone was used to make a shallow copy so the backup of the array will not be tampered with 
 * in case of using reset again
 * **/

