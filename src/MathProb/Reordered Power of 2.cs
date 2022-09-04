using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.MathProb
{
    // https://leetcode.com/problems/reordered-power-of-2/
    internal class Reordered_Power_of_2
    {
        public bool ReorderedPowerOf2(int n)
        {
            var count = GetCount(n);
            int num = 1;
            for (int i = 0; i < 31; i++)
            {
                var newCount = GetCount(num);
                if (Equals(count, newCount))
                    return true;
                num *= 2;
            }
            return false;
        }
        int[] GetCount(int num)
        {
            var arr = new int[10];
            while (num > 0)
            {
                arr[num % 10]++;
                num /= 10;
            }
            return arr;
        }
        bool Equals(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }
    }
}
