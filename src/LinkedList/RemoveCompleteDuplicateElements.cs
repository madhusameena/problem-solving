namespace CSharpProblemSolving.LinkedList
{
	// https://www.interviewbit.com/problems/remove-duplicates-from-sorted-list-ii/
	public class RemoveCompleteDuplicateElements
	{
		public static void Samples()
		{
			ListNode node = new ListNode(2);
			node.next = new ListNode(3);
			node.next.next = new ListNode(3);
			node.next.next.next = new ListNode(4);
			node.next.next.next.next = new ListNode(5);
			node.next.next.next.next.next = new ListNode(6);
			node.next.next.next.next.next.next = new ListNode(6);
			// node.next.next.next.next = new ListNode(5);
			var result = deleteDuplicatesSln(node);
			result.PrintChain();
		}

		public static ListNode deleteDuplicatesSln(ListNode A)
		{
			ListNode head = new ListNode(-1);
			head.next = A;
			ListNode pre = head;
			var current = A;
			while (current != null)
			{
				while (current.next != null && current.val == current.next.val)
				{
					current = current.next;
				}

				if (pre.next == current) // This will true when there are no duplicates so pre = pre.next(current)
				{
					pre = pre.next;
				}
				else // True when there are duplicates, so pre.next = current.next(next number not the duplicate one)
				{
					pre.next = current.next;
				}

				current = current.next;
			}

			return head.next;
		}

		public static ListNode deleteDuplicates(ListNode A) 
		{
			if (A == null || A.next == null)
			{
				return A;
			}
			ListNode lastPrev = new ListNode(-1);
			ListNode newHead = lastPrev;
			bool skip = false;
			var prev = A;
			A = A.next;
			
			while (prev != null && A != null)
			{
				if (prev.val == A.val)
				{
					skip = true;
				}
				else
				{
					if (!skip)
					{
						lastPrev.next = new ListNode(prev.val);
						lastPrev = lastPrev.next;
					}
					skip = false;
				}

				A = A.next;
				prev = prev.next;
			}

			if (prev != null && !skip)
			{
				lastPrev.next = prev;
			}

			// if (A != null && A.val != lastPrev.val && newHead.next != null)
			// {
			// 	lastPrev.next = A;
			// }

			return newHead.next;
		}
	}
}