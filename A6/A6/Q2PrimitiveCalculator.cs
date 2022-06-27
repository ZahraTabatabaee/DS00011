using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public long[] Solve(long n)
        {
            int[] result = new int[n + 1];
            for (int i = 1; i < result.Length; i++) 
            {
                int tmp1 = result[i-1] ;
                int tmp2 = i+1 ;
                int tmp3 = i+1 ;
                if(i % 3 == 0)
                    tmp3 = result[i/3];
                if(i % 2 == 0)
                    tmp2 = result[i/2];
                result[i] = Math.Min(tmp1, Math.Min(tmp2, tmp3)) + 1;
            }

            List<long> nums = new List<long>();
            while (n>1) 
            {
                nums.Add(n);
                if (n % 3 == 0 && result[n]-1 == result[n/3])
                {
                    n /= 3;
                }
                
                else if (n % 2 == 0 && result[n]-1 == result[n/2])
                {
                    n /= 2;
                }
                
                else
                {
                    n-= 1;
                }
            }
            nums.Add(1);
            long[] reversenum = new long[nums.Count];
            reversenum = nums.ToArray();
            Array.Reverse(reversenum);
            return reversenum;
        }
    }
}
