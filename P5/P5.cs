/**
 * Veng Leap Chan 
 * Friday, Jun 2nd, 2023
 * Last Revised: April 28th, 2023
 * Platform: MacOS
 **/

using System;
namespace P5
{
    public class P5
    {

        public static Guard[] makeGuardCollection()
        {
            Random rand = new Random();
            int[] art = { rand.Next(10) + 10, rand.Next(10) + 10, rand.Next(10) + 10, rand.Next(10) + 14, rand.Next(10) + 10 };
            Guard[] collection = new Guard[3];
            collection[0] = new Guard(art);
            int[] art2 = { rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 10, rand.Next(10) + 10 };
            collection[1] = new QuirkyGuard(art2);
            int[] art3 = { rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 10, rand.Next(10) + 10 };
            collection[2] = new OneSkipGuard(art3);
            return collection;
        }

        public static Guard[] makeGuardCollection1()
        {
            Random rand = new Random();
            int[] art4 = { rand.Next(10) + 10, rand.Next(10) + 10, rand.Next(10) + 10, rand.Next(10) + 14, rand.Next(10) + 10 };
            Guard[] collectionx = new Guard[3];
            collectionx[0] = new Guard(art4);
            int[] art5 = { rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 10, rand.Next(10) + 10 };
            collectionx[1] = new QuirkyGuard(art5);
            int[] art6 = { rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 10, rand.Next(10) + 10 };
            collectionx[2] = new OneSkipGuard(art6);
            return collectionx;

        }

        public static void guardHeterCollection()
        {
            //Random rand = new Random();
            //Guard[] collection = makeGuardCollection();
            //Console.WriteLine("---- Heterogenous Collection of Guard Objects: ----");
            //Console.WriteLine("---- Guard Object, QuirkyGuard Object, and OneSkipGuard Object were created ----");
            //Console.WriteLine();
            //Console.WriteLine("Guard Object: Calls raiseShield");
            //collection[0].raiseShield();
            //Console.WriteLine("Result of the call: " + collection[0].isUp());
            //Console.WriteLine("Guard Object will block");

            //collection[0].block(rand.Next() % 4);
            //Console.WriteLine("Result of the call: " + collection[0].isBlocking());
            //Console.WriteLine();

            //Console.WriteLine("Guard is Alive: " + collection[0].isAlive());
            //Console.WriteLine("QuirkyGuard is Alive: " + collection[1].isAlive());
            //Console.WriteLine("OneSkipGuard is Alive: " + collection[2].isAlive());
            //Console.WriteLine();

            //Console.WriteLine("QuirkyGuard will call block(x) 3 times and will die due to the Shield not being up");
            //collection[1].block(rand.Next() % 4);
            //collection[1].block(rand.Next() % 4);
            //collection[1].block(rand.Next() % 4);

            //Console.WriteLine();
            //Console.WriteLine("Guard is Alive: " + collection[0].isAlive());
            //Console.WriteLine("QuirkyGuard is Alive: " + collection[1].isAlive());
            //Console.WriteLine("OneSkipGuard is Alive: " + collection[2].isAlive());
            //Console.WriteLine();

            //Console.WriteLine("OneSkipBlock will call block properly");
            //collection[2].raiseShield();
            //collection[2].block(rand.Next() % 4);
            //Console.WriteLine();
            //Console.WriteLine("Guard is Blocking: " + collection[0].isBlocking());
            //Console.WriteLine("QuirkyGuard is Blocking: " + collection[1].isBlocking());
            //Console.WriteLine("OneSkipGuard is Blocking: " + collection[2].isBlocking());
            //Console.WriteLine();

        }

        //public static void fighterGuardCollection()
        //{
        //    Random rand = new Random();
        //    int[] art = { rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 14 };
        //    Fighter[] collection = new Fighter[3];
        //    Guard[] collection1 = makeGuardCollection();
        //    collection[0] = new FighterGuard((rand.Next(10) + 10), 5, art, 5, 6, collection1[0]);
        //    collection[1] = new FighterGuard((rand.Next(10) + 12), 5, art, 5, 7, collection1[1]);
        //    collection[2] = new FighterGuard((rand.Next(10) + 10), 5, art, 5, 8, collection1[2]);

        //    Console.WriteLine("---- FighterGuard Objects: ----");
        //    Console.WriteLine("---- FighterGuard (Object1), FighterQuirkyGuard (Object2), and FighterOneSkipGuard (Object3) ----");
        //    collection[0].move(5, 9);
        //    collection[0].move(5, 6);
        //    collection[1].move(5, 9);
        //    Console.WriteLine("Object1 is Active:" + collection[0].isActive());
        //    Console.WriteLine("Object2 is Active:" + collection[1].isActive());
        //    Console.WriteLine("Object3 is Active:" + collection[2].isActive());
        //    Console.WriteLine();
        //    Console.WriteLine("Object1: Calls Target");
        //    Console.WriteLine();
        //    Console.WriteLine("Result of the call: " + collection[0].target());
        //    collection[1].raiseShield();
        //    collection[1].block(rand.Next() % 5);
        //    collection[2].raiseShield();
        //    collection[2].block(rand.Next() % 5);
        //    Console.WriteLine("Result of the call: " + collection[0].target());
        //    collection[2].raiseShield();
        //    collection[2].block(rand.Next() % 5);
        //    Console.WriteLine("Result of the call: " + collection[0].target());
        //    collection[2].raiseShield();
        //    collection[2].block(rand.Next() % 5);
        //    Console.WriteLine("Result of the call: " + collection[0].target());
        //    Console.WriteLine("Result of the call: " + collection[0].target());
        //    Console.WriteLine();
        //    Console.WriteLine("Object1 is Active before reset:" + collection[0].isActive());
        //    Console.WriteLine("Object2 is Active before reset:" + collection[1].isActive());
        //    Console.WriteLine("Object3 is Active before reset:" + collection[2].isActive());
        //    Console.WriteLine();
        //    collection[0].reset();
        //    collection[1].reset();
        //    collection[2].reset();
        //    Console.WriteLine("Object1 is Active after reset:" + collection[0].isActive());
        //    Console.WriteLine("Object2 is Active after reset:" + collection[1].isActive());
        //    Console.WriteLine("Object3 is Active after reset:" + collection[2].isActive());
        //    Console.WriteLine();
        //    Console.WriteLine("Object1 sum: " + collection[0].sum());
        //    Console.WriteLine("Object2 sum: " + collection[1].sum());
        //    Console.WriteLine("Object3 sum: " + collection[2].sum());
        //    Console.WriteLine();

        //    collection[1].deleteBoard();
        //}

        public static void turretGuardCollection()
        {
            Random rand = new Random();

            int[] art = { rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 20, rand.Next(10) + 20 };
            Fighter[] collection = new Fighter[4];
            int[] art5 = { rand.Next(10) + 14, rand.Next(10) + 14, rand.Next(10) + 10, rand.Next(10) + 10 };
            Guard collectionx = new Guard(art5);
            collection[0] = new TurretGuard((rand.Next(10) + 10), 3, art, 5, 5, 5, collectionx);
            //    collection[1] = new Turret((rand.Next(10) + 10), 5, art, 5, 8, 5);
            //    collection[2] = new Turret((rand.Next(10) + 10), 5, art, 5, 11, 5);
            //    collection[0].move(6, 5);


            //    Console.WriteLine("---- Turret Guard Objects: ----");
            //    Console.WriteLine("---- Obect 1 (TurretGuard), Object 2 (TurretQuirkyGuard), and Object 3 (TurretOneSkipGuard) created ----");
            //    collection[0].move(6, 5);
            //    collection[3] = new Turret((rand.Next(10) + 10), 5, art, 6, 5, 5);
            //    Console.WriteLine("Object 4 was created on the location object 1 was supposed to move to");

            //    Console.WriteLine("Object1 is Active:" + collection[0].isAlive());
            //    Console.WriteLine("Object2 is Active:" + collection[1].isAlive());
            //    Console.WriteLine("Object3 is Active:" + collection[2].isAlive());
            //    Console.WriteLine("Object4 is Active:" + collection[3].isAlive());
            //    Console.WriteLine();

            //    Console.WriteLine("Object 1: Calls Target");
            //    Console.WriteLine("Result of the call: " + collection[0].target());
            //    Console.WriteLine("Result of the call: " + collection[0].target());
            //    Console.WriteLine("Object 1: Calls Shift");
            //    collection[0].shift(7);
            //    Console.WriteLine();
            //    Console.WriteLine("Result of the call: " + collection[0].target());
            //    Console.WriteLine("Result of the call: " + collection[0].target());
            //    Console.WriteLine("Result of the call: " + collection[0].target());
            //    Console.WriteLine();
            //    Console.WriteLine("Revive object 2 and 3");
            //    Console.WriteLine("Object1 is Alive (Before):" + collection[0].isAlive());
            //    Console.WriteLine("Object2 is Alive (Before):" + collection[1].isAlive());
            //    Console.WriteLine("Object3 is Alive (Before):" + collection[2].isAlive());
            //    Console.WriteLine("Object4 is Alive (Before):" + collection[3].isAlive());
            //    Console.WriteLine();
            //    collection[1].reset();
            //    collection[2].reset();
            //    Console.WriteLine("Object1 is Alive (After):" + collection[0].isAlive());
            //    Console.WriteLine("Object2 is Alive (After):" + collection[1].isAlive());
            //    Console.WriteLine("Object3 is Alive (After):" + collection[2].isAlive());
            //    Console.WriteLine("Object4 is Alive (After):" + collection[3].isAlive());
            //    Console.WriteLine();
            //    Console.WriteLine("Make Object 1 die permently");
            //    collection[0].move(1, 2);
            //    collection[0].move(1, 2);
            //    collection[0].move(1, 2);
            //    collection[0].move(1, 2);
            //    collection[0].move(1, 2);
            //    collection[0].move(1, 2);
            //    Console.WriteLine("Object1 is Alive (before revive attempt): " + collection[0].isAlive());
            //    Console.WriteLine();
            //    collection[0].reset();
            //    Console.WriteLine("Object1 is Alive (after revive attempt): " + collection[0].isAlive());
            //    Console.WriteLine();
            //    Console.WriteLine("Object1 sum: " + collection[0].sum());
            //    Console.WriteLine("Object2 sum: " + collection[1].sum());
            //    Console.WriteLine("Object3 sum: " + collection[2].sum());
            //    Console.WriteLine();
            //    collection[1].deleteBoard();
            //}
        }


        static void Main(string[] args)
        {
            //guardHeterCollection();
            //fighterGuardCollection();
            turretGuardCollection();
        }
    }
}

/** 
 * 
 * 3 array of objects were created: heterogenios collection of Guard Objects, FighterGuard array, TurretGuard array
 * - the Heterogeneous collection contains a Guard object, a QuirkyGuard Object, and a OneSkipGuard object 
 * - Some Functionalities were performed such as raisingShield, blocking, checking isUp(), isAlive(), and isBlocking()
 * 
 * - The fighterGuard array contains 3 FighterGuard class objects to perform certain functions and show its functionality
 * an example of this is moving an object to a location previously occupied by another object 
 * - similarly, fighterGuards object does not change any state when calling reset
 * - also, fighterGuard objects performed blocking 
 * 
 * 
 * - The turretGuard array contains 3 turret objects that will demonstrate its functionalities: turretGuard, turretQuirkyGuard, and turretOneSkip
 * - move() was show to not have any effect on the turret object 
 * - invalid requests will make turret object die permamently 
 * - turretGuard object can be revived and reset through the reset function if it has not died permently
 * - shift() shift was also show to have effected the range 
 * - target() can only attack items on the same row and within range 
 * - turretGuards can also perform blocking which blocks attacks
 */

