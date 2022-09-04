using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    // https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
    internal class Convert_Sorted_Array_to_Binary_Search_Tree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTHelper(nums, 0, nums.Length - 1);
        }
        private TreeNode SortedArrayToBSTHelper(int[] nums, int start, int end)
        {
            if (end - start < 0)
                return null;
            int mid = start + (end - start) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = SortedArrayToBSTHelper(nums, start, mid - 1);
            node.right = SortedArrayToBSTHelper(nums, mid + 1, end);
            return node;
        }
    }
}
