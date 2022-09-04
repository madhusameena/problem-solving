using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BinaryTree
{
    internal class N_ary_Tree_Preorder_Traversal
    {
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node()
            {
            }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
        // https://leetcode.com/problems/n-ary-tree-preorder-traversal/
        public class Solution
        {
            public IList<int> Preorder(Node root)
            {
                var list = new List<int>();
                PreOrder(root, list);
                return list;
            }
            private void PreOrder(Node root, List<int> list)
            {
                if (root == null)
                    return;
                list.Add(root.val);
                foreach (var child in root.children)
                {
                    PreOrder(child, list);
                }
            }
        }
    }
}
