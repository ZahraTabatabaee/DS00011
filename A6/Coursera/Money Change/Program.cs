using System;

namespace Money_Change
{
    class Program
    {
        public static long Solve(long n)
        {
            long[] Coins = new long[3]{1,3,4};
            long[] MinNumCoins = new long[(int)n+1];
            MinNumCoins[0] = 0;
            long NumCoins = 0 ;
            for (int i = 1; i <= (int)n; i++)
            {
                MinNumCoins[i] = long.MaxValue ;
                for (int j = 0; j < Coins.Length; j++)
                {
                    if (i >= Coins[j])
                    {
                        NumCoins = MinNumCoins[i-Coins[j]] +1 ;
                        if (NumCoins < MinNumCoins[i])
                            MinNumCoins[i] = NumCoins ;
                    }
                }
            }
            return MinNumCoins[n];


        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(Solve(int.Parse(Console.ReadLine())));
        }
    }
}
