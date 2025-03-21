// Class Invarient
// Fighter Guard is an extension of Turret class as well as have functionality of a Guard Class
// constructor takes in the same arguments as Turret class with an extra Guard reference passed in at the end (must be alive)
// any type of Guard can be passed in (QuirkyGuard, OneSkipGuard or Guard)
// isUp() will check if its shield is up
// isBlocking() will check if the object is blocking
// raiseShield() will raise the shield
// lowerShield() will lower the shield
// block(x) will use the xth shield to block an attack; same requirements as Guard Class

// -- FighterGuard class shares other functionalities with Turret class
// -- please check that documentation for more information


using System;
namespace P5
{
	public class FighterGuard: Fighter, iGuard
	{
		Guard guard;

        // precondition: pass in the appropriate items
        // postconditon: none
        public FighterGuard(int health, int attackRange, int[] artilleryPower, int rowPlacement, int columnPlacement, Guard guardian):base(health, attackRange,artilleryPower, rowPlacement,columnPlacement) 
		{
            if (guardian.isAlive())
            {
                guard = guardian;
            }
            else
            {
                int[] arr = { 15, 15, 15 };
                guard = new Guard(arr);

            }
        }

        // precondition: none
        // postconditon: none
        public override bool isUp()
		{
			return guard.isUp();
		}

        // precondition: none
        // postconditon: none
        public override bool isBlocking()
		{
			return guard.isBlocking();
		}

        // precondition: pass in appropriate x value
        // postcondition: alive could become false, could make blocking() true  
        public override void block(int x)
		{
			guard.block(x);
			if (!guard.isAlive())
			{
				incrementInvalid();
			}
		}

        // precondition: none 
        // postcondition: up will become true if it is alive 
        public override void raiseShield()
		{
			guard.raiseShield();
		}

        // precondition: none 
        // postcondition: up will become false if it is alive 
        public override void lowerShield()
        {
            guard.lowerShield();
        }

        protected override int strengthLeft()
        {
            if (guard.isBlocking() && guard.isAlive())
			{
				return base.strengthLeft() + guard.shieldingPower();
			}

			return base.strengthLeft();
        }
    }
}

// Implementation invarient:

/* Constructor - takes in what is required of a fighter object, as well as an extra guardObject which must appropriately passed in, if not a normal guard with default values is provided 
 * it will take Guard objects, QuirkyGuard objects, or OneSkipGuard objects, which means this item could be a cross of FighterGuard, FighterQuirkyGuard, or FighterOneSkipGuard
 * 
 * 
 * This object has all the same functionalities as a TurretGuard except instead of having turret functionalities, it has Fighter functionalities instead 
 * 
 * To learn more about the shared functionalities of TurretGuard, please check TurretGuard's implementation invarient 
 * **/