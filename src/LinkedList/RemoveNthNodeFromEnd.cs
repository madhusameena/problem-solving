namespace CSharpProblemSolving.LinkedList
{
	public static class RemoveNthNodeFromEnd
	{
		public static void Samples()
		{
			var node = new ListNode(1);
			node.next = new ListNode(2);
			node.next.next = new ListNode(3);
			node.next.next.next = new ListNode(4);
			node.next.next.next.next = new ListNode(5);
			var result = removeNthFromEndWithFastSlow(node, 2);
			result.PrintChain();
		}

		public static ListNode removeNthFromEndWithFastSlow(ListNode A, int B)
		{
			if (A == null)
			{
				return null;
			}

			ListNode head = new ListNode(-1);
			head.next = A;
			ListNode fast = head, slow = head;
			
			for (int i = 0; i <= B; i++)
			{
				if (fast == null) // Not enough length
				{
					return head.next.next;
				}

				fast = fast.next;
			}
			// Now move slow till fast reaches null
			while (fast != null)
			{
				fast = fast.next;
				slow = slow.next;
			}
			// now slow reached 
			slow.next = slow.next.next;
			return head.next;
		}

		public static ListNode removeNthFromEnd(ListNode A, int B) 
		{
			if (A == null)
			{
				return A;
			}

			if (A.next == null && B == 0)
			{
				return A;
			}
			if (A.next == null)
			{
				return null;
			}

			var temp = A;
			var len = GetLength(temp);
			int index = len - B - 1;
			if (index < 0)
			{
				return A.next;
			}
			temp = A;
			for (int i = 0; i < index; i++)
			{
				temp = temp.next;
			}

			temp.next = temp.next.next;
			return A;
		}
		public static int GetLength(ListNode temp)
		{
			if (temp == null)
			{
				return 0;
			}
			int count = 1;
			while (temp.next != null)
			{
				temp = temp.next;
				count++;
			}

			return count;
		}
	}
}