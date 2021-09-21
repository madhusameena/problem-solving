using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/subarray-sum-equals-k/submissions/
    // https://www.youtube.com/watch?app=desktop&v=HbbYPQc-Oo4
    public class SubArraySumWithK
	{
        public static void Samples()
        {
			Console.WriteLine(SubarraySum(new int[] { 1, -1, 0}, 0));
        }
        // https://www.youtube.com/watch?v=20v8zSo2v18
        public static int SubarraySumSol2(int[] nums, int k)
        {
            Dictionary<int, int> preSumDict = new Dictionary<int, int>();
            int sum = 0, count = 0;
            preSumDict.Add(0, 1); // 0 sum one time - to detect if first val is k
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                var leftSum = sum - k;
				if (preSumDict.ContainsKey(leftSum))
				{
                    count += preSumDict[leftSum];
                }
				if (preSumDict.ContainsKey(sum))
				{
                    preSumDict[sum]++;
				}
				else
				{
                    preSumDict.Add(sum, 1);
				}
            }
            return count;
        }
        public static int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> preSumDict = new Dictionary<int, int>();
            int sum = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum == k)
                {
                    count++;
                }
                if (preSumDict.ContainsKey(sum - k))
                {
                    count += preSumDict[sum - k];
                }
                if (preSumDict.ContainsKey(sum))
                {
                    preSumDict[sum]++;
                }
                else
                {
                    preSumDict.Add(sum, 1);
                }
            }
            return count;
        }
    }
}
