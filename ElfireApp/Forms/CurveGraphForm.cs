using ElfireApp.Curves;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class CurveGraphForm : Form
    {
        public List<double> Times { get; set; }
        public List<double> Temps { get; set; }
        private ToolTip graphToolTip; // ToolTip to display time and temp values

        private bool readyToDraw = false;

        public CurveGraphForm(List<double> Times, List<double> Temps)
        {
            InitializeComponent();
            this.Times = Times;
            this.Temps = Temps;

            graphToolTip = new ToolTip();
            graphToolTip.AutoPopDelay = 5000;
            graphToolTip.InitialDelay = 100;
            graphToolTip.ReshowDelay = 100;

            graph.MouseMove += graph_MouseMove;

            cb_MaksTemp.CheckedChanged += (sender, e) => { if (readyToDraw) CreateGraph(Times, Temps); };
            cb_ShowPhases.CheckedChanged += (sender, e) => { if (readyToDraw) CreateGraph(Times, Temps); };

            this.Load += (s, e) =>
            {
                readyToDraw = true;
                CreateGraph(Times, Temps); // Now Times and Temps are definitely ready
            };
        }

        private void CreateGraph(List<double> Times, List<double> Temps)
        {
            // Ensure the PictureBox control 'graph' is initialized
            if (graph == null)
            {
                MessageBox.Show("PictureBox control is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set the PictureBox to resize with its parent control
            graph.SizeMode = PictureBoxSizeMode.AutoSize;
            graph.Dock = DockStyle.Fill;

            // Create a bitmap with the size of the PictureBox
            Bitmap bmp = new Bitmap(graph.Width, graph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Clear the background
                g.Clear(Color.White);

                // Set up drawing parameters
                Pen axisPen = new Pen(Color.Black, 2);
                Pen graphPen = new Pen(Color.Blue, 2);
                Pen maxTempPen = new Pen(Color.Black, 2) { DashStyle = DashStyle.Dash };
                Pen gridPen = new Pen(Color.LightGray, 1); // Pen for drawing grid lines
                Font font = new Font("Arial", 10, FontStyle.Bold); // Larger font for better visibility
                Brush brush = Brushes.Black;

                // Brushes for transparent areas
                SolidBrush heatingBrush = new SolidBrush(Color.FromArgb(75, Color.Red));
                SolidBrush coolingBrush = new SolidBrush(Color.FromArgb(75, Color.Blue));

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

                    // Draw tick marks and labels
                    g.DrawLine(axisPen, xPos, graph.Height - margin, xPos, graph.Height - margin + 5);
                    g.DrawString((tickSpacingX * i).ToString("0.0"), font, brush, xPos - 10, graph.Height - margin + 10);
                }

                // Draw grid lines for Y-axis
                float tickSpacingY = maxY / 10; // Fixed number of intervals
                for (int i = 0; i <= 10; i++)
                {
                    float yPos = graph.Height - margin - i * tickSpacingY * fixedYScale; // Fixed y position
                    g.DrawLine(gridPen, margin, yPos, graph.Width - margin, yPos); // Horizontal grid line

                    // Draw tick marks and labels
                    g.DrawLine(axisPen, margin - 5, yPos, margin, yPos);
                    g.DrawString((tickSpacingY * i).ToString("0"), font, brush, 5, yPos - 10);
                }

                // Prepare points for heating and cooling phases
                List<PointF> heatingPoints = new List<PointF>();
                List<PointF> coolingPoints = new List<PointF>();

                // Find maximum temperature and its corresponding time index
                double maxTemp = Temps.Max();
                int maxTempIndex = Temps.IndexOf(maxTemp);
                float maxTempX = margin + (float)(Times[maxTempIndex] / 60) * xScale;
                float maxTempY = graph.Height - margin - (float)(maxTemp * fixedYScale);

                // Draw the graph lines and categorize points for heating and cooling phases
                for (int i = 0; i < Times.Count; i++)
                {
                    float x = margin + (float)((Times[i] / 60) * xScale); // Convert seconds to minutes
                    float y = graph.Height - margin - (float)(Temps[i] * fixedYScale);

                    // Store points for filling the area
                    if (i <= maxTempIndex)
                        heatingPoints.Add(new PointF(x, y));
                    else
                        coolingPoints.Add(new PointF(x, y));
                }

                // Draw the graph lines
                for (int i = 1; i < heatingPoints.Count; i++)
                {
                    g.DrawLine(graphPen, heatingPoints[i - 1], heatingPoints[i]);
                }

                for (int i = 1; i < coolingPoints.Count; i++)
                {
                    g.DrawLine(graphPen, coolingPoints[i - 1], coolingPoints[i]);
                }

                // Draw axis labels and values
                g.DrawString("Time (minutes)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 25);
                g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);

                // Show max temperature point and fill areas only if the checkbox is checked
                if (cb_MaksTemp.Checked || cb_ShowPhases.Checked)
                {
                    // Draw max temperature dashed lines and point
                    if (cb_MaksTemp.Checked)
                    {
                        g.DrawLine(maxTempPen, maxTempX, graph.Height - margin, maxTempX, maxTempY); // Vertical line
                        g.DrawLine(maxTempPen, margin, maxTempY, maxTempX, maxTempY); // Horizontal line
                        g.FillEllipse(Brushes.Black, maxTempX - 3, maxTempY - 3, 10, 10);

                        // Display the maximum temperature and time next to the point
                        g.DrawString($"Max Temp: {maxTemp:F2} °C", font, brush, maxTempX + 5, maxTempY - 20);
                        g.DrawString($"Time: {Times[maxTempIndex] / 60:F2} min", font, brush, maxTempX + 5, maxTempY);
                    }

                    // Fill the area below the graph with transparency for heating and cooling phases
                    if (cb_ShowPhases.Checked)
                    {
                        // Add base points to heating and cooling points to close the polygon for filling
                        heatingPoints.Insert(0, new PointF(margin, graph.Height - margin)); // Starting point at X-axis
                        heatingPoints.Add(new PointF(maxTempX, graph.Height - margin)); // End point at X-axis

                        coolingPoints.Insert(0, new PointF(maxTempX, graph.Height - margin)); // Starting point at X-axis
                        coolingPoints.Add(new PointF(margin + (float)(Times.Last() / 60) * xScale, graph.Height - margin)); // End point at X-axis

                        g.FillPolygon(heatingBrush, heatingPoints.ToArray());
                        g.FillPolygon(coolingBrush, coolingPoints.ToArray());

                        // Draw phase labels above the filled areas
                        float heatingPhaseX = margin + (maxTempX - margin) / 2 - 30; // Centered position before max temperature
                        float coolingPhaseX = maxTempX + (graph.Width - margin - maxTempX) / 2 - 30; // Centered position after max temperature

                        g.DrawString("Heating\nPhase", font, Brushes.Black, heatingPhaseX, graph.Height - margin - 60);
                        g.DrawString("Cooling\nPhase", font, Brushes.Black, coolingPhaseX, graph.Height - margin - 60);
                    }
                }
            }

            // Display the bitmap in the PictureBox
            graph.Image = bmp;
        }


        private void graph_SizeChanged(object sender, EventArgs e)
        {
            if (readyToDraw)
                CreateGraph(Times, Temps);
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
            graphToolTip.SetToolTip(graph, $"Time: {actualTime:F2} min\nTemp: {actualTemp:F2} °C");
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
