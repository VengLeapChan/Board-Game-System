// Class Invarient
// Turret Guard is an extension of Turret class as well as have functionality of a Guard Class
// constructor takes in the same arguments as Turret class with an extra Guard reference passed in at the end (must be alive)
// any type of Guard can be passed in (QuirkyGuard, OneSkipGuard or Guard)
// isUp() will check if its shield is up
// isBlocking() will check if the object is blocking
// raiseShield() will raise the shield
// lowerShield() will lower the shield
// block(x) will use the xth shield to block an attack; same requirements as Guard Class

// -- TurretGuard class shares other functionalities with Turret class
// -- please check that documentation for more information

using System;
namespace P5
{
    public class TurretGuard : Turret, iGuard
    {
        Guard guard;

        // precondition: pass in the appropriate items
        // postconditon: none
        public TurretGuard(int health, int attackRange, int[] artilleryPower, int rowPlacement, int columnPlacement, int inval, Guard g) : base(health, attackRange, artilleryPower, rowPlacement, columnPlacement, inval)
        {
            guard = g;
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

/* strengthLeft() was override
 * - if an object tries to attack a Turret Guard object, if it is blocking, it will use the strengthLeft() + shieldingPower() of the guard object 
 * - as such, a shield can be used for only one attack and will break immediately after the protection ahs been transferred 
 * 
 * - if the shield is not blocking, it will just return the strength of the fighter 
 * **/

/* Constructor - takes in what is required of a Turret object, as well as an extra guardObject which must appropriately passed in, if not a normal guard with default values is provided 
 * it will take Guard objects, QuirkyGuard objects, or OneSkipGuard objects, which means this item could be a cross of TurretGuard, TurretQuirkyGuard, or TurretOneSkipGuard
 * 
 * The cross product between Infantry and Guard objects is not supported because in this design, I believe that Infantrys are soliders who can only attack and not defend themselves, until turrets which
 * represents cannons and immobile objects 
*/

/* IsAlive() - will check the health of the fighter and not the health of the internal Guard objects because conceptually, in this design, a soldier can be alive without its shield
 * - the guard's livelihood is used to determine bad calls of block
 * **/

/** It retains all the functionalities of turretObject with the addition of guard functionalities
 */