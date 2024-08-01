using System;
using System.Diagnostics;
using System.Linq; // using LINQ

public class ThreeOrMore : Game // inherits from Game class
{
    public ThreeOrMore(Statistics stats) : base(stats, 5) { } // Constructor, inherits from base method from the game class

    public override int PlayGame() // overrides the PlayGame method from Game class
    {
        int totalscore = 0; // sets totalScore value to be an initial 0 for the game
        while (totalscore < 20) // while total score is less than 20...
        {
            Console.WriteLine("\nWould you like to roll the dice? (Y/N)\n"); // asks user if they'd like to roll the dice
            string roll = Console.ReadLine(); // reads the users input
            if (roll.ToUpper().Trim() == "Y") // checks if the user answered "Y", .ToUpper() to capitalise to avoid errors
            {

                int[] rollResults = new int[5]; // creates array to hold results of dice rolls
                for (int i = 0; i < 5; i++) // for loop for each dice
                {
                    rollResults[i] = dice[i].Roll(); // rolls each dice and adds the result to the array following the for loop to iterate between each location in the array
                }



                Console.WriteLine($"Rolled {string.Join(" ", rollResults)}"); // reads the roll results to the player



                var groups = rollResults.GroupBy(x => x).OrderByDescending(g => g.Count()).ToList();
                // first instance of LINQ, uses 'GroupBy' method to group the results of the dice. OrderByDescending then organises them from the vlaue which appears the most to least (if I rolled three 2's, that'd be the highest). Then "ToList()" makes the results into a list.
                int highestCount = groups.First().Count(); // updates highest count
                int highestValue = groups.First().Key; // updates most common value rollled by the dice



                if (highestCount >= 2) // if at least two of the dice roll the highest value
                {


                    Console.WriteLine($"\nRolled {highestCount} {highestValue}'s");// rerolls the rest of the dice
                    bool whileChoice = true; // used to loop for error handling

                    while (whileChoice) // loop until the user enters valid input
                    {
                        Console.WriteLine($"\nYou rolled the same number {highestCount} times!");
                        Console.WriteLine($"\nWould you like to rethrow all the dice, or just the dice that didn't roll {highestValue}? (1 for rethrow all, 2 for just the low occuring dice)\n");
                        string choice = Console.ReadLine().Trim().ToUpper();

                        if (choice == "1") // if user wants to rethrow all the dice
                        {
                            for (int i = 0; i < 5; i++) // for loop, iterates 5 times to go through all dice
                            {
                                rollResults[i] = dice[i].Roll(); // rerolls all dice
                            }
                            break;
                        }
                        else if (choice == "2") // if user only wants to rethrow dice that isn't the highestValue
                        {
                            for (int i = 0; i < 5; i++) // for loop, iterates 5 times to go through all dice
                            {
                                if (rollResults[i] != highestValue) // checks if the current dice in the loop is the most common value
                                {
                                    rollResults[i] = dice[i].Roll(); // if not, then it rerolls it.
                                }
                            }
                            break;
                        }
                        else // if user didn't enter 1 or 2
                        {
                            Console.WriteLine("Invalid Input, please try again!"); // error handling
                        }
                    }



                    Console.WriteLine($"Second Roll: {string.Join(" ", rollResults)}"); // displays result of the second rolls to the user

                    groups = rollResults.GroupBy(x => x).OrderByDescending(g => g.Count()).ToList(); // second instance of LINQ, does the same thing again and groups the dice rolls, organises them  from most occuring to least, and turns it into a list
                    highestCount = groups.First().Count(); // updates highestcount to the new highest
                    highestValue = groups.First().Key; // updates most common value rolled by the dice
                }



                if (highestCount == 3) totalscore += 3; // if rolled three-of-a-kind, add 3 to totalscore
                if (highestCount == 4) totalscore += 6; // if rolled four-of-a-kind, add 6 to the totalscore
                if (highestCount == 5) totalscore += 12; // if rolled five-of-akind, add 12 to the total score


                Console.WriteLine($"Current Score: {totalscore}"); // reads out the users current score
            }



            else if (roll.ToUpper().Trim() == "N") // if the user says "N", .ToUpper() to capitalise their answer to avoid errors.
            {
                Console.WriteLine("\nGame Aborted.\n"); // Game aborts when they say no to rolling the dice
                return totalscore;
            }




            else // if user enters anything other than Y/N
            {
                Console.WriteLine("\nInvalid Input, Please Try AgaiN\n"); // error handling
            }

        }

        Console.WriteLine("Total is 20 or more. You win!"); // congratulates the user
        statistics.UpdateStats("ThreeOrMore", totalscore); // updates the statistics class with the total score of the game
        return totalscore;
    }






    // Testing below





    private static Random random = new Random(); // random number generator
    public override int TestingGame() // testing method for threeormore
    {
        int totalScore = 0; // sets total score to 0

        while (totalScore < 20) // while loop for the game, ends when totalScore is 20+
        {
            int[] rollResults = new int[5]; // array
            for (int i = 0; i < 5; i++) // for loop to go to each item in the array
            {
                rollResults[i] = dice[i].Roll(); // adds a random dice roll to each item in the array
            }

            int rollSum = rollResults.Sum(); // adds all the dice rolls together
            Debug.Assert(rollSum >= 5 && rollSum <= 30, $"Invalid roll sum: {rollSum}"); // checks that the dice rolls make sense and not one dice is missing

            var groups = rollResults.GroupBy(x => x).OrderByDescending(g => g.Count()).ToList(); // first instance of LINQ, uses 'GroupBy' method to group the results of the dice. OrderByDescending then organises them from the vlaue which appears the most to least (if I rolled three 2's, that'd be the highest). Then "ToList()" makes the results into a list.
            int highestCount = groups.First().Count(); // updates highestcount to the new highest
            int highestValue = groups.First().Key; // updates most common value rolled by the dice
 
           
            Console.WriteLine($"\nRolled {string.Join(" ", rollResults)}"); // reads the roll results to the player
            Console.WriteLine($"Most Common Dice Roll is : {highestValue}, It appears: {highestCount} times"); // reads the highest dice roll & how many times it occurs
            Console.WriteLine($"Roll Sum is: {rollSum}\n"); // adds them all together and presents it to the user


            int randomChoice;
            randomChoice = random.Next(1, 2); // random number picker between 1 and 2 to simulate a user choice


            if (randomChoice == 1) // testing rethrowing all dice
            {
                for (int i = 0; i < 5; i++) // for loop, iterates 5 times to go through all dice
                {
                    rollResults[i] = dice[i].Roll(); // rerolls all dice
                }
            }
            else if (randomChoice == 2) // testing rethrowing dice that aren't highestValue
            {
                for (int i = 0; i < 5; i++) // for loop, iterates 5 times to go through all dice
                {
                    if (rollResults[i] != highestValue) // checks if the current dice in the loop is the most common value
                    {
                        rollResults[i] = dice[i].Roll(); // if not, then it rerolls it.
                    }
                }
            }


            Console.WriteLine($"\nSecond Roll: {string.Join(" ", rollResults)}"); // displays result of the second rolls to the user

            groups = rollResults.GroupBy(x => x).OrderByDescending(g => g.Count()).ToList(); // second instance of LINQ, does the same thing again and groups the dice rolls, organises them  from most occuring to least, and turns it into a list
            highestCount = groups.First().Count(); // updates highestcount to the new highest
            highestValue = groups.First().Key; // updates most common value rolled by the dice

            Console.WriteLine($"Most Common Dice Roll is : {highestValue}, It appears: {highestCount} times"); // reads the highest dice roll & how many times it occurs
            Console.WriteLine($"Roll Sum is: {rollSum}\n"); // adds them all together and presents it to the user

            if (highestCount == 3) totalScore += 3; // if three-of-a-kind, add 3 to totalScore
            if (highestCount == 4) totalScore += 6; // if four-of-a-kind, add 6 to totalScore
            if (highestCount == 5) totalScore += 12; // if five-of-a-kind, add 12 to totalScore
            if (highestCount <= 2) totalScore += 0; // error handling without debug.assert
            if (highestCount >= 6) totalScore += 0; // error handling without debug.assert

        }
        return totalScore; // return


    }

}
