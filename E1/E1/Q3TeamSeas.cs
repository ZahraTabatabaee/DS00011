using System;
using System.Collections.Generic;
using TestCommon;

namespace E1
{
    public class Q3TeamSeas : Processor
    {
        public Q3TeamSeas(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ3TeamSeas(inStr, Solve);

        public long Solve(long n, long m, long[] g, long[] c, long[] b, long[] p, long[] s)
        {
            List<double[][]> array = new List<double[][]>();
            double[][] T1 = new double[n][];
            for (int i = 0; i < n; i++)
            {
                T1[0] = new double[]{b[i],(double)c[i]/(double)b[i]};
                T1[1] = new double[]{p[i],(double)s[i]/(double)p[i]};
                array.Add(T1);
            }
            return 0;
        }
    }
}
