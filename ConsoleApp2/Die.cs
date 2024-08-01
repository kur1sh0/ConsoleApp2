using System;

public class Die // establishes a class called Die
{
    public int CurrentValue { get; private set; } // initialises a property called CurrentValue
    private static Random random = new Random(); // generate random numbers

    public Die() // when die is called, it calls the roll method
    {
        Roll(); // calls the Roll method below
    }

    public int Roll() // roll method
    {
        CurrentValue = random.Next(1, 7); // current value is set to random between 1,7
        return CurrentValue; // returns the value
    }
}
