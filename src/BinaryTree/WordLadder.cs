using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.BinaryTree
{
	// https://www.youtube.com/watch?v=ZVJ3asMoZ18
	// https://leetcode.com/problems/word-ladder/
	public class WordLadder
	{
		public static void Samples()
		{
			var wordList = new[] { "hot", "dot", "dog", "lot", "log", "cog" };
			Console.WriteLine(LadderLength("hit", "cog", wordList));
			
			wordList = new[] { "hot","dot","dog","lot","log" };
			Console.WriteLine(LadderLength("hit", "cog", wordList));
		}

		public static int LadderLength(string beginWord, string endWord, IList<string> wordList) 
		{
			HashSet<string> tempWorldList = new HashSet<string>();
			foreach (var s in wordList)
			{
				tempWorldList.Add(s);
			}
			if (!wordList.Contains(endWord) ||
			    beginWord == endWord)
			{
				return 0;
			}

			// Use BFS - to find the short path
			Queue<string> queue = new Queue<string>();
			queue.Enqueue(beginWord);
			int depth = 0;
			while (queue.Count > 0)
			{
				depth++;
				int width = queue.Count;
				for (var idx = 0; idx < width; idx++)
				{
					var curr = queue.Dequeue();
					for (var i = 0; i < curr.Length; i++)
					{
						var item = curr.ToCharArray();
						// Iterate over items in the same level and find the its child (left and right)
						for (char ch = 'a'; ch <= 'z'; ch++)
						{
							item[i] = ch;
							var str = new string(item);
							if (curr == str)
							{
								continue;
							}

							if (str == endWord)
							{
								return depth + 1;
							}

							if (tempWorldList.Contains(str))
							{
								queue.Enqueue(str);
								tempWorldList.Remove(str);
							}
						}
					}
					
				}
			}

			return 0;
		}
	}
}