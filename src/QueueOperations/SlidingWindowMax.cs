using System;
using System.Collections.Generic;
using System.Linq;
using CSharpProblemSolving.Strings;

namespace CSharpProblemSolving.QueueOperations
{
	// https://www.youtube.com/watch?v=39grPZtywyQ
	public static class SlidingWindowMax
	{
		class MyTuple
		{
			public MyTuple(int item1, int item2)
			{
				Item1 = item1;
				Item2 = item2;
			}

			public int Item1 { get; set; }
			public int Item2 { get; set; }
		}
		public static void Samples()
		{
			var list = new List<int>() {1, 2, 3, 1, 4, 5, 2, 3, 6};
			var op = slidingMaximum(list, 3);
			foreach (var i in op)
			{
				Console.Write($"{i} ");
			}

			Console.WriteLine();
			list = new List<int> {9, 7, 2, 4, 6, 8, 2, 1, 5};
			op = slidingMaximum(list, 3);
			foreach (var i in op)
			{
				Console.Write($"{i} ");
			}
			
			Console.WriteLine();
			list = new List<int> {1, 2, 3, 1, 4, 5, 2, 3, 6};
			op = slidingMaximum(list, 3);
			foreach (var i in op)
			{
				Console.Write($"{i} ");
			}
		}
		public static  List<int> slidingMaximum(List<int> A, int B)
		{
			// Dictionary<int, int> list = new Dictionary<int, int>();
			List<Tuple<int, int>> list = new List<Tuple<int, int>>();
			List<int> ans = new List<int>();
			for (var index = 0; index < A.Count; index++)
			{
				var num = A[index];
				// If the first elements is out of window remove it
				if (list.Count > 0 && list[0].Item1 + B <= index)
				{
					list.RemoveAt(0);
				}
				// Traverse from last to first, till you found larger element
				while (list.Count > 0 && list[^1].Item2 <= num)
				{
					list.RemoveAt(list.Count - 1);
				}

				// If the current value is either start or more than last, add to last of the list
				if (list.Count == 0 || list[^1].Item2 > num)
				{
					list.Add(new Tuple<int, int>(index, num));
				}
				if (index >= B - 1)
				{
					ans.Add(list[0].Item2);
				}
			}

			return ans;
		}
		public static  List<int> slidingMaximum_(List<int> A, int B)
		{
			// Dictionary<int, int> list = new Dictionary<int, int>();
			List<MyTuple> list = new List<MyTuple>();
			List<int> ans = new List<int>();
			for (var index = 0; index < A.Count; index++)
			{
				var num = A[index];
				// If the first elements is out of window remove it
				if (list.Count > 0 && list[0].Item1 + B <= index)
				{
					list.RemoveAt(0);
				}
				// Traverse from last to first, till you found larger element
				while (list.Count > 0 && list[list.Count - 1].Item2 <= num)
				{
					list.RemoveAt(list.Count - 1);
				}

				// If the current value is either start or more than last, add to last of the list
				if (list.Count == 0 || list[list.Count - 1].Item2 > num)
				{
					list.Add(new MyTuple(index, num));
				}
				if (index >= B - 1)
				{
					ans.Add(list[0].Item2);
				}
			}

			return ans;
		}
	}
}