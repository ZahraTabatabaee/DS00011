using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public class Table {
            public Table parent;
            public long rank;
            public long info;

            public Table(int info,long rank) {
                this.info = info;
                this.rank = rank;
                parent = this;
            }
            public static Table getParent(Table t) {
                while (t.parent != t)
                {
                    t = t.parent;
                }
                return t;
            }
        }
        public static long merge(Table destination, Table source) {
            Table realDestination = Table.getParent(destination);
            Table realSource = Table.getParent(source);
            if (realDestination != realSource) {
                source.parent = realDestination.parent;
                realSource.parent = realDestination.parent;
                destination.rank = realSource.rank + realDestination.rank ;
                source.rank = destination.rank ;
                realDestination.rank = destination.rank;
                realSource.rank = destination.rank ;
                // destination.rank = superparentd.rank;
                // superparents = superparentd;
                // superparentd.rank += superparents.rank;
                // superparents.rank = superparentd.rank;
                // destination.rank = superparentd.rank;
            }
            return destination.rank;
        }
        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        { 
            List<long> result = new List<long>();
            long max = tableSizes.Max();
            List<Table> resultTables = new List<Table>();
            for(int i = 1 ; i <= tableSizes.Length ; i++)
            {
                resultTables.Add(new Table(i,tableSizes[i-1]));
            }
            for(int i = 0 ; i < targetTables.Length; i++)
            {
                long target = targetTables[i];
                long source = sourceTables[i];
                long m = merge(resultTables[(int)target-1],resultTables[(int)source-1]);
                if(m > max)
                    max = m ;
                result.Add(max);
            }
            return result.ToArray();
        }

    }
}
