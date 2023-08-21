using static bowlingScoreCalculator2._0.logic;

var scores = new List<int>();
var spares = new List<int>();
var strikes = new List<int>();
bool bonusx1 = false;
bool bonusx2 = false;

for (int i = 0; i < 10; i++)                                                                               // loop x10 (once for each frame)
{
    Console.WriteLine("\nFRAME: " + (i + 1));
    Console.WriteLine("How many pins were knocked down on throw one?");
    int throwOne = roll();                                                                                 // first throw
    scores.Add(throwOne);

    int strike = strikeCheck(i, throwOne);                                                                 // check for strike
    if (strike < 900)
    {
        strikes.Add(strike);                                                                               // add the index of the strike to list
        bool bonusThrow = bonusCheck(i);
        if (bonusThrow == true)                                                                            // check for 10th frame bonus
        {
            bonusx2 = true;
            Console.WriteLine("\nHow many pins were knocked down on throw two? (BONUS BALL)");
            int extraThrow = roll();                                                                       // bonus ball 1
            scores.Add(extraThrow);
            strike = strikeCheck(i, extraThrow);                                                           // check for strike
            if (strike < 900)
            {
                Console.WriteLine("\nHow many pins were knocked down on throw three? (BONUS BALL)");
                int extraThrow2 = roll();                                                                  // bonus ball 2
                scores.Add(extraThrow2);
            }
            else
            {
                Console.WriteLine("\nHow many pins were knocked down on throw three? (BONUS BALL)");
                int extraThrow2 = roll2(extraThrow);                                                       // bonus ball 2 (alternate)
                scores.Add(extraThrow2);
            }
        }
    }

    if (throwOne < 10)
    {
        Console.WriteLine("\nHow many pins were knocked down on throw two?");
        int throwTwo = roll2(throwOne);                                                                     // second throw
        scores.Add(throwTwo);

        int spare = spareCheck(i, throwOne, throwTwo);                                                      // check for spare
        if (spare < 900)
        {
            spares.Add(spare);                                                                              // add the index of the spare to list
            bool bonusThrow = bonusCheck(i);
            if (bonusThrow == true)                                                                         // check for 10th frame bonus
            {
                bonusx1 = true;
                Console.WriteLine("\nHow many pins were knocked down on throw three? (BONUS BALL)");
                int extraThrow = roll();                                                                    // bonus ball
                scores.Add(extraThrow);
            }
        }
    }
}

calculateBonus(scores, strikes, spares);                                   // calculates bonus points from any strikes and spares

removeExcess(scores, bonusx1, bonusx2);                                    // removes either 1 or 2 last index's from a 10th frame spare or strike

finalScore(scores);                                                        // add up and display final score