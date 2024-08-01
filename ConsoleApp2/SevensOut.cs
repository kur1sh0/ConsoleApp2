using System;
using System.Diagnostics;

public class SevensOut : Game // inherits from game class
{
    public SevensOut(Statistics stats) : base(stats, 2) { } // takes the number of dice and the stats object as parameters

    public override int PlayGame() //  overrides the PlayGame method from Game class
    {
        int total = 0; // counter for how many points the user has got
        while (true) // loop until the game is completed
        {
            Console.WriteLine("\nWould you like to roll the dice? (Y/N)"); //asks user if they want to roll the dice
            string roll = Console.ReadLine(); // reads the users input
            if (roll.ToUpper().Trim() == "Y") // checks if the input is "Y", .ToUpper() method capitilises it to avoid capitalisation issues, .Trim() removes whitespace
            {
                int roll1 = dice[0].Roll(); // rolls dice 1
                int roll2 = dice[1].Roll(); // rolls dice 2
                int rollTotal = roll1 + roll2; // total is the two dice rolls added together

                Console.WriteLine($"\nYou have rolled: {roll1} and {roll2}"); // tell user what they rolled

                if (rollTotal == 7) // if total is 7, stop
                {
                    Console.WriteLine("Total is 7, Game Over!"); // tells player game is over
                    statistics.UpdateStats("SevensOut", total); // updates statistics class with the total score of the game
                    break;
                }

                if (roll1 == roll2) // if both dice are equal
                {
                    Console.WriteLine("Not quite! But because both dice are equal, your dice total has been doubled and added to your total!");
                    total += 2 * rollTotal; // if both dice are equal, double the total score to your total
                }
                else // if both dice are seperate numbers that don't add up to seven
                {
                    Console.WriteLine("Dice results added to your total score!");
                    total += rollTotal; // add rollTotal to total
                }

                Console.WriteLine($"Current Total: {total}"); // display current total to the user
            }
            else if (roll.ToUpper().Trim() == "N") // checks if the input is "N", .ToUpper() method capitilises it to avoid capitalisation issues, .Trim() removes whitespace
            {
                Console.WriteLine("\nGame Aborted.\n");
                return total; // Returns to main menu
            }
            else // if user inputs neither Y or N
            {
                Console.WriteLine("\nInvalid Input, please try again:\n"); // error handling for invalid inputs (any not Y or N)
            }

        }
        return total;
    }




    // Testing below






    private int TestingRollTotal; // used to store the final roll total for testing purposes
    public override int TestingGame() // testing method
    {

        int total = 0; // sets total score

        while (true) // while loop for rolls
        {
            int roll1 = dice[0].Roll(); // rolls dice 1
            int roll2 = dice[1].Roll(); // rolls dice 2
            int rollTotal = roll1 + roll2; // adds the result to rollTotal
            Debug.Assert(rollTotal >= 2 && rollTotal <= 12, "Roll total out of range."); // debugs checks for if it's somehow less than 1 or greater than 12 (shouldn't be possible on 2D6)
            Console.WriteLine($"Rolled: {roll1} and {roll2}\n"); // tells user their rolls

            if (rollTotal == 7) // if rolled 7
            {
                Console.WriteLine("Dice add up to 7, Game Over!"); // game over message
                TestingRollTotal = rollTotal; // sets TestingRollTotal to the actual rollTotal, used in Testing.cs to check for if it adds up to 7 or not
                Console.WriteLine($"Your total was: {total}\n"); // displays total
                return total; // returns total
            }

            if (roll1 == roll2) // if rolled a double
            {
                total += 2 * rollTotal; // add them together and then * 2
                Console.WriteLine($"Doubles rolled! Total doubled. {roll1} + {roll2} * 2\n"); // tells user what happened for testing

            }
            else // if its a standard roll
            {
                total += rollTotal; // add both dice rolls to total
            }
            Console.WriteLine($"Current Total: {total}\n"); // displays current total to user, will then continuously loop back until 7 is reached

        }
    }

    public int GetFinalRollTotal() // Used to get access to the RollTotal in the testing class
    {
        return TestingRollTotal;
    }

}
