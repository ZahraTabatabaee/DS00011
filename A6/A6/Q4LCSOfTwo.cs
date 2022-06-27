using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            long SizeA = seq1.Length ;
            long SizeB = seq2.Length ;
            long[,] DP = new long[SizeA+1, SizeB+1];
            for (int i = 0; i < SizeA+1 ; i++)
            {
                for (int j = 0; j < SizeB+1 ; j++){
                    if (i == 0 || j == 0)
                        DP[i, j] = 0;
                    else if (seq1[i - 1] == seq2[j - 1])
                        DP[i, j] = DP[i - 1, j - 1] + 1 ;
                    else
                        DP[i, j] = Math.Max(DP[i - 1, j], DP[i, j - 1]);
                }
            }            
            return DP[SizeA, SizeB];
        }
    }
}
