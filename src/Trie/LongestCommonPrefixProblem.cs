using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Trie
{
	public class LongestCommonPrefixProblem
	{
		public static void Samples()
		{
			var obj = new LongestCommonPrefixProblem();
			var list = new string[] { "flower", "flow", "flight" };
			Console.WriteLine(obj.LongestCommonPrefix(list));
			Console.WriteLine("======");

			list = new string[] { "flower", "abd", "bcd" };
			Console.WriteLine(obj.LongestCommonPrefix(list));
		}
		public string LongestCommonPrefix(string[] strs)
		{
			TrieNode node = new TrieNode('/' - 'a'); // root node;
			foreach (var item in strs)
			{
				node.Insert(item);
			}
			int count = strs.Length;
			var current = node;
			var requiredList = new List<char>();
			Dfs(count, current, requiredList);
			return new string(requiredList.ToArray());
		}

		private static void Dfs(int count, TrieNode current, List<char> requiredList)
		{
			foreach (var child in current.Children)
			{
				if (child != null)
				{
					if (child.Count != count)
					{
						return;
					}
					requiredList.Add(child.Val);
					Dfs(count, child, requiredList);
				}
			}
		}
	}
}
