using System;
using System.Collections.Generic;
using System.Linq;
using CSharpProblemSolving.BST;

namespace CSharpProblemSolving.BinaryTree
{
	// https://leetcode.com/problems/path-sum-ii/
	public class PathToSum
	{
		private IList<IList<int>> m_numList;
		public static void Samples()
		{
			TreeNode root = new TreeNode(1);
			root.left = new TreeNode(2);
			root.left.left = new TreeNode(4);
			root.right = new TreeNode(3);
			root.right.right = new TreeNode(3);
			var pathToSum = new PathToSum();
			var result = pathToSum.PathSum(root, 5);
			foreach (var ints in result)
			{
				foreach (var num in ints)
				{
					Console.Write($"\t{num}\t");
				}

				Console.WriteLine();
			}
			
			root = new TreeNode(1);
			root.left = new TreeNode(2);
			root.right = new TreeNode(3);
			
			result = pathToSum.PathSum(root, 5);
			foreach (var ints in result)
			{
				foreach (var num in ints)
				{
					Console.Write($"\t{num}\t");
				}

				Console.WriteLine();
			}
		}

		public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
			m_numList = new List<IList<int>>();
			var path = new List<int>();
			DepthFirstSearchPreOrder(root, path, targetSum);
			return m_numList;
		}
		private void DepthFirstSearchPreOrder(TreeNode node, List<int> path, int targetSum)
		{
			if (node == null)
			{
				return;
			}
			path.Add(node.val);

			if (node.left == null && node.right == null)
			{
				int sum = path.Aggregate((a, b) => a + b);
				if (sum == targetSum)
				{
					m_numList.Add(path);
				}
			}
			List<int> leftTempPath = new List<int>(path);
			List<int> rightTempPath = new List<int>(path);
			DepthFirstSearchPreOrder(node.left, leftTempPath, targetSum);
			DepthFirstSearchPreOrder(node.right, rightTempPath, targetSum);
		}
	}
}