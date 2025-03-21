using System;
using System.Collections;
using P5;

namespace FighterTest
{
    public class TurretGuardTest
    {
        [TestMethod]
        public void moveTestGuard()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new Guard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            cannon.move(1, 2);
            Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Turret(20, 5, artil, 0, 0, 5); });
            cannon.deleteBoard();
        }

        [TestMethod]
        public void moveTestQuirkyGuard()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new QuirkyGuard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            cannon.move(1, 2);
            Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Turret(20, 5, artil, 0, 0, 5); });
            cannon.deleteBoard();
        }

        [TestMethod]
        public void moveTestOneSkipGuard()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new OneSkipGuard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            cannon.move(1, 2);
            Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Turret(20, 5, artil, 0, 0, 5); });
            cannon.deleteBoard();
        }

        [TestMethod]
        public void permenentDeathTestOneSkipGuard()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new OneSkipGuard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            Assert.IsFalse(cannon.isActive());
            Assert.IsFalse(cannon.isAlive());
            cannon.reset();
            Assert.IsFalse(cannon.isActive());
            Assert.IsFalse(cannon.isAlive());

            cannon.deleteBoard();
        }

        [TestMethod]
        public void permenentDeathTestGuard()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new Guard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            Assert.IsFalse(cannon.isActive());
            Assert.IsFalse(cannon.isAlive());
            cannon.reset();
            Assert.IsFalse(cannon.isActive());
            Assert.IsFalse(cannon.isAlive());

            cannon.deleteBoard();
        }

        [TestMethod]
        public void permenentDeathTestQuirkyGuard()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new QuirkyGuard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            cannon.move(1, 2);
            Assert.IsFalse(cannon.isActive());
            Assert.IsFalse(cannon.isAlive());
            cannon.reset();
            Assert.IsFalse(cannon.isActive());
            Assert.IsFalse(cannon.isAlive());

            cannon.deleteBoard();
        }

        [TestMethod]
        public void reviveTestGuard()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new Guard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5,g);
            Fighter cannon1 = new Turret(20, 5, artil, 0, 1, 5);
            cannon1.target();
            Assert.IsFalse(cannon.isActive());
            Assert.IsFalse(cannon.isAlive());
            cannon.reset();
            Assert.IsTrue(cannon.isActive());
            Assert.IsTrue(cannon.isAlive());
            cannon.deleteBoard();
        }

        [TestMethod]
        public void reviveTestQuirkyGuard()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new QuirkyGuard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            Fighter cannon1 = new Turret(20, 5, artil, 0, 1, 5);
            cannon1.target();
            Assert.IsFalse(cannon.isActive());
            Assert.IsFalse(cannon.isAlive());
            cannon.reset();
            Assert.IsTrue(cannon.isActive());
            Assert.IsTrue(cannon.isAlive());
            cannon.deleteBoard();
        }

        [TestMethod]
        public void reviveTestOneSkipGuard()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new OneSkipGuard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            Fighter cannon1 = new Turret(20, 5, artil, 0, 1, 5);
            cannon1.target();
            Assert.IsFalse(cannon.isActive());
            Assert.IsFalse(cannon.isAlive());
            cannon.reset();
            Assert.IsTrue(cannon.isActive());
            Assert.IsTrue(cannon.isAlive());
            cannon.deleteBoard();
        }

        [TestMethod]
        public void targetTest()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new Guard(array);
            Guard h = new OneSkipGuard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            Fighter cannon1 = new TurretGuard(20, 5, artil, 0, 1, 5, h);
            Fighter cannon2 = new Turret(20, 5, artil, 1, 0, 5);
            Assert.IsTrue(cannon.target());
            Assert.IsFalse(cannon.target());
            cannon.deleteBoard();
        }

        [TestMethod]
        public void targetFailTest()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new Guard(array);
            Guard h = new OneSkipGuard(array);
            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            Fighter cannon1 = new TurretGuard(20, 5, artil, 0, 1, 5, h);
            Fighter cannon2 = new Turret(20, 5, artil, 1, 0, 5);
            cannon1.raiseShield();
            cannon1.block(2);
            Assert.IsTrue(cannon.target());
            Assert.IsFalse(cannon.target());
            Assert.IsTrue(cannon1.isAlive());
            cannon.deleteBoard();
        }

        [TestMethod]
        public void blockingTest()
        {
            int[] array = { 10, 20, 25 };
            Guard g = new Guard(array);
            Guard h = new OneSkipGuard(array);
            Guard i = new QuirkyGuard(array);

            int[] artil = { 25, 25, 25, 25, 25 };
            Fighter cannon = new TurretGuard(20, 5, artil, 0, 0, 5, g);
            Fighter cannon1 = new TurretGuard(20, 5, artil, 0, 1, 5, h);
            Fighter cannon2 = new TurretGuard(20, 5, artil, 0, 2, 5, i);
            cannon1.raiseShield();
            cannon1.block(2);
            Assert.IsTrue(cannon.target());
            Assert.IsTrue(cannon.target());
            Assert.IsFalse(cannon1.isAlive());
            cannon.deleteBoard();
        }


    }

}

