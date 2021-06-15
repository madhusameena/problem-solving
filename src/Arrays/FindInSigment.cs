using System;

namespace CSharpProblemSolving.Arrays
{
    // https://www.geeksforgeeks.org/check-if-a-key-is-present-in-every-segment-of-size-k-in-an-array/
    public static class FindInSigment
    {
        public static void Samples()
        {
            // SAmple 1
            int[] array = {3, 5, 2, 4, 9, 3, 1, 7, 3, 11, 12, 3};
            int x = 3;
            int k = 3;
            Console.WriteLine($"1 ans = {Solve(array, x, k)}");
            int[] array1 = { 21, 23, 56, 65, 34, 54, 76, 32, 23, 45, 21, 23, 25};
            x = 23;
            k = 5;
            Console.WriteLine($"2 ans = {Solve(array1, x, k)}");
            
            int[] array2 = { 5, 8, 7, 12, 14, 3, 9};
            x = 8;
            k = 2;
            Console.WriteLine($"3 ans = {Solve(array2, x, k)}");
        }

        public static string Solve(int[] array, int x, int k)
        {
            int count = 0;
            int remainging = array.Length % k == 0 ? k : array.Length % k;
            for (var idx = 0; idx < array.Length; idx++)
            {
                if (array[idx] == x)
                {
                    count++;
                }

                if ((idx + 1) % k == 0)
                {
                    if (count == 0)
                    {
                        return "No";
                    }

                    count = 0;
                }

                if (remainging != k && idx == array.Length - 1)
                {
                    return count > 0 ? "Yes" : "No";
                }
            }
            return "Yes";
        }
    }
}