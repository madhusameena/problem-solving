using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.BinaryTree
{
	// https://www.geeksforgeeks.org/insertion-in-a-binary-tree-in-level-order/
	public static class InsertionInLevelTree
	{
		public static void Samples()
		{
			var root = new Node(10);
			root.left = new Node(11);
			root.left.left = new Node(7);
			root.right = new Node(9);
			root.right.left = new Node(15);
			root.right.right = new Node(8);
			Console.WriteLine("Before inorder");
			Node.InOrder(root);
			Insert(root, 12);
			Insert(root, 22);
			Console.WriteLine();
			Console.WriteLine("After inorder");
			Node.InOrder(root);
		}

		public static void Insert(Node temp, int key)
		{
			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(temp);
			while (queue.Count > 0)
			{
				var tempQueue = queue.Dequeue();
				if (tempQueue.left == null)
				{
					tempQueue.left = new Node(key);
					break;
				}
				else
				{
					queue.Enqueue(tempQueue.left);
				}
				if (tempQueue.right == null)
				{
					tempQueue.right = new Node(key);
					break;
				}
				else
				{
					queue.Enqueue(tempQueue.right);
				}
			}
		}
	}
}