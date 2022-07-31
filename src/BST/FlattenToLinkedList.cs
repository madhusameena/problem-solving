using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    // https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
    internal class FlattenToLinkedList
    {
        public void Flatten(TreeNode root)
        {
            var curr = root;
            while (curr != null)
            {
                if (curr.left != null)
                {
                    var next = curr.left;
                    while (next.right != null)
                        next = next.right;
                    next.right = curr.right;
                    curr.right = curr.left;
                    curr.left = null;
                }
                curr = curr.right;
            }
        }
    }
}
