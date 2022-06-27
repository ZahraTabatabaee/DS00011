using System;
using TestCommon;

namespace E1
{
    public class Q2Cars : Processor
    {
        public Q2Cars(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ2Cars(inStr, Solve);

        public double Solve(long aX, long aY, long bX, long bY, long cX, long cY, long dX, long dY)
        {
            double xmid1 = (double)(aX+(bX-aX)/2) ;
            double ymid1 =  (double)(aY+(bY-aY)/2) ;
            double xmid2 = (double)(cX+(dX-cX)/2 );
            double ymid2 = (double)(cY+(dY-cY)/2) ;
            double ADist = Math.Sqrt((Math.Pow(aX - cX, 2) + Math.Pow(aY - cY, 2)));
            double CDist = Math.Sqrt((Math.Pow(bX - dX, 2) + Math.Pow(bY - dY, 2)));
            double MidDist = Math.Sqrt((Math.Pow((double)(aX+(bX-aX)/2)-(double)(cX+(dX-cX)/2 ), 2) + Math.Pow((double)(aY+(bY-aY)/2) - (double)(cY+(dY-cY)/2), 2)));
            if(MidDist - ADist < 0.000001 || MidDist - CDist < 0.000001 )
                return Math.Min(Math.Min(ADist, CDist),MidDist);
            if(CDist>MidDist)
                return Solve(aX,aY,(long)xmid1,(long)ymid1,cX,cY,(long)xmid2,(long)ymid2);
            return Solve((long)xmid1,(long)ymid1,bX,bY,(long)xmid2,(long)ymid2,dX,dY);
        }
        public static double dist(double a, double b)
        {
            return Math.Abs(a*a - b*b);
        }
    }
}
