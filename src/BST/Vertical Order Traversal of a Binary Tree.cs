using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    class Item
    {
        public int Val
        {
            get; set;
        }
        public int Level
        {
            get; set;
        }
    }
    class ItemComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x.Level == y.Level)
                return x.Val - y.Val;
            return x.Level - y.Level;
        }
    }
    // https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/
    internal class Vertical_Order_Traversal_of_a_Binary_Tree
    {
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var hash = new Dictionary<int, PriorityQueue<Item, Item>>();
            Dfs(root, 0, 0, hash);
            var lists = hash.OrderBy(x => x.Key).Select(x => x.Value).ToList();
            var ans = new List<IList<int>>();
            foreach (var pq in lists)
            {
                var list = new List<int>();
                while (pq.Count > 0)
                {
                    list.Add(pq.Dequeue().Val);
                }
                ans.Add(list);
            }
            return ans;
        }
        private void Dfs(TreeNode node, int col, int level, Dictionary<int, PriorityQueue<Item, Item>> hash)
        {
            if (node == null)
                return;
            if (!hash.ContainsKey(col))
            {
                hash.Add(col, new PriorityQueue<Item, Item>(new ItemComparer()));
            }
            var item = new Item()
            {
                Val = node.val,
                Level = level,
            };
            hash[col].Enqueue(item, item);
            Dfs(node.left, col - 1, level + 1, hash);
            Dfs(node.right, col + 1, level + 1, hash);
        }
    }
}
