using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    public class SegmentNode
    {
        public SegmentNode(int left, int right)
        {
            Left = left;
            Right = right;
        }
        public int Val
        {
            get; set;
        }

        public int Left
        {
            get; set;
        }
        public int Right
        {
            get; set;
        }
        public SegmentNode LeftNode
        {
            get; set;
        }
        public SegmentNode RightNode
        {
            get; set;
        }
    }
    public class SegmentTree
    {
        private SegmentNode _root;
        public void ConstructTree(int[] data)
        {
            _root = ConstructTree(0, data.Length - 1, data);
        }

        private SegmentNode ConstructTree(int left, int right, int[] data)
        {
            if (left > right)
            {
                return null;
            }
            var node = new SegmentNode(left, right);
            if (left == right)
            {
                node.Val = data[left];
            }
            else
            {
                var mid = left + (right - left) / 2;
                node.LeftNode = ConstructTree(left, mid, data);
                node.RightNode = ConstructTree(mid + 1, right, data);

                node.Val = node.LeftNode.Val + node.RightNode.Val;
            }
            
            return node;
        }

        public void Update(int idx, int val)
        {
            Update(_root, idx, val);
        }

        private void Update(SegmentNode node, int idx, int val)
        {
            if (node == null)
                return;
            if (node.Left == node.Right && node.Right == idx)
            {
                node.Val = val;
                return;
            }
            var mid = node.Left + (node.Right - node.Left) / 2;
            if (idx <= mid)
            {
                Update(node.LeftNode, idx, val);
            }
            else
            {
                Update(node.RightNode, idx, val);
            }
            node.Val = node.LeftNode.Val + node.RightNode.Val;
        }

        public int GetRangeSum(int left, int right)
        {
            if (_root == null)
                return int.MinValue;
            return GetRangeSum(_root, left, right);
        }

        private int GetRangeSum(SegmentNode node, int left, int right)
        {
            if (node.Left == left && node.Right == right)
            {
                return node.Val;
            }
            var mid = node.Left + (node.Right - node.Left) / 2;
            if (right <= mid)
            {
                // Move left side
                return GetRangeSum(node.LeftNode, left, right);
            }
            if (left > mid)
            {
                // Move right side
                return GetRangeSum(node.RightNode, left, right);
            }
            var leftNodeVal = GetRangeSum(node.LeftNode, left, mid);
            var rightNodeVal = GetRangeSum(node.RightNode, mid + 1, right);
            return leftNodeVal + rightNodeVal;
        }
    }
    public static class SegmentTreeSample
    {
        public static void Samples()
        {
            var tree = new SegmentTree();
            tree.ConstructTree(new int[] { 1, 3, 5 });
            Console.WriteLine(tree.GetRangeSum(0, 2));
            tree.Update(1, 2);
            Console.WriteLine(tree.GetRangeSum(0, 2));
        }
    }
    // https://leetcode.com/problems/range-sum-query-mutable
    public class NumArray
    {
        private SegmentTree _segTree = new SegmentTree();

        public NumArray(int[] nums)
        {
            _segTree.ConstructTree(nums);
        }

        public void Update(int index, int val)
        {
            _segTree.Update(index, val);
        }

        public int SumRange(int left, int right)
        {
            return _segTree.GetRangeSum(left, right);
        }
    }
}
