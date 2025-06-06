using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIA;

namespace ElfireApp.Forms
{
    public partial class CompareCurves : Form
    {
        public List<double> EurocodeTimes { get; set; }
        public List<double> EurocodeTemps { get; set; }
        public List<double> ISO834Times { get; set; }
        public List<double> ISO834Temps { get; set; }
        public List<double> HydroCarbonTimes { get; set; }
        public List<double> HydroCarbonTemps { get; set; }
        public List<double> ASTME119Times { get; set; }
        public List<double> ASTME119Temps { get; set; }

        private ToolTip graphToolTip;

        private bool readyToDraw = false;

        public CompareCurves(List<double> eurocodeTimes, List<double> eurocodeTemps)
        {
            InitializeComponent();
            this.EurocodeTimes = eurocodeTimes;
            this.EurocodeTemps = eurocodeTemps;

            ISO834Times = new List<double>();
            ISO834Temps = new List<double>();

            HydroCarbonTimes = new List<double>();
            HydroCarbonTemps = new List<double>();

            ASTME119Times = new List<double>();
            ASTME119Temps = new List<double>();

            for (int i = 0; i < 180; i++)
            {
                ISO834Times.Add(i);
                ISO834Temps.Add(20 + (345 * (Math.Log10(8 * i + 1))));

                HydroCarbonTimes.Add(i);
                HydroCarbonTemps.Add(20 + 1080 * (1 - 0.325 * Math.Exp(-0.167 * i) - 0.675 * Math.Exp(-2.5 * i)));

                double t_minutes = i / 60.0;
                ASTME119Times.Add(i);
                ASTME119Temps.Add(20 + 750 * (1 - Math.Exp(-3.795583 * Math.Sqrt(t_minutes))) + 170.41 * Math.Sqrt(t_minutes));
            }

            graphToolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 100,
                ReshowDelay = 100
            };

            cb_ShowGrids.CheckedChanged += (s, e) => { if (readyToDraw) DrawGraphs(); };
            cb_ISO834.CheckedChanged += (s, e) => { if (readyToDraw) DrawGraphs(); };
            cb_HydroCarbon.CheckedChanged += (s, e) => { if (readyToDraw) DrawGraphs(); };
            cb_ASTME119.CheckedChanged += (s, e) => { if (readyToDraw) DrawGraphs(); };
            cb_MaksTemp.CheckedChanged += (s, e) => { if (readyToDraw) DrawGraphs(); };

            this.Load += (s, e) =>
            {
                readyToDraw = true;
                DrawGraphs();
            };
        }

        private void chkShowGrids_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraphs();
        }

        private void chkISO834_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraphs();
        }
        private void chkHydroCarbon_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraphs();
        }
        private void chkASTME119_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraphs();
        }
        private void chkShowMaxTemp_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraphs();
        }

        private void DrawGraphs()
        {

            if (!readyToDraw || EurocodeTimes == null || EurocodeTemps == null || EurocodeTimes.Count == 0 || EurocodeTemps.Count == 0)
                return;

            if (graph == null)
            {
                MessageBox.Show("PictureBox control is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Bitmap bmp = new Bitmap(graph.Width, graph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {

                g.Clear(Color.White);

                Pen axisPen = new Pen(Color.Black, 2);
                Pen eurocodePen = new Pen(Color.Red, 4);
                Pen iso834Pen = new Pen(Color.Blue, 2);
                Pen HydroCarbonPen = new Pen(Color.Green, 2);
                Pen ASTME119Pen = new Pen(Color.Purple, 2);
                Pen maxTempPen = new Pen(Color.Black, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                Pen gridPen = new Pen(Color.LightGray, 1);
                Font font = new Font("Arial", 10, FontStyle.Bold); 
                Brush brush = Brushes.Black;

                // Draw X and Y axis with margins
                int margin = 40;
                g.DrawLine(axisPen, margin, graph.Height - margin, graph.Width - margin, graph.Height - margin); // X Axis
                g.DrawLine(axisPen, margin, graph.Height - margin, margin, margin); // Y Axis

                // Keep y-axis fixed and stretch x-axis dynamically
                float maxX = (float)Math.Max(Math.Max(EurocodeTimes.Max(), ISO834Times.Max()), Math.Max(HydroCarbonTimes.Max(), ASTME119Times.Max())) / 60; // Convert max time to hours for consistent scaling
                float maxY = (float)Math.Max(Math.Max(EurocodeTemps.Max(), ISO834Temps.Max()), Math.Max(HydroCarbonTemps.Max(), ASTME119Temps.Max()));

                // Calculate dynamic x-scaling factor based on PictureBox width
                float xScale = (graph.Width - 2 * margin) / maxX; // X-axis stretches dynamically
                float fixedYScale = (graph.Height - 2 * margin) / maxY; // Y-axis scale remains fixed

                // Draw grid lines for X-axis and Y-axis if Show Grids checkbox is checked
                if (cb_ShowGrids.Checked)
                {
                    float tickSpacingX = maxX / 10; // Fixed number of intervals
                    for (int i = 0; i <= 10; i++)
                    {
                        float xPos = margin + i * tickSpacingX * xScale; // Adjust based on xScale
                        g.DrawLine(gridPen, xPos, margin, xPos, graph.Height - margin); // Vertical grid line
                    }

                    float tickSpacingY = maxY / 10; // Fixed number of intervals
                    for (int i = 0; i <= 10; i++)
                    {
                        float yPos = graph.Height - margin - i * tickSpacingY * fixedYScale; // Fixed y position
                        g.DrawLine(gridPen, margin, yPos, graph.Width - margin, yPos); // Horizontal grid line
                    }
                }

                // Draw tick marks and labels for X-axis
                float tickSpacingXLabel = maxX / 10; // Fixed number of intervals
                for (int i = 0; i <= 10; i++)
                {
                    float xPos = margin + i * tickSpacingXLabel * xScale; // Adjust based on xScale
                    g.DrawLine(axisPen, xPos, graph.Height - margin, xPos, graph.Height - margin + 5);
                    g.DrawString((tickSpacingXLabel * i).ToString("0.0"), font, brush, xPos - 10, graph.Height - margin + 10);
                }

                // Draw tick marks and labels for Y-axis
                float tickSpacingYLabel = maxY / 10; // Fixed number of intervals
                for (int i = 0; i <= 10; i++)
                {
                    float yPos = graph.Height - margin - i * tickSpacingYLabel * fixedYScale; // Fixed y position
                    g.DrawLine(axisPen, margin - 5, yPos, margin, yPos);
                    g.DrawString((tickSpacingYLabel * i).ToString("0"), font, brush, 5, yPos - 10);
                }

                // Draw legend in the red rectangle area
                int legendX = graph.Width - 200; // Position X for legend (inside red rectangle area)
                int legendY = 100; // Position Y for legend

                // Draw the Eurocode graph lines (always visible)
                for (int i = 1; i < EurocodeTimes.Count; i++)
                {
                    float x1 = margin + (float)((EurocodeTimes[i - 1] / 60) * xScale); // Convert seconds to minutes
                    float y1 = graph.Height - margin - (float)(EurocodeTemps[i - 1] * fixedYScale);
                    float x2 = margin + (float)((EurocodeTimes[i] / 60) * xScale); // Convert seconds to minutes
                    float y2 = graph.Height - margin - (float)(EurocodeTemps[i] * fixedYScale);

                    g.DrawLine(eurocodePen, x1, y1, x2, y2);
                }

                g.DrawString("Legend:", font, brush, legendX, legendY);
                g.DrawLine(eurocodePen, legendX, legendY + 20, legendX + 20, legendY + 20);
                g.DrawString("Eurocode", font, brush, legendX + 30, legendY + 15);

                // Draw the ISO834 graph lines if the checkbox is checked
                if (cb_ISO834.Checked)
                {
                    for (int i = 1; i < ISO834Times.Count; i++)
                    {
                        float x1 = margin + (float)((ISO834Times[i - 1]) * xScale);
                        float y1 = graph.Height - margin - (float)(ISO834Temps[i - 1] * fixedYScale);
                        float x2 = margin + (float)((ISO834Times[i]) * xScale);
                        float y2 = graph.Height - margin - (float)(ISO834Temps[i] * fixedYScale);

                        g.DrawLine(iso834Pen, x1, y1, x2, y2);
                    }

                    g.DrawLine(iso834Pen, legendX, legendY + 40, legendX + 20, legendY + 40);
                    g.DrawString("ISO 834", font, brush, legendX + 30, legendY + 35);
                }

                if (cb_HydroCarbon.Checked)
                {
                    for (int i = 1; i < HydroCarbonTimes.Count; i++)
                    {
                        float x1 = margin + (float)((HydroCarbonTimes[i - 1]) * xScale);
                        float y1 = graph.Height - margin - (float)(HydroCarbonTemps[i - 1] * fixedYScale);
                        float x2 = margin + (float)((HydroCarbonTimes[i]) * xScale);
                        float y2 = graph.Height - margin - (float)(HydroCarbonTemps[i] * fixedYScale);

                        g.DrawLine(HydroCarbonPen, x1, y1, x2, y2);
                    }

                    g.DrawLine(HydroCarbonPen, legendX, legendY + 60, legendX + 20, legendY + 60);
                    g.DrawString("Hydro Carbon", font, brush, legendX + 30, legendY + 55);
                }

                if (cb_ASTME119.Checked)
                {
                    for (int i = 1; i < ASTME119Times.Count; i++)
                    {
                        float x1 = margin + (float)((ASTME119Times[i - 1]) * xScale);
                        float y1 = graph.Height - margin - (float)(ASTME119Temps[i - 1] * fixedYScale);
                        float x2 = margin + (float)((ASTME119Times[i]) * xScale);
                        float y2 = graph.Height - margin - (float)(ASTME119Temps[i] * fixedYScale);

                        g.DrawLine(ASTME119Pen, x1, y1, x2, y2);
                    }

                    g.DrawLine(ASTME119Pen, legendX, legendY + 80, legendX + 20, legendY + 80);
                    g.DrawString("ASTM E119", font, brush, legendX + 30, legendY + 75);
                }

                // Show max temperature point and lines if checkbox is checked
                if (cb_MaksTemp.Checked)
                {
                    // Get maximum temperature and its corresponding time
                    double maxTemp = EurocodeTemps.Max();
                    int maxTempIndex = EurocodeTemps.IndexOf(maxTemp);
                    double maxTempTime = EurocodeTimes[maxTempIndex] / 60; // Convert to hours

                    // Calculate position for maximum temperature point
                    float maxTempX = margin + (float)(maxTempTime * xScale);
                    float maxTempY = graph.Height - margin - (float)(maxTemp * fixedYScale);

                    // Draw dashed lines to indicate the maximum temperature
                    g.DrawLine(maxTempPen, maxTempX, graph.Height - margin, maxTempX, maxTempY); // Vertical line
                    g.DrawLine(maxTempPen, margin, maxTempY, maxTempX, maxTempY); // Horizontal line

                    // Draw a small rectangle or circle to mark the maximum temperature point
                    g.FillEllipse(Brushes.Black, maxTempX - 3, maxTempY - 3, 10, 10);

                    // Display the maximum temperature and time next to the point
                    g.DrawString($"Max Temp: {maxTemp:F2} °C", font, brush, maxTempX + 5, maxTempY - 20);
                    g.DrawString($"Time: {EurocodeTimes[maxTempIndex] / 60:F2} min", font, brush, maxTempX + 5, maxTempY);
                }

                // Draw axis labels and values
                g.DrawString("Time (minutes)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 25);
                g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);
            }

            // Display the bitmap in the PictureBox
            graph.Image = bmp;
        }



        private void graph_SizeChanged(object sender, EventArgs e)
        {
            if (readyToDraw) DrawGraphs();
        }

        private void graph_MouseMove(object sender, MouseEventArgs e)
        {
            if (graph.Image == null) return; // If no image is drawn, return

            // Calculate mouse position relative to the graph
            int margin = 40;
            float maxX = (float)Math.Max(Math.Max(EurocodeTimes.Max(), ISO834Times.Max()), Math.Max(HydroCarbonTimes.Max(), ASTME119Times.Max())) / 60; // Convert max time to hours for consistent scaling
            float maxY = (float)Math.Max(Math.Max(EurocodeTemps.Max(), ISO834Temps.Max()), Math.Max(HydroCarbonTemps.Max(), ASTME119Temps.Max()));
            float xScale = (graph.Width - 2 * margin) / maxX; // X-axis scaling factor
            float fixedYScale = (graph.Height - 2 * margin) / maxY; // Y-axis scaling factor

            // Calculate the x (time in minutes) and y (temperature) values based on mouse position
            double mouseTime = (e.X - margin) / xScale; // Time in hours
            double mouseTemp = (graph.Height - margin - e.Y) / fixedYScale;

            // Prepare the tooltip text
            StringBuilder tooltipText = new StringBuilder();
            tooltipText.AppendLine($"Time: {mouseTime:F2} min"); // Convert time back to minutes for display

            // Find the closest data point to the mouse position for Eurocode
            int closestIndexEurocode = GetClosestIndex(EurocodeTimes, mouseTime * 60);
            double actualTempEurocode = EurocodeTemps[closestIndexEurocode];
            tooltipText.AppendLine($"Eurocode Temp: {actualTempEurocode:F2} °C");

            // Find the closest data point to the mouse position for ISO834 if visible
            if (cb_ISO834.Checked)
            {
                int closestIndexISO834 = GetClosestIndex(ISO834Times, mouseTime);
                double actualTempISO834 = ISO834Temps[closestIndexISO834];
                tooltipText.AppendLine($"ISO 834 Temp: {actualTempISO834:F2} °C");
            }

            // Find the closest data point to the mouse position for HydroCarbon if visible
            if (cb_HydroCarbon.Checked)
            {
                int closestIndexHydroCarbon = GetClosestIndex(HydroCarbonTimes, mouseTime);
                double actualTempHydroCarbon = HydroCarbonTemps[closestIndexHydroCarbon];
                tooltipText.AppendLine($"Hydro Carbon Temp: {actualTempHydroCarbon:F2} °C");
            }

            // Find the closest data point to the mouse position for ASTME119 if visible
            if (cb_ASTME119.Checked)
            {
                int closestIndexASTME119 = GetClosestIndex(ASTME119Times, mouseTime);
                double actualTempASTME119 = ASTME119Temps[closestIndexASTME119];
                tooltipText.AppendLine($"ASTM E119 Temp: {actualTempASTME119:F2} °C");
            }

            // Show ToolTip with actual time and temperatures
            graphToolTip.SetToolTip(graph, tooltipText.ToString());
        }

        // Helper method to find the closest index for a given time
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


        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            // Check if there is an image in the PictureBox to save
            if (graph.Image == null)
            {
                MessageBox.Show("No image available to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a SaveFileDialog to allow the user to select the save location and file format
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save Graph Image";
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.DefaultExt = "png"; // Set default extension to PNG

                // Show the SaveFileDialog and check if the user clicked 'Save'
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Get the file extension chosen by the user
                        string fileExtension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                        // Determine the appropriate image format
                        System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                        if (fileExtension == ".jpg")
                        {
                            format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        }
                        else if (fileExtension == ".bmp")
                        {
                            format = System.Drawing.Imaging.ImageFormat.Bmp;
                        }

                        // Save the image in the selected format
                        graph.Image.Save(saveFileDialog.FileName, format);
                        MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
