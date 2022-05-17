using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.TwoPointers
{
    internal class MaximumOnes
    {
        // Given a binary array A and a number B, we need to find length of the longest subsegment of ‘1’s possible by changing at most B ‘0’s. 
        // A = [1, 0, 0, 1, 0, 1, 0, 1, 0, 1], B = 2 => Ans 5
        internal static int GetMaximumOnes(int[] arr, int k)
        {
            int maxLen = 0, numOfZeros = 0, zeroIdx = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    numOfZeros++;
                }
                while (numOfZeros > k) // Max flips happened  -> so flip back from beginning (zeroIdx)
                {
                    if (arr[zeroIdx] == 0)
                    {
                        numOfZeros--;
                    }
                    zeroIdx++;
                }
                maxLen = Math.Max(maxLen, i -  zeroIdx + 1);
            }
            return maxLen;
        }
    }
}
