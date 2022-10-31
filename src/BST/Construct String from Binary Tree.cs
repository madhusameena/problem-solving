using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    // https://leetcode.com/problems/construct-string-from-binary-tree/
    internal class Construct_String_from_Binary_Tree
    {
        public string Tree2str(TreeNode root)
        {
            if (root == null)
                return "";
            if (root.left == null && root.right == null)
                return $"{root.val}";
            var left = Tree2str(root.left);
            if (root.right == null)
                return $"{root.val}({left})";
            string right = Tree2str(root.right);
            return $"{root.val}({left})({right})";
        }
    }
}
