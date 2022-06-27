using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;
using System.Collections;

namespace C1
{
    public class Q1 : Processor
    {
        public Q1(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long x = first[1];
            long [] a = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, a, x).ToString();
        }

        public long Solve(long n, long[] a, long x)
        {
            long sum = 0 ;
            int s = 0 ;
            long count = 0 ;
            Array.Sort(a);
            Array.Reverse(a);
            List<long> MyList = a.ToList();
            while (MyList.Count > 0 && MyList[s] >= x )
            {
                sum += (MyList[s]-x);
                count++;
                MyList.Remove(MyList[s]);
                // s++ ;
            }
            int size = MyList.Count() ;
            for (int i = 0; i < size && sum >= 0; i++)
            {
                sum -= (x-MyList[i]);
                if(sum >= 0)
                    count++;
            }
            return count ;
        }
    }
}
