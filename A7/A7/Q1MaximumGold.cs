using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            long SizeA = goldBars.Length ;
            long[,] DP = new long[SizeA+1, W+1];
            for (int i = 0; i < SizeA+1 ; i++)
            {
                for (int j = 0; j < W+1 ; j++){
                    if (i == 0 || j == 0)
                        DP[i, j] = 0;
                    else if (goldBars[i-1] <= j)
                        DP[i, j] = Math.Max(goldBars[i - 1]+DP[i-1,j - goldBars[i-1]], DP[i-1,j]);
                    else
                        DP[i, j] = DP[i-1,j];
                }
            }            
            return DP[SizeA, W];
        }
    }
}
