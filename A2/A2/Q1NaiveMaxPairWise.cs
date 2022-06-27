using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q1NaiveMaxPairWise : Processor
    {
        public Q1NaiveMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s))
                .ToArray()).ToString();

        public virtual long Solve(long[] numberList){
            for (int i = 0; i < numberList.Length; i++)
                for (int j = i + 1; j < numberList.Length; j++)
                    if (numberList[i] < numberList[j])
                    {
                        var temp = numberList[i];
                        numberList[i] = numberList[j];
                        numberList[j] = temp;
                    }
            return (numberList[0] * numberList[1]);
        }
    }
}

