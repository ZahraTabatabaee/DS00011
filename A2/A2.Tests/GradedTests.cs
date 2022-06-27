using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestCommon;
using System.Diagnostics;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest(){
            Stopwatch s = new Stopwatch(); s.Start();
            while(s.ElapsedMilliseconds<500){
            Random rnd = new Random();
            int num = rnd.Next(2, 100);
            long[] array = new long[num];
            for(int i=0; i< array.Length; i++){
                array[i] = rnd.Next(2, 100);
            }
            Q1NaiveMaxPairWise Naive = new Q1NaiveMaxPairWise("TD2");
            Q2FastMaxPairWise Fast = new Q2FastMaxPairWise("TD2");
            if(Naive.Solve(array) != Fast.Solve(array)){
                Console.WriteLine("naiveAnswer={0}, fastAnswer={1}",Naive.Solve(array), Fast.Solve(array) );
            }
            }
            }
        

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}