using System;

namespace ArrayApplication
{
    class MyArray
    {
        public static void Run(string[] args)
        {
            int[] n = new int[10];
            int i, j;

            /* 初始化数组 */
            for (i = 0; i < n.Length; i++)
            {
                n[i] = i + 1;
            }

            /* 输出数组 */
            for (j = 0; j < n.Length; j++)
            {
                Console.WriteLine("n[{0}] = {1}", j, n[j]);
            }
        }
    }
}