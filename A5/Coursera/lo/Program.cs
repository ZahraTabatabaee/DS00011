using System;
using System.Collections.Generic;
using System.Collections;
namespace lo
{
    class Program
    {
        // class segment{
        //     public long n {get; set;}
        //     public bool isEnd {get; set;}
        //     public segment(long N, bool IsEnd){
        //         n = N; isEnd = IsEnd;
        //     }

        // }
        // 3 6 8 12 14 30
        // for mid-1 0 
        static long BinarySearch(long[] Array, long low, long high , long key)
        {
            if (high<low){
                    return high;
            }
            int mid = (int)(low + (high-low)/2) ;
            if(key==Array[mid])
                return mid;
            // if(key==Array[mid])
            //     for(mid +1 => len-1)
            //         if(array i != array mid) break;
            //             mid++;
            //     return mid;
            else if(key < Array[mid])
                return BinarySearch(Array,low,mid-1,key);
            else
                return BinarySearch(Array,mid+1,high,key);
        }
        static long[] lottery(long[] starts,long[] ends, long[] point){
            long[] result = new long[point.Length];
            for (int i = 0; i < point.Length; i++){
                long startidx = BinarySearch(starts, 0, starts.Length-1, point[i]);
                long endidx = BinarySearch(ends, 0, ends.Length-1, point[i]);
                result[i] = startidx-endidx;
            }
            return result;
        }
        static long[] Solve(long[] points, long[] startSegment, long[] endSegment)
        {
            Array.Sort(startSegment); Array.Sort(endSegment);
            // int j = 2 * startSegment.Length; int i=0;
            // segment[] segments = new segment[j];
            // for(int k=0; k<(j/2); k++){
            //     segments[i] = new segment(startSegment[k], false);
            //     segments[i+1] = new segment(endSegment[k], true);
            //     i+=2;
            // }
            //Array.Sort(segments,  delegate(segment x, segment y) { return (x.n).CompareTo(y.n);});
            return lottery(startSegment,endSegment, points);
        }
        static void Main(string[] args)
        {
            long[] point = {4, 7, 2};
            long[] s = {1, 0, 7, 6};
            long[] e = {3, 5, 23, 12};
            long[] result = Solve(point, s, e);
            foreach (var i in result)
            Console.WriteLine(i);
        }
    }
}
