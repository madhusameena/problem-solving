using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    internal class Binary_Search
    {
        // https://leetcode.com/problems/binary-search/
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) / 2);
                if (nums[mid] == target)
                    return mid;
                if (target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }
    }
}
