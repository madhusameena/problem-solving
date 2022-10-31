using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.StackOperations
{
    internal class Next_Greater_Element_II
    {
        // https://leetcode.com/problems/next-greater-element-ii/solution/
        public int[] NextGreaterElements(int[] nums)
        {
            var res = new int[nums.Length];
            int n = nums.Length;
            var stack = new Stack<int>();
            for (int i = (n * 2) - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] <= nums[i % n])
                    stack.Pop();
                if (stack.Count > 0)
                    res[i % n] = nums[stack.Peek()];
                else
                    res[i % n] = -1;
                stack.Push(i % n);
            }
            return res;
        }
    }
}
