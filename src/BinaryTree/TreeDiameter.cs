using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpProblemSolving.BST;

namespace CSharpProblemSolving.BinaryTree
{
	// https://leetcode.com/problems/diameter-of-binary-tree/description/
	// https://www.youtube.com/watch?v=ey7DYc9OANo
	public class TreeDiameter
	{
		public static void Samples()
		{
			var root = new TreeNode(1);
			root.left = new TreeNode(2);
			var test = new TreeDiameter();
			Console.WriteLine(test.DiameterOfBinaryTree(root));
		}
		public int DiameterOfBinaryTree(TreeNode root)
		{
			int dia = 0;
			GetHeight(root, ref dia);
			return dia;
		}
		private int GetHeight(TreeNode root, ref int dia)
		{
			if (root == null)
			{
				return 0;
			}
			int leftHeight = GetHeight(root.left, ref dia);
			int rightHeight = GetHeight(root.right, ref dia);

			dia = Math.Max(leftHeight + rightHeight, dia);


			return Math.Max(leftHeight, rightHeight) + 1;

		}
	}
}
