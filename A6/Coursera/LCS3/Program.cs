using System;

namespace LCS3
{
    class Program
    {
        public static long Solve(long[] seq1, long[] seq2, long[] seq3)
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
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string str1 = Console.ReadLine();
            string num2 = Console.ReadLine();
            string str2 = Console.ReadLine();
            string num3 = Console.ReadLine();
            string str3 = Console.ReadLine();
            long[] a = Array.ConvertAll(str1.Split(), Convert.ToInt64);
            long[] b = Array.ConvertAll(str2.Split(), Convert.ToInt64);
            long[] c = Array.ConvertAll(str3.Split(), Convert.ToInt64);

            System.Console.WriteLine(Solve(a,b,c));
        }
    }
}
