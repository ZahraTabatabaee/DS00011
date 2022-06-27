using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q2IsItBST : Processor
    {
        public Q2IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            List<long> key = new List<long>();
            List<long> left = new List<long>();
            List<long> right = new List<long>();
            for (int i = 0; i < nodes.Length; i++)
            {
                key.Add(nodes[i][0]);
                left.Add(nodes[i][1]);
                right.Add(nodes[i][2]);
            }
            List<long> result = new List<long>();
            List<long> Sorted = new List<long>();
            result = inorder(key,left,right);
            for (int i = 0; i < result.Count; i++)
            {
                Sorted.Add(result[i]);
            }
            Sorted.Sort();
            var a = Sorted.SequenceEqual(result);
            return a;
        }
        public List<long> inorder(List<long> key, List<long> left, List<long> right)
        {
            Stack<long> nodes = new Stack<long>(); 
            long current = 0; 
            List<long> result = new List<long>();
            while (nodes.Count!=0 || current != -1) 
            { 
                if (current != -1) 
                { 
                    nodes.Push(current);
                    current = left[(int)current]; 
                } 
                else 
                { 
                    long node = nodes.Pop(); 
                    result.Add(key[(int)node]);
                    current = right[(int)node]; 
                } 
            }
            return result;
        }
    }
}
