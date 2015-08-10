using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Orbital_Mechanix_Suite
{
    public class Lambert
    {
        private double r1, r2, A, t;
        private static double mu = 132712440018d;
        private static double d2r = Math.PI / 180d;
        public Vector3 Solver(Vector3 R1,Vector3 R2, double T,string str,string returnVel )
        {
                t = T * 86400d;
                R1 = new Vector3(R1.x, R1.y, R1.z);
                R2 = new Vector3(R2.x, R2.y, R2.z);
                r1 = R1.Magnitude();
                r2 = R2.Magnitude();
                Vector3 c12 = VectorMath.cross(R1, R2);
                double dotprod = VectorMath.dot(R1, R2);
                double theta = Math.Acos(VectorMath.dot(R1, R2) / r1 / r2);

                if (str == "pro")
                {
                    if (c12.z <= 0)
                    {
                        theta = 2d * Math.PI - theta;
                    }
                }
                else if (str == "retro")
                {
                    if (c12.z >= 0)
                    {
                        theta = 2d * Math.PI - theta;
                    }
                }
                A = Math.Sin(theta) * Math.Sqrt(r1 * r2 / (1d - Math.Cos(theta)));
                double Z = -100d;
                double tempFZ = -1;
                while (F(Z) < 0)
                {
                    Z = Z + .1;
                }
                double tol = 1E-8d;
                int nmax = 10000;
                double ratio = 2d;
                int n = 0;
                while (Math.Abs(ratio) > tol && n <= nmax)
                {
                    n++;
                    ratio = F(Z) / dFdz(Z);
                    double fz = F(Z);
                    double dfdz = dFdz(Z);
                    Z = Z - ratio;
                }
                if (n >= nmax)
                {
                    Console.WriteLine(" number of iterations exceeded");
                    //return new Vector3(999, 999, 999);
                }
                double f = 1d - y(Z) / r1;
                double g = A * Math.Sqrt(y(Z) / mu);
                double gdot = 1d - y(Z) / r2;
                double og = 1d / g;
                if (returnVel == "V2")
                {
                    return new Vector3(og * (gdot * R2.x - R1.x), og * (gdot * R2.y - R1.y), og * (gdot * R2.z - R1.z));
                }
                else
                {
                    Vector3 outVal = new Vector3(og * (R2.x - f * R1.x), og * (R2.y - f * R1.y), og * (R2.z - f * R1.z));
                    return outVal;
                }
        }
        private double y(double z)
        {
            double tempkjfd = S(z);
            double dum = r1+r2+A*(z*S(z)-1d)/Complex.Sqrt(C(z)).Real;
            if (double.IsNaN(dum))
            {
                int ss = 0;
                tempkjfd = S(z);
            }
            return dum;
        }
        private double F(double z)
        {
            double temp1 = y(z);
            double temp2 = C(z);
            double dum = temp1 / temp2;
            double temp3 = Math.Pow(y(z),1.5) / Math.Pow(C(z),1.5);
            double temp5 = Math.Pow(temp3, 1.5);
            double temp4 = Math.Pow(y(z) / C(z), 1.5) * S(z);
            double temp7 =S(z);
            Complex tempor = Complex.Pow(y(z) / C(z), 1.5) * S(z) + A * Complex.Sqrt(y(z)) - Complex.Sqrt(mu) * t;
            dum = tempor.Real;
            if (double.IsNaN(dum))
            {
                int xx = 0;
            }
            
        //    dum += A*Math.Sqrt(y(z));
        //    dum -= Math.Sqrt(mu)*t;
            return dum;
        }
        private double dFdz(double z)
        {
            double dum;
            if(z==0d)
            {
                dum = (Math.Sqrt(2d) / 40d) * Math.Pow(y(0), 1.5)+ (A / 8d) * (Math.Sqrt(y(0d)) + A * Math.Sqrt((.5) / y(0d)));
            }
            else
            {
               double temp1 = y(z);
                double temp2 = C(z);
                double temp3 = S(z);
                double temp5 = y(z) / C(z);
                double temp4 = ((.5 / z) * (C(z) - 1.5 * S(z) / C(z)) + (.75/C(z)) * (Math.Pow(S(z), 2d)));

                dum = Math.Pow(y(z)/C(z),1.5)*((.5/z)*(C(z) - 1.5*S(z)/C(z))
                    + (.75/C(z))*(Math.Pow(S(z),2d))) + (A/8d)*(3d*S(z)/C(z)*Math.Sqrt(y(z))
                    + A*Math.Sqrt(C(z)/y(z)));
                if (double.IsNaN(dum))
                {
                    dum = Complex.Pow(y(z) / C(z), 1.5).Real * (((.5) / z) * (C(z) - 1.5 * S(z) / C(z))
                    + (3/4) * (Complex.Pow(S(z), 2d).Real) / C(z)) + (A / 8d) * (3d * S(z) / C(z) * Complex.Sqrt(y(z)).Real
                    + A * Complex.Sqrt(C(z) / y(z)).Real);

                }
            }
            return dum;
        }
        private double C(double z)
        {
            double dum = stumpC(z);
            return dum;
        }
        private double S(double z)
        {
            double dum = stumpS(z);
            return dum;
        }

        private double stumpS(double z)
        {
            double s;
            if(z>0d)
            {
                s = (Math.Sqrt(z) - Math.Sin(Math.Sqrt(z))) / (Math.Pow(Math.Sqrt(z), 3d));
            }
            else if(z<0d)
            {
                s = (Math.Sinh(Math.Sqrt(-z)) - Math.Sqrt(-z)) / (Math.Pow(Math.Sqrt(-z), 3d));
            }
            else
            {
                s = 1d / 6d;
            }
            if (double.IsNaN(s))
            {
                int ppp = 0;
            }
            return s;
        }
        private double stumpC(double z)
        {
            double c;
            if(z>0d)
            {
                c = (1d - Math.Cos(Math.Sqrt(z))) / z;
            }
            else if(z<0d)
            {
                c = (Math.Cosh(Math.Sqrt(-z)) - 1d) / (-z);
            }
            else
            {
                c = 0.5d;
            }
            return c;
        }
    }
}

