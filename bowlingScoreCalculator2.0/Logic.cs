using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowlingScoreCalculator2._0
{
    internal class logic
    {
        public static int firstThrow()
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

        public static int secondThrow()
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

        public static int spareCheck(int i, int firstThrow, int secondThrow)
        {
            if (firstThrow + secondThrow == 10)
            {
                return i;
            }
            return 999;
        }
    }
}