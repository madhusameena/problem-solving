using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    // https://leetcode.com/problems/balanced-binary-tree/
    internal class Balanced_Binary_Tree
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;
            var leftHt = Height(root.left);
            var rightHt = Height(root.right);
            return Math.Abs(leftHt - rightHt) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }
        int Height(TreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(Height(node.left), Height(node.right));
        }
    }
}
