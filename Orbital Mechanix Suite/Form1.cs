using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartDirector;
using System.Threading.Tasks;
using System.Threading;


namespace Orbital_Mechanix_Suite
{

    public partial class Form1 : Form
    {
        public int year, month, day;
        double daysFromJ2000;
        public List<Planet> PlanetList = new List<Planet>();
        public List<Vector3> InitVel = new List<Vector3>();
        public List<Vector3> FinalVel = new List<Vector3>();
        private static double AU2m = 149597870.700E3;
        public Planet Mercury = new Planet("Mercury", 0.20563593, 7.00497902, 0.38709927*AU2m, 48.33076593, 77.45779628- 48.33076593, 1.789289550796730E2, 3.302E23);
        public Planet Venus = new Planet("Venus", 1.616509607284541E-02, 3.381654228084926, 1.103556808489555E11, 7.663280644582068E+01, 7.454007924054743E+01, 3.063745561693953E+01, 48.685E23);
        public Planet Earth = new Planet("Earth", 0.01671123, -0.00001531, 1.00000261*AU2m, 0, 102.93768193, -2.47311027, 5.97219E24);
        public Planet Mars = new Planet("Mars", 0.09341233, 1.84969142, 1.52371034 * AU2m, 49.55953891, -23.94362959-49.55953891, -4.55343205+23.94362959, 6.4185E23);
        public double[] departVel;
        //public Planet Mars = new Planet();

        //Get the date and the days from J2000 Epoch from the datePick item
        private double getDate(DateTimePicker temp)
        {
            day = temp.Value.Day;
            month = temp.Value.Month;
            year = temp.Value.Year;

            if (month == 1 || month == 2)
            {
                year--;
                month += 12;
            }
            int A = year / 100;
            int B = A / 4;
            int C = 2 - A + B;
            double E = Math.Truncate(365.25 * (year + 4716d));
            double F = Math.Truncate(30.6001 * (month + 1d));
            double JDCT =(double) C + day + E + F - 1524;
            double deltaJDCT = JDCT - 2451545;

            /*
            int temp1 = (year+(month+9)/12)/4;
            int temp2 = 275*month/9;

            daysFromJ2000 = (double) 367d * year - 7d * temp1 + temp2 + day - 730531.5 +.5;
            */
            Console.Write(daysFromJ2000);
            return deltaJDCT;
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PlanetList.Add(Mercury);
            PlanetList.Add(Venus);
            PlanetList.Add(Earth);
            PlanetList.Add(Mars);
            foreach (Planet plan in PlanetList)
            {
                comboBox1.Items.Add(plan.name);
                InitPlanet.Items.Add(plan.name);
                FinPlanet.Items.Add(plan.name);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            double TA = 0;
            string selectedPlanet = comboBox1.Text;
           // float day = (float)day_numeric.Value;
            
             daysFromJ2000 = getDate(datePick);
            foreach (Planet plan1 in PlanetList)
                {
                    if (selectedPlanet == plan1.name)
                    {
                        outputBox.Text = "";
                        outputBox.AppendText("Computed Results for " + plan1.name + "\r\n");
                        outputBox.AppendText("Date for the Computation is " + datePick.Value.ToLongDateString() + " at 12:00 PM"+ "\r\n\r\n");
                        outputBox.AppendText("%----------------------------------------------------------%\r\n\r\n");
                        int checkcount=0;
                        foreach (int item in checkedListBox1.CheckedIndices)
                        {
                            checkcount++;
                        }
                        int itemcount=0;
                        foreach (int item in checkedListBox1.CheckedIndices)
                        {
                            itemcount++;
                            if(progressBar1.Value <progressBar1.Maximum)
                            {
                                progressBar1.Value =(100*itemcount) / checkcount;
                            }
                            switch (item)
                            {
                                case 0:
                                    TA = plan1.True_anomaly(daysFromJ2000);
                                    outputBox.AppendText("True Anomaly (deg) = " + TA + "\r\n");
                                    break;
                                case 1:
                                    double Radius = plan1.Radius(daysFromJ2000);
                                    outputBox.AppendText("Radius from Orbiting Body (m) = " + Radius + "\r\n");
                                    break;
                                case 2:
                                    double SemiMajor = plan1.semi_Major_Axis;
                                    outputBox.AppendText("Semi-Major Axis (m) = " + SemiMajor + "\r\n");
                                    break;
                                case 3:
                                    double Eccentr = plan1.eccentricity;
                                    outputBox.AppendText("Eccentricity = " + Eccentr + "\r\n");
                                    break;
                                case 4:
                                    double inc = plan1.inclination;
                                    outputBox.AppendText("Inclination (deg) = " + inc + "\r\n");
                                    break;
                                case 5:
                                    double longAscNode = plan1.Long_asc_node;
                                    outputBox.AppendText("Longitude of Ascending Node (deg)= " + longAscNode + "\r\n");
                                    break;
                                case 6:
                                    double ArgPer = plan1.arg_periapse;
                                    outputBox.AppendText("Argument of Periapse (deg) = " + ArgPer + "\r\n");
                                    break;
                                case 7:
                                    double Mass = plan1.mass_Planet;
                                    outputBox.AppendText("Mass (Kg)" + Mass + "\r\n");
                                    break;
                                default:
                                    TA = plan1.True_anomaly(daysFromJ2000);
                                    Radius = plan1.Radius(daysFromJ2000);
                                    break;
                            }
                        }
                    Vector3 hc = Earth.Heliocentric(2457239 - 2451545);
                        progressBar1.Value = 100;
                    }
                }
        }

        private void output_label_Click(object sender, EventArgs e)
        {

        }

        private void winChartViewer1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] depart = new double[100];
            double[] arrive = new double[100];
            double[] departVel = new double[depart.Length * arrive.Length];
            string Plan1Name = InitPlanet.Text;
            string Plan2Name = FinPlanet.Text;
            Planet Plan1 = PlanetFind(Plan1Name);
            Planet Plan2 = PlanetFind(Plan2Name);
            double depDate = getDate(DepartDate);
            double arrivDate = getDate(ArriveDate);
            for (int i = 0; i < depart.Length; i++)
            {
                depart[i] = (double)depDate+2451545d + i * 2d;
                arrive[i] = (double)arrivDate+2451545 + i * 2d;
            }
            departVel = new double[depart.Length * arrive.Length];
            int DLength = depart.Length;
            int state = 0;
            Parallel.For(0, arrive.Length, new ParallelOptions { MaxDegreeOfParallelism = 3 }, arriveinc =>
             {
                 double[] Depart = { 0};

                     Depart = depart;

                 //Console.WriteLine(arriveinc);
                 double ArriveTime = arrive[arriveinc];
                 Vector3 Rad2 = Plan2.Heliocentric(ArriveTime - 2451545);

                 for (int departinc = 0; departinc < DLength; departinc++)
                 {

                     double temp = 0;
                     double departTime = Depart[departinc];
                     Vector3 Rad1 = new Vector3();
                     Rad1 = Plan1.Heliocentric(departTime - 2451545);
                     Vector3 VelPlan1 = Plan1.HeliocentricVelocity(departTime - 2451545);
                     Vector3 Vel1 = new Vector3();
                     if (ArriveTime - departTime > 10)
                     {
                        Lambert L1 = new Lambert();
                        Vel1 = L1.Solver(Rad1, Rad2, ArriveTime - departTime, "pro", "V1");
                     }
                     Vel1 = new Vector3(Vel1.x - VelPlan1.x, Vel1.y - VelPlan1.y, Vel1.z - VelPlan1.z);
                     temp = Vel1.Magnitude();
                     lock(departVel)
                     {
                         departVel[arriveinc * DLength + departinc] = temp;
                     }
                 }
                 Interlocked.Increment(ref state);
             });
            XYChart c = new XYChart(800, 800);
            c.setPlotArea(75, 40, 600, 600, -1, -1, -1, c.dashLineColor(unchecked((int)0x80000000), Chart.DotLine), -1);
            // When auto-scaling, use tick spacing of 40 pixels as a guideline
            c.yAxis().setTickDensity(40);
            c.xAxis().setTickDensity(40);


            // Add a contour layer using the given data
            ContourLayer layer = c.addContourLayer(depart, arrive, departVel);
            c.getPlotArea().moveGridBefore(layer);
            ColorAxis cAxis = layer.setColorAxis(700, 40, Chart.TopLeft, 400, Chart.Right);
            double[] colorScale = { 3, 0x090446, 3.3, 0x16366B, 3.6, 0x236890, 3.9, 0x309AB5, 4.2, 0x53C45A, 4.5, 0x77EF00, 4.8, 0xBBF70F, 5.1, 0xFFFF1E, 5.4, 0xFF8111, 5.7, 0xFF0404 };
            cAxis.setColorScale(colorScale, 0x090446, 0xffffff);
            cAxis.setColorGradient(false);
            // Add a title to the color axis using 12 points Arial Bold Italic font
            cAxis.setTitle("Departure Velocity (km/s)", "Arial Bold Italic", 12);
            c.xAxis().setTitle("Departure Date (JDCT)");
            c.yAxis().setTitle("Arrival Date (JDCT)");
            c.addTitle("Departure Velocity from " + Plan1Name + " to " + Plan2Name);
            c.xAxis().setTickLength(10);
            c.yAxis().setTickLength(10);

            // Output the chart
            winChartViewer1.Chart = c;
            /*
                        // The data for the bar chart
            double[] data = {85, 156, 179.5, 211, 123};

            // The labels for the bar chart
            string[] labels = { "Mon", "Tue", "Wed", "Thu", "Fri" };

            XYChart c = new XYChart(250, 250);
            c.setPlotArea(30, 20, 200, 200);
            c.addBarLayer(data);
            c.xAxis().setLabels(labels);
            winChartViewer1.Chart = c;
            */
        }
        private Planet PlanetFind(string Name)
        {
            Planet PlanetOut = PlanetList[2];
            foreach (Planet plan in PlanetList)
            {
                if (plan.name == Name)
                {
                    PlanetOut = plan;
                    break;
                }
            }
            return PlanetOut;
        }
    }
}
