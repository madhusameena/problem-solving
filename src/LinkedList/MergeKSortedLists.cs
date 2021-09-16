using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.LinkedList
{
	// https://leetcode.com/problems/merge-k-sorted-lists/
	// https://www.interviewbit.com/problems/merge-k-sorted-lists/
	// https://www.youtube.com/watch?v=kpCesr9VXDA&t=273s
	public class MergeKSortedLists
	{
		// TODO Find Effective method
		public ListNode MergeKListsDivideAndConquer(ListNode[] lists)
		{
			int k = lists.Length;
			if (k == 0)
			{
				return null;
			}
			if (k == 1)
			{
				return lists[0];
			}
			//Array.Sort(lists, (a, b) => a.val.CompareTo(b.val));
			ListNode h1 = SplitAndMerge(lists, 0, (k / 2) - 1);// Left side
			ListNode h2 = SplitAndMerge(lists, k / 2, k - 1);
			// Merge h1 and h1
			return MergeLists(h1, h2);
		}

		private ListNode SplitAndMerge(ListNode[] lists, int start, int end)
		{
			if (start > end)
			{
				return null;
			}
			if (start == end)
			{
				return lists[start];
			}
			// Split into 2 half
			int k = end - start + 1;
			var h1 = SplitAndMerge(lists, start, start + (k / 2) - 1);
			var h2 = SplitAndMerge(lists, start + (k / 2), end);
			return MergeLists(h1, h2);
		}
		private ListNode MergeLists(ListNode firstNode, ListNode listNode)
		{
			ListNode node = new ListNode(-1);
			ListNode root = node;
			while (firstNode != null && listNode != null)
			{
				if (firstNode.val < listNode.val)
				{
					node.next = firstNode;
					firstNode = firstNode.next;
				}
				else if (firstNode.val > listNode.val)
				{
					node.next = listNode;
					listNode = listNode.next;
				}
				else
				{
					node.next = listNode;
					node = node.next;
					node.next = firstNode;
					listNode = listNode.next;
					firstNode = firstNode.next;
				}
				node = node.next;
			}
			while (firstNode != null)
			{
				node.next = firstNode;
				firstNode = firstNode.next;
				node = node.next;
			}

			while (listNode != null)
			{
				node.next = listNode;
				listNode = listNode.next;
				node = node.next;
			}
			return root.next;
		}

		public ListNode MergeKListsBruteForce(ListNode[] lists)
		{
			if (lists.Length == 0)
			{
				return null;
			}
			if (lists.Length == 1)
			{
				return lists[0];
			}
			var firstNode = lists[0];
			for (int i = 1; i < lists.Length; i++)
			{
				firstNode = MergeLists(firstNode, lists[i]);
			}
			return firstNode;
		}

		
	}
}
