using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	public class FruitsCoupon
	{
		public static void Samples()
		{
			var codeList = new List<string>()
			{
				"apple, apple",
				"banana, anything, banana"
			};
			var shoppingCart = new List<string>()
			{
				"banana", "orange", "banana", "apple", "apple"
			};
			Console.WriteLine(Foo(codeList, shoppingCart));

			codeList = new List<string>()
			{
				"apple, apple",
				"banana, anything, banana"
			};
			shoppingCart = new List<string>()
			{
				"orange", "apple", "apple", "banana", "orange", "banana"
			};
			Console.WriteLine("-------------");
			Console.WriteLine(Foo(codeList, shoppingCart));
		}
		public static int Foo(List<string> codeList, List<string> shoppingCart)
		{
			return FooDp(codeList, shoppingCart, 0, 0);
		}
		private static int FooDp(List<string> codeList, List<string> shoppingCart, int codeIdx, int shoppingStartIdx)
		{
			if (codeIdx == codeList.Count)
			{
				return 1;
			}
			var code = codeList[codeIdx];
			if (string.IsNullOrEmpty(code))
			{
				return FooDp(codeList, shoppingCart, codeIdx + 1, shoppingStartIdx);
			}
			var codes = code.Split(", ");
			int shoppingCount = shoppingCart.Count - shoppingStartIdx;
			if (codes.Length > shoppingCount)
			{
				Console.WriteLine($"codes.Length = {codes.Length}, shoppingCount = {shoppingCount}");
				return 0;
			}
			var dp = new bool[codes.Length, shoppingCount];
			var newShoppingIdx = -1;
			for (int row = 0; row < codes.Length; row++)
			{
				for (int col = 0; col < shoppingCount; col++)
				{
					Console.WriteLine($"codes[row] = {codes[row]}, shoppingCart[col + shoppingStartIdx] = {shoppingCart[col + shoppingStartIdx]}");
					if (codes[row] == "anything" || codes[row] == shoppingCart[col + shoppingStartIdx])
					{
						if (row == 0)
						{
							dp[row, col] = true;
						}
						else if (col == 0)
						{
							dp[row, col] = false;
						}
						else
						{
							dp[row, col] = dp[row - 1, col - 1];
						}
						if (dp[row, col] && row == codes.Length - 1 && newShoppingIdx == -1)
						{
							newShoppingIdx = col + shoppingStartIdx + 1;
						}
					}
					else
					{
						dp[row, col] = false;
					}
				}
			}
			Console.WriteLine();
			for (int row = 0; row < codes.Length; row++)
			{
				for (int col = 0; col < shoppingCount; col++)
				{
					Console.Write($"{dp[row, col]}\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.WriteLine($"newShoppingIdx = {newShoppingIdx}");
			if (newShoppingIdx == -1)
			{
				return 0;
			}
			return FooDp(codeList, shoppingCart, codeIdx + 1, newShoppingIdx);
		}
	}
}
