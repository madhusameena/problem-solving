using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    // https://leetcode.com/problems/binary-tree-pruning/
    internal class Binary_Tree_Pruning
    {
        public TreeNode PruneTreeRecursive(TreeNode root)
        {
            if (root == null)
                return null;
            root.left = PruneTreeRecursive(root.left);
            root.right = PruneTreeRecursive(root.right);
            if (root.val == 0 && root.left == null && root.right == null)
                return null;
            return root;
        }
        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
                return null;
            var zeroStack = new Stack<(TreeNode, TreeNode)>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            // zeroStack.Push((root, null));
            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var item = queue.Dequeue();
                    if (item.left != null && item.left.val == 0)
                        zeroStack.Push((item.left, item));
                    if (item.right != null && item.right.val == 0)
                        zeroStack.Push((item.right, item));

                    if (item.left != null)
                        queue.Enqueue(item.left);
                    if (item.right != null)
                        queue.Enqueue(item.right);
                }
            }
            while (zeroStack.Count > 0)
            {
                (TreeNode item, TreeNode parent) = zeroStack.Pop();
                if (item.left == null && item.right == null)
                {
                    if (parent.left == item)
                        parent.left = null;
                    else
                        parent.right = null;
                }
            }
            return root.val == 0 && root.left == null && root.right == null ? null : root;
        }
    }
}
