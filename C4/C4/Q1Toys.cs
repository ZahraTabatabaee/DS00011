using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q1Toys : Processor
    {
        public Q1Toys(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long [] arr = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, arr).ToString();
        }
        public static long Solve(long a, long[] arr)
        {
            Array.Reverse(arr);
            long[] dp = new long[a];
            dp[0] = (arr[0]);
            dp[1] = (arr[1]+arr[0]);
            dp[2] = (arr[0]+arr[1]+arr[2]);
            int idx = 3 ;
            long sum = arr[0]+arr[1]+arr[2] ;
            while (idx<a)
            {
                long x1 = arr[idx] + sum - dp[idx-1];
                long x2 = arr[idx] + sum - dp[idx-2];
                long x3 = arr[idx] + sum - dp[idx-3];
                long max = Math.Max(x1, Math.Max(x2,x3));
                dp[idx] = (max);
                sum += arr[idx];
                idx++;
            }
            int count = dp.Length ;
            return dp[count-1];  
        }
    }
}
