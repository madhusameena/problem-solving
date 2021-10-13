using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://www.youtube.com/watch?v=pHXntFeu6f8&t=13s
    // https://leetcode.com/problems/shortest-common-supersequence/
    public class ShortestCommonSupersequenceProblem
	{
        public static void Samples()
        {
            var obj = new ShortestCommonSupersequenceProblem();
			//Console.WriteLine(obj.ShortestCommonSupersequence("bbbaaaba", "bbababbb"));
			Console.WriteLine(obj.ShortestCommonSupersequence("abc", "defba"));
        }
        public string ShortestCommonSupersequence(string str1, string str2)
        {
            var lcsStr = GetLcsString(str1, str2);
            int p1 = 0, p2 = 0;
            var sb = new StringBuilder();
            foreach (var ch in lcsStr)
            {
				while (ch != str1[p1])
				{
                    sb.Append(str1[p1]);
                    p1++;
				}
                while (ch != str2[p2])
                {
                    sb.Append(str2[p2]);
                    p2++;
                }
                sb.Append(ch);
                p1++;
                p2++;
            }
            while (p1 < str1.Length)
            {
                sb.Append(str1[p1]);
                p1++;
            }
            while (p2 < str2.Length)
            {
                sb.Append(str2[p2]);
                p2++;
            }
            return sb.ToString();
        }
        private int[,] LongestCommonSubsequence(string text1, string text2)
        {
            int len1 = text1.Length + 1, len2 = text2.Length + 1;
            var dpArray = new int[len1, len2];
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dpArray[i, j] = 0;
                    }
                    else if (text1[i - 1] == text2[j - 1])
                    {
                        dpArray[i, j] = 1 + dpArray[i - 1, j - 1];
                    }
                    else
                    {
                        dpArray[i, j] = Math.Max(dpArray[i - 1, j], dpArray[i, j - 1]);
                    }
                }
            }
            return dpArray;
        }
        private string GetLcsString(string str1, string str2)
        {
            var dpArray = LongestCommonSubsequence(str1, str2);
            int x = str1.Length, y = str2.Length, lcsIdx = dpArray[str1.Length, str2.Length] - 1;
            if (lcsIdx < 0)
            {
                return string.Empty;
            }
            var lcsChars = new char[lcsIdx + 1];
            while (x > 0 && y > 0)
            {
                if (str1[x - 1] == str2[y - 1])
                {
                    lcsChars[lcsIdx] = str1[x - 1];
                    x--;
                    y--;
                    lcsIdx--;
                }
                else if (dpArray[x - 1, y] > dpArray[x, y - 1])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }
            return new string(lcsChars);
        }
    }
}
