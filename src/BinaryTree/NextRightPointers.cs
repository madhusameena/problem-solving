using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.BinaryTree
{
	// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
	public class NextRightPointers
	{
		public class Node
		{
			public int data;
			public Node left, right, next;

			public Node(int item)
			{
				data = item;
				left = right = null;
				next = null;
			}
		}

		public static void Samples()
		{
			var nodes = new Node[7];
			for (int i = 0; i < 7; i++)
			{
				nodes[i] = new Node(i + 1);
			}

			nodes[0].left = nodes[1];
			nodes[0].right = nodes[2];
			
			nodes[1].left = nodes[3];
			nodes[1].right = nodes[4];
			
			nodes[2].left = nodes[5];
			nodes[2].right = nodes[6];
			var resultNode = Connect(nodes[0]);
			
		}

		public static Node Connect(Node root) 
		{
			if (root == null)
			{
				return null;
			}

			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(root);
			List<Node> levelNodes = new List<Node>();
			while (queue.Count > 0)
			{
				levelNodes.Clear();
				var width = queue.Count;
				for (var idx = 0; idx < width; idx++)
				{
					var item = queue.Dequeue();
					levelNodes.Add(item);
					if (item.left != null)
					{
						queue.Enqueue(item.left);	
					}
					if (item.right != null)
					{
						queue.Enqueue(item.right);	
					}
				}
				for (var idx = 0; idx < levelNodes.Count - 1; idx++)
				{
					levelNodes[idx].next = levelNodes[idx + 1];
				}
			}

			return root;
		}
	}
}