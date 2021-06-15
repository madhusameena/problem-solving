namespace CSharpProblemSolving.LinkedList
{
	public static class SortBinary
	{
		public static void Samples()
		{
			ListNode node = new ListNode(1);
			node.next = new ListNode(0);
			node.next.next = new ListNode(0);
			node.next.next.next = new ListNode(1);
			var result = solve(node);
			result.PrintChain();
			result = solveWithSwap(node);
		}

		public static ListNode solve(ListNode A)
		{
			if (A == null)
			{
				return null;
			}

			if (A.GetLength() == 1)
			{
				return A;
			}
			var counts = new int[2] {0, 0};
			var tmpNode = A;
			while (tmpNode != null)
			{
				counts[tmpNode.val] += 1;
				tmpNode = tmpNode.next;
			}

			tmpNode = A;
			int index = 0;
			ListNode headNode = null;
			while (tmpNode != null)
			{
				if (counts[index] == 0)
				{
					index++;
				}
				else
				{
					tmpNode.val = index;
					if (headNode == null)
					{
						headNode = tmpNode;
					}
					tmpNode = tmpNode.next;
					counts[index] -= 1;
				}
			}

			return headNode;
		}

		public static ListNode solveWithSwap(ListNode node)
		{
			if (node == null)
			{
				return null;
			}

			if (node.next == null)
			{
				return node;
			}

			var t1 = node;
			var t2 = node.next;
			while (t2 != null)
			{
				if (t1.val == 1 && t2.val == 0)
				{
					// swap it
					t1.val = 0;
					t2.val = 1;
					t1 = t1.next;
					t2 = t2.next;
				}
				else if (t1.val == 1 && t2.val == 1)
				{
					t2 = t2.next;
				}
				else
				{
					t1 = t1.next;
					t2 = t2.next;
				}
			}

			return node;
		}
	}
}