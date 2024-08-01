class Program
{
    static void Main() //application start
    {
        Statistics statistics = new Statistics(); //instantiates Statistics class

        while (true) //loops game menu
        {
            try // try and except, error handling
            {
                Console.WriteLine("\nMenu:"); // menu for the game, below are the options the user can pick
                Console.WriteLine("1) Play SevensOut"); // plays SevensOut
                Console.WriteLine("2) Play ThreeOrMore"); //plays ThreeorMore
                Console.WriteLine("3) View Statistics"); //views statistics
                Console.WriteLine("4) Testing Mode"); //enters testing mode
                Console.WriteLine("5) Quit Game"); // Quits the game

                Console.WriteLine("\nPlease Enter your input: (1-5)\n"); //asks user to enter a value of 1-5 to determine which option to use, it will then go down to the switch below and go with the corresponding choice

                string choice = Console.ReadLine().Trim().ToUpper(); //reads the users input, .Trim() to remove whitespace, .ToUpper() to capitalise the result

                switch (choice) //switch depending on what the user has picked, easier to read than a bunch of else if conditions
                {
                    case "1": // if user entered "1"
                        Game sevensOutGame = new SevensOut(statistics); //creates a new instance of the statistics for sevensOut
                        sevensOutGame.PlayGame(); // starts game
                        break; 
                    case "2": // if user entered "2"
                        Game threeOrMoreGame = new ThreeOrMore(statistics); //instantiates ThreeorMore game, 
                        threeOrMoreGame.PlayGame(); // starts game
                        break;
                    case "3":// if user entered "3"
                        statistics.ViewStats(); // activates method which prints current statistics (high score and total games played per game)
                        break;
                    case "4": // if user entered "4"
                        Testing testing = new Testing(statistics); // instantiates testing classes with statistics
                        testing.SevensOutTest(); // runs SevensOutTest
                        testing.ThreeOrMoreTest(); // runs ThreeOrMoreTest
                        break;
                    case "5": // if user entered "5"
                        return; // exits the game
                    default: // error handling, if the user does not pick between 1-5 it will send an error message and loop back to the menu and present the choices again
                        Console.WriteLine("\nInvalid Input, please try again.\n"); //error handling, any input that isn't 1-5 will output this and then loop back to the menu
                        break;
                }
            }
            catch (Exception ex) // error handling
            {
                Console.WriteLine($"\nAn Error Occurred: {ex.Message}\n"); // error handling
            }
        }
    }
}
