using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orbital_Mechanix_Suite;

namespace Orbital_Mechanix_Suite_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static double AU2m = 149597870.700E3;
        public Planet Earth = new Planet("Earth", 0.01671123, -0.00001531, 1.00000261 * AU2m, 0, 102.93768193, -2.47311027, 5.97219E24);
        public Planet Mars = new Planet("Mars", 0.09341233, 1.84969142, 1.52371034 * AU2m, 49.55953891, -23.94362959 - 49.55953891, -4.55343205 + 23.94362959, 6.4185E23);
        [TestMethod]
        public void TrueAnomalytest()
        {
            double TAtest = Earth.True_anomaly(2457239- 2451545);
            double shouldBe = 2.086312097774296E+02;
            Assert.AreEqual(TAtest,shouldBe,1d);

        }
        [TestMethod]
        public void RadiusTest()
        {
            double RadTest = Earth.Radius(2457239 - 2451545);
            double shouldBe = 1.517812368444415E11;
            Assert.AreEqual(RadTest,shouldBe,1E9);
        }
        [TestMethod]
        public void HeliocentricTest()
        {
            Vector3 HeliocentricTest = Earth.Heliocentric(2457239 - 2451545);
            Vector3 shouldbe = new Vector3(1.007607714648472E+08, - 1.135112804082973E+08,  3.450534188434482E+03);
            Assert.AreEqual(HeliocentricTest.x, shouldbe.x,1E7);
            Assert.AreEqual(HeliocentricTest.y, shouldbe.y, 1E7);
            Assert.AreEqual(HeliocentricTest.z, shouldbe.z, 5E3);
        }
        [TestMethod]
        public void HeliocentricMarsTest()
        {
            Vector3 HeliocentricTest = Mars.Heliocentric(2459219 - 2451545);
            Vector3 shouldbe = new Vector3(8.550441288420311E+07, 2.098123095830674E+08, 2.299312316831380E+06);
            double SBMag = shouldbe.Magnitude();
            Assert.AreEqual(HeliocentricTest.x, shouldbe.x, 1E7,"X out of bound");
            Assert.AreEqual(HeliocentricTest.y, shouldbe.y, 1E7, "Y out of bound");
            Assert.AreEqual(HeliocentricTest.z, shouldbe.z, 1E7, "Z out of bound");
            Assert.AreEqual(HeliocentricTest.Magnitude(), SBMag,1E7, "Magnitude out of bound");
        }
        [TestMethod]
        public void EarthVelTest()
        {
            Vector3 EarthVel = Earth.HeliocentricVelocity(2459219 - 2451545);
            double temp = EarthVel.Magnitude();
            Vector3 ShouldBe = new Vector3(-2.931579565201015E+01, - 7.607823944405751E+00,  4.377774115122968E-04);
            double temp2 = ShouldBe.Magnitude();
            Assert.AreEqual(ShouldBe.x, EarthVel.x,.5,"1");
            Assert.AreEqual(ShouldBe.y, EarthVel.y,1,"2");
            Assert.AreEqual(ShouldBe.z, EarthVel.z,.5,"3");
        }
        [TestMethod]
        public void LambertTest()
        {
            /*
            Vector3 EarthRad = Earth.Heliocentric(2457239 - 2451545);
            Vector3 MarsRad = Mars.Heliocentric(2457239 - 2451545 + 150);
            double time = 150;
            */
            Vector3 EarthRad = new Vector3(4.440778960961146E+07, - 1.454625135657227E+08,  7.039903338298202E+03);
            Vector3 MarsRad = new Vector3(8.550441288420311E+07, 2.098123095830674E+08, 2.299312316831380E+06);
            double time = 2459219- 2459039;
            Vector3 Vout = new Lambert().Solver(EarthRad, MarsRad, time, "pro", "V1");
            double LambertIs = Vout.Magnitude();
            double ShouldBe = 32.9054;
            Assert.AreEqual(LambertIs, ShouldBe, .05);
            
        }
}
}
