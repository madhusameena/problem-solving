using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BinaryTree
{
    internal class TreeNodeGenerate
    {
      internal int val;
      internal TreeNodeGenerate left;
      internal TreeNodeGenerate right;
      internal TreeNodeGenerate(int val = 0, TreeNodeGenerate left = null, TreeNodeGenerate right = null)
      {
           this.val = val;
           this.left = left;
           this.right = right;
      }
     }
    internal class GenerateTreesProblem
    {
        public IList<TreeNodeGenerate> GenerateTrees(int n)
        {
            var dp = new IList<TreeNodeGenerate>[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    dp[i, j] = null;
                }
            }
            return GenerateTreesUtil(1, n, dp);
        }
        private IList<TreeNodeGenerate> GenerateTreesUtil(int left, int right, IList<TreeNodeGenerate>[,] dp)
        {
            var list = new List<TreeNodeGenerate>();
            if (left > right)
            {
                list.Add(null);
                return list;
            }
            if (dp[left, right] != null)
                return dp[left, right];
            for (int i = left; i <= right; i++)
            {
                var leftItems = GenerateTreesUtil(left, i - 1, dp);
                var rightItems = GenerateTreesUtil(i + 1, right, dp);
                foreach (var leftItem in leftItems)
                {
                    foreach (var rightItem in rightItems)
                    {
                        var node = new TreeNodeGenerate(i, leftItem, rightItem);
                        list.Add(node);
                    }
                }
            }

            dp[left, right] = list;
            return list;
        }
    }
}
