using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C3
{
    public class Q1Array : Processor
    {
        public Q1Array(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long[], long>)Solve);
        public static long Solve(long n, long[] a)
        {
            return MaxSum(0,n-1,a);
        }
        public static long MaxSum(long l , long r , long[] a)
        {
            if(l>=r)
                return a[l];
            long mid = Convert.ToInt64((l+r)/2);
            long x = MaxSum(l,mid,a);
            long y = MaxSum(mid+1,r,a);

            long SumR = 0;
            long MaxR = 0;
            for (int i = Convert.ToInt32(mid+1); i <= r; i++)
            {
                SumR += a[i];
                MaxR = Math.Max(MaxR, SumR);
            }

            long SumL = 0;
            long MaxL = 0;
            for (int i = Convert.ToInt32(mid); i >= l; i--)
            {
                SumL += a[i];
                MaxL = Math.Max(MaxL, SumL);
            }

            long z = MaxL + MaxR ;
            return Math.Max(x,Math.Max(y,z));
        }
    }
}
