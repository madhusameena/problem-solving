using System;

namespace CSharpProblemSolving.BST
{
	//https://www.geeksforgeeks.org/generate-two-bsts-from-the-given-array-such-that-maximum-height-among-them-is-minimum/
	public class TwoBst
	{
		public static void Samples()
		{
			int []arr = { 1, 2, 3, 4, 6 };
			int n =arr.Length;
			Console.WriteLine( maximumHeight(n, arr));
			arr = new[] { 74, 25, 23, 1, 65, 2, 8, 99 };
			n =arr.Length;
			Console.WriteLine( maximumHeight(n, arr));
		}

		static int cal_log(int n)
		{
			int ans = 0;
 
			while (n > 0)
			{
				n /= 2;
				ans++;
			}
 
			return ans;
		}
 
		static int maximumHeight(int n, int []arr)
		{
			int level = cal_log(n / 2 + n % 2);
			return (level - 1);
		}
	}
}