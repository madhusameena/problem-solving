using System;
using CSharpProblemSolving.BinaryTree;

namespace CSharpProblemSolving.BST
{
	public static class FixTwoSwappedNodes
	{
		public static void Samples()
		{
			TreeNode root = new TreeNode(1);
			root.left = new TreeNode(3);
			root.left.right = new TreeNode(2);
			
			
			Console.WriteLine("========Before==============");
			TreeNode.InOrder(root);
			Console.WriteLine("========Before==============");
			RecoverTree(root);
			Console.WriteLine("========After==============");
			TreeNode.InOrder(root);
			Console.WriteLine("========After==============");
		}

		// https://www.geeksforgeeks.org/fix-two-swapped-nodes-of-bst/
		// https://leetcode.com/problems/recover-binary-search-tree/
		public static void CorrectBSTUtil(TreeNode node, ref TreeNode prev, ref TreeNode first, ref TreeNode middle, ref TreeNode end)
		{
			if (node == null) return;
			CorrectBSTUtil(node.left, ref prev, ref first, ref middle, ref end);
			if (prev != null && prev.val > node.val)
			{
				if (first == null)
				{
					// Found first unexpected series
					first = prev;
					middle = node;
				}
				else
				{
					end = node;
				}
				
			}

			prev = node;
			CorrectBSTUtil(node.right, ref prev, ref first, ref middle, ref end);
		}

		private static void RecoverTree(TreeNode root)
		{
			TreeNode prev = null, first = null, middle = null, end = null;
			CorrectBSTUtil(root, ref prev, ref first, ref middle, ref end);

			if (first != null && end != null)
			{
				// Swap first and mid
				(first.val, end.val) = (end.val, first.val);
			}
			else if (first != null && middle != null)
			{
				// Swap last and mid
				(first.val, middle.val) = (middle.val, first.val);
			}
		}

	}
}