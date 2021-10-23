using System;
using System.Linq;
using System.Text;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/add-binary-strings/
	public static class AddBinary
	{
		public static string addBinary(string A, string B)
		{
			int max = Math.Max(A.Length, B.Length);
			StringBuilder sb = new StringBuilder();
			// int carry = 0;
			// for (int idx = 0; idx < max; idx++)
			// {
			// 	int a = 0, b = 0;
			// 	
			// 	int idx1 = A.Length - idx - 1;
			// 	int idx2 = B.Length - idx - 1;
			// 	
			// 	if (idx1 < A.Length && idx1 >= 0)
			// 	{
			// 		a = int.Parse(A[idx1].ToString());
			// 	}
			// 	if (idx2 < B.Length && idx2 >= 0)
			// 	{
			// 		b = int.Parse(B[idx2].ToString());
			// 	}
			//
			// 	var sum = a + b + carry;
			// 	switch (sum)
			// 	{
			// 		case 0:
			// 			sum = 0;
			// 			carry = 0;
			// 			break;
			// 		case 1:
			// 			sum = 1;
			// 			carry = 0;
			// 			break;
			// 		case 2:
			// 			sum = 0;
			// 			carry = 1;
			// 			break;
			// 		case 3:
			// 			sum = 1;
			// 			carry = 1;
			// 			break;
			// 	}
			// 	sb.Append(sum);
			// }
			int idx1 = A.Length - 1, idx2 = B.Length - 1, carry = 0;
			while (idx1 >= 0 || idx2 >= 0)
			{
				Console.WriteLine($"idx1 = {idx1}, idx2 = {idx2}");
				int a = idx1 >= 0 ? int.Parse(A[idx1].ToString()) : 0;
				int b = idx2 >= 0 ? int.Parse(B[idx2].ToString()) : 0;
				int sum = a + b + carry;
				carry = sum / 2;
				sum %= 2;
				sb.Append(sum);
				idx1--;
				idx2--;
				Console.WriteLine($"a = {a}, b = {b}, sum = {sum}, carry = {carry}");
			}
			if (carry != 0)
			{
				sb.Append(carry);
			}

			return new string(sb.ToString().Reverse().ToArray());
		}
	}
}