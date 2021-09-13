using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BinaryTree
{
	// https://www.interviewbit.com/problems/painters-partition-problem/
	// https://www.youtube.com/watch?v=zNVT8SnGRig
	// https://www.youtube.com/watch?v=U4vEszMVNsM
	public class PaintersPartitionProblem
	{
		public static void Samples()
		{
			var obj = new PaintersPartitionProblem();
			//Console.WriteLine(obj.paint(2, 5, new List<int> { 1, 10 }));
			Console.WriteLine(obj.paint(3, 10, new List<int> { 640, 435, 647, 352, 8, 90, 960, 329, 859 }));
		}
		public int paint(int painters, int paintWeight, List<int> boards)
		{
			// Min value is max of all items, max value is Sum of all paints
			int left = boards.Max(), right = boards.Sum();
			while (left < right)
			{
				int mid = (left + right) / 2;
				// If we can fit it below mid, Check left side, else right side
				if (GetRequiredPainters(boards, painters, mid) <= painters)
				{
					right = mid;
				}
				else
				{
					left = mid + 1;
				}
			}
			return (left * paintWeight) % 10000003;
		}

		private int GetRequiredPainters(List<int> boards, int painters, int maxValue)
		{
			int sum = 0, givenPainters = 0;
			foreach (var item in boards)
			{
				sum += item;
				if (sum > maxValue)
				{
					sum = item;
					givenPainters++;
				}
			}
			return givenPainters;
		}
	}
}
