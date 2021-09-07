using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpProblemSolving.BST;

namespace CSharpProblemSolving.BinaryTree
{
	public class InvertBinaryTree
	{
		public TreeNode InvertTree(TreeNode root)
		{
			InvertBfs(root);
			return root;
		}
		private void InvertBfs(TreeNode root)
		{
			if (root == null ||
				root.left == null && root.right == null)
			{
				return;
			}
			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			while (queue.Count > 0)
			{
				var count = queue.Count;
				for (int i = 0; i < count; i++)
				{
					var node = queue.Dequeue();
					if (node == null ||
						node.left == null && node.right == null)
					{
						continue;
					}
					var temp = node.left;
					node.left = node.right;
					node.right = temp;
					queue.Enqueue(node.left);
					queue.Enqueue(node.right);
				}
			}
		}
	}
}
