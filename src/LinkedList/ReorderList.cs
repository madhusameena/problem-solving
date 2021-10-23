using System;

namespace CSharpProblemSolving.LinkedList
{
	// https://www.interviewbit.com/problems/reorder-list/
	public static class ReorderList
	{
		public static void Samples()
		{
			var node1 = ListNodeHelper.GetListNode(new[] { 1, 2, 3, 4, 5});
			var result = reorderList(node1);
			result.PrintChain();
		}
		public static ListNode reorderList(ListNode A)
		{
			ListNode node = new ListNode(-1);
			node.next = A;
			ListNode fastNode = A, slowNode = A;
			while (fastNode != null && fastNode.next != null)
			{
				fastNode = fastNode.next.next;
				slowNode = slowNode.next;
			}

			var temp = slowNode.next;
			slowNode.next = null;

			var rev = reverseList(temp);
			temp = node;
			// while (A != null && rev != null)
			// {
			// 	var aNext = A.next;
			// 	var bNext = rev.next;
			// 	temp.next = A;
			// 	temp.next.next = rev;
			// 	A = aNext;
			// 	rev = bNext;
			// 	temp = temp.next.next;
			// }
			bool first = true;
			while (A != null && rev != null)
			{
				if (first)
				{
					temp.next = A;
					A = A.next;
				}
				else
				{
					temp.next = rev;
					rev = rev.next;
				}

				temp = temp.next;
				first = !first;
			}

			if (temp != null && A != null)
			{
				temp.next = A;
				temp = temp.next;
			}
			if (temp != null && rev != null)
			{
				temp.next = rev;
			}
			return node.next;
		}
		public static ListNode reverseList(ListNode A)
		{
			var current = A;
			ListNode prev = null;
			while (current != null)
			{
				var next = current.next;
				current.next = prev;
				prev = current;
				current = next;
			}

			return prev;// current will be null
		}
	}
}