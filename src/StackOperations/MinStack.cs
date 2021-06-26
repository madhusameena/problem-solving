using CSharpProblemSolving.LinkedList;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.youtube.com/watch?v=QMlDCR9xyd8
	public class MinStack
	{
		private ListNode m_head;
		int m_min;
		public MinStack()
		{
			m_head = null;
			m_min = -1;
		}

		public void push(int x)
		{
			if (m_head == null)
			{
				m_head = new ListNode(x);
				m_min = x;
				return;
			}
			int num = x;
			if (num < m_min)
			{
				num = 2 * num - m_min;
				m_min = x;
			}
			ListNode node = new ListNode(num);
			ListNode temp = m_head;
			node.next = temp;
			m_head = node;
		}

		public void pop()
		{
			if (m_head == null)
			{
				return;
			}
			ListNode temp = m_head;
			m_head = m_head.next;
			if (temp.val < m_min)
			{
				m_min = 2 * m_min - temp.val;
			}
			temp = null;
			if (m_head == null)
			{
				m_min = -1;
			}
		}

		public int top()
		{
			if (m_head == null)      {
				return -1;
			}
			if (m_head.val >= m_min)
			{
				return m_head.val;
			}
			return m_min;
		}

		public int getMin()
		{
			return m_min;
		}

		public static void Samples()
		{
		}
	}
}