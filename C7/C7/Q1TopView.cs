using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C7
{
    public class Q1TopView : Processor
    {
        public Q1TopView(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ1TopView(inStr, Solve);
        

        public string Solve(long n, BinarySearchTree tree)
        {
            SortedDictionary<long,Node> result = new SortedDictionary<long,Node>();
            Queue<Node> queue = new Queue<Node>();
            Node root = tree.root;
            queue.Enqueue(root);
            long level = 0 ;
            long h = 0 ;
            long qcount = 0 ;
            while (queue.Count() != 0)
            {
                Node node = queue.Dequeue();
                level = node.level;
                h = node.index; 
                qcount = queue.Count();
                if(!result.ContainsKey(h))
                    result[h] = node ;
                else
                {
                    if(result[h].level > node.level)
                        result[h] = node ;
                }
                if(node.left != null)
                {
                    node.left.index = h-1;
                    node.left.level = level + 1;
                    queue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    node.right.index = h+1;
                    node.right.level = level + 1;
                    queue.Enqueue(node.right);
                }
            }
            string StrResult = "" ;
            foreach(var i in result)
            {
                StrResult += i.Value.info.ToString() + " ";
            } 
            return StrResult;
        }
    }
}
