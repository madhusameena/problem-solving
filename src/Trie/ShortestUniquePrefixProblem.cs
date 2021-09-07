using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Trie
{
	public class ShortestUniquePrefixProblem
	{
		public static void Samples()
		{
			var obj = new ShortestUniquePrefixProblem();
			var list = new List<string>() { "", "d", "duck", "dove" };
			//var list = new List<string>() { "zebra", "dog", "duck", "dove" };
			var result = obj.prefix(list);
			foreach (var item in result)
			{
				Console.Write($"{item},\t");
			}
			Console.WriteLine();
		}
		public List<string> prefix(List<string> strs)
		{
			TrieNode node = new TrieNode('/' - 'a'); // root node;
			foreach (var item in strs)
			{
				node.Insert(item);
			}
			var list = new List<string>();
			foreach (var item in strs)
			{
				StringBuilder sb = new StringBuilder();
				Dps(node, item, sb, 0);
				list.Add(sb.ToString());
			}
			return list;
		}

		private static void Dps(TrieNode node, string item, StringBuilder sb, int index)
		{
			if (item == null || index > item.Length - 1)
			{
				return;
			}
			if (item == string.Empty)
			{
				sb.Append(string.Empty);
				return;
			}
			var child = node.Children[item[index] - 'a'];
			if (child.Count > 0)
			{
				sb.Append(item[index].ToString());
			}
			if (child.Count == 1)
			{
				return;
			}
			Dps(child, item, sb, index + 1);
		}
	}
}
