using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.MathProb
{
    // https://leetcode.com/problems/longest-repeating-character-replacement/
    internal class Longest_Repeating_Character_Replacement
    {
        public int CharacterReplacement(string s, int k)
        {
            int left = 0, maxFreqLetter = 0, max = 0;
            var arr = new int[26];
            for (int right = 0; right < s.Length; right++)
            {
                arr[s[right] - 'A']++;
                maxFreqLetter = Math.Max(maxFreqLetter, arr[s[right] - 'A']);
                int lettersChange = (right - left + 1) - maxFreqLetter;
                if (lettersChange > k)
                {
                    arr[s[left] - 'A']--;
                    left++;
                }
                max = Math.Max(max, right - left + 1);
            }
            return max;
        }   
    }
}
