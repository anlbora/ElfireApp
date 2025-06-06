using ElfireApp.Curves;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class EurocodeCurveTempValue : Form
    {
        public Dictionary<string, Eurocode> eurocodeCurves;
        public EurocodeCurveTempValue(Dictionary<string, Eurocode> eurocodeCurves)
        {
            InitializeComponent();
            this.eurocodeCurves = eurocodeCurves;

        }

        private void btn_CalculateTemp_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse the time value from the input text box
                double time = double.Parse(txt_TimeValue.Text)*60;

                // Clear the DataGridView before populating new rows
                EurocodeCurvesTable.Rows.Clear();

                // Iterate through each Eurocode curve in the dictionary
                foreach (var curvePair in eurocodeCurves)
                {
                    string curveName = curvePair.Key; // The curve name
                    Eurocode curve = curvePair.Value; // The corresponding Eurocode curve object

                    // Find the closest temperature value for the given time
                    double temperature = GetTemperatureAtTime(curve, time);

                    // Add a new row to the DataGridView with the curve name and temperature
                    EurocodeCurvesTable.Rows.Add(curveName, temperature.ToString("0.000", CultureInfo.InvariantCulture));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid time value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double GetTemperatureAtTime(Eurocode curve, double targetTime)
        {
            // If there are no time or temperature values, return 0
            if (curve.Times.Count == 0 || curve.Temperatures.Count == 0)
                return 0;

            // Find the closest time index
            int closestIndex = GetClosestIndex(curve.Times, targetTime);

            // Return the temperature corresponding to the closest time
            return curve.Temperatures[closestIndex];
        }

        // Helper method to find the closest time index
        private int GetClosestIndex(List<double> times, double targetTime)
        {
            int closestIndex = 0;
            double minDistance = double.MaxValue;

            for (int i = 0; i < times.Count; i++)
            {
                double currentDistance = Math.Abs(targetTime - times[i]);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    closestIndex = i;
                }
            }

            return closestIndex;
        }


    }
}
