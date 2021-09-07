using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
	// https://leetcode.com/problems/sum-root-to-leaf-numbers/
	// https://www.interviewbit.com/problems/sum-root-to-leaf-numbers/
	public class SumRootToLeave
	{
		public int SumNumbers(TreeNode root)
		{
			int num = 0;
			return Dfs(root, num);

		}
		private int Dfs(TreeNode node, int num)
		{
			if (node == null)
			{
				return 0;
			}
			num = num * 10 + node.val;
			if (node.left == null && node.right == null)
			{
				return num;
			}
			int leftVal = 0, rightVal = 0;
			if (node.left != null)
			{
				leftVal = Dfs(node.left, num);
			}
			if (node.right != null)
			{
				rightVal = Dfs(node.right, num);
			}
			return leftVal + rightVal;
		}
	}
}
