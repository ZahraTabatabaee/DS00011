using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C9
{
    public class Q1Median : Processor
    {
        public Q1Median(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ1Median(inStr, Solve);
        

        public String Solve(long n,long[] arr)
        {
            double[] res = new double[n];
            // -------------------
            // your code here
            // -------------------
            var ans = res.Select(x => String.Format("{0:0.0}", x));
            return String.Join('\n',ans);
        }
    }
}
