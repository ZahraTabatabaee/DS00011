using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q3ParallelProcessing : Processor
    {
        public Q3ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            List<Tuple<long, long>> result = new List<Tuple<long, long>>();
            List<long[]> tree = new List<long[]>();
            for (int i = 0; i < threadCount; i++)
                tree.Add(new long[]{i,0});
            for (int i = 0; i < jobDuration.Length ; i++)
            {
                result.Add(Tuple.Create(tree[0][0],tree[0][1]));
                tree[0][1] += jobDuration[i];
                siftdown(tree);
            }
            return result.ToArray();
        }
        public void siftdown(List<long[]> array)
        {
            long i = 0 ;
            while (i<= (int)((array.Count-2)/2))
            {
                long minindex = i ;
                int size = array.Count;
                long left = 2*i+1;
                if(left < size )
                {
                    if(array[(int)left][1] < array[(int)minindex][1])
                        minindex = left;
                    else if(array[(int)left][1] == array[(int)minindex][1])
                    {
                        if(array[(int)left][0] < array[(int)minindex][0])
                            minindex = left;
                    }
                }
                long right = 2*i+2;
                if(right < size )
                {
                    if(array[(int)right][1] < array[(int)minindex][1])
                        minindex = right;
                    else if(array[(int)right][1] == array[(int)minindex][1])
                    {
                        if(array[(int)right][0] < array[(int)minindex][0])
                            minindex = right;
                    }
                }
                if(i != minindex)
                {
                    long[] temp = array[(int)i];
                    array[(int)i] = array[(int)minindex];
                    array[(int)minindex] = temp ;
                    i = minindex;
                }
                else
                    break;
    
            }
        }
    }
}
