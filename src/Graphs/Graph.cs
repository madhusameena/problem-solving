using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpProblemSolving.Graphs
{
	public class Graph <T>
	{
		private int m_connectionCount;
		private IDictionary<T, List<T>> m_adjacentList;
		
		public Graph()
		{
			m_connectionCount = 0;
			m_adjacentList = new Dictionary<T, List<T>>();
		}

		public void AddVertex(T node)
		{
			m_adjacentList.Add(node, new List<T>());
			m_connectionCount++;
		}

		public void AddEdge(T node1, T node2)
		{
			m_adjacentList[node1].Add(node2);
			m_adjacentList[node2].Add(node1);
		}

		public void PrintData()
		{
			Console.WriteLine($"Count = {m_connectionCount}");
			foreach ((var key, var val) in m_adjacentList)
			{
				Console.Write($"{key}:\t");
				foreach (var edge in val)
				{
					Console.Write($"{edge}\t");
				}

				Console.WriteLine();
			}
		}

		public static void Samples()
		{
			var graph = new Graph<int>();
			for (int i = 0; i < 7; i++)
			{
				graph.AddVertex(i);
			};
			graph.AddEdge(3, 1);
			graph.AddEdge(3, 4);
			graph.AddEdge(4, 2);
			graph.AddEdge(4, 5);
			graph.AddEdge(1, 2);
			graph.AddEdge(1, 0);
			graph.AddEdge(0, 2);
			graph.AddEdge(6, 5);
			graph.PrintData();
		}
	}
}