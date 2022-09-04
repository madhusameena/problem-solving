using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.LinkedList
{
    // https://leetcode.com/problems/odd-even-linked-list/
    internal class Odd_Even_Linked_List
    {
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return null;
            ListNode evenHead = head.next, odd = head, even = head.next;
            while (even != null && even.next != null && odd != null && odd.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }
    }
}
