using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.MathProb
{
    internal class PoorPigsProb
    {
        public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            int eachPig = 1 + (minutesToTest / minutesToDie);
            return (int)Math.Ceiling(Math.Log(buckets) / Math.Log(eachPig));
        }
        public int PoorPigs1(int buckets, int minutesToDie, int minutesToTest)
        {
            int eachPig = 1 + (minutesToTest / minutesToDie);
            int pigs = 0;
            while (Math.Pow(eachPig, pigs) < buckets)
            {
                pigs++;
            }
            return pigs;
        }
    }
}
