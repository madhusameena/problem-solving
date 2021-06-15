using System;

namespace CSharpProblemSolving.Arrays
{
    public static class MinMax
    {
        public static int Min(int[] array)
        {
            var min = array[0];
            for (var index = 1; index < array.Length; index++)
            {
                var i = array[index];
                min = Math.Min(min, i);
            }

            return min;
        }
        public static int Max(int[] array)
        {
            var max = array[0];
            for (var index = 1; index < array.Length; index++)
            {
                var i = array[index];
                max = Math.Max(max, i);
            }

            return max;
        }
    }
}