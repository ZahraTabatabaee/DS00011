using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q1Reverse : Processor
    {
        public Q1Reverse(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ1Reverse(inStr, Solve);

        public LinkedList<long> Solve(long n, LinkedList<long> list)
        {
            LinkedList<long> result = new LinkedList<long>();
            Stack<Node<long>> stack = new Stack<Node<long>>();
            Node<long> head = list.Head;
            while(head != null)
            {
                stack.Push(head);
                head = head.Next;
            }
            while (stack.Count != 0)
            {
                result.AddLast(stack.Pop().Value);
            }
            return result;
        }

    }
}
