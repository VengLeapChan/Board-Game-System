// Class invariant:
// Guard class is a representation of Guard who can guard against attacks
// to create a Guard class object, you must pass in an array of int, the values of each int must positive and be 20 or less
// the array represents how many shield the object has and each int represents its durability

// shields are instantiated as down

// raiseShield() will make the shield go up and lowerShield() will make the shields go down
// block(x) takes in an int and will be used to block, where x is the position of the shield to be used (x >= 0 and x < length of the array)
// shield must be up to be used

// isAlive() - see if the object is alive or not
// isUp() - checks to see if the shield is up
// isBlocking() - checks to see if the shield is blocking or not

// if any values fall beyong the specified range, default values will be provided
using System;
namespace P5
{
	public class Guard : iGuard
	{

        private const int MAX_SHIELD = 20;
        private const int DEFAULT_SHIELDS = 5;
        private const int DEFAULT_SHIELD = 15;
        private const int BROKEN_SHIELD = -1;

        private bool up = false;
        private bool alive = true;
        private int defectiveShields;

        protected int[] shields;
        protected int activeShieldIndex ;

        private bool blocking = false; 

        // precondition: appropriate shieldArray
        // postcondition: none 
        public Guard(int[] shieldArray)
		{

            if (shieldArray.Length <= 0 || shieldArray == null)
            {
              
                shields = new int[DEFAULT_SHIELDS];
                for (int i = 0; i < shields.Length; i++)
                {
                    shields[i] = DEFAULT_SHIELD;
                }
            }
            else
            {
 
                shields = (int[])shieldArray.Clone();
                for (int i = 0; i < shields.Length; i++)
                {
                    shields[i] = (shields[i] <= 0 || shields[i] > MAX_SHIELD) ? DEFAULT_SHIELD : shields[i];
                }
            }

        }


        private bool shouldDie()
        {
            if (defectiveShields > (shields.Length / 2))
            {
                return true;
            }
            return false;
        }

        private int findUsableShieldIndex()
        {
            for (int i = 0; i < shields.Length; i++)
            {
                if (shields[i] != BROKEN_SHIELD)
                {
                    return i;
                }
            }

            return -1;
        }

        // precondition: none
        // postcondition: up will become true if it is alive  
        public void raiseShield()
        {
            if (isAlive()) { up = true; }
          
        }

        // precondition: none 
        // postcondition: up will become false if it is alive  
        public void lowerShield()
        {
            if (isAlive()) { up = false; }
        }

        // precondition: none
        // postcondition: none 
        public bool isUp()
        {
            return up;
        }

        // precondition: none
        // postcondition: none 
        public bool isBlocking()
        {
            return blocking; 
        }

        // precondition: none
        // postcondition: none 
        public bool isAlive()
        {
            return alive;
        }

        // precondition: appropriate x value
        // postcondition: alive could become false, could make blocking() true  
        public virtual void block(int x)
        {
            x = (Math.Abs(x) % (shields.Length));
            if (isUp() && shields[x] != BROKEN_SHIELD && isAlive())
            {
                activeShieldIndex = x;
                blocking = true; 
            }
            else
            {
                blocking = false;
                up = false;
                shields[findUsableShieldIndex()] = BROKEN_SHIELD;
                defectiveShields++;
                alive = (shouldDie()) ? false : alive; 
            }
        }

        private void breakShield()
        {
            blocking = false;
            up = false;
            shields[activeShieldIndex] = BROKEN_SHIELD;
            defectiveShields++;
            alive = (shouldDie()) ? false : alive;
        }

        // precondition: none
        // postcondition: alive could become false, blocking could become false 
        public int shieldingPower()
        {
            int shieldPower = shields[activeShieldIndex];
            breakShield();
            return shieldPower;
        }

	}
}


// Implementation Invarient:
/**
 * Guard() - instantiate Guard object based an array of integers representing the shields and each int represents the durability 
 * - error checking was provided by checking if the array was null or has the size of 0, to which default values were provided
 * - up is false from the beginning and blocking is set as false as well 
 */

/**
 * raiseShield() - changes the status of up to true (if alive) 
 */

/* lowerShield() - changes the status of up to false (if alive) 
 */

/** block(x) - takes in an integer 
 * - error checking is provided through modulo operation 
 * - will only block if shield is up and the shield is not broken -> makes the xth index of the shields array become the active shield to be used
 * - if shield is not up or shield is broken at that index -> will lose one shield, it will find the shield to break from the start of the array until it finds a shield that is not broken 
 */

/* shieldingPower() - is intented to be used to transfer the power of the shield to another object 
 * - it is used to take the shield's power and returns that power 
 * - shields can only be used once regardless of it the attack is stronger or not 
 * */
