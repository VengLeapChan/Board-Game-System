﻿namespace FighterTest;
using P5;
[TestClass]
public class GaurdTest
{
    [TestMethod]
    public void instantiationDefault()
    {
        int[] badArray = { -1, -1, -1 };
        Guard g = new Guard(badArray);

        Assert.IsTrue(g.isAlive());
        Assert.IsFalse(g.isUp());
    }

    [TestMethod]
    public void raiseLowerTest()
    {
        int[] badArray = { -1, -1, -1 };
        Guard g = new Guard(badArray);
        g.raiseShield();
        Assert.IsTrue(g.isUp());
        g.lowerShield();
        Assert.IsFalse(g.isUp());
    }

    [TestMethod]
    public void blockingTest()
    {
        int[] badArray = { -1, -1, -1 };
        Guard g = new Guard(badArray);
        g.raiseShield();
        Assert.IsTrue(g.isUp());
        g.block(2);
        Assert.IsTrue(g.isBlocking());
    }

    [TestMethod]
    public void badBlocking()
    {
        int[] badArray = { -1, -1, -1 };
        Guard g = new Guard(badArray);
        g.block(2);
        Assert.IsFalse(g.isBlocking());
    }

    [TestMethod]
    public void death()
    {
        int[] badArray = { -1, -1, -1 };
        Guard g = new Guard(badArray);
        g.block(2);
        Assert.IsTrue(g.isAlive());
        g.block(2);
        Assert.IsFalse(g.isBlocking());
        Assert.IsFalse(g.isAlive());
    }

    [TestMethod]
    public void blockingPower()
    {
        int[] badArray = { -1, -1, -1 };
        Guard g = new Guard(badArray);
        g.raiseShield();
        g.block(2);
        Assert.AreEqual(15, g.shieldingPower());
    }

}
