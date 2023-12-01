using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metric_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Tikrinama ar ivestas skaicius
            var inputText = textBox1.Text;
            var pattern = @"^[+-]?(\d+(\.\d*)?|\.\d+)([Ee][+-]?\d+)?$";

            if (Regex.IsMatch(inputText, pattern))
            {
                label2.Text = "Valid string";
            }
            else
            {
                //Istriname neleistinus simbolius iskyrus .
                textBox1.Text = "";
                label2.Text = "Only alpha-numeric characters and dots please";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1 || listBox2.SelectedIndex == -1)
            {
                label2.Text = "Please select both source and target units.";
                return;
            }

            string sourceUnit = listBox1.SelectedItem.ToString();
            string targetUnit = listBox2.SelectedItem.ToString();
            //extra atveju jei regex neapsaugojo kad necrashintu programa.
            if (!double.TryParse(textBox1.Text, out double inputValue))
            {
                label2.Text = "Invalid input. Please enter a valid number.";
                return;
            }

            double convertedValue = ConvertUnits(inputValue, sourceUnit, targetUnit);
            textBox2.Text = convertedValue.ToString();
            label2.Text = $"Converted from {sourceUnit} to {targetUnit}: {convertedValue}";
        }

        private double ConvertUnits(double inputValue, string sourceUnit, string targetUnit)
        {
            switch (sourceUnit)
            {
                case "kilometers":
                    return ConvertFromKilometers(inputValue, targetUnit);
                case "meters":
                    return ConvertFromMeters(inputValue, targetUnit);
                case "centimeters":
                    return ConvertFromCentimeters(inputValue, targetUnit);
                case "miles":
                    return ConvertFromMiles(inputValue, targetUnit);
                case "yards":
                    return ConvertFromFeet(inputValue, targetUnit);
                case "feet":
                    return ConvertFromFeet(inputValue, targetUnit);
                case "inches":
                    return ConvertFromInches(inputValue, targetUnit);
                case "kilograms":
                    return ConvertFromKilograms(inputValue, targetUnit);
                case "grams":
                    return ConvertFromGrams(inputValue, targetUnit);
                case "pounds":
                    return ConvertFromPounds(inputValue, targetUnit);
                case "ounces":
                    return ConvertFromOunces(inputValue, targetUnit);
                case "celsius":
                    return ConvertFromCelsius(inputValue, targetUnit);
                case "farenheit":
                    return ConvertFromfarenheit(inputValue, targetUnit);
                default:
                    ShowErrorMessageBox("Invalid source unit.");
                    return 0;
            }
        }
        private void ShowErrorMessageBox(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private double ConvertFromKilometers(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilometers":
                    return value;
                case "meters":
                    return value * 1000;
                case "centimeters":
                    return value * 100000;
                case "miles":
                    return value / 1.60934;
                case "yards":
                    return value * 1094;
                case "feet":
                    return value * 3280.84;
                case "inches":
                    return value * 39370.10;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;
            }
        }

        private double ConvertFromMeters(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilometers":
                    return value / 1000;
                case "meters":
                    return value;
                case "centimeters":
                    return value * 100;
                case "miles":
                    return value / 0.000621371; 
                case "yards":
                    return value * 0.9144; 
                case "feet":
                    return value * 0.3048; 
                case "inches":
                    return value * 0.0254;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;
            }
        }

        private double ConvertFromCentimeters(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilometers":
                    return value / 100000;
                case "meters":
                    return value / 100;
                case "centimeters":
                    return value;
                case "miles":
                    return value / 160900; 
                case "yards":
                    return value / 91.44;
                case "feet":
                    return value / 30.48; 
                case "inches":
                    return value / 2.54; 
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;
            }
        }
        private double ConvertFromMiles(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilometers":
                    return value * 1.609;
                case "meters":
                    return value * 1609;
                case "centimeters":
                    return value * 160900;
                case "miles":
                    return value;
                case "yards":
                    return value * 1760;
                case "feet":
                    return value * 5280;
                case "inches":
                    return value * 63360;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;
            }
        }
        private double ConvertFromYards(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilometers":
                    return value / 1094;
                case "meters":
                    return value / 1.094;
                case "centimeters":
                    return value / 91.44;
                case "miles":
                    return value / 1760;
                case "yards":
                    return value;
                case "feet":
                    return value * 3;
                case "inches":
                    return value * 36;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;
            }
        }
        private double ConvertFromFeet(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilometers":
                    return value / 3281;
                case "meters":
                    return value / 3.281;
                case "centimeters":
                    return value / 30.48;
                case "miles":
                    return value / 5280;
                case "yards":
                    return value / 3;
                case "feet":
                    return value;
                case "inches":
                    return value * 12;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;
            }
        }
        private double ConvertFromInches(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilometers":
                    return value / 39370;
                case "meters":
                    return value / 39.37;
                case "centimeters":
                    return value / 2.54;
                case "miles":
                    return value / 63360;
                case "yards":
                    return value / 36;
                case "feet":
                    return value / 12;
                case "inches":
                    return value;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;

            }
        }

        private double ConvertFromKilograms(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilograms":
                    return value;
                case "grams":
                    return value * 1000;
                case "pounds":
                    return value * 2.205;
                case "ounces":
                    return value * 35.274;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;

            }
        }

        private double ConvertFromGrams(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilograms":
                    return value / 1000;
                case "grams":
                    return value;
                case "pounds":
                    return value / 453.6;
                case "ounces":
                    return value / 28.35;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;

            }
        }

        private double ConvertFromPounds(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilograms":
                    return value / 2.205;
                case "grams":
                    return value * 453.6;
                case "pounds":
                    return value;
                case "ounces":
                    return value * 16;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;

            }
        }

        private double ConvertFromOunces(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "kilograms":
                    return value / 35.274;
                case "grams":
                    return value * 28.35;
                case "pounds":
                    return value / 16;
                case "ounces":
                    return value;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;

            }
        }

        private double ConvertFromCelsius(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "celsius":
                    return value;
                case "farenheit":
                    return (value* 9 / 5) + 32;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;

            }
        }
        private double ConvertFromfarenheit(double value, string targetUnit)
        {
            switch (targetUnit)
            {
                case "celsius":
                    return (value - 32) * 5/9;
                case "farenheit":
                    return value;
                default:
                    ShowErrorMessageBox("Invalid target unit.");
                    return value = 0;

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
