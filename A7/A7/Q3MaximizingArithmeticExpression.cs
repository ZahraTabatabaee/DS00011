using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            List<long> nums = new List<long>();
            List<char> Op = new List<char>();
            for (var i = 0; i < expression.Length ; i++)
            {
                if(expression[i] == '+' || expression[i] == '-' || expression[i] == '*')
                    Op.Add((expression[i]));
                else
                {
                    char c = expression[i];
                    nums.Add(Int32.Parse(c.ToString()));
                }
            }
            long[] a = nums.ToArray();
            char[] b = Op.ToArray();
            return Parenthesis(a,b);
        }
        public static Tuple<long,long> MinAndMax(long[,] M , long[,] m , char[] op , int i , int j) {
            long min = long.MaxValue ;
            long max = long.MinValue ;
            long a,b,c,d ;
            for(int k = i ; k <= j-1 ; k++)
            {
                a = eval(M[i,k], M[k+1,j] , op[k-1]);
                b = eval(M[i,k], m[k+1,j] , op[k-1]);
                c = eval(m[i,k], M[k+1,j] , op[k-1]);
                d = eval(m[i,k], m[k+1,j] , op[k-1]);
                min = Math.Min(Math.Min(Math.Min(a,b),Math.Min(c,d)),min);
                max = Math.Max(Math.Max(Math.Max(a,b),Math.Max(c,d)),max);
            }
            return new Tuple<long, long>(min, max);
            }
        public static long Parenthesis(long[] nums, char[] Op)
        {
            long[,] m = new long[nums.Length+1,nums.Length+1];
            long[,] M = new long[nums.Length+1,nums.Length+1];
            for(int i = 1 ; i <= nums.Length ; i++)
            {
                m[i,i] = nums[i-1];
                M[i,i] = nums[i-1];
            }
            int j;
            for(int s=1 ; s <= nums.Length-1 ; s++)
            {
                for(int i = 1 ; i <= nums.Length -s ; i++)
                {
                    j = i + s ;
                    Tuple<long, long> t = MinAndMax(M,m,Op,i,j);
                    m[i,j] = t.Item1;
                    M[i,j] = t.Item2;        
                }
            }
            return M[1,nums.Length];
        }
        public static long eval(long a, long b, char op) {
            if (op == '+') {
                return a + b;
            } 
            else if (op == '-') {
                return a - b;
            } 
            else if (op == '*') {
                return a * b;
            } 
            else {
                return 0;
            }
    }
    }
}
