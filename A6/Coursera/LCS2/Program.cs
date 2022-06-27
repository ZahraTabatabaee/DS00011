using System;

namespace LCS2
{
    class Program
    {
        public static long Solve(long[] seq1, long[] seq2)
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
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string str1 = Console.ReadLine();
            string num2 = Console.ReadLine();
            string str2 = Console.ReadLine();
            long[] a = Array.ConvertAll(str1.Split(), Convert.ToInt64);
            long[] b = Array.ConvertAll(str2.Split(), Convert.ToInt64);
            System.Console.WriteLine(Solve(a,b));
        }
    }
}
