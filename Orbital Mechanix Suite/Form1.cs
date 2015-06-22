using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orbital_Mechanix_Suite
{

    public partial class Form1 : Form
    {
        public List<Planet> PlanetList = new List<Planet>();
        private static double AU2m = 149597870700;
        public Planet Mercury = new Planet("Mercury", 1.976193311288083E-01, 7.013873298083790, 5.885642355456797E10, 4.812376548400915E1, 2.581669078701001E1, 1.789289550796730E2, 3.302E23);
        public Planet Venus = new Planet("Venus", 1.616509607284541E-02, 3.381654228084926, 1.103556808489555E11, 7.663280644582068E+01, 7.454007924054743E+01, 3.063745561693953E+01, 48.685E23);
        public Planet Earth = new Planet("Earth", 1.539024710796432E-02, 1.179024940726686E-02, 1.489476741134844E11, -1.059863596387948E+01, 6.373464993332024E+01, 2.570514546707050E+01, 5.97219E24);
        //public Planet Mars = new Planet();


        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlanetList.Add(Mercury);
            PlanetList.Add(Venus);
            PlanetList.Add(Earth);
            foreach (Planet plan in PlanetList)
            {
                comboBox1.Items.Add(plan.name);
            }
        }

        private void day_numeric_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double TA = 0;
            string selectedPlanet = comboBox1.Text;
            float day = (float)day_numeric.Value;
            foreach (Planet plan1 in PlanetList)
            {
                if (selectedPlanet == plan1.name)
                {
                    TA = plan1.True_anomaly(day);
                    break;
                }
            }
            output_label.Text = TA.ToString("#0.00");
        }
    }
}
