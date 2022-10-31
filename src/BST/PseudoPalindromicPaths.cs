using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    // https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/
    internal class PseudoPalindromicPathsProblem
    {
        public static void Samples()
        {
            var obj = new PseudoPalindromicPathsProblem();
            var node = new TreeNode(2);
            node.left = new TreeNode(3);
            node.left.left = new TreeNode(3);
            node.left.right = new TreeNode(1);
            node.right = new TreeNode(1);
            node.right.right = new TreeNode(1);

            Console.WriteLine(obj.PseudoPalindromicPaths(node));
        }
        public int PseudoPalindromicPaths(TreeNode root)
        {
            var hash = new Dictionary<int, int>();
            for (int i = 0; i < 9; i++)
                hash.Add(i, 0);
            return PseudoPalindromicPaths(root, hash);
        }
        int PseudoPalindromicPaths(TreeNode root, Dictionary<int, int> hash)
        {
            if (root == null)
                return 0;
            hash[root.val - 1]++;
            if (root != null && root.left == null && root.right == null)
            {
                var count = hash.Values.Sum();
                int oddCount = hash.Count(x => x.Value > 0 && x.Value % 2 == 1);
                if (count % 2 == 0)
                {
                    return oddCount == 0 ? 1 : 0;
                }
                return oddCount == 1 ? 1 : 0;
            }
            var left = PseudoPalindromicPaths(root.left, new Dictionary<int, int>(hash));
            var right = PseudoPalindromicPaths(root.right, new Dictionary<int, int>(hash));
            return left + right;
        }
    }
}
