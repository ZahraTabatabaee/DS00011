using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s))
                .ToArray()).ToString();

        public virtual long Solve(long[] numberList)
        {
            List<long> list = new List<long>();
            list = numberList.ToList();
            long firstMax = 0;
            foreach (var number in list)
                if (number > firstMax)
                    firstMax = number;
            list.Remove(firstMax);
            long secondMax = 0;
            foreach (var number in list)
                if (number > secondMax)
                    secondMax = number;

            return(firstMax * secondMax);
        }
    }
}
