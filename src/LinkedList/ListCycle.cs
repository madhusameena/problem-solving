namespace CSharpProblemSolving.LinkedList
{
	public static class ListCycle
	{
		public static void Samples()
		{
		}
		/*
		 * // https://www.geeksforgeeks.org/detect-loop-in-a-linked-list/
	ListNode* detectCycle(ListNode* A) {
	 ListNode* slowNode = A;
	 ListNode* fastNode = A;
     while (fastNode != NULL && fastNode->next != NULL)
     {
		 fastNode = fastNode->next->next;
		 slowNode = slowNode->next;
         if (fastNode == slowNode)
         {
			 fastNode = A;
             while (fastNode != slowNode)
             {
				 slowNode = slowNode->next;
				 fastNode = fastNode->next;
             }
			 return slowNode;
		 }
     }
	 return NULL;
 }
		 */
	}
}