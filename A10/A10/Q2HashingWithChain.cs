using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        protected List<string>[] hashtable;
        public const long ChosenX = 263;
        public static long bucketCounts = 0;
        public string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            hashtable = new List<string>[bucketCount];
            bucketCounts = bucketCount;
            for (int i = 0; i < hashtable.Length; i++)
            {
                hashtable[i] = new List<string>();
            }
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;

        public static long PolyHash(
            string str, int start, long count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length-1; i >= 0; i--)
            {
                hash = ((hash*x)+str[i])%p;
            }
            return hash % bucketCounts;
        }

        public void Add(string str)
        {
            long hashed = PolyHash(str, 0, bucketCounts);
            if(hashtable[hashed].Contains(str))
                return;
            hashtable[hashed].Add(str);
        }

        public string Find(string str)
        {
            long hashed = PolyHash(str, 0, bucketCounts);
            if(hashtable[hashed].Contains(str))
                return "yes";
            return "no";
        }

        public void Delete(string str)
        {
            long hashed = PolyHash(str, 0, bucketCounts);
            if(hashtable[hashed].Contains(str))
                hashtable[hashed].Remove(str);
        }

        public string Check(int i)
        {
            string result = "";
            if(hashtable[i].Count == 0)
                return "-";
            for (int j = hashtable[i].Count -1; j >= 0; j--)
            {
                result += hashtable[i][j] + " ";
            }
            return result.TrimEnd();

        }
    }
}
