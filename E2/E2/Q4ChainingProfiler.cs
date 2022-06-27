using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q4ChainingProfiler : Processor
    {
        public Q4ChainingProfiler(string testDataName) : base(testDataName)
        {
        }

        /// <summary>
        /// FNV-1a - (Fowler/Noll/Vo) is a fast, consistent, non-cryptographic hash algorithm with good dispersion. (see http://isthe.com/chongo/tech/comp/fnv/#FNV-1a)
        /// </summary>
        private static int GetFNV1aHashCode(string str, int bucketCount)
        {
            if (str == null)
                return 0;
            var length = str.Length;
            int hash = length;
            for (int i = 0; i != length; ++i)
                hash = (hash ^ str[i]) * 16777619;
            return (hash % bucketCount + bucketCount) % bucketCount;
        }

        public override string Process(string inStr) => E2Processors.ProcessQ4ChainingProfiler(inStr, Solve);

        // Returns:
        //      A Tuple:
        //          Item1 = Adjusted sample variance of the chain lengths
        //          Item2 = Hash table, a list of length bucketCount
        public Tuple<double, List<LinkedList<string>>> Solve(int n, int bucketCount, string[] s)
        {
            List<LinkedList<string>> hash = new List<LinkedList<string>>();
            for (int i = 0; i < n; i++)
            {
                int hashed = GetFNV1aHashCode(s[i], bucketCount);
                while (hash.Count <= hashed)
                {
                    hash.Add(new LinkedList<string>());
                }
                hash[hashed].AddLast(s[i]);
            }
            double sum = 0 ;
            foreach (var item in hash)
            {
                sum += getsize(item);
            }
            double average = (double)sum/(hash.Count);
            double sumdist = 0 ;
            foreach (var item in hash)
            {
                sumdist += Math.Pow(average - getsize(item),2);
            } 
            double varians = (double)sumdist/(hash.Count-1);
            Tuple<double, List<LinkedList<string>>> MyTuple = new Tuple<double, List<LinkedList<string>>>(varians,hash);
            return MyTuple;
        }
        public double getsize(LinkedList<string> a)
        {
            Node<string> temp = a.Head;
            double count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }
            return count;
        }
    }
}
