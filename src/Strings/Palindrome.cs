using System;
using System.Linq;
using CSharpProblemSolving.Mad;

namespace CSharpProblemSolving.Strings
{
	public static class Palindrome
	{
		public static void Samples()
		{
			// Console.WriteLine(MinimumInsertionsNeededToMakePalindrome("MadM"));
			// Console.WriteLine(MinimumInsertionsNeededToMakePalindrome("MadaM"));
			// Console.WriteLine(AppendsNeededAtFrontToMakePalindrome("abcb"));
			
			
			// Console.WriteLine(MinimumInsertionsNeededToMakePalindromeLcs("MadM"));
			// Console.WriteLine(MinimumInsertionsNeededToMakePalindromeLcs("MadaM"));
			//
			//
			// var ret = LongestCommonSubSequence("ABCDGH", "AEDFHR", StringComparison.Ordinal);
			// var val = PrintLongestCommonSubSequence("ABCDGH", "AEDFHR", StringComparison.Ordinal);
			// Console.WriteLine($"Ret = {ret}, LCS = {val}");
			//
			// ret = LongestCommonSubSequence("ABAC", "CABA", StringComparison.Ordinal);
			// val = PrintLongestCommonSubSequence("ABAC", "CABA", StringComparison.Ordinal);
			// Console.WriteLine($"Ret = {ret}, LCS = {val}");
			var test = MadHelper.BuildKmpPrefixArray("adam$mada");

			Console.WriteLine(LongestPalindromeLengthManacherAlgo("abba"));
		}

			// https://www.geeksforgeeks.org/minimum-number-appends-needed-make-string-palindrome/
		// num of strings that can append at the end to make the string palindrome
		// ex: abcb -> add a at the end to make palindrome => abcba, similarly abbcc => abbccbba
		// We solve this using KMP (Knuth Morris Pratt Algorithm)
		// Similar to this -> https://www.geeksforgeeks.org/minimum-characters-added-front-make-string-palindrome/
		public static int AppendsNeededToMakePalindrome(string str)
		{
			var reverse = new string(str.Reverse().ToArray());
			// We can do as done in https://www.geeksforgeeks.org/minimum-characters-added-front-make-string-palindrome/

			// Steps here will be:
			// 1. Reverse(STR)+"$"+STR
			// 2. Fill up LPS array
			// 3. Return length-lps(n-1), where n is length of concatenated string in step1
			var totalString = reverse + "$" + str;
			var lps = MadHelper.BuildKmpPrefixArray(totalString);
			return str.Length - lps[lps.Length - 1];
		}
		
		// https://www.geeksforgeeks.org/minimum-characters-added-front-make-string-palindrome/
		// num of strings that can append at front to make the string palindrome
		// ex: abcb -> add bcb at at front to make palindrome => "bcbabcb", similarly
		// We solve this using KMP (Knuth Morris Pratt Algorithm)
		public static int AppendsNeededAtFrontToMakePalindrome(string str)
		{
			var reverse = new string(str.Reverse().ToArray());
			// We can do as done in https://www.geeksforgeeks.org/minimum-characters-added-front-make-string-palindrome/

			// Steps here will be:
			// 1. STR + "$" + Reverse(STR)
			// 2. Fill up LPS array
			// 3. Return length-lps(n-1), where n is length of concatenated string in step1
			var totalString = str + "$" + reverse;
			var lps = MadHelper.BuildKmpPrefixArray(totalString);
			return str.Length - lps[lps.Length - 1];
		}
		
		//https://www.geeksforgeeks.org/minimum-insertions-to-form-a-palindrome-dp-28/
		// Minimum num of insertions needed to make the string palindrome - insertions can be anywhere in the string, but do not change the existing string order
		public static int MinimumInsertionsNeededToMakePalindrome(string str, StringComparison comparison = StringComparison.Ordinal)
		{
			// Construct array to represent the string
			// 
			//         a b c b m
			//         0 1 2 3 4
			//       ------------
			//a - 0 -  0 1 2 1 2
			//b - 1 -  0 0 1 0 2 
			//c - 2 -  0 0 0 1 2 
			//b - 3 -  0 0 0 0 1 
			//m - 4 -  0 0 0 0 0
			// return array[0][4] value
			
			int[,] table = new int[str.Length, str.Length];
			
			// Fill the table diagonally based on gap
			// Gap = 1: (0, 1) (1, 2) (2, 3) (3, 4)
			// 
			// Gap = 2: (0, 2) (1, 3) (2, 4)
			// 
			// Gap = 3: (0, 3) (1, 4)
			// 
			// Gap = 4: (0, 4)
			
			// lets start array [low, high] values based on gap and str.Length
			for (int gap = 1; gap < str.Length; gap++)
			{
				for (int low = 0, high = gap; low < str.Length && high < str.Length; low++, high++)
				{
					// Console.WriteLine($"low = {low}, high = {high}");
					if (string.Compare(str[low].ToString(), str[high].ToString(), comparison) == 0)
					{
						// first and last char equal, so remove them and check the value of remaining
						// i.e. if the value at low + 1 and high -1, this is will same as what we are looking for
						table[low, high] = table[low + 1, high - 1];
					}
					else
					{
						// remove first or last char find its num of palindrome values -> Find min + 1 -> Coz we split already either at first or last
						table[low, high] = Math.Min(table[low + 1, high], table[low, high - 1]) + 1;
					}
				}	
			}
			// Return the last value
			return table[0, str.Length - 1];
		}
		
		// https://www.geeksforgeeks.org/minimum-insertions-to-form-a-palindrome-dp-28/
		// Minimum num of insertions needed to make the string palindrome - insertions can be anywhere in the string, but do not change the existing string order
		// Here we find it using LongestCommonSubSequence 
		
		public static int MinimumInsertionsNeededToMakePalindromeLcs(string str, StringComparison comparison = StringComparison.Ordinal)
		{
			// Find LongestCommonSubsequence length of given string and and its reverse
			// required value will be str.Length - LCS.Length
			// EX: ABAB => reverse => BABA, LCS BAB, If we add A at the end, str will be palindrome

			var lcsLen = LongestCommonSubSequence(str, new string(str.Reverse().ToArray()), comparison);
			return str.Length - lcsLen;
		}

		// https://www.geeksforgeeks.org/longest-common-subsequence-dp-4/
		// https://www.youtube.com/watch?v=NnD96abizww
		// https://leetcode.com/problems/longest-common-subsequence/
		// https://www.interviewbit.com/problems/longest-common-subsequence/
		// LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3.
		// LCS for input Sequences “AGGTAB” and “GXTXAYB” is “GTAB” of length 4.
		public static int LongestCommonSubSequence(string str1, string str2,  StringComparison stringComparison)
		{
			var vals = LcsArray(str1, str2, stringComparison);

			return vals[str1.Length, str2.Length];
		}

		private static int[,] LcsArray(string str1, string str2, StringComparison stringComparison)
		{
			// Add +1 for row and column with 0 values at index = 0
			// Check if str1[row] == str2[col] => this char has tobe counted so we add 1 and check the value at  previous pair(remove both chars) i.e. => value[str[row - 1, col - 1]] + 1
			// When ever we found a match => you can add that char to return the LongestCommonSubSequence string
			// If values are not name => we compare previous values by removing one char at a time and get the max longest subsequence value => Math.Max(value[str[row - 1, col]], value[str[row, col - 1]]) 

			//		  a b c d a f
			//		0 0 0 0 0 0 0
			//	a	0 1 1 1 1 1 1
			//	c   0 1 1 2 2 2 2
			//	b   0 1 2 2 2 2 2
			//	c   0 1 2 3 3 3 3
			//	f   0 1 2 3 3 3 4

			// O index is additional val, which values are zeros
			int[,] vals = new int[str1.Length + 1, str2.Length + 1];
			for (var row = 1; row <= str1.Length; row++)
			{
				for (var col = 1; col <= str2.Length; col++)
				{
					// row has to row - 1 similarly col - 1 => Because row is starting from 1 not 0...
					if (string.Compare(str1[row - 1].ToString(), str2[col - 1].ToString(), stringComparison) == 0)
					{
						// Add 1 and check previous value in row and col
						vals[row, col] = vals[row - 1, col - 1] + 1;
					}
					else
					{
						// Find Max value from previous values in row and col
						vals[row, col] = Math.Max(vals[row - 1, col], vals[row, col - 1]);
					}
				}
			}

			return vals;
		}

		// Print the value of longest subsequence 
		public static string PrintLongestCommonSubSequence(string str1, string str2, StringComparison stringComparison)
		{
			var lcsArray = LcsArray(str1, str2, stringComparison);
			var lcsLength = lcsArray[str1.Length, str2.Length];
			
			// Length of lcs = lcsArray.Length
			char[] lcs = new char[lcsLength];
			
			//		  a b c d a f
			//		0 0 0 0 0 0 0
			//	a	0 1 1 1 1 1 1
			//	c   0 1 1 2 2 2 2
			//	b   0 1 2 2 2 2 2
			//	c   0 1 2 3 3 3 3
			//	f   0 1 2 3 3 3 4
			
			// Based on the given array check value from rowEnd, colEnd and traverse back
			// Check at the present value str1[row - 1] == str2[col - 1] => If Yes add this values to lcs from back
			// And move to previous pair, i.e. row -= 1, col -= 1
			// If str1[row - 1] != str2[col - 1] => Traverse to previous row or col based on which is the max
			// i.e Max(lcsArray[row - 1, col], lcsArray[row, col - 1]), Traverse till beginning of the loop

			int row = str1.Length, col = str2.Length, lcsIndex = lcsLength - 1;
			
			// Check till row = 1 or col = 1 => That is our first row or col to check
			while (row > 0 && col > 0)
			{
				if (string.Compare(str1[row - 1].ToString(), str2[col - 1].ToString(), stringComparison) == 0)
				{
					// If they are equal => add this char to lcs and check previous values in row and col
					lcs[lcsIndex] = str1[row - 1];
					row--;
					col--;
					lcsIndex--;
				}
				else
				{
					// Check max of previous values in row and col
					if (lcsArray[row - 1, col] > lcsArray[row, col - 1])
					{
						row--;
					}
					else
					{
						col--;
					}
				}
			}
			
			return new string(lcs);
		}

		// https://www.youtube.com/watch?v=nbTSfrEfo6M
		// https://www.geeksforgeeks.org/manachers-algorithm-linear-time-longest-palindromic-substring-part-1/
		// https://www.geeksforgeeks.org/manachers-algorithm-linear-time-longest-palindromic-substring-part-2/
		public static int LongestPalindromeLengthManacherAlgo(string inputStr)
		{
			var strArray = new char[inputStr.Length * 2 + 3];
			int newIdx = 0;
			strArray[newIdx++] = '@';
			strArray[newIdx++] = '|';
			strArray[^1] = '$';
			for (var idx = 0; idx < inputStr.Length; idx++)
			{
				strArray[newIdx++] = inputStr[idx];
				strArray[newIdx++] = '|';
			}

			var palindromeArray = new int[strArray.Length];
			int center = 0, rightBorder = 0;
			for (var idx = 1; idx < strArray.Length - 1; idx++)
			{
				int mirror = 2 * center - idx;
				if (idx < rightBorder)
				{
					palindromeArray[idx] = Math.Min(rightBorder - idx, palindromeArray[mirror]);
				}

				while (strArray[idx + (1 + palindromeArray[idx])] == strArray[idx - (1 + palindromeArray[idx])])
				{
					palindromeArray[idx]++;
				}

				if (idx + palindromeArray[idx] > rightBorder)
				{
					center = idx;
					rightBorder = idx + palindromeArray[idx];
				}
			}

			return palindromeArray.Max();
		}
	}
}