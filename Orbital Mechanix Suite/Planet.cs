
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Orbital_Mechanix_Suite
{
    public class Planet
    {

        public string name;
        public double eccentricity;
        public double inclination;
        public double Long_asc_node;
        public double arg_periapse;
        public double semi_Major_Axis;
        public double mean_Anomaly_Epoch;
        public double mass_Planet;
        public double true_anomaly;
        public double radius;
        public  Vector3 heliocentric_coord = new Vector3();
        private static double d2r = Math.PI / 180d;
        private static double r2d = 180 / Math.PI;
        private double mu = 1.3271284354517480E+11;
        public Planet()
        {
            name = "default";
            eccentricity = 0;
            inclination = 0;
            Long_asc_node = 0;
            arg_periapse = 0;
            mass_Planet = 0;
        }
        public Planet(string newName, double newEccentricity, double newInclination, double newSemiMajorAxis, double newLongAscNode, double newArgPeriapse, double newMeanAnomEpoch, double newMassPlanet)
        {
            name = newName;
            eccentricity = newEccentricity;
            inclination = newInclination;
            Long_asc_node = newLongAscNode;
            arg_periapse = newArgPeriapse;
            semi_Major_Axis = newSemiMajorAxis;
            mean_Anomaly_Epoch = newMeanAnomEpoch;
            mass_Planet = newMassPlanet;
        }
        public void SetName(string newName) { name = newName; }
        public void setEccentricity(double newEccentricity) { eccentricity = newEccentricity; }
        public void setInclinaiton(double newInclinaiton) { inclination = newInclinaiton; }
        public void setSemiMajorAxis(double newSemiMajorAxis) { semi_Major_Axis = newSemiMajorAxis; }
        public void setLongAscNode(double newLongAscNode) { Long_asc_node = newLongAscNode; }
        public void setArgPeriapse(double newArgPeriapse) { arg_periapse = newArgPeriapse; }
        public void setMeanAnomEpoch(double newMeanAnomEpoch) { mean_Anomaly_Epoch = newMeanAnomEpoch; }
        public void setMass(double newMassPlanet) { mass_Planet = newMassPlanet; }

        //bisection method
        private double Bisection(double m)
        {
            double E = 0;
            double EHi = 2 * Math.PI, ELO = 0, Error = 500, minErr = Math.Pow(10, -5);
            for (int i = 0; i < 500; i++)
            {
                E = (EHi + ELO) / 2;
                Error = E - eccentricity * Math.Sin(E) - m;
                if (Math.Abs(Error) < minErr)
                {
                    break;
                }
                else if (Error > 0)
                {
                    EHi = E;
                }
                else if (Error < 0)
                {
                    ELO = E;
                }
            }
            return E;
        }
        //find the position at a point days from epoch
        public double True_anomaly(double days)
        {
            double G = 6.67E-11;
            double M_sun = 1.989E30;
            //first step is to find "n"
            double n = Math.Sqrt(G * (M_sun + mass_Planet) / ((Math.Pow(semi_Major_Axis, 3))));

            double Time_sec = days * 24d * 3600d;

            double m = n * Time_sec + mean_Anomaly_Epoch * Math.PI / 180;
            m = m % (2d * Math.PI); //keep within bounds of 
            double E = Bisection(m);


            double theta = 2 * Math.Atan(Math.Sqrt((1d + eccentricity) / (1d - eccentricity)) * Math.Tan(E / 2d));
            theta = theta * 180d / Math.PI;
            theta = theta % 360d;
            while (theta < 0)
            {
                theta += 360d;
            }
            true_anomaly = theta;
            return theta;
        }

        public double Radius(double days)
        {
            double theta = True_anomaly(days);
            theta = theta * Math.PI / 180d;
            double rad = (semi_Major_Axis * (1d - Math.Pow(eccentricity, 2d))) / (1d + eccentricity * Math.Cos(theta));
            radius = rad;
            return rad;
        }
        public Vector3 Heliocentric(double days)
        {
            double v = True_anomaly(days)*d2r;
            double rad = Radius(days)*.001;
            double o = Long_asc_node*d2r;
            double w = arg_periapse * d2r;
            double i = inclination*d2r;
            double temp = (1d + eccentricity * Math.Cos(v)) * mu * rad*.001;
            double h = Math.Sqrt(temp);
            double prec = (h*h / mu) * 1d / (2d + eccentricity * Math.Cos(v));
            Vector3 R = new Vector3(rad * Math.Cos(v), rad * Math.Sin(v), 0);
            Vector3 HeliocentricRad = VectorMath.Perifocal2Geocentric(R, o, w, i);
            return HeliocentricRad;
        }
        public double Velocity(double days)
        {
            double R = Radius(days);
            double mu = 132712440018E9;
            double Vel = Math.Sqrt(mu * ((2 / R) - (1 / semi_Major_Axis)));
            return Vel;
        }
        public Vector3 HeliocentricVelocity(double days)
        {
            double o = Long_asc_node * d2r;
            double w = arg_periapse * d2r;
            double i = inclination * d2r;
            double R = Radius(days)*.001;
            double v = True_anomaly(days)*d2r;
            double MU = 132712440018d;
            double h = Math.Sqrt(semi_Major_Axis*.001 * (1d - Math.Pow(eccentricity, 2d)) * MU);
            double temp = MU / h;
            Vector3 VelPerifocal = new Vector3((MU / h) * (-Math.Sin(v)), (MU / h) * (eccentricity + Math.Cos(v)), 0d);
            Vector3 VelHelioc = VectorMath.Perifocal2Geocentric(VelPerifocal, o, w, i);
            return VelHelioc;

        }
    }
}
