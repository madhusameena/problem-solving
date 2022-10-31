using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    public class Node1
    {
        public int val;
        public IList<Node1> children;

        public Node1()
        {
        }

        public Node1(int _val)
        {
            val = _val;
        }

        public Node1(int _val, IList<Node1> _children)
        {
            val = _val;
            children = _children;
        }
    }

    // https://leetcode.com/problems/n-ary-tree-level-order-traversal/
    internal class N_ary_Tree_Level_Order_Traversal
    {
        public IList<IList<int>> LevelOrder(Node1 root)
        {
            if (root == null)
                return new List<IList<int>>();
            var hash = new Dictionary<int, IList<int>>();
            LevelOrderDfs(root, hash, 0);
            return hash.OrderBy(s => s.Key).Select(s => s.Value).ToList();
        }
        private void LevelOrderDfs(Node1 node, Dictionary<int, IList<int>> hash, int level)
        {
            if (node == null)
                return;
            if (!hash.ContainsKey(level))
                hash.Add(level, new List<int>() { node.val });
            else
                hash[level].Add(node.val);
            foreach (var child in node.children)
            {
                LevelOrderDfs(child, hash, level + 1);
            }
        }
        public IList<IList<int>> LevelOrderBFS(Node1 root)
        {
            var ans = new List<IList<int>>();
            if (root == null)
                return ans;
            var queue = new Queue<Node1>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var count = queue.Count;
                var list = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    list.Add(node.val);
                    foreach (var child in node.children)
                    {
                        if (child != null)
                            queue.Enqueue(child);
                    }
                }
                ans.Add(list);
            }
            return ans;
        }
    }
}
