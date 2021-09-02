using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpProblemSolving.BST;

namespace CSharpProblemSolving.BinaryTree
{
	// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
	// https://www.youtube.com/watch?v=13m9ZCB8gjw&t=157s
	// https://www.interviewbit.com/problems/least-common-ancestor/
	public class LowestCommonAncestor
	{
		public TreeNode LowestCommonAncestorLeetCode(TreeNode root, TreeNode p, TreeNode q)
		{
			if (root == null)
			{
				return null;
			}
			if (root.val == p.val ||
				root.val == q.val)
			{
				// root is the parent, other value is somewhere down
				return root;
			}
			var leftRoot = LowestCommonAncestorLeetCode(root.left, p, q);
			var rightRoot = LowestCommonAncestorLeetCode(root.right, p, q);
			if (leftRoot != null && rightRoot != null)
			{
				// found something from left and right -> so root is the parent
				return root;
			}
			if (leftRoot == null && rightRoot == null)
			{
				// Cannot find anywhere
				return null;
			}
			// Else set what is not null
			return leftRoot == null ? rightRoot : leftRoot;
		}

	}
}
