using System;

namespace CSharpProblemSolving.BinaryTree
{
	public class Node
	{
		public int data;
		public Node left, right;
		public Node(int item)
		{
			data = item;
			left = right = null;
		}

		// left root right
		public static void InOrder(Node node)
		{
			if (node == null)
			{
				return;
			}
			InOrder(node.left);
			Console.Write($"{node.data}\t");
			InOrder(node.right);
		}
	}
}