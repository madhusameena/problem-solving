using System.Collections.Generic;

namespace CSharpProblemSolving.LinkedList
{
	public static class RemoveDuplicates
	{
		public static void Samples()
		{
			ListNode node = new ListNode(3);
			node.next = new ListNode(4);
			node.next.next = new ListNode(4);
			node.next.next.next = new ListNode(5);
			node.next.next.next.next = new ListNode(5);
			var result = deleteDuplicatesForSortedList(node);
			result.PrintChain();
		}
		public static ListNode deleteDuplicates(ListNode A)
		{
			if (A == null || A.next == null)
			{
				return A;
			}
			HashSet<int> hashSet = new HashSet<int>();
			var head = A;
			hashSet.Add(A.val);
			while (A != null && A.next != null)
			{
				if (hashSet.Contains(A.next.val))
				{
					A.next = A.next.next;
				}
				else
				{
					hashSet.Add(A.next.val);
					A = A.next;
				}
			}

			return head;
		}
		public static ListNode deleteDuplicatesForSortedList(ListNode A)
		{
			if (A == null || A.next == null)
			{
				return A;
			}
			var head = A;
			while (A != null && A.next != null)
			{
				if (A.val == A.next.val)
				{
					A.next = A.next.next;
				}
				else
				{
					A = A.next;
				}
			}

			return head;
		}
	}
}