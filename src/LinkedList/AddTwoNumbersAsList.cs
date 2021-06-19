namespace CSharpProblemSolving.LinkedList
{
	public static class AddTwoNumbersAsList
	{
		public static void Samples()
		{
			var node1 = new ListNode(9);
			node1.next = new ListNode(8);
			node1.next.next = new ListNode(3);
			node1.next.next.next = new ListNode(9);
			node1.next.next.next.next = new ListNode(9);
			
			var node2 = new ListNode(8);
			node2.next = new ListNode(9);
			node2.next.next = new ListNode(9);
			var result = addTwoNumbers(node2, node1);
			result.PrintChain();
		}
		public static ListNode addTwoNumbers(ListNode A, ListNode B)
		{
			ListNode dummy = new ListNode(-1);
			var head = dummy;
			int carry = 0;
			while (A != null || B != null)
			{
				int a = 0, b = 0;
				if (A != null)
				{
					a = A.val;
					A = A.next;
				}

				if (B != null)
				{
					b = B.val;
					B = B.next;
				}

				var sum = a + b + carry;
				carry = sum / 10;
				var num = sum % 10;
				head.next = new ListNode(num);
				head = head.next;
			}

			if (carry == 1)
			{
				head.next = new ListNode(1);
			}

			return dummy.next;
		}
	}
}