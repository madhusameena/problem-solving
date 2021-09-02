using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpProblemSolving.LinkedList;

namespace CSharpProblemSolving.BST
{
	// https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/
	// https://www.interviewbit.com/problems/convert-sorted-list-to-binary-search-tree/
	public class SortedListToBinaryTree
	{
		// https://www.youtube.com/watch?v=5IQF13nNq6A
		public TreeNode SortedListToBST(ListNode head)
		{
			if (head == null)
			{
				return null;
			}
			if (head.next == null)
			{
				return new TreeNode(head.val);
			}
			ListNode middle = FindMiddle(head);
			var nextItem = middle.next;
			TreeNode root = new TreeNode(middle.val);
			root.left = SortedListToBST(head);
			root.right = SortedListToBST(nextItem);
			return root;
		}

		private ListNode FindMiddle(ListNode head)
		{
			ListNode slow = head, fast = head, prev = null; // needed to break at before mid
			while (fast != null && fast.next != null)
			{
				prev = slow;
				slow = slow.next;
				fast = fast.next.next;
			}
			prev.next = null; // Break previous loop, no need to break prev loop
			return slow;
		}
	}
}
