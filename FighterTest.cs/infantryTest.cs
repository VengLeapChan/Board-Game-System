namespace FighterTest;
using P5;

[TestClass]
public class infantryTest
{
    [TestMethod]
    public void sameLocationTest()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter soldier = new Infantry(20, 5, artil, 0, 0);
        Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Infantry(20, 5, artil, 0, 0); });
        Assert.ThrowsException<Exception>(() => { soldier.move(0, 0); });

        soldier.deleteBoard();
    }

    [TestMethod]
    public void illegalMoveTest()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter infant = new Infantry(20, 5, artil, 0, 0);
        infant.move(1, 1);
        infant.move(0, 0);
        Fighter infant1 = new Infantry(20, 5, artil, 0, 0);
        infant.deleteBoard();
    }

    [TestMethod]
    public void resetCheck()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter infant = new Infantry(20, 5, artil, 0, 0);
        Fighter infant1 = new Infantry(20, 5, artil, 0, 1);
        Fighter infant2 = new Infantry(20, 5, artil, 0, 2);
        Fighter infant3 = new Infantry(20, 5, artil, 0, 3);
        Fighter infant4 = new Infantry(20, 5, artil, 0, 4);
        Fighter infant5 = new Infantry(20, 5, artil, 0, 5);
        Fighter infant6 = new Infantry(20, 5, artil, 1, 0);
        Assert.IsTrue(infant.target());
        Assert.IsTrue(infant.target());
        Assert.IsTrue(infant.target());
        Assert.IsTrue(infant.target());
        Assert.IsTrue(infant.target());
        Assert.ThrowsException<Exception>(() => infant.target());
        Assert.IsFalse(infant.isActive());
        infant.reset();
        Assert.IsTrue(infant.target());
        Assert.IsTrue(infant.isActive());
        infant.deleteBoard();
    }

    [TestMethod]
    public void noReviveCheck()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter infant = new Infantry(20, 5, artil, 0, 0);
        Fighter infant2 = new Infantry(10, 5, artil, 0, 1);

        Assert.IsTrue(infant.target());
        Assert.IsFalse(infant2.isAlive());
        infant2.reset();
        Assert.IsFalse(infant2.isActive());
        Assert.IsFalse(infant2.isAlive());

        infant.deleteBoard();
    }

    [TestMethod]
    public void illegalMoveCheck()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter infant = new Infantry(20, 5, artil, 0, 0);
        infant.move(1, 2);
        infant.move(0, 0);
        Assert.ThrowsException<Exception>(() => { Fighter soldier2 = new Infantry(20, 5, artil, 1, 2); });

        infant.deleteBoard();
    }


    [TestMethod]
    public void rangeCheck()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter infant = new Infantry(20, 5, artil, 0, 0);
        Fighter infant1 = new Infantry(20, 5, artil, 4, 0);
        infant.shift(5);
        Assert.IsTrue(infant.target());
        Fighter infant2 = new Infantry(20, 5, artil, 3, 0);
        infant.shift(2);
        Assert.IsFalse(infant.target());
        infant.deleteBoard();
    }

    [TestMethod]
    public void invalidRangeCheck()
    {
        int[] artil = { 25, 25, 25, 25, 25 };
        Fighter infant = new Infantry(20, 14, artil, 0, 0);
        Fighter infant1 = new Infantry(20, 6, artil, 6, 0);
        Assert.IsTrue(infant.target());
        infant.deleteBoard();
    }
}
