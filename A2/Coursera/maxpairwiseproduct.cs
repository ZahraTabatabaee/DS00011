using System;
using System.Collections.Generic;

namespace maxpairwiseproduct
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberCount = Console.ReadLine();
            var numbers = Console.ReadLine();

            var numberArray = numbers.Split(' ');

            List<long> numberList = new List<long>();
            foreach (var number in numberArray)
                numberList.Add(long.Parse(number));


            // I implemented this loop to sort my list. But it was slow and failed the test on Coursera.
            // 
            // for (int i = 0; i < numberList.Count; i++)
            //     for (int j = i + 1; j < numberList.Count; j++)
            //         if (numberList[i] < numberList[j])
            //         {
            //             var temp = numberList[i];
            //             numberList[i] = numberList[j];
            //             numberList[j] = temp;
            //         }

            // Console.WriteLine(numberList[0] * numberList[1]);

            long firstMax = 0;
            foreach (var number in numberList)
                if (number > firstMax)
                    firstMax = number;

            numberList.Remove(firstMax);

            long secondMax = 0;
            foreach (var number in numberList)
                if (number > secondMax)
                    secondMax = number;

            System.Console.WriteLine(firstMax * secondMax);
        }
    }
}
