using System;
using System.Diagnostics;

public class Testing // testing class
{
    private Statistics mockStatistics; // mock stats

    public Testing(Statistics statistics) // mock stats
    {
        mockStatistics = statistics; // mock stats
    }

    public void SevensOutTest() // sevens out test called from program.cs
    {
        Console.WriteLine("Running SevensOut Test..."); // informs user whats happening


        SevensOut game = new SevensOut(mockStatistics); // instantiates sevensout game


        int totalScore = game.TestingGame(); // calls totalScore variable from Testing game in sevensOut
        int finalRollTotal = game.GetFinalRollTotal(); // calls finalRollTotal variable from Testing game in sevensOut


        Debug.Assert(totalScore >= 0, "Total score should be a positive number!"); // debugging to check the score is positive
        Debug.Assert(finalRollTotal == 7, "The final roll total should be exactly 7!");// debugging to check the dice rolls are exactly 7


        Console.WriteLine("SevensOut Test Completed, no issues detected"); // test completed

    }

    public void ThreeOrMoreTest() // three or more test called from program.cs
    {
        Console.WriteLine("Running ThreeOrMoreTest...."); // informs user whats happening

        ThreeOrMore game = new ThreeOrMore(mockStatistics); // instantiates ThreeOrMore game

        int score = game.TestingGame();


        Debug.Assert(score >= 0, "Total score should be above zero!"); // debugging if the score is above zero

        Console.WriteLine("ThreeOrMore Test Completed, no issues detected"); // test completed
    }


}