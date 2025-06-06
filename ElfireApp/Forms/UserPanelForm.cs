using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Internal;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class UserPanelForm : UserControl
    {
        private Image image;
        public UserPanelForm()
        {
            InitializeComponent();
            image = Image.FromFile(@"C:\Users\PC\source\repos\ElfireApp\ElfireApp\AnilBora.jpeg");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Attach the paint event to the PictureBox
            pictureBox1.Paint += pictureBox1_Paint;

            // Create a circular shape for the PictureBox
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(pictureBox1.Width/5, pictureBox1.Height/256, pictureBox1.Height, pictureBox1.Height);
            pictureBox1.Region = new Region(path); // Set the PictureBox region to be a circle
            pictureBox1.Image = image;

            // Set image mode to Zoom, so it scales properly within the circle
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Get the graphics object
                Graphics g = e.Graphics;

                // Create a circular clipping path
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(pictureBox1.Width / 5, pictureBox1.Height / 256, pictureBox1.Height, pictureBox1.Height);
                g.SetClip(path);

                // Draw the image centered and zoomed
                g.DrawImage(pictureBox1.Image, pictureBox1.ClientRectangle);
            }
        }


    }
}
