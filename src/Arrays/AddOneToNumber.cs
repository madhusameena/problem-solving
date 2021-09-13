using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://www.interviewbit.com/old/problems/add-one-to-number/
	// https://leetcode.com/problems/plus-one/
	public class AddOneToNumber
	{
		public int[] PlusOne(int[] digits)
		{
			int carry = 0;
			for (int i = digits.Length - 1; i >= 0; i--)
			{
				int sum = carry + digits[i];
				if (i == digits.Length - 1)
				{
					sum++;
				}
				digits[i] = sum % 10;
				carry = sum / 10;
			}
			var list = new List<int>();
			bool numAdded = false;
			if (carry != 0)
			{
				list.Add(carry);
				numAdded = true;
			}
			
			foreach (var item in digits)
			{
				if (item != 0 || numAdded)
				{
					list.Add(item);
					numAdded = true;
				}
			}
			
			return list.ToArray();
		}
	}
}
