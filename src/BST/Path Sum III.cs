using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    // https://leetcode.com/problems/path-sum-iii/
    internal class Path_Sum_III
    {
        public static void Samples()
        {
            var obj = new Path_Sum_III();
            var node = new TreeNode(10);
            node.right = new TreeNode(-3);
            node.right.right = new TreeNode(11);
            Console.WriteLine(obj.PathSum(node, 8));
        }
        public int PathSum(TreeNode root, int targetSum)
        {
            var hash = new Dictionary<long, int>();
            hash.Add(0, 1);
            return PathSum(root, targetSum, hash, 0L);
        }
        private int PathSum(TreeNode node, int target, Dictionary<long, int> hash, long sum)
        {
            if (node == null)
                return 0;
            sum += node.val;
            int ret = 0;
            if (hash.ContainsKey(sum - target))
                ret += hash[sum - target];
            if (hash.ContainsKey(sum))
                hash[sum]++;
            else
                hash.Add(sum, 1);
            ret += PathSum(node.left, target, hash, sum);
            ret += PathSum(node.right, target, hash, sum);
            hash[sum]--; // Revert change
            return ret;
        }
    }
}
