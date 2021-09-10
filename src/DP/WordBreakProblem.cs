using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://www.interviewbit.com/problems/word-break/
	// https://leetcode.com/problems/word-break/
	public class WordBreakProblem
	{
        // TODO Solve it
        public int wordBreak(string A, List<string> B)
        {
            HashSet<string> dict = new HashSet<string>();
			foreach (var item in B)
			{
                dict.Add(item);
			}
            return 1;
            //return wordBreak(0, A, dict);
        }
        public bool wordBreak(int index, string s, HashSet<string> dict)
        {
            // BASE CASES

            bool result = false;
            // try to construct all substrings.
            for (int i = index; i < s.Length; i++)
            {
                var substring = s.Substring(index, i);// *the substring s[index..i] with i inclusive *
				if (dict.Contains(substring))
				{
                    result |= wordBreak(i + 1, s, dict);
                }
            }
            return result;
        }
    }
}
