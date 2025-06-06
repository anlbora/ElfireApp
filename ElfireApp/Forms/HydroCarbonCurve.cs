using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WIA;

namespace ElfireApp.Forms
{
    public partial class HydroCarbonCurve : Form
    {
        private ToolTip graphToolTip; // ToolTip to display time and temp values
        private List<double> Times; // Declare Times and Temps here
        private List<double> Temps;
        public HydroCarbonCurve()
        {
            InitializeComponent(); // Make sure this is called first
            graph.SizeChanged += GraphArea_SizeChanged; // Attach the SizeChanged event handler

            // Initialize ToolTip
            graphToolTip = new ToolTip();
            graphToolTip.AutoPopDelay = 5000; // Show the tooltip for 5 seconds
            graphToolTip.InitialDelay = 100;
            graphToolTip.ReshowDelay = 100;

            graph.MouseMove += graph_MouseMove;

            // Initialize the data lists
            Times = new List<double>();
            Temps = new List<double>();
        }

        private void HydroCarbonCurve_Load(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void DrawGraph()
        {
            Times.Clear();
            Temps.Clear();

            for (int i = 0; i < 180; i++)
            {
                Times.Add(i);
                // Apply the new temperature formula
                double temperature = 20 + 1080 * (1 - 0.325 * Math.Exp(-0.167 * i) - 0.675 * Math.Exp(-2.5 * i));
                Temps.Add(temperature);
            }

            // Draw the graph with the generated data
            CreateGraph(Times, Temps);
        }


        private void GraphArea_SizeChanged(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void graph_MouseMove(object sender, MouseEventArgs e)
        {
            if (graph.Image == null) return; // If no image is drawn, return

            // Calculate mouse position relative to the graph
            int margin = 40;
            float maxX = (float)Times.Max() / 60; // Convert max time from seconds to minutes
            float maxY = (float)Temps.Max();
            float xScale = (graph.Width - 2 * margin) / maxX; // X-axis scaling factor
            float fixedYScale = (graph.Height - 2 * margin) / maxY; // Y-axis scaling factor

            // Calculate the x (time in minutes) and y (temperature) values based on mouse position
            double mouseTime = (e.X - margin) / xScale; // Time in minutes
            double mouseTemp = (graph.Height - margin - e.Y) / fixedYScale;

            // Ensure mouse position is within the graph data range
            if (mouseTime < 0 || mouseTime > maxX || mouseTemp < 0 || mouseTemp > maxY)
                return;

            // Find the closest data point to the mouse position
            int closestIndex = 0;
            double minDistance = double.MaxValue;

            for (int i = 0; i < Times.Count; i++)
            {
                double currentDistance = Math.Abs(mouseTime - (Times[i] / 60)); // Distance in minutes
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    closestIndex = i;
                }
            }

            double actualTime = Times[closestIndex] / 60; // Convert to minutes
            double actualTemp = Temps[closestIndex];

            // Show ToolTip with actual time (in minutes) and temperature
            graphToolTip.SetToolTip(graph, $"Time: {actualTime * 60:F2} min\nTemp: {actualTemp:F2} °C");
        }


        private void CreateGraph(List<double> Times, List<double> Temps)
        {
            // Ensure the PictureBox control 'graph' is initialized
            if (graph == null)
            {
                MessageBox.Show("PictureBox control is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a bitmap with the size of the PictureBox
            Bitmap bmp = new Bitmap(graph.Width, graph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Clear the background
                g.Clear(Color.White);

                // Set up drawing parameters
                Pen axisPen = new Pen(Color.Black, 2);
                Pen graphPen = new Pen(Color.Blue, 2);
                Pen gridPen = new Pen(Color.LightGray, 1); // Pen for drawing grid lines
                Font font = new Font("Arial", 10, FontStyle.Bold); // Larger font for better visibility
                Brush brush = Brushes.Black;

                // Draw X and Y axis with margins
                int margin = 40;
                g.DrawLine(axisPen, margin, graph.Height - margin, graph.Width - margin, graph.Height - margin); // X Axis
                g.DrawLine(axisPen, margin, graph.Height - margin, margin, margin); // Y Axis

                // Keep y-axis fixed and stretch x-axis dynamically
                float maxX = (float)Times.Max() / 60; // Convert max time from seconds to minutes
                float maxY = (float)Temps.Max();

                // Calculate dynamic x-scaling factor based on PictureBox width
                float xScale = (graph.Width - 2 * margin) / maxX; // X-axis stretches dynamically
                float fixedYScale = (graph.Height - 2 * margin) / maxY; // Y-axis scale remains fixed

                // Draw grid lines for X-axis
                float tickSpacingX = maxX / 10; // Fixed number of intervals
                for (int i = 0; i <= 10; i++)
                {
                    float xPos = margin + i * tickSpacingX * xScale; // Adjust based on xScale
                    g.DrawLine(gridPen, xPos, margin, xPos, graph.Height - margin); // Vertical grid line

                    // Draw tick marks and labels for X-axis
                    g.DrawLine(axisPen, xPos, graph.Height - margin, xPos, graph.Height - margin + 5);
                    g.DrawString((tickSpacingX * i).ToString("0.0"), font, brush, xPos - 10, graph.Height - margin + 10);
                }

                // Draw grid lines for Y-axis
                float tickSpacingY = maxY / 10; // Fixed number of intervals
                for (int i = 0; i <= 10; i++)
                {
                    float yPos = graph.Height - margin - i * tickSpacingY * fixedYScale; // Fixed y position
                    g.DrawLine(gridPen, margin, yPos, graph.Width - margin, yPos); // Horizontal grid line

                    // Draw tick marks and labels for Y-axis
                    g.DrawLine(axisPen, margin - 5, yPos, margin, yPos);
                    g.DrawString((tickSpacingY * i).ToString("0"), font, brush, 5, yPos - 10);
                }

                // Draw the graph lines
                for (int i = 1; i < Times.Count; i++)
                {
                    float x1 = margin + (float)((Times[i - 1] / 60) * xScale); // Convert seconds to minutes
                    float y1 = graph.Height - margin - (float)(Temps[i - 1] * fixedYScale);
                    float x2 = margin + (float)((Times[i] / 60) * xScale); // Convert seconds to minutes
                    float y2 = graph.Height - margin - (float)(Temps[i] * fixedYScale);

                    g.DrawLine(graphPen, x1, y1, x2, y2);
                }

                // Draw axis labels and values
                g.DrawString("Time (hours)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 25);
                g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);
            }

            // Display the bitmap in the PictureBox
            graph.Image = bmp;
        }

    }
}
