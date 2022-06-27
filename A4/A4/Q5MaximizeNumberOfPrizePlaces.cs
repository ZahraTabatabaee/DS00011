using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            List<long> result = new List<long>();
            if(n==1)
            {
                result.Add(1); 
                long[] b = result.ToArray();
                return b;
            }
            for(int i=1; n>0; i++){
                if(n-i>=0)
                    result.Add(i);
                else if(i>0)
                    result[i-2] += n;
                n-=i;
            }
            long[] a = result.ToArray();
            return a;

        }
    }
}

