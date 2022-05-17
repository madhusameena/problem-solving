using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.BinaryTree
{
	// Also called BFT
	// https://www.geeksforgeeks.org/level-order-tree-traversal/

	//		1
	//    2   3
	// 4    5
	// result -> 1 2 3 4 5
	public static class ReverseLevelOrder
	{
		public static List<int> solve()
		{
			Node node = new Node(1);
			node.left = new Node(2);
			node.left.left = new Node(4);
			node.left.right = new Node(5);
			node.left.left.left = new Node(8);
			node.left.left.right = new Node(9);
			node.right = new Node(3);
			node.right.left = new Node(6);
			node.right.right = new Node(7);
			var ht = GetHeight(node);
			var ans = new List<int>();
			for (int i = ht; i >= 1; i--)
			{
				PrintCurrentLevel(node, i, ans);
			}
			return ans;
		}
		private static void PrintCurrentLevel(Node node, int level, List<int> ans)
		{
			if (node == null)
			{
				return;
			}
			if (level == 1)
            {
                ans.Add(node.data);
                return;
			}
			PrintCurrentLevel(node.left, level - 1, ans);
			PrintCurrentLevel(node.right, level - 1, ans);
		}
		private static int GetHeight(Node node)
		{
			if (node == null)
			{
				return 0;
			}
			int left = GetHeight(node.left);
			int right = GetHeight(node.right);
			return Math.Max(left, right) + 1;
		}
	}
	public static class LevelOrderTraversal
	{
		public static void ReverseLevelOrder()
		{
			Node node = new Node(1);
			node.left = new Node(2);
			
			node.right = new Node(3);
			node.right.left = new Node(4);
			node.right.left.right = new Node(5);
			var height = GetHeight(node);
			var ans = new List<int>();
			for (int i = height; i > 0; i--)
			{
				PrintCurrentLevel(node, i, ans);
			}
			foreach (var item in ans)
			{
				Console.Write($"{item}\t");
			}

		}
		public static void Samples()
		{
			Node node = new Node(1);
			node.left = new Node(2);
			node.left.left = new Node(4);
			node.left.right = new Node(5);
			node.left.left.left = new Node(8);
			node.left.left.right = new Node(9);
			node.right = new Node(3);
			node.right.left = new Node(6);
			node.right.right = new Node(7);
			var height = GetHeight(node);
			for (int i = 1; i <= height; i++)
			{
				PrintCurrentLevel(node, i);
				Console.WriteLine();
			}

			Console.WriteLine("-------");
			TraverseUsingQueue(node);
		}

		public static void PrintCurrentLevel(Node node, int level)
		{
			if (node == null)
			{
				return;
			}
			if (level == 1)
			{
				Console.Write($"{node.data}\t");
				return;
			}
			PrintCurrentLevel(node.left, level - 1);
			PrintCurrentLevel(node.right, level - 1);
		}
		public static void PrintCurrentLevel(Node node, int level, List<int> ans)
		{
			if (node == null)
			{
				return;
			}
			if (level == 1)
			{
				ans.Add(node.data);
				return;
			}
			PrintCurrentLevel(node.left, level - 1, ans);
			PrintCurrentLevel(node.right, level - 1, ans);
		}

		public static int GetHeight(Node node)
		{
			if (node == null)
			{
				return 0;
			}

			int leftHeight = GetHeight(node.left);
			int rightHeight = GetHeight(node.right);
			return Math.Max(leftHeight, rightHeight) + 1;
		}

		public static void TraverseUsingQueue(Node node)
		{
			if (node == null)
			{
				return;
			}
			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(node);
			while (queue.Count > 0)
			{
				var tempQueue = queue.Dequeue();
				Console.Write($"{tempQueue.data}\t");
				if (tempQueue.left != null)
				{
					queue.Enqueue(tempQueue.left);
				}
				if (tempQueue.right != null)
				{
					queue.Enqueue(tempQueue.right);
				}
			}
		}
	}
}