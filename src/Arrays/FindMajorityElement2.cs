using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/majority-element-ii/
	public class FindMajorityElement2
	{
		public static void Samples()
		{
			var nums = new int[] { 1, 1, 2, 2, 7, 7, 8, 8, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3 };
			nums = new int[] { 1, 2 };
			var op = MajorityElementMooreVoting(nums);
			foreach (var item in op)
			{
				Console.Write($"{item}\t");
			}
			Console.WriteLine();
		}
		public static IList<int> MajorityElementMooreVoting(int[] nums)
		{
			var result = new List<int>();
			if (nums.Length == 0)
			{
				return result;
			}
			if (nums.Length < 2)
			{
				result.Add(nums[0]);
				return result;
			}
			int num1 = -1, num2 = -1, counter1 = 0, counter2 = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] == num1)
				{
					counter1++;
				}
				else if (nums[i] == num2)
				{
					counter2++;
				}
				else if (counter1 == 0)
				{
					num1 = nums[i];
					counter1 = 1;
				}
				else if (counter2 == 0)
				{
					num2 = nums[i];
					counter2 = 1;
				}
				else
				{
					counter1--;
					counter2--;
				}
			}
			counter1 = 0;
			counter2 = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] == num1)
				{
					counter1++;
				}
				if (nums[i] == num2)
				{
					counter2++;
				}
			}
			if (counter1 > nums.Length / 3)
			{
				result.Add(num1);
			}
			if (counter2 > nums.Length / 3 && num1 != num2)
			{
				result.Add(num2);
			}
			return result;
		}
		public static IList<int> MajorityElement(int[] nums)
		{
			Array.Sort(nums);
			var result = new List<int>();
			if (nums.Length == 0)
			{
				return result;
			}
			int prev = nums[0];
			int expectedLength = (int)Math.Floor(((double)(nums.Length) / 3)) + 1, counter = 1;
			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] == prev)
				{
					counter++;
				}
				else
				{
					if (counter >= expectedLength)
					{
						result.Add(prev);
					}
					counter = 1;
				}
				prev = nums[i];
			}
			if (counter >= expectedLength)
			{
				result.Add(prev);
			}
			return result;
		}
	}
}
