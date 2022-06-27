using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {

            long SizeA = str1.Length ;
            long SizeB = str2.Length ;
            long[,] DP = new long[SizeA+1, SizeB+1];
            for (int i = 0; i < SizeA+1 ; i++)
            {
                for (int j = 0; j < SizeB+1 ; j++){
                    if (i == 0)
                        DP[i, j] = j;
                    else if (j == 0)
                        DP[i, j] = i;
                    else if (str1[i - 1] == str2[j - 1])
                        DP[i, j] = DP[i - 1, j - 1] ;
                    else
                        DP[i, j] = 1 + Math.Min(Math.Min(DP[i - 1, j], DP[i, j - 1]), DP[i-1,j-1]);
                }
            }            
            return DP[SizeA, SizeB];
        }
    }
}
