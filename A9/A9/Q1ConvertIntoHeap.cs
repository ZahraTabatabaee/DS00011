using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] array)
        {
            int size = array.Length;
            int idx = 0;
            List<Tuple<long, long>> result = new List<Tuple<long, long>>();
            for (int i = size/2-1  ; i >= 0 ; i--)
            {
                siftdown(i,array,result,idx);
            }
            return result.ToArray();
        }

        public void siftdown(long i , long[] array, List<Tuple<long, long>> result, int idx)
        {
            long minindex = i ;
            int size = array.Length;
            long left = 2*i+1;
            if(left < size && array[left] < array[minindex])
                minindex = left;
            long right = 2*i+2;
            if(right < size && array[right] < array[minindex])
                minindex = right;
            if( i != minindex )
            {
                long temp = array[i];
                array[i] = array[minindex];
                array[minindex] = temp ;
                result.Add(new Tuple<long, long>(i,minindex));
                idx++;
                siftdown(minindex,array,result,idx);
            }
        }
    }
}
