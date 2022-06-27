using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C6
{
    public class Q2Truck : Processor
    {
        public Q2Truck(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C6Processors.ProcessQ2Truck(inStr, Solve);
        

        public long Solve(long n ,long[] petr ,long[] dist)
        {
            long PSum = 0 ; long DSum = 0 ;
            long min = long.MaxValue ;
            long way = 0 ; long  idx = 0 ;
            for(int i = 0 ; i < n ; i++)
            {
                PSum += petr[i] ; DSum += dist[i] ;
                way += (petr[i] - dist[i]);
                if(way<min)
                {
                    min = way;
                    idx = i+1 ;
                }
            }  
            if(PSum < DSum) return -1;
            return idx;          

        }
    }
}
