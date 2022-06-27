using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2DPitioningSouvenirs : Processor
    {
        public Q2DPitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long sum = souvenirs.Sum();
            if(sum < 3 || sum%3 !=0)
                return 0;
            long w = (int)(sum/3);
            long[,] DP = new long[w + 1, souvenirsCount+1];
            long count = 0;
            for (int i = 1; i < w+1 ; i++)
            {
                for (int j = 1; j < souvenirsCount ; j++){
                    DP[i,j] = DP[i,j-1] ;
                    if (souvenirs[j-1]<=i)
                    {
                        long temp = DP[i-souvenirs[j-1],j-1] + souvenirs[j-1] ;
                        if (temp > DP[i,j])
                            DP[i,j] = temp ;
                    }
                    if (DP[i,j] == w)
                        count += 1;
                }
            }  
            if(count!=0)
                return 1;
            return 0 ;
        }
    }
}
