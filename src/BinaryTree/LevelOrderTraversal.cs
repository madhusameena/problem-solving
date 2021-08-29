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
	public static class LevelOrderTraversal
	{
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