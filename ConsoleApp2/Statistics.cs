using System;

public class Statistics // statistics class
{
    protected int sevensoutPlays = 0; // tracks how many times the SevensOut game has been played
    protected int sevensoutHighScore = 0; // tracks the high score of the sevensout game
    protected int threeormorePlays = 0; // tracks how many times the threeormore game has been played
    protected int threeorMoreHighScore = 0; // tracks the high sore of the threeormore game

    public void UpdateStats(string game, int score) // for updating the stats depending on the score, will be called in other classess to update the total score and plays
    {
        if (game == "SevensOut") // checking if the game is sevensout
        {
            sevensoutPlays++; // increments sevensout by one each time its played, if the game is actually sevensout.
            if (score > sevensoutHighScore) // checking if the current achieved score is greater then the all-time high score recorded of the game.
            {
                sevensoutHighScore = score; // if it is higher, the high score is updated to be the current score
            }
        }
        else if (game == "ThreeOrMore") // checking if the game is threeormore
        {
            threeormorePlays++; // increments threeormore by one each time its played, if the game is actually threeormore.
            if (score > threeorMoreHighScore) // checks if the current achieved score is greater then the high score
            {
                threeorMoreHighScore = score; // if so, it updates the high score to be the current score
            }
        }
    }

    public void ViewStats() // for viewing the stats of the games from the main menu, being high score and number of plays, called from the main menu
    {
        Console.WriteLine("Statistics:"); // details the statistics to the player
        Console.WriteLine($"Sevens Out - Plays: {sevensoutPlays}, High Score: {sevensoutHighScore}"); // sevens out statistics
        Console.WriteLine($"Three Or More - Plays: {threeormorePlays}, High Score: {threeorMoreHighScore}"); // three or more stats
    }
}
