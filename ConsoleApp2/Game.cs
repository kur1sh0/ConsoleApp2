public abstract class Game // base for other classes
{
    protected Die[] dice; // array of Die class returns
    protected Statistics statistics; // instance of Statistics class

    public Game(Statistics stats, int numberofDice) // constructor, takes two methods being stats tracking and amount of dice used in the game
    {
        dice = new Die[numberofDice]; // array the size of the method numberOfDice
        for (int i = 0; i < numberofDice; i++) // for loop, go through the array
        {
            dice[i] = new Die(); // goes through each location in the array and assigns it a random value
        }
        statistics = stats; //instance of the Statistics class is updated with the stats method
    }

    public abstract int PlayGame(); // abstract method for each game to base itself off
    public abstract int TestingGame(); // abstract method for each test for each game to base itself off, adds more of a controlled environment and a consistent way to test each game
}   
