using System;
using System.Data.Common;
using System.Text;

// Class invarient:
// -- Turret class is an extension of the Fighter class
// -- Turret object will die if 5 invalid requests are made
// -- Dying from that manner will make turret object die permamently
// -- move(x,y) -- turret object cannot be moved, thus, any call to move will lead to an
// -- increment as an invalid request
// -- reest() -- will revive and reset object back to its original state
// -- reset cannot be used on objects that have permently died
// -- shift(p) -- will change the range to p (within proper bounds)
// -- target() -- will find the closes object within range p
// -- it will only search for targets on the left of it, and right of it
// -- constructor takes in the same arguments as Fighter class with an extra allowedInvalidRequest variable at the end which can be passed in
// -- each object can have a different maximum invalid request
// -- Turret class shares other functionalities with Fighter class
// -- please check that documentation for more information

namespace P5
{
    public class Turret : Fighter
    {
        private int previousRow, previousColumn;
        private int[] previousArray;
        private int previousArrSize;
        private int previousHealth;
        private bool canRevive;

        public Turret(int health, int attackRange, int[] artilleryPower, int rowPlacement, int columnPlacement, int invalidAllowed) : base(health, attackRange, artilleryPower, rowPlacement, columnPlacement)
        {
            previousRow = -1;
            previousColumn = -1;
            previousArray = currentArtillery();
            previousArrSize = currentArtSize();
            previousHealth = strengthLeft();
            setAllowedInvalid(invalidAllowed);
            canRevive = true;
        }

        // preconditon: valid x and y
        // postcondition: could become invalid or permently dead 
        public override void move(int x, int y)
        {
            incrementInvalid();
            checkActive();
        }

        // preconditon: none
        // postcondition: could become valid and alive again 
        public override void reset()
        {
            if (canRevive)
            {
                updateArtillery((int[])previousArray.Clone());
                updateArtSize(previousArrSize);
                makeActive();
                changeStrength(previousHealth);
                makeAlive();
            }
        }

        protected override void checkActive()
        {
            if (seeInvalids() > totalInvalidMovesAllowed())
            {
                canRevive = false;
                makeDead();

            }

            base.checkActive();
        }

        // preconditon: none
        // postconditon: none 
        public override void shift(int p)
        {
            setRange(p);
        }

        protected override Fighter search()
        {

            for (int i = currentCol() - 1; i >= (currentCol() - seeRange()); i--)
            {
                if (i >= 0)
                {
                    if (board[currentRow(), i] != null && board[currentRow(), i].isAlive())
                    {

                        return board[currentRow(), i];
                    }
                }
            }
            for (int i = currentCol() + 1; i <= (currentCol() + seeRange()); i++)
            {
                if (i < seeMaxBoardCol())
                {
                    if (board[currentRow(), i] != null && board[currentRow(), i].isAlive())
                    {
                        return board[currentRow(), i];
                    }
                }
            }

            return null;
        }
    }
}

// Implementation invarient
/* constructor: takes in the same parameters as the parent class 
 * -- adds new variables: previousRow, previousColumn, previousArray, previousArrSize, previousHealth, canRevive
 * to be used as a backup for reset and used to revive as well 
 * 
 * move(x, y): is overriden from the parent class's method 
 * -- object cannot be moved, if move is called, it will incrememnt invalid request counter 
 * 
 * shift(p): changes the range of the infantry object to p (if p is within bounds)
 * 
 * target(): calls helper method search to find a target. 
 * search can now only be used to search the left and right of the object 
 * 
 * reset(): resets and revives the object if the object has not died permanently
 * resets objects back to its previous active state, giving it original artillery array and size back
 * it also changes the strength back to the original and changes the state back to alive
 * -- clone was used to make a shallow copy so the backup of the array will not be tampered with 
 * in case of using reset again
 * **/

