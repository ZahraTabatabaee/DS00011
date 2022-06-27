using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);
        public bool Solve(long[][] nodes)
        {
            return isBST(nodes, nodes[0] , long.MinValue, long.MaxValue);
        }

        public bool isBST(long[][] nodes, long[] vs, long minValue, long maxValue)
        {
            if(vs.Length == 0)
                return true;
            if(vs[0]<minValue || vs[0]>=maxValue)
                return false;
            if((vs[1]!= -1 && !isBST(nodes,nodes[vs[1]],minValue,vs[0]) )||(vs[2]!= -1 && !isBST(nodes,nodes[vs[2]],vs[0],maxValue)))
                return false;
            return true;
        }

    }
}
