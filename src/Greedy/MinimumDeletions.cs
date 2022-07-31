using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Greedy
{
    // https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique/
    internal class MinimumDeletions
    {
        public int MinDeletions(string s)
        {
            var chArray = new int[26];
            foreach (var ch in s)
            {
                chArray[ch - 'a']++;
            }
            var hash = new HashSet<int>();
            int ret = 0;
            for (int i = 0; i < 26; i++)
            {
                while (chArray[i] > 0 && hash.Contains(chArray[i]))
                {
                    chArray[i]--;
                    ret++;
                }
                hash.Add(chArray[i]);
            }
            return ret;
        }
    }
}
