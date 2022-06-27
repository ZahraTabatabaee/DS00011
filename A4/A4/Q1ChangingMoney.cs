using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
        {
            long count = 0;
            long ten = 0;
            long five = 0 ;
            if (money >= 10)
            {
                ten = money/10; 
                money -= ten*10 ;   
            }
            if(money >= 5)
            {
                five =money/5; 
                money -= five*5 ;          
            }
            count  = ten + five + money;
            return count ;              
        }
    }
}
