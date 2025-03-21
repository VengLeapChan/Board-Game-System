namespace FighterTest;
using P5;

[TestClass]
public class turretTest
{
    [TestMethod]
    public void moveTest()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter cannon = new Turret(20, 5, artil, 0, 0, 5);
        cannon.move(1, 2);
        Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Turret(20, 5, artil, 0, 0, 5); });
        cannon.deleteBoard();
    }

    [TestMethod]
    public void permenentDeathTest()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter cannon = new Turret(20, 5, artil, 0, 0, 5);
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
    public void reviveTest()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter cannon = new Turret(20, 5, artil, 0, 0, 5);
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
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter cannon = new Turret(20, 5, artil, 0, 0, 5);
        Fighter cannon1 = new Turret(20, 5, artil, 0, 1, 5);
        Fighter cannon2 = new Turret(20, 5, artil, 1, 0, 5);
        Assert.IsTrue(cannon.target());
        Assert.IsFalse(cannon.target());
        cannon.deleteBoard();
    }

    [TestMethod]
    public void rangeTest()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter cannon = new Turret(20, 5, artil, 0, 0, 5);
        Fighter cannon1 = new Turret(20, 5, artil, 0, 6, 5);
        Assert.IsFalse(cannon.target());
        cannon.shift(7);
        Assert.IsTrue(cannon.target());
        cannon.deleteBoard();
    }

}
