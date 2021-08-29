using System.Collections.Generic;

namespace CSharpProblemSolving.BinaryTree
{
	// https://www.geeksforgeeks.org/deletion-binary-tree/
	public class DeleteFromBinaryTree
	{
		public static void Samples()
		{
		}

		public static Node DeleteDeepest(Node node, int item)
		{
			if (node == null)
			{
				return null;
			}

			if (node.left == null && node.right == null)
			{
				if (node.data == item)
				{
					node = null;
					return null;
				}
				else
				{
					return node;
				}
			}
			Node temp = node;
			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(temp);
			while (queue.Count > 0)
			{
				
			}
			return node;
		}
	}
}