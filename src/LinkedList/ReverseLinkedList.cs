namespace CSharpProblemSolving.LinkedList
{
	public class ReverseLinkedList
	{
		public static void Samples()
		{
			ListNode node = new ListNode(1);
			node.next = new ListNode(2);
			node.next.next = new ListNode(3);
			node.next.next.next = new ListNode(4);
			var revList = reverseList(node);
			revList.PrintChain();
		}

		// https://www.interviewbit.com/problems/reverse-linked-list/
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