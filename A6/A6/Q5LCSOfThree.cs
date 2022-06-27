using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            long SizeA = seq1.Length ;
            long SizeB = seq2.Length ;
            long SizeC = seq3.Length ;
            long[,,] DP = new long[SizeA+1, SizeB+1, SizeC+1];
            for (int i = 0; i < SizeA+1 ; i++)
            {
                for (int j = 0; j < SizeB+1 ; j++){
                    for (int k = 0; k < SizeC+1; k++)
                    {
                        if (i == 0 || j == 0 || k == 0)
                            DP[i, j, k] = 0;
                        else if (seq1[i - 1] == seq2[j - 1] && seq1[i-1] == seq3[k-1])
                            DP[i, j, k] = DP[i - 1, j - 1, k-1] + 1 ;
                        else
                            DP[i, j, k] = Math.Max(Math.Max(DP[i - 1, j, k], DP[i, j - 1, k]),DP[i, j, k-1]);
                        
                    }
                }
            }            
            return DP[SizeA, SizeB, SizeC];
        }
    }
}
