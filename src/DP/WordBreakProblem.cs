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
        public static void Samples()
        {
            //Console.WriteLine(wordBreak("a", new List<string>() { "aaa" }));
            Console.WriteLine(wordBreak("myinterviewtrainer", new List<string>() { "interview", "my", "trainer" }));
        }
        public static int wordBreak(string str, List<string> wordDict)
        {
            HashSet<string> hash = new HashSet<string>();
			foreach (var item in wordDict)
			{
                hash.Add(item);
			}
            var dp = new int[str.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    var subStr = str.Substring(j, i - j + 1);

                    if (hash.Contains(subStr))
					{
                        if (j > 0)
                        {
                            dp[i] += dp[j - 1];
                        }
                        else
                        {
                            dp[i]++;
                        }
					}
                }
            }
            return dp[str.Length - 1] > 0 ? 1 : 0;
        }
    }
}
