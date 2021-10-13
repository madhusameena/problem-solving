using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.BinaryTree
{
	// https://leetcode.com/problems/kth-ancestor-of-a-tree-node/
	public class TreeAncestor
	{
		private readonly int[] m_elements;
		private int[,] m_parents;
		private int m_logCount;
		private int[] m_depth;
		public TreeAncestor(int n, int[] parent)
		{
			// Bruteforce
			m_elements = parent;

			m_depth = new int[n];
			
			m_logCount = (int)(Math.Log2(n - 1) + 1);
			m_parents = new int[n, m_logCount];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m_logCount; j++)
				{
					m_parents[i, j] = -1;
				}
			}
			// Precompute using binary lifting
			// If parents numbers are not lower children we can initialize array of given numbers initially
			for (int i = 0; i < n; i++)
			{
				m_parents[i, 0] = parent[i];
				if (i != 0)
				{
					m_depth[i] = m_depth[parent[i]] + 1;
				}
			}

			// I know already first ancestors, compute 2nd, 3rd ...
			for (int j = 1; j < m_logCount; j++)
			{
				for (int i = 0; i < n; i++)
				{
					var x = m_parents[i, j - 1];
					if (x != -1)
					{
						m_parents[i, j] = m_parents[x, (j - 1)];
					}
				}
			}
		}

		public static void Samples()
		{
			TreeAncestor ancestor = new TreeAncestor(7, new int[] { -1, 0, 0, 1, 1, 2, 2 });
			// Console.WriteLine(ancestor.GetKthAncestor(3, 1));
			// Console.WriteLine(ancestor.GetKthAncestor(5, 2));
			// Console.WriteLine(ancestor.GetKthAncestor(6, 3));
			// Console.WriteLine("===================");
			
			// ancestor = new TreeAncestor(5, new int[] { -1,0,0,1,2 });
			// Console.Write($"{ancestor.GetKthAncestor(3, 5)} ");
			// Console.Write($" {ancestor.GetKthAncestor(3, 2)} ");
			// Console.Write($" {ancestor.GetKthAncestor(2, 2)} ");
			// Console.Write($" {ancestor.GetKthAncestor(0, 2)} ");
			// Console.Write($" {ancestor.GetKthAncestor(2, 1)}");
			// Console.WriteLine("\n===================");

			Console.WriteLine("\n===================");
			ancestor = new TreeAncestor(10, new int[] { -1,0,0,1,2,0,1,3,6,1 });
			Console.Write($"{ancestor.GetKthAncestor(8, 6)} ");
			Console.Write($" {ancestor.GetKthAncestor(9, 7)} ");
			Console.Write($" {ancestor.GetKthAncestor(1, 1)} ");
			Console.Write($" {ancestor.GetKthAncestor(2, 5)} ");
			Console.Write($" {ancestor.GetKthAncestor(4, 2)} ");
			Console.Write($" {ancestor.GetKthAncestor(7, 3)} ");
			Console.Write($" {ancestor.GetKthAncestor(3, 7)} ");
			Console.Write($" {ancestor.GetKthAncestor(9, 6)} ");
			Console.Write($" {ancestor.GetKthAncestor(3, 5)} ");
			Console.Write($" {ancestor.GetKthAncestor(8, 8)} ");
			Console.WriteLine("\n===================");
			
			Console.WriteLine("\n===================");
			ancestor = new TreeAncestor(5, new int[] { -1,0,0,0,3 });
			Console.Write($"{ancestor.GetKthAncestor(1, 5)} ");
			Console.Write($" {ancestor.GetKthAncestor(3, 2)} ");
			Console.Write($" {ancestor.GetKthAncestor(0, 1)} ");
			Console.Write($" {ancestor.GetKthAncestor(3, 1)} ");
			Console.Write($" {ancestor.GetKthAncestor(3, 5)} ");
			Console.WriteLine("\n===================");
			
			Console.WriteLine("\n===================");
			ancestor = new TreeAncestor(2, new int[] { -1,0 });
			Console.Write($"{ancestor.GetKthAncestor(1, 2)} ");
			Console.WriteLine("\n===================");
		}

		public int GetKthAncestor(int node, int k)
		{
			if (m_depth[node] < k)
			{
				return -1;
			}
			for (int i = 0; i <= m_logCount; i++)
			{
				if ((k & (1 << i)) > 0)
				{
					node = m_parents[node, i];
					if (node == -1)
					{
						return node;
					}
				}
			}
			return node;
		}

		public int GetKthAncestorBruteForce(int node, int k)
		{
			int root = -1;
			if (node >= m_elements.Length)
			{
				return root;
			}
			int element = node;
			for (int idx = 0; idx < k; idx++)
			{
				root = m_elements[element];
				if (root == -1)
				{
					return root;
				}

				element = root;
			}

			return root;
		}
	}
}