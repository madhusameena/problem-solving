using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://www.interviewbit.com/problems/word-break-ii/
	// https://leetcode.com/problems/word-break-ii/
	public class WordBreakII
	{
        public static void Samples()
        {
            var obj = new WordBreakII();
        }
		public IList<string> WordBreak(string str, IList<string> wordDict)
		{
            var dict = new Dictionary<string, List<string>>();
            var hashList = new HashSet<string>();
            foreach (var item in wordDict)
            {
                hashList.Add(item);
            }
            return WordBreakRecursive(str, hashList, dict);
        }

		private IList<string> WordBreakRecursive(string str, HashSet<string> wordDict, Dictionary<string, List<string>> dict)
		{
			if (dict.ContainsKey(str))
			{
                return dict[str];
			}
            var list = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                string left = str.Substring(0, i + 1);
				if (wordDict.Contains(left))
				{
					if (left != str)
					{
                        string right = str.Substring(i + 1, (str.Length - i - 1));
                        var rightItems = WordBreakRecursive(right, wordDict, dict);
                        foreach (var item in rightItems)
                        {
                            list.Add(string.Concat(left, " ", item));
                        }
                    }
					else
					{
                        list.Add(left);
					}
				}
            }
            dict.Add(str, list);
            return list;
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
            return dp[str.Length - 1];
        }
        public static IList<string> wordBreak2(string str, IList<string> wordDict)
        {
            HashSet<string> hash = new HashSet<string>();
            foreach (var item in wordDict)
            {
                hash.Add(item);
            }
            Dictionary<int, List<string>> dicts = new Dictionary<int, List<string>>();
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    var subStr = str.Substring(j, i - j + 1);

                    if (hash.Contains(subStr))
                    {
                        if (j > 0)
                        {
                            if (!dicts.ContainsKey(i))
                            {
                                dicts.Add(i, new List<string>());
                            }
							if (dicts.ContainsKey(j - 1))
							{
                                var strs = dicts[j - 1];
                                foreach (var item in strs)
                                {
                                    dicts[i].Add(string.Concat(item, " ", subStr));
                                }
                            }
                        }
                        else
                        {
							if (!dicts.ContainsKey(i))
							{
                                dicts.Add(i, new List<string>());
                            }
                            dicts[i].Add(str.Substring(0, i + 1));
                        }
                    }
                }
            }
			if (dicts.ContainsKey(str.Length - 1))
			{
                return dicts[str.Length - 1];
			}
            return new List<string>();
        }
    }
}
