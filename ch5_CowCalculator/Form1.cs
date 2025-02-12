using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ch5_CowCalculator
{
    public partial class Form1 : Form
    {
        Farmer farmer;
        public Form1()
        {
            InitializeComponent();
            farmer = new Farmer() { NumerOfCows = 15 };

            numericUpDown1.Value = 15;
            numericUpDown1.Minimum = 5;
            numericUpDown1.Maximum = 300;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            farmer.NumerOfCows = (int)numericUpDown1.Value;
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("I need {0} bags of feed for {1} cows", farmer.BagsOfFeed, farmer.NumerOfCows);
        }
    }
}
