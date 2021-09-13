using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/multiply-strings/
	// https://leetcode.com/problems/multiply-strings/
	public class MultiplyStrings
	{
		public static void Samples()
		{
			//Console.WriteLine(Multiply("9999999999", "2"));
			Console.WriteLine(Multiply("99999", "99999"));
			Console.WriteLine(Multiply("99999", "0"));
		}
		public static string Multiply(string num1, string num2)
		{
			// 89 X 23
			// 0027 -> last index at i+j+1, sum / 10 -> i+j val => sum = val[i, j] + num1[i] * num2[j]
			// 0240
			// 0180
			// 1600
			// SUM -> 2047
			var chArray = new char[num1.Length + num2.Length];
			for (int idx = 0; idx < chArray.Length; idx++)
			{
				chArray[idx] = '0';// Default value
			}
			for (int i = num1.Length - 1; i >= 0; i--)
			{
				for (int j = num2.Length - 1; j >= 0; j--)
				{
					int sum = (num1[i] - '0') * (num2[j] - '0') + (chArray[i + j + 1] - '0');
					chArray[i + j + 1] = (char)(sum % 10 + '0');
					int carry = chArray[i + j] - '0' + sum / 10; // Add carry to existing number
					chArray[i + j] = (char)(carry + '0');
				}
			}

			var str = new string(chArray);
			str = str.TrimStart('0');
			return str == string.Empty ? "0" : str;
		}
	}
}
