namespace CSharpProblemSolving.LinkedList
{
	public static class InsertionNode
	{
		public static ListNode getIntersectionNode(ListNode A, ListNode B)
		{
			if (A == null || B == null)
			{
				return null;
			}

			var lenA = A.GetLength();
			var lenB = B.GetLength();
			if (lenA > lenB)
			{
				for (int idx = 0; idx < lenA - lenB; idx++)
				{
					A = A.next;
				}
			}
			else
			{
				for (int idx = 0; idx < lenB - lenA; idx++)
				{
					B = B.next;
				}
			}

			while (A != null && B != null)
			{
				if (A == B)
				{
					return A;
				}

				A = A.next;
				B = B.next;
			}

			return null;
		}
	}
}