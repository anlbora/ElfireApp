using ElfireApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class MainPage : Form
    {
        UserPanelForm frm;
        int Panel1_Width;
        public MainPage()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Show the dialog to get the curve name from the user
            NewCurveName newCurveNameDialog = new NewCurveName();
            newCurveNameDialog.ShowDialog();

            // Retrieve the curve name entered by the user
            string curveName = newCurveNameDialog.curveName;

            // Check if a TabPage with the same name already exists
            bool tabExists = tabControl.TabPages.Cast<TabPage>().Any(tab => tab.Text == curveName);

            if (!tabExists)
            {
                // Create a new instance of the EurocodeCurve control
                EurocodeCurve eurocodeCurve = new EurocodeCurve(curveName);
                eurocodeCurve.Dock = DockStyle.Fill;

                // Create a new TabPage with the curve name
                TabPage tabPage = new TabPage(curveName);
                tabPage.AutoScroll = true;

                // Add the EurocodeCurve control to the TabPage
                tabPage.Controls.Add(eurocodeCurve);

                // Add the new TabPage to the TabControl
                tabControl.TabPages.Add(tabPage);

                // Set the focus to the newly created tab
                tabControl.SelectedTab = tabPage;
            }
            else
            {
                // Show a message box if the tab with the same name already exists
                MessageBox.Show($"A curve with the name '{curveName}' already exists. Please choose a different name.",
                                "Duplicate Curve Name",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }


        private void jPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != null)
            {
                // Get the selected TabPage
                TabPage selectedTab = tabControl.SelectedTab;

                // Create a bitmap with the size of the TabPage
                Bitmap bmp = new Bitmap(selectedTab.ClientSize.Width, selectedTab.ClientSize.Height);

                // Draw the TabPage's content onto the bitmap
                selectedTab.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                // Save the bitmap as a JPG file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                saveFileDialog.Title = "Save the TabPage as an Image";
                saveFileDialog.FileName = selectedTab.Text + ".jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    bmp.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("Screenshot saved successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No TabPage selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_CompareCurves_Click(object sender, EventArgs e)
        {
            // Initialize the OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select CSV Files";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.Multiselect = true; // Allow multiple file selection

                // Show the dialog and check if the user selected files
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Open the CompareEurocodeCurvesForm and pass the selected file paths
                    CompareEurocodeCurvesForm compareForm = new CompareEurocodeCurvesForm(openFileDialog.FileNames);
                    compareForm.ShowDialog(); // Show the form as a modal dialog
                }
            }
        }

        private void btn_CreateCurve_Click(object sender, EventArgs e)
        {
            // Retrieve the curve name entered by the user
            string curveName = txt_CurveName.Text;
            txt_CurveName.Text = string.Empty;

            // Check if a TabPage with the same name already exists
            bool tabExists = tabControl.TabPages.Cast<TabPage>().Any(tab => tab.Text == curveName);

            if (!tabExists)
            {
                // Create a new instance of the EurocodeCurve control
                EurocodeCurve eurocodeCurve = new EurocodeCurve(curveName);
                eurocodeCurve.Dock = DockStyle.Fill; // Use None if you want to control size manually

                // Create a new TabPage with the curve name
                TabPage tabPage = new TabPage(curveName)
                {
                    AutoScroll = true, // Enable AutoScroll for the TabPage
                    AutoSize = true,

                };

                // Add the EurocodeCurve control to the TabPage
                tabPage.Controls.Add(eurocodeCurve);

                // Add the new TabPage to the TabControl
                tabControl.TabPages.Add(tabPage);

                // Set the focus to the newly created tab
                tabControl.SelectedTab = tabPage;
            }
            else
            {
                // Show a message box if the tab with the same name already exists
                MessageBox.Show($"A curve with the name '{curveName}' already exists. Please choose a different name.",
                                "Duplicate Curve Name",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }



        private void btn_OpenCurves_Click(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Width = 800;
                this.Height = 600;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            //// Create an instance of the UserPanelForm
            //frm = new UserPanelForm();


            //// Assuming HomePage has a SplitContainer named splitContainer1
            //SplitContainer splitContainer1 = HomePage.Controls.Find("splitContainer1", true).FirstOrDefault() as SplitContainer;

            //if (splitContainer1 != null)
            //{
            //    frm.Dock = DockStyle.Fill; // Fill the container's panel

            //    // Add the form to the desired panel (e.g., Panel1)
            //    splitContainer1.Panel1.Controls.Add(frm);

            //    frm.Show();
            //}
            //else
            //{
            //    MessageBox.Show("SplitContainer not found in HomePage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void newToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            NewCurveName newCurveNameDialog = new NewCurveName();
            newCurveNameDialog.ShowDialog();
            string curveName = newCurveNameDialog.curveName;
            // Check if a TabPage with the same name already exists
            bool tabExists = tabControl.TabPages.Cast<TabPage>().Any(tab => tab.Text == curveName);

            if (!tabExists)
            {
                // Create a new instance of the EurocodeCurve control
                EurocodeCurve eurocodeCurve = new EurocodeCurve(curveName);
                eurocodeCurve.Dock = DockStyle.Fill; // Use None if you want to control size manually

                // Create a new TabPage with the curve name
                TabPage tabPage = new TabPage(curveName)
                {
                    AutoScroll = true, // Enable AutoScroll for the TabPage
                    AutoSize = true,

                };

                // Add the EurocodeCurve control to the TabPage
                tabPage.Controls.Add(eurocodeCurve);

                // Add the new TabPage to the TabControl
                tabControl.TabPages.Add(tabPage);

                // Set the focus to the newly created tab
                tabControl.SelectedTab = tabPage;
            }
            else
            {
                // Show a message box if the tab with the same name already exists
                MessageBox.Show($"A curve with the name '{curveName}' already exists. Please choose a different name.",
                                "Duplicate Curve Name",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

        }
    }
}
