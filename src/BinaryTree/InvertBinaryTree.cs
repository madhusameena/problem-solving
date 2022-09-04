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
        private void InvertBfs2(TreeNode root)
        {
            if (root == null)
                return;
            (root.left, root.right) = (root.right, root.left);
            InvertBfs2(root.left);
            InvertBfs2(root.right);
        }
        private void InvertBfs(TreeNode root)
        {
            if (root == null)
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
                    (node.left, node.right) = (node.right, node.left);
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
        }
    }
}
