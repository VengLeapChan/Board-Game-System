using System;
using System.Collections;
using P5;

namespace FighterTest
{
	public class FighterGuardTest
	{
        [TestMethod]
        public void moveTestGuard()
        {
            int[] badArray = { -1, -1, -1 };
            Guard g = new Guard(badArray);
            int[] artil = { 25, 25, 25, 25, 25 };
            FighterGuard fG = new FighterGuard(20, 5, artil, 0, 0,g);
            fG.move(1, 2);
            Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Turret(20, 5, artil, 0, 0, 5); });
            fG.deleteBoard();
        }

        [TestMethod]
        public void moveTestQuirkyGuard()
        {
            int[] badArray = { -1, -1, -1 };
            Guard g = new QuirkyGuard(badArray);
            int[] artil = { 25, 25, 25, 25, 25 };
            FighterGuard fG = new FighterGuard(20, 5, artil, 0, 0, g);
            fG.move(1, 2);
            Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Turret(20, 5, artil, 0, 0, 5); });
            fG.deleteBoard();
        }

        [TestMethod]
        public void moveTestOneSkipGuard()
        {
            int[] badArray = { -1, -1, -1 };
            Guard g = new OneSkipGuard(badArray);
            int[] artil = { 25, 25, 25, 25, 25 };
            FighterGuard fG = new FighterGuard(20, 5, artil, 0, 0, g);
            fG.move(1, 2);
            Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Turret(20, 5, artil, 0, 0, 5); });
            fG.deleteBoard();
        }

        [TestMethod]
        public void checkInactiveGuard()
        {
            int[] badArray = { -1, -1, -1 };
            Guard g = new Guard(badArray);
            int[] artil = { 25, 25, 25, 25, 25};
            Fighter soldier1 = new FighterGuard(20, 5, artil, 0, 0, g);
            soldier1.target();
            soldier1.target();
            soldier1.target();
            soldier1.target();
            Assert.IsTrue(soldier1.isActive());
            soldier1.target();
            soldier1.target();
            Assert.IsFalse(soldier1.isActive());
            soldier1.deleteBoard();
        }

        [TestMethod]
        public void checkInactiveQuirkyGuard()
        {
            int[] badArray = { -1, -1, -1 };
            Guard g = new QuirkyGuard(badArray);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter soldier1 = new FighterGuard(20, 5, artil, 0, 0, g);
            soldier1.target();
            soldier1.target();
            soldier1.target();
            soldier1.target();
            Assert.IsTrue(soldier1.isActive());
            soldier1.target();
            soldier1.target();
            Assert.IsFalse(soldier1.isActive());
            soldier1.deleteBoard();
        }

        [TestMethod]
        public void checkInactiveOneSkipGuard()
        {
            int[] badArray = { -1, -1, -1 };
            Guard g = new OneSkipGuard(badArray);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter soldier1 = new FighterGuard(20, 5, artil, 0, 0, g);
            soldier1.target();
            soldier1.target();
            soldier1.target();
            soldier1.target();
            Assert.IsTrue(soldier1.isActive());
            soldier1.target();
            soldier1.target();
            Assert.IsFalse(soldier1.isActive());
            soldier1.deleteBoard();
        }

        [TestMethod]
        public void checkKillsGuard()
        {
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter soldier1 = new Fighter(20, 5, artil, 0, 0);
            int[] badArray = { -1, -1, -1 };
            Guard g = new QuirkyGuard(badArray);
            Fighter soldier2 = new FighterGuard(20, 5, artil, 1, 0,g);
            Guard m = new OneSkipGuard(badArray);
            Fighter soldier3 = new FighterGuard(20, 5, artil, 2, 0, m);
            Guard n = new Guard(badArray);
            Fighter soldier4 = new FighterGuard(20, 5, artil, 3, 0, n);
            Fighter soldier5 = new Fighter(20, 5, artil, 4, 0);
            Fighter soldier6 = new Fighter(20, 5, artil, 5, 0);
            soldier1.target();
            soldier1.target();
            soldier1.target();
            soldier1.target();
            soldier1.target();

            Assert.IsFalse(soldier2.isAlive());

            Assert.AreEqual(5, soldier1.sum());
            soldier1.deleteBoard();
        }

        [TestMethod]
        public void checkBlock()
        {
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter soldier1 = new Fighter(20, 5, artil, 0, 0);
            int[] badArray = { -1, -1, -1 };
            Guard g = new QuirkyGuard(badArray);
            Fighter soldier2 = new FighterGuard(20, 5, artil, 1, 0, g);
            soldier2.raiseShield();
            soldier2.block(1);
            Guard m = new OneSkipGuard(badArray);
            Fighter soldier3 = new FighterGuard(20, 5, artil, 2, 0, m);
            soldier3.raiseShield();
            soldier3.block(1);
            Guard n = new Guard(badArray);
            Fighter soldier4 = new FighterGuard(20, 5, artil, 3, 0, n);
            soldier4.raiseShield();
            soldier4.block(1);
            Fighter soldier5 = new Fighter(20, 5, artil, 4, 0);
            Fighter soldier6 = new Fighter(20, 5, artil, 5, 0);
            soldier1.target();
            soldier1.target();
            soldier1.target();
            soldier1.target();
            soldier1.target();

            Assert.IsFalse(soldier2.isAlive());

            Assert.AreEqual(2, soldier1.sum());
            soldier1.deleteBoard();
        }

        [TestMethod]
        public void checkBadBlocks()
        {
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter soldier1 = new Fighter(20, 5, artil, 0, 0);
            int[] badArray = { -1, -1, -1 };
            Guard g = new QuirkyGuard(badArray);
            Fighter soldier2 = new FighterGuard(20, 5, artil, 1, 0, g);
            Assert.IsFalse(soldier2.isUp());
            soldier2.block(1);
            Guard m = new OneSkipGuard(badArray);
            Fighter soldier3 = new FighterGuard(20, 5, artil, 2, 0, m);
            Assert.IsFalse(soldier3.isUp());
            soldier3.block(1);
            Guard n = new Guard(badArray);
            Fighter soldier4 = new FighterGuard(20, 5, artil, 3, 0, n);
            Assert.IsFalse(soldier4.isUp());
            soldier4.block(1);
            soldier4.isUp();
            Fighter soldier5 = new Fighter(20, 5, artil, 4, 0);
            Fighter soldier6 = new Fighter(20, 5, artil, 5, 0);
            soldier1.target();
            soldier1.target();
            soldier1.target();
            soldier1.target();
            soldier1.target();

            Assert.IsFalse(soldier2.isAlive());

            Assert.AreEqual(5, soldier1.sum());
            soldier1.deleteBoard();
        }


    }

}

