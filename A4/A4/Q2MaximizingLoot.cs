using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);



        public static long Solve(long capacity, long[] weights, long[] values)
        {
            double value = 0 ;
            int size = weights.Length;
            List<Tuple<double,long>> array = new List<Tuple<double, long>>();
            for (int i = 0; i < size; i++)
            {
                array.Add(new Tuple<double, long>((double)values[i]/(double)weights[i], weights[i]));
            }
            array = array.OrderByDescending(i => i.Item1).ToList();
            foreach (var item in array)
            {
                if(capacity==0)
                    return (long) value;
                if (item.Item2 <= capacity && capacity!=0 )
                {
                    value += (item.Item2 * item.Item1);
                    capacity -= item.Item2;
                }
                else
                {
                    value += (capacity * item.Item1);
                    break;
                }

            }
            return (long)value ;
        }

        // static long[,] JaggedSort(long[,] array)
        // {
        //     for (int i = 0; i < array.GetLength(0); i++)
        //     {
        //         for(int j=i; j<array.GetLength(0); j++)
        //         {
        //             if(array[i,0] < array[j,0]){
        //                 var tmp1 = array[i,0]; 
        //                 array[i,0] = array[j,0]; 
        //                 array[j,0] = tmp1;
        //                 var tmp2 = array[i,1]; 
        //                 array[i,1] = array[j,1]; 
        //                 array[j,1] = tmp2;
        //             }
        //         }
        //     }
        //     return array;
        // }


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
