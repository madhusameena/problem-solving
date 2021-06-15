using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpProblemSolving.Arrays
{
    public static class CountPairs
    {
        public static void Samples()
        {
            int[] arr = {1, 5, 7, -1};
            Console.WriteLine(CountNumOfPairs(arr, 6));
            
            int[] arr1 = {1, 5, 7, -1, 5};
            Console.WriteLine(CountNumOfPairs(arr1, 6));
            
            int[] arr2 = {1, 1, 1, 1};
            Console.WriteLine(CountNumOfPairs(arr2, 2));

            int[] arr3 = {10, 12, 10, 15, -1, 7, 6, 5, 4, 2, 1, 1, 1};
            Console.WriteLine(CountNumOfPairs(arr3, 11));
            
            int[] arr4 = {10, 10};
            Console.WriteLine(CountNumOfPairs(arr4, 20));
            
            int[] arr5 = {10, 11, 10};
            Console.WriteLine(CountNumOfPairs(arr5, 21));
        }

        public static int countPairsWithSum(int[] arr, int sum)
        {
            Hashtable hashrecords = new Hashtable();
            int count = 0;
            int diff = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                diff = sum - arr[i];
                if (hashrecords.Contains(diff))
                {
                    count += Convert.ToInt32(hashrecords[diff]);
                }

                if (hashrecords.Contains(arr[i]))
                    hashrecords[arr[i]] = Convert.ToInt32(hashrecords[arr[i]]) + 1;
                else
                    hashrecords[arr[i]] = 1;
            }

            return count;
        }

        public static int CountNumOfPairs(int[] arr, int sum)
        {
            // return countPairsWithSum(arr, sum);
            var dict = new Dictionary<int, int>();

            int count = 0;
            for (var idx = 0; idx < arr.Length; idx++)
            {
                int num = sum - arr[idx];
                if (dict.ContainsKey(num))
                {
                    count += dict[num];
                }

                if (dict.ContainsKey(arr[idx]))
                {
                    dict[arr[idx]] += 1;
                }
                else
                {
                    dict[arr[idx]] = 1;
                }
            }

            return count;
        }
    }
}