using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowlingScoreCalculator2._0
{
    internal class logic
    {
        public static int roll()                                 // roll method 1, checks for valid input, returns amount of pins hit
        {
            while (true)
            {
                int pinsHit = Convert.ToInt32(Console.ReadLine());
                if (pinsHit < 0 || pinsHit > 10)
                {
                    Console.WriteLine("Please enter a valid number (between 0-10)");
                }
                else
                {
                    return pinsHit;
                }
            }
        }

        public static int roll2(int firstThrow)                 // roll method 2, checks for valid input (doesn't exceed 10 when added to first roll), returns amount of pins hit
        {
            while (true)
            {
                int pinsHit = Convert.ToInt32(Console.ReadLine());
                if (pinsHit < 0 || pinsHit > 10 || (pinsHit + firstThrow) > 10)
                {
                    Console.WriteLine("Please enter a valid number (between 0-10, and not over 10 once added to first roll)");
                }
                else
                {
                    return pinsHit;
                }
            }
        }

        public static bool bonusCheck(int i)                     // checks if on the final frame for the bonus, return boolean value
        {
            if (i == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int strikeCheck(int i, int firstThrow)     // checks for a strike, returns index of the strike if true
        {
            if (firstThrow == 10)
            {
                return i;
            }
            else
            {
                return 999;
            }
        }

        public static int spareCheck(int i, int firstThrow, int secondThrow)     // checks for a spare, returns index of the spare if true
        {
            if (firstThrow + secondThrow == 10)
            {
                return i;
            }
            else
            {
                return 999;
            }
        }

        public static void calculateBonus(List<int> scores, List<int> strikes, List<int> spares)
        {
            foreach (int x in strikes)                                                 // iterate through list of strike index's, add bonus points
            {
                scores[x] = scores[x] + (scores[x + 1] + scores[x + 2]);
            }
            foreach (int y in spares)                                                  // iterate through list of spare index's, add bonus points
            {
                scores[y] = scores[y] + scores[y + 1];
            }
        }

        public static void removeExcess(List<int> scores, bool bonusx1, bool bonusx2)
        {
            if (bonusx1 == true)                                                       // remove last index in the case of a 10th frame spare
            {
                scores.RemoveAt(scores.Count - 1);
            }
            if (bonusx2 == true)                                                       // remove last 2 index's in the case of a 10th frame strike
            {
                scores.RemoveAt(scores.Count - 1);
                scores.RemoveAt(scores.Count - 1);
            }
        }

        public static void finalScore(List<int> scores)                                 // add up and display final score
        {
            int playerTotal = 0;
            playerTotal = scores.Sum();
            Console.WriteLine("\nTotal Score:");
            Console.WriteLine(playerTotal);
        }
    }
}