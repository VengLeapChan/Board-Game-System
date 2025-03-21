
using P5;
[TestClass]
public class fighterTest
{
    [TestMethod]
    public void occupyingSameSpace()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter soldier = new Fighter(20, 5, artil, 0, 0);
        Assert.ThrowsException<Exception>(() => { soldier.move(0, 0); });
        Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Fighter(20, 5, artil, 0, 0); });
        soldier.deleteBoard();
    }

    [TestMethod]
    public void checkInactive()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter soldier1 = new Fighter(20, 5, artil, 0, 0);
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
    public void checkKills()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter soldier1 = new Fighter(20, 5, artil, 0, 0);
        Fighter soldier2 = new Fighter(20, 5, artil, 1, 0);
        Fighter soldier3 = new Fighter(20, 5, artil, 2, 0);
        Fighter soldier4 = new Fighter(20, 5, artil, 3, 0);
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
    public void checkRange()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter soldier1 = new Fighter(20, 1, artil, 0, 0);
        Fighter soldier2 = new Fighter(20, 5, artil, 1, 0);
        Fighter soldier3 = new Fighter(20, 5, artil, 2, 0);
        Fighter soldier4 = new Fighter(20, 5, artil, 3, 0);
        soldier1.target();
        soldier1.target();
        soldier1.target();

        Assert.AreEqual(1, soldier1.sum());
        soldier1.deleteBoard();
    }

    [TestMethod]
    public void checkArtillery()
    {
        int[] artil = { 25, 25, 5, 25, 25 };
        Fighter soldier1 = new Fighter(20, 5, artil, 0, 0);
        Fighter soldier2 = new Fighter(20, 5, artil, 1, 0);
        Fighter soldier3 = new Fighter(20, 5, artil, 2, 0);
        Fighter soldier4 = new Fighter(20, 5, artil, 3, 0);
        soldier1.target();
        soldier1.target();
        Assert.IsFalse(soldier1.target());
        soldier1.deleteBoard();
    }

    [TestMethod]
    public void checkInvalidInjectionWithInvalidSize()
    {
        int[] artil = { };
        Fighter soldier1 = new Fighter(20, 5, artil, 0, 0);
        Fighter soldier2 = new Fighter(14, 5, artil, 1, 0);
        Fighter soldier3 = new Fighter(16, 5, artil, 2, 0);

        soldier1.target();
        Assert.IsFalse(soldier1.target());
        Assert.AreEqual(soldier1.sum(), 1);
        soldier1.deleteBoard();
    }

    public void checkInvalidInjectionWithInvalid()
    {
        int[] artil = { 100, 100, 100 };
        Fighter soldier1 = new Fighter(20, 5, artil, 0, 0);
        Fighter soldier2 = new Fighter(15, 5, artil, 1, 0);
        Fighter soldier3 = new Fighter(14, 5, artil, 2, 0);
        Fighter soldier4 = new Fighter(16, 5, artil, 2, 0);

        soldier1.target();
        soldier1.target();
        Assert.IsFalse(soldier1.target());
        Assert.AreEqual(soldier1.sum(), 2);
        soldier1.deleteBoard();
    }
}
