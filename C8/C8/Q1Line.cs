using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C8
{
	public class Q1Line : Processor
	{
		public Q1Line(string testDataName) : base(testDataName) {}

		public override string Process(string inStr) => C8Processors.ProcessQ1Line(inStr, Solve);
		public bool Same(long x1,long y1,long x2,long y2){
			if(x1==x2 && y1==y2) return true;
			return false;
		}
		public string Solve(long n, long[][] p)
		{
			int count = 0 ;
			double shib = 0 ;
			if (n < 2)
    			return n.ToString();
			for (int i = 0; i < n; i++)
			{
				int localmax = 0;
				int same = 1;
				int amud = 1;
				Dictionary<double,int> line = new Dictionary<double,int>();
				for (int j = i+1; j < n; j++)
				{
					shib = (double)(p[i][1] - p[j][1]) / (p[i][0] - p[j][0]);
					if (Same(p[i][0],p[i][1],p[j][0],p[j][1])) 
						same++;
					else if (p[i][0] == p[j][0]) 
						amud++;
					else {
						if(!line.ContainsKey(shib))
							line[shib] = 1 ;
						else
							line[shib] = line[shib] + 1;
					}
				}
				foreach (var item in line.Keys)
					localmax = Math.Max(line[item], localmax);
				count = Math.Max(amud, Math.Max(localmax + same, count));
			}
			return count.ToString();
		}
	}
}
