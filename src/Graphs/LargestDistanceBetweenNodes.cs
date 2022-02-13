using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
	// https://www.interviewbit.com/problems/largest-distance-between-nodes-of-a-tree/
	// https://www.youtube.com/watch?v=x5ZH4pnts7Q&t=31s
	public class LargestDistanceBetweenNodes
	{
		bool[] visited;
		List<List<int>> adjList;
		int maxNode = 0;
		int maxDist = -1;
		public static void Samples()
		{
			var obj = new LargestDistanceBetweenNodes();
			var list = new List<int>() { -1, 0, 0, 0, 3 };
			Console.WriteLine(obj.solve(list));
		}
		public int solve(List<int> A)
		{
			if (A.Count < 2)
			{
				return 0;
			}
			if (A.Count == 2)
			{
				return A.Count - 1;
			}
			adjList = new List<List<int>>();
			visited = new bool[A.Count];
			for (int i = 0; i < A.Count; i++)
			{
				adjList.Add(new List<int>());
			}
			for (int i = 1; i < A.Count; i++)
			{
				adjList[A[i]].Add(i);
				adjList[i].Add(A[i]);
			}
			// Find farthest node
			dfs(0, 0); // dist will be zero
			// Reset visited
			for (int i = 0; i < visited.Length; i++)
			{
				visited[i] = false;
			}
			// Reset maxDist
			maxDist = -1;

			// Now calculate max node from already calculated max node
			dfs(maxNode, 0);
			
			return maxDist;
		}
		private void dfs(int node, int dist)
		{
			visited[node] = true;
			if (dist > maxDist)
			{
				maxNode = node;
				maxDist = dist;
			}
			// Iterate over all childs
			var childs = adjList[node];
			foreach (var child in childs)
			{
				if (!visited[child])
				{
					dfs(child, dist + 1);
				}
			}
		}
	}
}
