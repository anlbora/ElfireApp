using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfireApp.Curves
{
    public class CompareCurvesWithEurocode
    {
        public List<double> EurocodeTimes { get; set; }
        public List<double> EurocodeTemps { get; set; }
        public List<double> ISO834Times { get; set; }
        public List<double> ISO834Temps { get; set; }
        public List<double> HydroCarbonTimes { get; set; }
        public List<double> HydroCarbonTemps { get; set; }
        public List<double> ASTME119Times { get; set; }
        public List<double> ASTME119Temps { get; set; }

        public PictureBox graph { get; set; }

        public CompareCurvesWithEurocode()
        {
            ISO834Times = new List<double>();
            ISO834Temps = new List<double>();

            HydroCarbonTimes = new List<double>();
            HydroCarbonTemps = new List<double>();

            ASTME119Times = new List<double>();
            ASTME119Temps = new List<double>();

            for (int i = 0; i < 360; i++)
            {
                double timeInMinutes = i;
                ISO834Times.Add(timeInMinutes);
                ISO834Temps.Add(20 + (345 * (Math.Log10(8 * timeInMinutes + 1))));
            }

            for (int i = 0; i < 360; i++)
            {
                HydroCarbonTimes.Add(i);

                double temperature = 20 + 1080 * (1 - 0.325 * Math.Exp(-0.167 * i) - 0.675 * Math.Exp(-2.5 * i));
                HydroCarbonTemps.Add(temperature);
            }

            for (int i = 0; i < 360; i++)
            {
                ASTME119Times.Add(i);
                double t_minutes = i / 60.0;

                double temperature = 20 + 750 * (1 - Math.Exp(-3.795583 * Math.Sqrt(t_minutes))) + 170.41 * Math.Sqrt(t_minutes);
                ASTME119Temps.Add(temperature);
            }

            graph = new PictureBox();

            graph.Width = 800;
            graph.Height = 600;

        }

        public Bitmap CompareISO834()
        {
            Bitmap bmp = new Bitmap(graph.Width, graph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {

                g.Clear(Color.White);

                Pen axisPen = new Pen(Color.Black, 2);
                Pen eurocodePen = new Pen(Color.Red, 4);
                Pen iso834Pen = new Pen(Color.Blue, 2);
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

                // Draw axis labels and values
                g.DrawString("Time (minutes)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 25);
                g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);
            }

            // Display the bitmap in the PictureBox
            graph.Image = bmp;

            return bmp;
        }

        public Bitmap CompareHydroCarbom()
        {
            Bitmap bmp = new Bitmap(graph.Width, graph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {

                g.Clear(Color.White);

                Pen axisPen = new Pen(Color.Black, 2);
                Pen eurocodePen = new Pen(Color.Red, 4);
                Pen iso834Pen = new Pen(Color.Blue, 2);
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

                // Draw axis labels and values
                g.DrawString("Time (minutes)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 25);
                g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);
            }

            // Display the bitmap in the PictureBox
            graph.Image = bmp;

            return bmp;
        }

        public Bitmap CompareASTME119()
        {
            Bitmap bmp = new Bitmap(graph.Width, graph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {

                g.Clear(Color.White);

                Pen axisPen = new Pen(Color.Black, 2);
                Pen eurocodePen = new Pen(Color.Red, 4);
                Pen ASTME119Pen = new Pen(Color.Blue, 2);
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

                // Draw axis labels and values
                g.DrawString("Time (minutes)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 25);
                g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);
            }

            // Display the bitmap in the PictureBox
            graph.Image = bmp;

            return bmp;
        }

        public Bitmap CompareHydroCarbon()
        {
            Bitmap bmp = new Bitmap(graph.Width, graph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {

                g.Clear(Color.White);

                Pen axisPen = new Pen(Color.Black, 2);
                Pen eurocodePen = new Pen(Color.Red, 4);
                Pen HydroCarbonPen = new Pen(Color.Blue, 2);
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

                // Draw axis labels and values
                g.DrawString("Time (minutes)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 25);
                g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);
            }

            // Display the bitmap in the PictureBox
            graph.Image = bmp;

            return bmp;
        }
    }
}
