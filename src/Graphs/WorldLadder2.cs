using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
	// https://leetcode.com/problems/word-ladder-ii/
	public class WorldLadder2
	{
		// TODO Finish it
		public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
		{
			IList<IList<string>> responses = new List<IList<string>>();
			HashSet<string> tempWorldList = new HashSet<string>();
			foreach (var s in wordList)
			{
				tempWorldList.Add(s);
			}
			if (!wordList.Contains(endWord) ||
				beginWord == endWord)
			{
				return responses;
			}

			// Use BFS - to find the short path
			Queue<string> queue = new Queue<string>();
			queue.Enqueue(beginWord);
			int depth = 0;
			while (queue.Count > 0)
			{
				var response = new List<string>();
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
							response.Add(str);

							if (str == endWord)
							{
								responses.Add(response);
								break;
								//return depth + 1;
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
			return responses;
		}
	}
}
