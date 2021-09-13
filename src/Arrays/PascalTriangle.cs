using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/pascals-triangle/
	// https://www.interviewbit.com/problems/pascal-triangle/
	public class PascalTriangle
	{
		public IList<IList<int>> Generate(int numRows)
		{
			var lists = new List<IList<int>>();
			for (int i = 0; i < numRows; i++)
			{
				var list = new List<int>();
				for (int j = 0; j <= i; j++)
				{
					if (j == 0 || j == i)
					{
						list.Add(1);
					}
					else
					{
						list.Add(lists[i - 1][j - 1] + lists[i - 1][j]);
					}
				}
				lists.Add(list);
			}
			return lists;
		}
	}
}
