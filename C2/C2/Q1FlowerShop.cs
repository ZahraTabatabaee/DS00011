using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q1FlowerShop : Processor
    {
        public Q1FlowerShop(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long b = first[1];
            long [] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, b, p).ToString();
        }
        static long Solve(long a, long b, long[] p)
        {
		int x = 1 ;
		long sum = 0 ;
		Array.Sort(p) ;
		Array.Reverse(p) ;
		int i = 0 ;
		while(i < p.Length)
		{
			for(int j = 0 ; (j < b) && (i < p.Length) ; j++,i++)
			{
				sum += p[i]*x ;
			}
			x += 1 ;
			
		}
		return sum ;
        }
    }
}
