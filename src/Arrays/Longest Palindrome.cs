using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
    // https://leetcode.com/problems/longest-palindrome/
    internal class Longest_Palindrome
    {
        public int LongestPalindrome(string s)
        {
            var arr = new int[128]; // max val of z is 122
            foreach (var item in s)
            {
                arr[(int)item]++;
            }
            int oddCount = 0;
            foreach (var item in arr)
            {
                if (item == 0)
                    continue;
                if (item % 2 == 1)
                    oddCount++;
            }
            // Remove odd counts, and add 1, if odd count > 0
            return s.Length - oddCount + (oddCount > 0 ? 1 : 0);
        }
    }
}
