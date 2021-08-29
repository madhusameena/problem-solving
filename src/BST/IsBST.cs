using System;
using System.Collections.Generic;
using CSharpProblemSolving.BinaryTree;

namespace CSharpProblemSolving.BST
{
	public static class IsBST
	{
		public static void Samples()
		{
			var root = new Node(4);
			root.left = new Node(2);
			root.right = new Node(5);
			root.left.left = new Node(1);
			root.left.right = new Node(3);
			// Console.WriteLine(ValidateBst(root));
			
			
			root = new Node(-2147483648);
			root.left = new Node(-2147483648);
			Console.WriteLine(ValidateBst(root));
		}

		public static bool ValidateBst(Node root)
		{
			HashSet<int> nums = new HashSet<int>();
			int min = int.MinValue, max = int.MaxValue;
			if (!ValidateBst(root, min, max, nums))
			{
				return false;
			}

			return true;
		}

		public static bool ValidateBstSol(Node root)
		{
			return IsValidBstSol(root, null, null);
		}

		private static bool IsValidBstSol(Node root, Node left, Node right)
		{
			if (root == null)
			{
				return true;
			}

			if (left != null && left.data >= root.data)
			{
				return false;
			}

			if (right != null && right.data <= root.data)
			{
				return false;
			}

			return IsValidBstSol(root.left, left, root) &&
			       IsValidBstSol(root.right, root, right);
		}

		private static bool ValidateBst(Node node, int min, int max, HashSet<int> hashSet)
		{
			if (node == null)
			{
				return true;
			}
			if (node.data < min || node.data > max)
			{
				return false;
			}

			if (hashSet.Contains(node.data))
			{
				return false;
			}

			hashSet.Add(node.data);

			return ValidateBst(node.left, min, node.data - 1, hashSet) &&
			       ValidateBst(node.right, node.data + 1, max, hashSet);
		}
	}
}