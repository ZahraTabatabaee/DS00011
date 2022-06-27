using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
// using Priority_Queue;
using TestCommon;

namespace C9
{
    public class Q2Snakes : Processor
    {
        public Q2Snakes(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ2Snakes(inStr, Solve);
        
        public class Cell
        {
            public int v = 0;
            public int count = 0;
        }

        static int snakesDicecount(long[] move)
        {
            bool[] isVisited = new bool[100];
            bool isPossible = false;
            isVisited[0] = true;
            Queue<Cell> q = new Queue<Cell>();
            Cell qe = new Cell();
            q.Enqueue(qe);
            while(q.Count != 0)
            {
                qe = q.Dequeue(); 
                int v = qe.v;
                if (v == 99) 
                { 
                    isPossible = true; 
                    break;
                }
                for (int j = v + 1; j < (v + 7) && j < 100; j++)
                {
                    if (!isVisited[j])
                    {
                        Cell newcell = new Cell();
                        newcell.count = (qe.count + 1);
                        isVisited[j] = true;
                        if (move[j] == -1)
                        {
                            newcell.v = j;
                            q.Enqueue(newcell);
                            continue;
                        }
                        newcell.v = (int)move[j];
                        q.Enqueue(newcell);
                    }
                }
            }
            if(!isPossible) 
                return -1;
            return qe.count;
        }

        public long Solve(long n,long[][] ladders, long m,long[][] snakes)
        {
            long[] moves = new long[100];
            for(int i = 0; i < 100; i++)
                moves[i] = -1;
            for(int i = 0; i < n; i++)
            {
                long x = ladders[i][0];
                moves[(int)x - 1] = ladders[i][1] - 1;
            }
            for(int i = 0; i < m; i++)
            {
                long x = snakes[i][0];
                moves[(int)x - 1] = snakes[i][1] - 1;
            }
            return snakesDicecount(moves);
        }
    }
}
