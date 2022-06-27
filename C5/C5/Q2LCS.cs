using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C5
{
    public class Q2LCS : Processor
    {
        public Q2LCS(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);


        public static long Solve(string a, string b)
        {
            long count = 0;
            long SizeA = a.Length;
            long SizeB = b.Length;
            long[,] dp1 = new long[SizeA + 2, SizeB + 2];
            long[,] dp2 = new long[SizeA + 2, SizeB + 2];
            for (int i = 1; i < SizeA + 1; i++){
                for (int j = 1; j < SizeB + 1; j++){
                    if (a[i - 1] == b[j - 1])
                        dp1[i, j] = dp1[i - 1, j - 1] +1 ;
                    else
                        dp1[i, j] = Math.Max(dp1[i - 1, j], dp1[i, j - 1]);
                }
            }
            long LCS1 = dp1[SizeA, SizeB];
            for (int i = (int)SizeA; i >= 1; i--){
                for (int j = (int)SizeB; j >= 1; j--){
                    if ((a[i-1] == b[j- 1]))
                        dp2[i, j] = 1 + dp2[i + 1, j + 1];
                    else
                        dp2[i, j] = Math.Max(dp2[i + 1, j], dp2[i, j+1]);
                }
            }
            
            for (int i = 0; i < SizeA + 1; i++)
            {
                List<char> Result = new List<char>();
                for (int j = 1; j < SizeB + 1; j++)
                {
                    if (dp1[i, j - 1] + dp2[i+1, j + 1] == LCS1 && !Result.Contains(b[j-1]))
                    {
                        Result.Add(b[j - 1]);
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
