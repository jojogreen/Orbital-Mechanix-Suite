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
using System.Collections;

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
        public Planet Mercury = new Planet("Mercury", 0.20563593, 7.00497902, 0.38709927 * AU2m, 48.33076593, 77.45779628 - 48.33076593, 252.25032350 - 77.45779628, 3.302E23);
        public Planet Venus = new Planet("Venus", 0.00677672, 3.39467605, 0.72333566 * AU2m, 76.67984255, 131.60246718 - 76.67984255, 181.97909950 - 131.60246718, 48.685E23);
        public Planet Earth = new Planet("Earth", 0.01671123, -0.00001531, 1.00000261 * AU2m, 0, 102.93768193, -2.47311027, 5.97219E24);
        public Planet Mars = new Planet("Mars", 0.09341233, 1.84969142, 1.52371034 * AU2m, 49.55953891, -23.94362959 - 49.55953891, -4.55343205 + 23.94362959, 6.4185E23);
        public Planet Jupiter = new Planet("Jupiter", 0.04838624, 1.30439695, 5.20288700 * AU2m, 100.47390909, 14.72847983 - 100.47390909, 34.39644051 - 14.72847983, 1.8986E27);
        public Planet Saturn = new Planet("Saturn", 0.05386179, 2.48599187, 9.53667594 * AU2m, 113.66242448, 92.59887831 - 113.66242448, 49.95424423 - 92.59887831, 5.6846E26);
        public Planet Uranus = new Planet("Uranus", 0.04725744, 0.77263783, 19.18916464 * AU2m, 74.01692503, 170.95427630 - 74.01692503, 313.23810451 - 170.95427630, 8.6810E25);
        public Planet Neptune = new Planet("Neptune", 0.00859048, 1.77004347, 30.06992276 * AU2m, 131.78422574, 44.96476227 - 131.78422574, -55.12002969 - 44.96476227, 1.0243E26);
        public Planet Pluto = new Planet("Pluto", 0.24882730, 17.14001206, 39.48211675 * AU2m, 110.30393684, 224.06891629 - 110.30393684, 238.92903833 - 224.06891629, 1.305E22);
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
            double JDCT = (double)C + day + E + F - 1524;
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
            PlanetList.Add(Jupiter);
            PlanetList.Add(Saturn);
            PlanetList.Add(Uranus);
            PlanetList.Add(Neptune);
            PlanetList.Add(Pluto);
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
                    outputBox.AppendText("Date for the Computation is " + datePick.Value.ToLongDateString() + " at 12:00 PM" + "\r\n\r\n");
                    outputBox.AppendText("%----------------------------------------------------------%\r\n\r\n");
                    int checkcount = 0;
                    foreach (int item in checkedListBox1.CheckedIndices)
                    {
                        checkcount++;
                    }
                    int itemcount = 0;
                    foreach (int item in checkedListBox1.CheckedIndices)
                    {
                        itemcount++;
                        if (progressBar1.Value < progressBar1.Maximum)
                        {
                            progressBar1.Value = (100 * itemcount) / checkcount;
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

        private void winChartViewer1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePlot(object sender, RunWorkerCompletedEventArgs e)
        {
            List<object> objlist = new List<object>();
            objlist.AddRange((List<object>)e.Result);
            double[] depart = (double[])objlist[0];
            double[] arrive = (double[])objlist[1];
            double[] departVel = (double[])objlist[2];
            string Plan1Name = (string)objlist[3];
            string Plan2Name = (string)objlist[4];

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
            winChartViewer1.ImageMap = c.getHTMLImageMap("");
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

        private void RunPorkchop(object sender, DoWorkEventArgs e)
        {
            List<object> objlist = e.Argument as List<object>;
            double[] depart = (double[])objlist[0];
            double[] arrive = (double[])objlist[1];
            double[] departVel = (double[])objlist[2];
            string Plan1Name = (string)objlist[3];
            string Plan2Name = (string)objlist[4];
            Planet Plan1 = (Planet)objlist[5];
            Planet Plan2 = (Planet)objlist[6];
            int DLength = depart.Length;
            int state = 0;
            Parallel.For(0, arrive.Length, new ParallelOptions { MaxDegreeOfParallelism = 3 }, arriveinc =>
            {
                double[] Depart = { 0 };

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
                    else { Vel1 = new Vector3(999, 999, 999); }
                    Vel1 = new Vector3(Vel1.x - VelPlan1.x, Vel1.y - VelPlan1.y, Vel1.z - VelPlan1.z);
                    temp = Vel1.Magnitude();
                    lock (departVel)
                    {
                        departVel[arriveinc * DLength + departinc] = temp;
                    }
                }
                Interlocked.Increment(ref state);
            }
             );
            List<object> resultList = new List<object>();
            resultList.Add(depart);
            resultList.Add(arrive);
            resultList.Add(departVel);
            resultList.Add(Plan1Name);
            resultList.Add(Plan2Name);
            e.Result = resultList;

        }

        private void winChartViewer1_MouseMovePlotArea(object sender, MouseEventArgs e)
        {

        }
        //
        // Draw the track line with legend
        //
        private void crossHair(XYChart c, int mouseX, int mouseY)
        {
            //System.Threading.Thread.Sleep(500);
            // Clear the current dynamic layer and get the DrawArea object to draw on it.
            DrawArea d = c.initDynamicLayer();

            // The plot area object
            PlotArea plotArea = c.getPlotArea();

            // Draw a vertical line and a horizontal line as the cross hair
            d.vline(plotArea.getTopY(), plotArea.getBottomY(), mouseX, d.dashLineColor(0x000000, 0x0101));
            d.hline(plotArea.getLeftX(), plotArea.getRightX(), mouseY, d.dashLineColor(0x000000, 0x0101));

            // Draw y-axis label
            string label = "<*block,bgColor=FFFFDD,margin=3,edgeColor=000000*>" + c.formatValue(c.getYValue(
                mouseY, c.yAxis()), "{value|P4}") + "<*/*>";
            TTFText t = d.text(label, "Arial Bold", 8);
            t.draw(plotArea.getLeftX() - 5, mouseY, 0x000000, Chart.Right);

            // Draw x-axis label
            label = "<*block,bgColor=FFFFDD,margin=3,edgeColor=000000*>" + c.formatValue(c.getXValue(mouseX),
                "{value|P4}") + "<*/*>";
            t = d.text(label, "Arial Bold", 8);
            t.draw(mouseX, plotArea.getBottomY() + 5, 0x000000, Chart.Top);
        }

        private void winChartViewer1_Move(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Mouse is moving");
            WinChartViewer viewer = (WinChartViewer)sender;
            crossHair((XYChart)viewer.Chart, viewer.PlotAreaMouseX, viewer.PlotAreaMouseY);
            viewer.updateDisplay();

            // Hide the track cursor when the mouse leaves the plot area
            viewer.removeDynamicLayer("MouseLeavePlotArea");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] depart = new double[100];
            double[] arrive = new double[100];
            double[] departVel = new double[depart.Length * arrive.Length];
            string Plan1Name = "Earth";
            string Plan2Name = "Mars";
            Plan1Name = InitPlanet.Text;
            Plan2Name = FinPlanet.Text;
            Planet Plan1 = PlanetFind(Plan1Name);
            Planet Plan2 = PlanetFind(Plan2Name);
            double depDate = getDate(DepartDate);
            double arrivDate = getDate(ArriveDate);
            for (int i = 0; i < depart.Length; i++)
            {
                depart[i] = (double)depDate + 2451545d + i * 2d;
                arrive[i] = (double)arrivDate + 2451545 + i * 2d;
            }
            departVel = new double[depart.Length * arrive.Length];
            List<object> argumentlist = new List<object>();
            argumentlist.Add(depart);
            argumentlist.Add(arrive);
            argumentlist.Add(departVel);
            argumentlist.Add(Plan1Name);
            argumentlist.Add(Plan2Name);
            argumentlist.Add(Plan1);
            argumentlist.Add(Plan2);
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(argumentlist);
            }
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
