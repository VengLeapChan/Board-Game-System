// Interface Invariant:
// For any implementation of iGuard:
// - isUp should return true if the guard is up, and false otherwise.
// - isBlocking should return true if the guard is currently blocking, and false otherwise.
// - isAlive should return true if the guard is alive, and false otherwise.
// - all guards must be able to block
// - all gaurds must be able to raiseShield() and lowerShield()

using System;
namespace P5
{
	public interface iGuard
	{
		void block(int x);
        void raiseShield();
        void lowerShield();
        bool isUp();
        bool isBlocking();
        bool isAlive();
    }
}

