using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbital_Mechanix_Suite
{
    class Lambert
    {
        private static double r1, r2, A, t;
        private static double mu = 132712440018;
        private static double d2r = Math.PI / 180;
        public static Vector3 Solver(Vector3 R1,Vector3 R2, double T,string str,string returnVel )
        {
            t = T * 23.9347 * 3600;
            R1 = new Vector3(R1.x * .001, R1.y * .001, R1.z * .001);
            R2 = new Vector3(R2.x * .001, R2.y * .001, R2.z * .001);
            r1 = R1.Magnitude();
            r2 = R2.Magnitude();
            Vector3 c12 = VectorMath.cross(R1, R2);
            double dotprod = VectorMath.dot(R1, R2);
            double theta = Math.Acos(VectorMath.dot(R1, R2) / r1 / r2);

            if (str == "pro")
            {
                if (c12.z<=0)
                {
                    theta = 2 * Math.PI - theta;
                }
            }
            else if(str =="retro")
            {
                if(c12.z>=0)
                {
                    theta = 2 * Math.PI - theta;
                }
            }
            A = Math.Sin(theta) * Math.Sqrt(r1 * r2 / (1 - Math.Cos(theta)));
            double Z = -100;
            while(FLessZero(Z))
            {
                Z = Z + .1;
            }
            double tol = 1E-5f;
            int nmax = 10000;
            double ratio = 2f;
            int n = 0;
            while (Math.Abs(ratio) > tol && n <= nmax)
            {
                n++;
                ratio = F(Z) /dFdz(Z);
                Z = Z - ratio;
            }
            if (n >= nmax)
            {
                Console.WriteLine(" number of iterations exceeded");
                return new Vector3(999, 999, 999);
            }
            double f = 1 - y(Z) / r1;
            double g = A * Math.Sqrt(y(Z) / mu);
            double gdot = 1 - y(Z) / r2;
            double og = 1/g;
            if (returnVel == "V2")
            {
                return new Vector3(og * (gdot * R2.x - R1.x), og * (gdot * R2.y - R1.y), og * (gdot * R2.z - R1.z));
            }
            else
            {
               Vector3 outVal = new Vector3(og * (R2.x - f * R1.x), og * (R2.y - f * R1.y), og * (R2.z - f * R1.z));
                return outVal;
            }
            /*
            Vector3 V1 =new Vector3(og*(R2.x-f*R1.x),og*(R2.y-f*R1.y),og*(R2.z-f*R1.z));
            
            Vector3 V2 = new Vector3(og * (gdot * R2.x - R1.x), og * (gdot * R2.y - R1.y), og * (gdot * R2.z - R1.z));
            Vector3[] Vout = new Vector3[2];
            Vout[0] = V1;
            Vout[1] = V2;
            return Vout;*/
        }
        private static double y(double z)
        {
            double dum = r1+r2+A*(z*S(z)-1)/Math.Sqrt(C(z));
            return dum;
        }
        private static bool FLessZero(double z)
        {
            int temp1 = -1;
            int temp2 = -1;
            int temp3 = -1;
            bool dum = false;

            if (y(z) > 0)
            { temp1 = 1; }
            if (C(z) > 0) { temp2 = 1; }
            if (S(z) > 0) { temp3 = 1; }
            int temporary = temp1 * temp2 * temp3;
            if (temp1 * temp2 * temp3 < 0)
            {
                dum = true;
            }
            else
            {
                dum = false;
            }
            return dum;
        }
        private static double F(double z)
        {
            double temp1 = y(z);
            double temp2 = C(z);
            double dum = temp1 / temp2;
            dum = Math.Pow(dum,3/2)*S(z);
            dum += A*Math.Sqrt(y(z));
            dum -= Math.Sqrt(mu)*t;
            return dum;
        }
        private static double dFdz(double z)
        {
            double dum;
            if(z==0)
            {
                dum = (Math.Sqrt(2) / 40) * Math.Pow(y(0), 3 / 2);
                dum += (A / 8) * (Math.Sqrt(y(0)) + A * Math.Sqrt((1 / 2) / y(0)));
            }
            else
            {
                dum = Math.Pow(y(z)/C(z),3/2)*((1/2)/z*(C(z) - 3*S(z)/2/C(z))
                    + 3*(Math.Pow(S(z),2))/4/C(z)) + A/8*(3*S(z)/C(z)*Math.Sqrt(y(z))
                    + A*Math.Sqrt(C(z)/y(z)));
            }
            return dum;
        }
        private static double C(double z)
        {
            double dum = stumpC(z);
            return dum;
        }
        private static double S(double z)
        {
            double dum = stumpS(z);
            return dum;
        }

        private static double stumpS(double z)
        {
            double s;
            if(z>0)
            {
                s = (Math.Sqrt(z) - Math.Sin(Math.Sqrt(z))) / (Math.Pow(Math.Sqrt(z), 3));
            }
            else if(z<0)
            {
                s = (Math.Sinh(Math.Sqrt(-z)) - Math.Sqrt(-z)) / (Math.Pow(Math.Sqrt(-z), 3));
            }
            else
            {
                s = 1 / 6;
            }
            return s;
        }
        private static double stumpC(double z)
        {
            double c;
            if(z>0)
            {
                c = (1 - Math.Cos(Math.Sqrt(z))) / z;
            }
            else if(z<0)
            {
                c = (Math.Cosh(Math.Sqrt(-z)) - 1) / (-z);
            }
            else
            {
                c = 1 / 2;
            }
            return c;
        }
    }
}

