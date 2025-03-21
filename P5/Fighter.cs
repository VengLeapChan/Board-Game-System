using System;
namespace P5;

// Class invariant:
// -- Fighter class represents a character on a board game 
// -- In the fighter class, there is one board that all fighter class, and its children shares
// -- To create a fighter object, you must give it armament strength (int), range (int), artilleryArray (int), and row (int) and column (int)
// -- the Range of strength will be from 1 to 20; the range of range will be from 0 to 7; all elements of the artilleryArray must be less than 30
// -- The board that the pieces reside on is a 21 by 21 board where it is indexed from 0 to 20, rows and columns must fall within those ranges
// -- The artillery array represents a fighter's attack and the length of the array represents how many times it can attack
// -- The artillery array must contant 5 or less items, each int must be in the range of 1 to 30
// -- Fighters have 4 states represents by 2 booleans: active, inactive (represented by active) and dead, alive (represented by alive)
// -- Fighter objects cannot be revived nor resetted, meaning once it becomes inactive and dead, it will remain so 
// -- If the object is dead, it cannot move
// -- Fighter objects can make up to 5 invalid moves. If it exceeds this limit, it will become inactive and it will no longer be able to attack
// -- Fighter object cannot be instantiate on the board if another object is placed, an exception will be thrown if that occurs
// -- move(int x, int y) allows the object to move from one place to the specified place on the board if it is valid,
// -- move cannot move items to the same place
// -- shift(int p) does not have any functionality
// -- reset() is a placehold to be overriden and does not have any effect on the class
// -- target() will find the nearest object in the range and try to attack it, it the attack is successful, it will return true and the
// targeted object will die, otherwise, it will increment invalid move
// -- target() requires artillery_size > 0, if not, an exception will be thrown
// -- sum() returns how many enemy this object has killed
// -- all dead objects will become inactive
// -- deleteBoard() removes all the piece off the board, including the piece that calls it 
// -- if any values fall beyong the specified range, default values will be provided

// Update:
// the strength of the fighter is depedent on the last item of the artilery array
// isUp(), isBlocking(), block(int x), raiserShield(), lowerShield() all do not have any effect on this class and is a placeholder


public class Fighter
{
    private const int MAX_BOARD_ROW = 21;
    private const int MAX_BOARD_COLUMN = 21;
    private const int MAX_ATTACK_RANGE = 7;
    private const int MAX_ARTILLERY_SIZE = 7;
    private const int MAX_ARTILLERY_ATTACK = 30;
    private const int MAX_STRENGTH = 20;
    private const int MAX_INVALID_MOVE = 5;

    static protected Fighter[,] board = new Fighter[MAX_BOARD_ROW, MAX_BOARD_COLUMN];

    private int[] artillery;
    private int artillerySize;
    private int strength;
    private int range;
    private bool active, alive;
    private int invalidMove;
    private int vanquished;
    private int invalidRequestAllowed;

    private int row, column;


    public Fighter(int health, int attackRange, int[] artilleryPower, int rowPlacement, int columnPlacement)
    {
        range = ((Math.Abs(attackRange) % (MAX_ATTACK_RANGE + 1)) == 0) ? 1 : ((Math.Abs(attackRange) % (MAX_ATTACK_RANGE + 1)));
        vanquished = 0;

        invalidRequestAllowed = MAX_INVALID_MOVE;
        if (!addToBoard(rowPlacement, columnPlacement))
        {
            throw new Exception("You are trying to place an object on the board, but another object is there");
        }
        if (artilleryPower.Length <= 0 || artilleryPower.Length > MAX_ARTILLERY_SIZE || artilleryPower == null)
        {
            artillerySize = MAX_ARTILLERY_SIZE / 2;
            artillery = new int[artillerySize];
            for (int i = 0; i < artillerySize; i++)
            {
                artillery[i] = MAX_ARTILLERY_ATTACK / 2;
            }
        }
        else
        {
            artillerySize = artilleryPower.Length;
            artillery = (int[])artilleryPower.Clone();
            for (int i = 0; i < artillerySize; i++)
            {
                artillery[i] = (artillery[i] <= 0 || artillery[i] > MAX_ARTILLERY_ATTACK) ? MAX_ARTILLERY_ATTACK / 2 : artillery[i];
            }
        }

        strength = (((Math.Abs(health)+ (artillery[artillery.Length - 1] * 10 / 100) % (MAX_STRENGTH + 1))) == 0) ? 1 : ((Math.Abs(health) % (MAX_STRENGTH + 1)));
        active = true;
        alive = true;
    }

    protected bool addToBoard(int itemRow, int itemColumn)
    {
        row = ((Math.Abs(itemRow) % (MAX_BOARD_ROW + 1)));
        column = ((Math.Abs(itemColumn) % (MAX_BOARD_COLUMN + 1)));

        if (board[itemRow, itemColumn] == null)
        {
            board[itemRow, itemColumn] = this;
            return true;
        }

        return false;
    }

    // precondition: valid x, and valid y 
    // postcondition: become inactive 
    public virtual void move(int x, int y)
    {
        if (!isAlive()) { return; }
        if (x == row && y == column)
        {
            throw new Exception("You are try to move the object to the same location.");
        }
        board[row, column] = null;

        row = ((Math.Abs(x) % (MAX_BOARD_ROW + 1)));
        column = ((Math.Abs(y) % (MAX_BOARD_COLUMN + 1)));

        if (!addToBoard(row, column))
        {
            invalidMove++;
            checkActive();
        };
    }

    // precondition: None
    // postcondition: None
    public virtual void shift(int p) { return; }

    // precondition: None
    // postcondition: change this object, or targetted object into death and inactive 
    public virtual bool target()
    {

        // check if there is anything to shoot
        Fighter target = search();
        if (target == null)
        {
            invalidMove++;
            checkActive();
            return false;
        }

        if (artillerySize <= 0)
        {
            throw new Exception("You cannot attack because your artillery is empty");
        }

        artillerySize--;
        if (target.strengthLeft() <= artillery[artillerySize])
        {
            target.die();
            vanquished++;
            checkActive();
            return true;
        }

        invalidMove++;
        checkActive();
        return false;
    }

    // pre-condition: None
    // post-condition: None 
    public virtual void reset()
    {
        return;
    }

    // precondition: None
    // postcondition: None
    public void deleteBoard()
    {
        board = null;
        board = new Fighter[MAX_BOARD_ROW, MAX_BOARD_COLUMN];
    }

    protected virtual Fighter search()
    {

        for (int i = row + 1; i <= (row + range); i++)
        {
            if (i < MAX_BOARD_ROW)
            {
                if (board[i, column] != null && board[i, column].isAlive())
                {
                    return board[i, column];
                }
            }
        }

        for (int i = column + 1; i <= (column + range); i++)
        {
            if (i < MAX_BOARD_COLUMN)
            {
                if (board[row, i] != null && board[row, i].isAlive())
                {
                    return board[row, i];
                }
            }
        }

        for (int i = row - 1; i >= (row - range); i--)
        {
            if (i > 0)
            {
                if (board[i, column] != null && board[i, column].isAlive())
                {
                    return board[i, column];
                }
            }
        }

        for (int i = column - 1; i >= (column - range); i--)
        {
            if (i >= 0)
            {
                if (board[row, i] != null && board[row, i].isAlive())
                {
                    return board[row, i];
                }
            }
        }

        return null;
    }

    protected void die()
    {
        strength = 0;
        alive = false;
        checkActive();
    }

    protected virtual void checkActive()
    {
        if (invalidMove > invalidRequestAllowed || artillerySize <= 0 || !isAlive())
        {
            active = false;
            artillery = null;
            artillerySize = 0;
        }
    }


    // pre-condition: None
    // post-condition: None 
    public int sum()
    {
        return vanquished;
    }

    // pre-condition: None
    // post-condition: None 
    public bool isAlive() { return alive; }
    protected void makeAlive() { alive = true; }
    protected void makeDead() { alive = false; }

    // pre-condition: None
    // post-condition: None 
    public bool isActive() { return active; }
    protected void makeActive() { active = true; }

    protected virtual int strengthLeft() { return strength; }
    protected void changeStrength(int health) { strength = ((Math.Abs(health) % (MAX_STRENGTH + 1)) == 0) ? 1 : ((Math.Abs(health) % (MAX_STRENGTH + 1))); }

    protected int seeRange() { return range; }
    protected void setRange(int attackRange) { range = ((Math.Abs(attackRange) % (MAX_ATTACK_RANGE + 1)) == 0) ? 1 : ((Math.Abs(attackRange) % (MAX_ATTACK_RANGE + 1))); }

    protected int seeInvalids() { return invalidMove; }
    protected void incrementInvalid() { invalidMove++; }

    protected int currentRow() { return row; }
    protected void updateRow(int rowPlacement) { row = rowPlacement; }

    protected int currentCol() { return column; }
    protected void updateCol(int columnPlacement) { column = columnPlacement; }

    protected int[] currentArtillery() { return (int[])artillery.Clone(); }
    protected int currentArtSize() { return artillerySize; }

    protected void updateArtillery(int[] artil) { artillery = (int[])artil.Clone(); }
    protected void updateArtSize(int size) { artillerySize = size; }

    protected int totalInvalidMovesAllowed() { return invalidRequestAllowed; }
    protected void setAllowedInvalid(int x) { invalidRequestAllowed = x; }
    protected int seeMaxBoardCol() { return MAX_BOARD_COLUMN; }

    public virtual bool isUp() { return false; }
    public virtual bool isBlocking() { return false; }
    public virtual void block(int x) { return; }
    public virtual void raiseShield() { return; }
    public virtual void lowerShield() { return; }
}

// Implementation Invarient:
/**
 * Fighter() - instantiate Fighter object based passed in values 
 * - if values are too large or negative, modulo operator was used to convert it to the appropriate range
 * - artillery array that is supposed to be passed must have the size smaller than MAX_ARTILLERY_SIZE (currently set to 5) 
 * - and ints in the array must be 0 - MAX_ARTILLERY_ATTACK
 * - artillery creates a copy of the injected array
 * - if any items in the artillery array is considered invalid (less than zero, or more than MAX_ARTILLERY_ATTACK), they will be set with half of MAX_ARTILLERY_ATTACK
 * - if fighter tries to occupy a space that is already occupied, an exception is thrown 
 * - modulo is used for error response for strength and range to keep them in appropriate range
 * - modulo is also used if the range of row and column to keep them in appropriate range
 */

/**
 * move(int x, int y) - moves the calling object to x and y if it is currently not occupied and if it is in valid range 
 * - move will throw an exception if you try to move it to the same location or if you are trying to move it to an occupied location 
 * - dead objects cannot be moved but active objects can, this is to represent an character that is out of ammunition, but is still alive, so it can still move 
 * - 
 */

/* shift(int x) - does not do anything, but is place holder for child class to override
 */

/* deleteBoard() - was created to reset the shared internal board and set it back all to null
 */

/* sum() - returns the calling object's kill count, based on the vanquished 
 * **/

/* target() - Fighter object can only attack in 4 directions, up, down, left, right 
 * - target() will scan upwards and move clockwise, if nothing is found, it is considered an invalid move and will return false
 * - it will scan each direction based on the range of the object
 * - target will attack with the artillery[artillerySize - 1] and get the strength of the targetted object, if artillery[artillerySize - 1] > strength, the object will be killed 
 * - if target strength is larger, they will not be affect, but the calling object will increment invalid move 
 * - once the size of artillery hits 0, the object becomes inactive
 * */

/* there are a lot of protected getters and setter in place of making the 
 **/

// update
// added error checking for artillery array is null