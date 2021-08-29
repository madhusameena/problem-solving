using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpProblemSolving.Strings
{
						//https://www.interviewbit.com/problems/palindrome-string/
	public static class IsPalindrome
	{
		public static void Samples()
		{
			string test = "race a car";
			string test2 = "A man, a plan, a canal: Panama";
			Console.WriteLine(isPalindrome(test));
			Console.WriteLine(isPalindrome(test2));
			Console.WriteLine(isPalindromeNew("\""));
		}

		public static int isPalindromeNew(string A)
		{
			if (string.IsNullOrEmpty(A))
			{
				return 1;
			}

			int startIdx = 0, endIdx = A.Length - 1;
			while (startIdx < endIdx)
			{
				char start, end;

				if ((A[startIdx] >= 'a' && A[startIdx] <= 'z') || (A[startIdx] >= 'A' && A[startIdx] <= 'Z'))
				{
				}
				else
				{
					continue;
				}
				start = A[startIdx];
				startIdx++;

				if ((A[endIdx] >= 'a' && A[endIdx] <= 'z') || (A[endIdx] >= 'A' && A[endIdx] <= 'Z'))
				{
				}
				else
				{
					continue;
				}
				end = A[endIdx];
				endIdx--;

				if (start.ToString().ToLower() != end.ToString().ToLower())
				{
					return 0;
				}
			}

			return 1;
		}

		public static int isPalindrome(string A)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var c in A)
			{
				if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
				{
					sb.Append(c);
				}
			}

			if (A.Length == sb.Length)
			{
				if (A.Length < 2)
				{
					return 1;
				}	
			}

			A = sb.ToString();
			if (A.Length == 0)
			{
				return 1;
			}

			if (A.Length == 1)
			{
				return 0;
			}
			
			// A = String.Concat(A.Where(c => ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))));
			sb = new StringBuilder();
			for (var i = A.Length - 1; i >= 0; i--)
			{
				sb.Append(A[i]);
			}
			// var B = String.Concat(A.Reverse());
			var B = sb.ToString();
			if (string.Compare(A, B, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return 1;
			}
			return 0;
		}
		public static int isPalindromeSource(string A) {
			Regex r = new Regex("^[a-zA-Z0-9]*$");
			var start = 0; var end = A.Length - 1;
			while (start <= end)
			{
				if (!r.IsMatch(A[start].ToString()))
				{
					start++; continue;
				}
				if (!r.IsMatch(A[end].ToString()))
				{
					end--; continue;
				}
				if (A[start].ToString().ToLower() != A[end].ToString().ToLower())
				{
					return 0;
				}
				start++; end--;
			}
			return 1;
		}
	}
}