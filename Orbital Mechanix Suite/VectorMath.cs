using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbital_Mechanix_Suite
{
    class VectorMath
    {
               public static Vector3 cross(Vector3 Vect1,Vector3 Vect2)
        {
            double i = Vect1.y * Vect2.z - Vect1.z * Vect2.y;
            double j = Vect1.z * Vect2.x - Vect1.x * Vect2.z;
            double k = Vect1.x * Vect2.y - Vect1.y * Vect2.x;
            return new Vector3(i, j, k);
        }
        public static double dot(Vector3 Vect1, Vector3 Vect2)
        {
            double returnval = Vect1.x*Vect2.x+Vect1.y*Vect2.y+Vect1.z*Vect2.z;
            return returnval;
        }
        public static Vector3 Euler(Vector3 ang, Vector3 radius)
        {
            double c1, c2, c3, s1, s2, s3;
            double d2r = Math.PI/180;
            double r2d = 180/Math.PI;
            Vector3 returnVal = new Vector3();
            ang.x *=  d2r;
            ang.y *= d2r;
            ang.z *= d2r;
            
            double[,] rad = new double[3,1];
            double[,] outrad = new double[3, 1];
            rad[1, 1] = radius.x;
            rad[2, 1] = radius.y;
            rad[3, 1] = radius.z;

            c1 = Math.Cos(ang.x);
            c2 = Math.Cos(ang.y);
            c3 = Math.Cos(ang.z);
            s1 = Math.Sin(ang.x);
            s2 = Math.Sin(ang.y);
            s3 = Math.Sin(ang.z);

            double[,] EulerMat = new double[3, 3];
            EulerMat[0, 0] = c1 * c3 - c2 * s1 * s3;
            EulerMat[0, 1] = -c1 * s3 - c2 * c3 * s1;
            EulerMat[0, 2] = s1 * s2;
            EulerMat[1, 0] = c3 * s1 + c1 * c2 * s3;
            EulerMat[1, 1] = c1 * c2 * c3 - s1 * s3;
            EulerMat[1, 2] = -c1 * s2;
            EulerMat[2, 0] = s2 * s3;
            EulerMat[2,1] = c3*s2;
            EulerMat[2,2] = c2;

            double count1 = 0;
            for (int i = 0; i < 3; i++)
            {
                double count2 = 0;
                for (int j = 0; j < 3; j++)
                {
                    double count3 = 0;
                    outrad[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        outrad[i, j] += EulerMat[i, k] * rad[k, j];
                        count3++;
                    }
                    count2++;
                }
                count1++;
            }
            returnVal.x = outrad[1, 1];
            returnVal.y = outrad[2, 1];
            returnVal.z = outrad[3, 1];
            return returnVal;
        }
        public static Vector3 Perifocal2Geocentric(Vector3 perifocal, double Omega, double w, double i)
        {
            double sOmega = Math.Sin(Omega);
            double cOmega = Math.Cos(Omega);
            double sw = Math.Sin(w);
            double cw = Math.Cos(w);
            double si = Math.Sin(i);
            double ci = Math.Cos(i);
            
            double X = (-sOmega * ci * sw + cOmega * cw) * perifocal.x + (-sOmega * ci * cw - cOmega * sw) * perifocal.y;
            double Y = (cOmega * ci * sw + sOmega * cw) * perifocal.x + (cOmega * ci * cw - sOmega * sw) * perifocal.y;
            double Z = si * sw * perifocal.x + si * cw * perifocal.y;
            /*
            double X = (-sOmega * ci * sw + cOmega * cw) * perifocal.x + (cOmega * ci * sw + sOmega * sw) * perifocal.y;
            double Y = (-sOmega * ci * cw - cOmega * sw) * perifocal.x + (cOmega * ci * cw - sOmega * sw) * perifocal.y;
            double Z = (sOmega * si) * perifocal.x + (-cOmega * si) * perifocal.y;*/
            return new Vector3(X, Y, Z);
        }

    }
    public class Vector3
    {
        public double x;
        public double y;
        public double z;
        

        public Vector3(double newX, double newY, double newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }
        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public double Magnitude()
        {
            double mag = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            return mag;
        }
        public Vector3 UnitVector()
        {
           Vector3 uv= new Vector3();
           double magnitude = Magnitude();
           uv.x = x / magnitude;
           uv.y = y / magnitude;
           uv.z = z / magnitude;
           return uv;
        }
        public double[] GetVector3()
        {
            double[] vect = {x,y,z};
            return vect;
        }

    }

 
}
