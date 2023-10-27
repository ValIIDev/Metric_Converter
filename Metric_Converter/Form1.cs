using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;


namespace Metric_Converter
{

    public partial class Form1 : Form
    {

        private Cm_inchConvert converter; // Define the Cm_inchConvert object at a scope accessible to both event handlers 
        class Cm_inchConvert
        {
            private double ValueInCentimeters;
            private double ValueInInches;

            public Cm_inchConvert(double valueInCentimeters)
            {
                ValueInCentimeters = valueInCentimeters;
                ConvertToInches();
            }

            public Cm_inchConvert(double valueInInches, bool inches)
            {
                ValueInInches = valueInInches;
                ConvertToCentimeters();
            }

            public double GetValueInCentimeters()
            {
                return ValueInCentimeters;
            }

            public double GetValueInInches()
            {
                return ValueInInches;
            }

            private void ConvertToInches()
            {
                ValueInInches = ValueInCentimeters / 2.54; // 1 inch = 2.54 cm
            }

            private void ConvertToCentimeters()
            {
                ValueInCentimeters = ValueInInches * 2.54; // 1 inch = 2.54 cm
            }
        }

        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double centimeters))
            {
                converter = new Cm_inchConvert(centimeters); // Create the converter instance with the user input in centimeters
                double inchesValue = converter.GetValueInInches(); // Get the value in inches
                textBox2.Text = inchesValue.ToString();
            }
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
