
using System;
using System.Runtime.CompilerServices;

int playerTotal = 0;
int finalThrow = 0;
bool lastRoll = false;
bool[] strikes = { false, false, false, false, false, false, false, false, false, false, };
bool[] spares = { false, false, false, false, false, false, false, false, false, false, };
int[,] frames = { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
String[] showFrames = { "", "", "", "", "", "", "", "", "", "" };

for (int i = 0; i < frames.GetLength(0); i++)
{
    Console.WriteLine(" ");
    Console.WriteLine("FRAME: " + (i + 1));
    Console.WriteLine("How many pins were knocked down on throw one?");                                  // first roll
    int pinsKnocked1 = Convert.ToInt32(Console.ReadLine());



    if (pinsKnocked1 == 10)                                                                              // check for strike
    {
        if (i == 9)                                                                                      // check if on 10th frame for bonus (strike)
        {
            Console.WriteLine(" ");
            Console.WriteLine("How many pins were knocked down on throw two? (BONUS BALL)");
            int pinsKnocked3 = Convert.ToInt32(Console.ReadLine());

            if (pinsKnocked3 == 10)
            {
                Console.WriteLine(" ");
                Console.WriteLine("How many pins were knocked down on throw three? (BONUS BALL)");
                finalThrow = Convert.ToInt32(Console.ReadLine());

                lastRoll = true;                                                                          // last roll true

                if (finalThrow == 10)
                {
                    showFrames[i] = "X" + "X" + "X";
                }
                else
                {
                    showFrames[i] = "X" + "X" + finalThrow;
                }
            }
            else if (pinsKnocked3 == 0)
            {
                showFrames[i] = "X" + "-";
            }
            else
            {
                showFrames[i] = "X" + pinsKnocked3;
            }
            frames[i, 0] = pinsKnocked1;
            frames[i, 1] = pinsKnocked3;
        }
        else
        {
            frames[i, 0] = pinsKnocked1;
            strikes[i] = true;                                                                           // strike true
            showFrames[i] = "X";
        };
    }
    else
    {
        if (pinsKnocked1 == 0)
        {
            showFrames[i] = showFrames[i] + "-";
        }

        Console.WriteLine(" ");
        Console.WriteLine("How many pins were knocked down on throw two?");                              // second roll
        int pinsKnocked2 = Convert.ToInt32(Console.ReadLine());

        if (pinsKnocked1 + pinsKnocked2 == 10)                                                           // check for spare
        {
            if (i == 9)                                                                                  // check if on 10th frame for bonus (spare)
            {
                Console.WriteLine(" ");
                Console.WriteLine("How many pins were knocked down on throw three? (BONUS BALL)");
                finalThrow = Convert.ToInt32(Console.ReadLine());

                lastRoll = true;                                                                         // last roll true

                if (finalThrow == 10)
                {
                    showFrames[i] = Convert.ToString(pinsKnocked1) + "/" + "X";
                    strikes[i] = true;                                                                   // strike true
                }
                else if (finalThrow == 0)
                {
                    showFrames[i] = Convert.ToString(pinsKnocked1) + "/" + "-";
                }
                else
                {
                    showFrames[i] = Convert.ToString(pinsKnocked1) + "/" + Convert.ToString(finalThrow);
                }
            }
            else
            {
                spares[i] = true;                                                                        // spare true
                showFrames[i] = Convert.ToString(pinsKnocked1) + "/";
            }
            frames[i, 0] = pinsKnocked1;
            frames[i, 1] = pinsKnocked2;
        }
        else if (pinsKnocked2 == 0)
        {
            showFrames[i] = showFrames[i] + "-";
        }
        else
        {
            showFrames[i] = Convert.ToString(pinsKnocked1) + "," + Convert.ToString(pinsKnocked2);
        };
        frames[i, 0] = pinsKnocked1;
        frames[i, 1] = pinsKnocked2;
    };
};

// using 2 for loops to go through the values of the strikes and spares arrays, match those values to the frames array and add the respective bonus points.

for (int i2 = 0; i2 < strikes.Length; i2++)
{
    if (strikes[i2] == true)
    {
        if (strikes[i2 + 1] == false)
        {
            frames[i2, 0] = frames[i2, 0] + (frames[i2 + 1, 0] + frames[i2 + 1, 1]);
        }
        if (strikes[i2 + 1] == true)
        {
            frames[i2, 0] = frames[i2, 0] + (frames[i2 + 1, 0] + frames[i2 + 2, 0]);
        }
    }
}

for (int i3 = 0; i3 < spares.Length; i3++)
{
    if (spares[i3] == true)
    {
        frames[i3, 1] = frames[i3, 1] + frames[i3 + 1, 0];
    }
}

// using another for loop to add up all the values within the frames array and display the total along with the scores on the frames array, but formatted nicely.

foreach (int i4 in frames)
{
    playerTotal = playerTotal + i4;
}
if (lastRoll == true)
{
    playerTotal = playerTotal + finalThrow;
}

Console.WriteLine(" ");
Console.WriteLine("Final Score:");
for (int i5 = 0; i5 < showFrames.Length; i5++)
{
    Console.Write(showFrames[i5] + "  ");
}
Console.WriteLine(" ");
Console.WriteLine("Total = " + playerTotal);
