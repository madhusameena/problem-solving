using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Strings
{
	// https://leetcode.com/problems/find-the-closest-palindrome/
	// https://www.interviewbit.com/problems/next-smallest-palindrome/
	// https://www.youtube.com/watch?v=hZcindWcYI4
	public class ClosestPalindrome
	{
		// TODO Fix it
		public string NearestPalindromic(string n)
		{
			if (string.IsNullOrEmpty(n))
			{
				return string.Empty;
			}
			if (n == "0")
			{
				return n;
			}
			var chArray = n.ToCharArray();
			if (chArray.Length == 1)
			{
				chArray[0] = (char)(chArray[0] - 1);
				return new string(chArray);
			}
			return new string(chArray);
		}
	}
}
