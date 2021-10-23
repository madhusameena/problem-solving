using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Trie
{
	public class TrieNode
	{
		public int Count
		{
			get; set;
		}
		public int EndsHere
		{
			get; set;
		}
		public char Val
		{
			get; set;
		}
		public TrieNode[] Children;
		public TrieNode(int index) // ASCII val
		{
			Val = (char)('a' + index);
			Count = 0;
			Children = new TrieNode[26];// a-z
			EndsHere = 0;
		}
		public void Insert(string str)
		{
			var currentNode = this;
			foreach (var item in str)
			{
				int index = item - 'a';
				if (currentNode.Children[index] == null)
				{
					currentNode.Children[index] = new TrieNode(index);
				}
				currentNode.Children[index].Count++;
				currentNode = currentNode.Children[index];
			}
			currentNode.EndsHere++;
		}
		public bool StartsWith(string str)
		{
			var current = this;
			foreach (var item in str)
			{
				int index = item - 'a';
				if (current.Children[index] == null)
				{
					return false;
				}
				current = current.Children[index];
			}
			return current.Count > 0;
		}
		public bool Search(string str)
		{
			var current = this;
			foreach (var item in str)
			{
				int index = item - 'a';
				if (current.Children[index] == null)
				{
					return false;
				}
				current = current.Children[item];
			}
			return current.EndsHere > 0;
		}
	}
}
