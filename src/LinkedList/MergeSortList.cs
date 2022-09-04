using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace CSharpProblemSolving.LinkedList
{
    // https://leetcode.com/problems/sort-list/
    public static class MergeSortList
	{
		public static void Samples()
		{
			ListNode node = new ListNode(55);
			node.next = new ListNode(33);
			node.next.next = new ListNode(3);
			node.next.next.next = new ListNode(11);
			var result = SortList(node);
			result.PrintChain();
		}


        public static ListNode SortList(ListNode node)
        {
            if (node == null || node.next == null)
            {
                return node;
            }
            var middleNode = FindMid(node);
            var newHead1 = SortList(node);
            var newHead2 = SortList(middleNode);
            var mergedNode = Merge(newHead1, newHead2);
            return mergedNode;
        }
        private static ListNode Merge(ListNode head1, ListNode head2)
        {
            // head1 and head2 are already sorted
            // Now merge them
            ListNode head = new ListNode(-1);
            ListNode tempNode = head;
            while (head1 != null && head2 != null)
            {
                if (head1.val < head2.val)
                {
                    tempNode.next = head1;
                    head1 = head1.next;
                }
                else
                {
                    tempNode.next = head2;
                    head2 = head2.next;
                }
                tempNode = tempNode.next;
            }
            tempNode.next = head1 == null ? head2 : head1;
            return head.next;
        }

        public static ListNode FindMid(ListNode node)
        {

            // Move fast node 2 times, slow node once to get middle
            var fastNode = node; // Start with index 1
            var slowNode = node;
            ListNode prev = null;
            while (fastNode != null && fastNode.next != null)
            {
                fastNode = fastNode.next.next;
                prev = slowNode;
                slowNode = slowNode.next;
            }
            prev.next = null;
            return slowNode;
        }
    }
}