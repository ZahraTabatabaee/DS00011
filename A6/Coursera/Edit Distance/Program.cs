using System;

namespace Edit_Distance
{
    class Program
    {
        public static long Solve(string str1, string str2)
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
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            System.Console.WriteLine(Solve(str1,str2));
        }
    }
}
