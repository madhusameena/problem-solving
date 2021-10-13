using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    // https://www.interviewbit.com/problems/inorder-traversal/
    // https://leetcode.com/problems/binary-tree-inorder-traversal/solution/
    public class InorderProblem
	{
        public List<int> inorderTraversal(TreeNode A)
        {
            return inorderTraversalUsingStack(A);
        }
        // https://www.youtube.com/watch?v=5y_j0OqD7v8
        public static List<int> inorderTraversalUsingStack(TreeNode root)
        {
            var list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
			while (stack.Count > 0 || root != null)
			{
				if (root == null)
				{
                    list.Add(stack.Peek().val);
                    root = stack.Pop().right;
                }
                while (root != null)
				{
                    stack.Push(root);
                    root = root.left;
				}
			}
            return list;
        }
        // https://www.youtube.com/watch?v=wGXB9OWhPTg
        public List<int> inorderTraversalUsingMorris(TreeNode root)
        {
            var list = new List<int>();
            while (root != null)
            {
                if (root.left != null)
                {
                    // attach right most of left to current
                    var pre = root.left;
                    while (pre.right != null)
                    {
                        pre = pre.right;
                    }
                    pre.right = root;
                    // Remove left break
                    var temp = root;
                    root = root.left;
                    temp.left = null;
                }
                else
                {
                    list.Add(root.val);
                    root = root.right;
                }
            }
            return list;
        }
        private void InorderTraversalRecursion(TreeNode node, List<int> list)
        {
            if (node == null)
            {
                return;
            }
            InorderTraversalRecursion(node.left, list);
            list.Add(node.val);
            InorderTraversalRecursion(node.right, list);
        }
    }
}
