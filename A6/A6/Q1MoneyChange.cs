using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { 
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
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
    }
}
