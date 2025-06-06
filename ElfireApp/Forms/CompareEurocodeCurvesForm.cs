using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ElfireApp.Curves; // Include your namespace

namespace ElfireApp.Forms
{
    public partial class CompareEurocodeCurvesForm : Form
    {
        #region Variables
        private string[] filePaths;
        private Dictionary<string, Eurocode> eurocodeCurves; // Store the Eurocode objects
        private Dictionary<string, Pen> curvePens; // Store pens to maintain color consistency
        private ToolTip graphToolTip;

        string selectedArea;
        string selectedOpeningFactor;
        string selectedMaterial;

        private string highlightedCurveName = null; // This tracks which curve is highlighted (null if none)

        #endregion

        #region Ctor
        public CompareEurocodeCurvesForm(string[] filePaths)
        {
            InitializeComponent();
            this.KeyPreview = true; // Enable key capturing at the form level

            this.filePaths = filePaths;
            eurocodeCurves = new Dictionary<string, Eurocode>();
            curvePens = new Dictionary<string, Pen>();

            selectedArea = "";
            selectedOpeningFactor = "";
            selectedMaterial = "";

            // Initialize DataGridView and Graph when form loads
            InitializeDataGridView();

            ImportCsvFiles();  // Load the Eurocode curves

            // Populate ComboBoxes with the distinct values from Eurocode curves
            PopulateComboBoxes();

            PlotCSVFiles();  // Plot the curves

            // Attach event handlers
            AttachEventHandlers();

        }

        #endregion

        #region Attach Event Handlers
        private void AttachEventHandlers()
        {
            dg_curves.CellDoubleClick += Dg_curves_CellDoubleClick;
            cb_Labels.CheckedChanged += cb_Labels_CheckedChanged;
            cb_ShowFuelControlled.CheckedChanged += cb_FuelControlled_CheckedChanged;
            cb_ShowVentilationControlled.CheckedChanged += cb_VentilationControlled_CheckedChanged;
            cb_Area.SelectedIndexChanged += cb_Area_SelectedIndexChanged;
            cb_OpeningFactor.SelectedIndexChanged += cb_OpeningFactor_SelectedIndexChanged;
            cb_Material.SelectedIndexChanged += cb_Material_SelectedIndexChanged;
            dg_curves.CellValueChanged += dg_curves_CellValueChanged; // Attach event
            this.KeyDown += CompareEurocodeCurvesForm_KeyDown;
            this.Resize += Form_Resize;
            PlotCSVFiles();  // Plot the curves
        }
        #endregion

        #region Form Load
        private void Form_Load(object sender, EventArgs e)
        {
            // Check the checkboxes when the form loads
            cb_ShowFuelControlled.Checked = true;
            cb_ShowVentilationControlled.Checked = true;
            cb_Labels.Checked = true;

            Form_Resize(sender, e);
        }
        #endregion

        #region Initialize DataGrid
        private void InitializeDataGridView()
        {
            // Clear existing rows
            dg_curves.Rows.Clear();

            // Add the Color column if not already added
            if (!dg_curves.Columns.Contains("Color"))
            {
                DataGridViewButtonColumn colorColumn = new DataGridViewButtonColumn();
                colorColumn.Name = "";
                colorColumn.HeaderText = "Color";
                colorColumn.FlatStyle = FlatStyle.Popup; // Make it look like a button
                dg_curves.Columns.Add(colorColumn);
            }

            // Ensure the Line Type column is already present and has the right items
            if (dg_curves.Columns.Contains("LineType"))
            {
                var lineTypeColumn = (DataGridViewComboBoxColumn)dg_curves.Columns["LineType"];
                // Check if the items are added, if not, add them
                if (lineTypeColumn.Items.Count == 0)
                {
                    lineTypeColumn.Items.AddRange(new object[]
                    {
                "Solid",
                "Dashed",
                "Dotted",
                "DashDotDot",
                "DashDot"
                    });
                }
            }


            // Populate the DataGridView with CSV file names without the '.csv' extension
            foreach (string filePath in filePaths)
            {
                // Get file name without extension
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                // Split the file name by spaces and take the first part as the curve name
                string curveName = fileNameWithoutExtension.Split(' ')[0];

                // Assign a unique color for each file for consistency
                if (!curvePens.ContainsKey(curveName))
                {
                    Random rand = new Random();
                    curvePens[curveName] = new Pen(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)), 2);
                }

                // Add a row and set the custom button cell
                int rowIndex = dg_curves.Rows.Add(new object[] { true, curveName, "", "", "Solid" }); // Default to Solid line type

                ColorButtonCell buttonCell = new ColorButtonCell();
                buttonCell.ButtonColor = curvePens[curveName].Color;
                dg_curves.Rows[rowIndex].Cells["Color"] = buttonCell;
                dg_curves.Rows[rowIndex].Cells["Color"].Value = ""; // Set the button text

                // Ensure the LineType column is assigned the default value if needed
                dg_curves.Rows[rowIndex].Cells["LineType"].Value = "Solid";
            }

            // Initialize ToolTip
            graphToolTip = new ToolTip();
            graphToolTip.AutoPopDelay = 5000;
            graphToolTip.InitialDelay = 100;
            graphToolTip.ReshowDelay = 100;
        }
        #endregion

        #region Import CSV Files
        private void ImportCsvFiles()
        {
            // Load each CSV file into an Eurocode object
            foreach (string filePath in filePaths)
            {
                Eurocode eurocodeCurve = new Eurocode();
                eurocodeCurve.InitializeFromCsv(filePath);

                // Split the file name by spaces to extract parts
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string[] nameParts = fileNameWithoutExtension.Split(' ');

                // Extract CurveName, FireType, and CurveCode
                eurocodeCurve.CurveName = nameParts[0];
                string fireTypePart = nameParts[1];
                eurocodeCurve.CurveCode = nameParts[2]; // Third part is the curve code

                // Parse the curve code to extract area, opening factor, and material
                eurocodeCurve.ParseCurveCode(eurocodeCurve.CurveCode);

                // Determine FireType based on file name
                eurocodeCurve.FireType = fireTypePart.Contains('V') ? "Ventilation" : fireTypePart.Contains('F') ? "Fuel" : "Unknown";

                // Add the Eurocode object to the dictionary
                eurocodeCurves[eurocodeCurve.CurveName] = eurocodeCurve;

                // Update the corresponding row in the DataGridView with the maximum temperature and fire type
                foreach (DataGridViewRow row in dg_curves.Rows)
                {
                    if (row.Cells[1].Value.ToString() == eurocodeCurve.CurveName)
                    {
                        row.Cells[2].Value = eurocodeCurve.MaximumTemperature.ToString("0.000", CultureInfo.InvariantCulture);
                        row.Cells[3].Value = eurocodeCurve.FireType;
                        row.Cells[4].Value = eurocodeCurve.CurveCode;
                        break;
                    }
                }
            }
        }

        #endregion

        #region Plot CSV Files
        private void PlotCSVFiles()
        {
            // Ensure the PictureBox control 'graph' is initialized
            if (graph == null)
            {
                MessageBox.Show("PictureBox control is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure comboboxes have valid selected items before using them
            if (cb_Area.SelectedItem == null || cb_Material.SelectedItem == null || cb_OpeningFactor.SelectedItem == null)
            {
                // MessageBox.Show("Please ensure that all filters (Area, Material, Opening Factor) are selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Create a bitmap with the size of the PictureBox
                Bitmap bmp = new Bitmap(graph.Width, graph.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    // Clear the background
                    g.Clear(Color.White);

                    // Set up drawing parameters
                    Pen axisPen = new Pen(Color.Black, 2);
                    Pen gridPen = new Pen(Color.LightGray, 1); // Pen for drawing grid lines
                    Font font = new Font("Arial", 10, FontStyle.Bold); // Larger font for better visibility
                    Brush brush = Brushes.Black;

                    // Increase the margin to provide space for X-axis labels
                    int margin = 40;
                    int xAxisOffset = 20; // Additional space above the x-axis

                    // Draw X and Y axis with increased margins
                    g.DrawLine(axisPen, margin, graph.Height - margin - xAxisOffset, graph.Width - margin, graph.Height - margin - xAxisOffset); // X Axis
                    g.DrawLine(axisPen, margin, graph.Height - margin - xAxisOffset, margin, margin); // Y Axis

                    // Initialize variables to track global max values for scaling
                    double globalMaxTime = 180 * 60; // Default max time (180 minutes in seconds)
                    double globalMaxTemp = 1000; // Default max temperature

                    // Retrieve selected values from combo boxes, ensuring they are not null
                    selectedArea = cb_Area.SelectedItem != null ? cb_Area.SelectedItem.ToString() : "All";
                    selectedMaterial = cb_Material.SelectedItem != null ? cb_Material.SelectedItem.ToString() : "All";
                    selectedOpeningFactor = cb_OpeningFactor.SelectedItem != null ? cb_OpeningFactor.SelectedItem.ToString() : "All";

                    // Draw axis labels and values
                    g.DrawString("Time (minutes)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 10); // Adjusted Y position
                    g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);

                    // First, find the global max values across all selected files with filtering
                    bool anyCurveSelected = false; // Check if any curve is selected
                    foreach (DataGridViewRow row in dg_curves.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value)) // Check if the checkbox is selected
                        {
                            string fireType = row.Cells[3].Value.ToString();
                            if ((fireType == "Fuel" && !cb_ShowFuelControlled.Checked) ||
                                (fireType == "Ventilation" && !cb_ShowVentilationControlled.Checked))
                            {
                                continue; // Skip drawing if the checkbox is unchecked for this fire type
                            }

                            // Ensure the curve name is valid before accessing the dictionary
                            string curveName = row.Cells[1].Value?.ToString();
                            if (string.IsNullOrEmpty(curveName) || !eurocodeCurves.ContainsKey(curveName))
                            {
                                MessageBox.Show($"Curve {curveName} does not exist in the dictionary.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            // Get the curve object
                            Eurocode eurocodeCurve = eurocodeCurves[curveName];

                            // Check if curve matches the selected filter
                            if (!CurveMatchesFilter(eurocodeCurve, selectedArea, selectedMaterial, selectedOpeningFactor))
                            {
                                continue; // Skip the curve if it doesn't match the selected filters
                            }

                            anyCurveSelected = true;

                            // Update global max values
                            if (eurocodeCurve.Times.Count > 0) globalMaxTime = Math.Max(globalMaxTime, eurocodeCurve.Times.Max());
                            if (eurocodeCurve.Temperatures.Count > 0) globalMaxTemp = Math.Max(globalMaxTemp, eurocodeCurve.Temperatures.Max());
                        }
                    }

                    // Reset to default scale if no curve is selected
                    if (!anyCurveSelected)
                    {
                        globalMaxTime = 180 * 60; // 180 minutes in seconds
                        globalMaxTemp = 1000;
                    }

                    // Scaling factors
                    float xScale = (graph.Width - 2 * margin) / (float)(globalMaxTime / 60); // Convert max time to minutes
                    float yScale = (graph.Height - 2 * margin - xAxisOffset) / (float)globalMaxTemp; // Y-axis scale remains fixed

                    // Draw grid lines and tick marks for X-axis
                    float tickSpacingX = (float)(globalMaxTime / 60) / 10; // Fixed number of intervals
                    for (int i = 0; i <= 10; i++)
                    {
                        float xPos = margin + i * tickSpacingX * xScale; // Adjust based on xScale
                        g.DrawLine(gridPen, xPos, margin, xPos, graph.Height - margin - xAxisOffset); // Vertical grid line

                        // Draw tick marks and labels
                        g.DrawLine(axisPen, xPos, graph.Height - margin - xAxisOffset, xPos, graph.Height - margin - xAxisOffset + 5);
                        g.DrawString((tickSpacingX * i).ToString("0.0"), font, brush, xPos - 10, graph.Height - margin - xAxisOffset + 10);
                    }

                    // Draw grid lines and tick marks for Y-axis
                    float tickSpacingY = (float)(globalMaxTemp) / 10; // Fixed number of intervals
                    for (int i = 0; i <= 10; i++)
                    {
                        float yPos = graph.Height - margin - xAxisOffset - i * tickSpacingY * yScale; // Fixed y position
                        g.DrawLine(gridPen, margin, yPos, graph.Width - margin, yPos); // Horizontal grid line

                        // Draw tick marks and labels
                        g.DrawLine(axisPen, margin - 5, yPos, margin, yPos);
                        g.DrawString((tickSpacingY * i).ToString("0"), font, brush, 5, yPos - 10);
                    }

                    // Now, draw each selected file with the filtering logic applied
                    // Now, draw each selected file with the filtering logic applied
                    foreach (DataGridViewRow row in dg_curves.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value)) // Check if the checkbox is selected
                        {
                            string fireType = row.Cells[3].Value.ToString();
                            if ((fireType == "Fuel" && !cb_ShowFuelControlled.Checked) ||
                                (fireType == "Ventilation" && !cb_ShowVentilationControlled.Checked))
                            {
                                continue;
                            }

                            string curveName = row.Cells[1].Value.ToString();

                            if (eurocodeCurves.ContainsKey(curveName))
                            {
                                Eurocode eurocodeCurve = eurocodeCurves[curveName];

                                // Apply filtering conditions
                                if (!CurveMatchesFilter(eurocodeCurve, selectedArea, selectedMaterial, selectedOpeningFactor))
                                {
                                    continue; // Skip this curve if it doesn't match the filter
                                }

                                Pen graphPen = curvePens[eurocodeCurve.CurveName];

                                // Adjust the pen width to ensure visibility of the dashed lines (optional)
                                graphPen.Width = 2; // You can adjust this value if needed


                                // Draw the curve
                                if (eurocodeCurve.Times.Count > 1)
                                {
                                    List<PointF> points = new List<PointF>();
                                    for (int i = 0; i < eurocodeCurve.Times.Count; i++)
                                    {
                                        float x = margin + (float)(eurocodeCurve.Times[i] / 60 * xScale); // Convert time to minutes
                                        float y = graph.Height - margin - xAxisOffset - (float)(eurocodeCurve.Temperatures[i] * yScale);
                                        points.Add(new PointF(x, y));
                                    }

                                    // Draw lines using the updated Pen (graphPen)
                                    for (int i = 1; i < points.Count; i++)
                                    {
                                        g.DrawLine(graphPen, points[i - 1], points[i]);
                                    }

                                    // Draw labels (if required)
                                    if (cb_Labels.Checked)
                                    {
                                        int peakIndex = eurocodeCurve.Temperatures.IndexOf(eurocodeCurve.MaximumTemperature);
                                        if (peakIndex >= 0 && peakIndex < points.Count)
                                        {
                                            PointF labelPosition = points[peakIndex];
                                            g.DrawString(eurocodeCurve.CurveName, font, new SolidBrush(graphPen.Color), labelPosition.X + 5, labelPosition.Y - 15);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Curve {curveName} does not exist in the dictionary.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                }

                // Display the bitmap in the PictureBox
                graph.Image = bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while plotting the graphs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Populate ComboBoxes
        private void PopulateComboBoxes()
        {
            // Populate Area ComboBox
            var distinctAreas = eurocodeCurves.Values
                                .Where(c => c.Area != null)
                                .Select(c => c.Area.ToString())
                                .Distinct()
                                .ToList();

            if (distinctAreas.Count > 0)
            {
                cb_Area.Items.Clear();
                cb_Area.Items.Add("All");
                cb_Area.Items.AddRange(distinctAreas.ToArray());
                cb_Area.SelectedIndex = 0;
            }

            // Populate Material ComboBox
            var distinctMaterials = eurocodeCurves.Values
                                  .Where(c => c.Material != null)
                                  .Select(c => c.Material)
                                  .Distinct()
                                  .ToList();

            if (distinctMaterials.Count > 0)
            {
                cb_Material.Items.Clear();
                cb_Material.Items.Add("All");
                cb_Material.Items.AddRange(distinctMaterials.ToArray());
                cb_Material.SelectedIndex = 0;
            }

            // Populate Opening Factor ComboBox
            var distinctOpeningFactors = eurocodeCurves.Values
                                        .Where(c => c.OpeningFactor != null)
                                        .Select(c => c.OpeningFactor.ToString())
                                        .Distinct()
                                        .ToList();

            if (distinctOpeningFactors.Count > 0)
            {
                cb_OpeningFactor.Items.Clear();
                cb_OpeningFactor.Items.Add("All");
                cb_OpeningFactor.Items.AddRange(distinctOpeningFactors.ToArray());
                cb_OpeningFactor.SelectedIndex = 0;
            }
        }
        #endregion

        #region Handle Line Type Selection
        private void dg_curves_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the changed column is the Line Type column
            if (dg_curves.Columns[e.ColumnIndex].Name == "LineType" && e.RowIndex >= 0)
            {
                string selectedLineType = dg_curves.Rows[e.RowIndex].Cells["LineType"].Value.ToString();
                string curveName = dg_curves.Rows[e.RowIndex].Cells[1].Value.ToString(); // Assuming second column has the curve name

                if (curvePens.ContainsKey(curveName))
                {
                    // Change the line style based on the selected line type
                    switch (selectedLineType)
                    {
                        case "Solid":
                            curvePens[curveName].DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                            break;
                        case "Dashed":
                            curvePens[curveName].DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            break;
                        case "Dotted":
                            curvePens[curveName].DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            break;
                        case "DashDot":
                            curvePens[curveName].DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                            break;
                        case "DashDotDot":
                            curvePens[curveName].DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                            break;
                    }

                    // Redraw the graph after changing the line style
                    PlotCSVFiles();
                    Form_Resize(sender, e);
                }
            }
        }


        #endregion

        #region Helpers and Filters
        private bool CurveMatchesFilter(Eurocode curve, string selectedArea, string selectedMaterial, string selectedOpeningFactor)
        {
            bool areaMatches = selectedArea == "All" || curve.Area.ToString() == selectedArea;
            bool materialMatches = selectedMaterial == "All" || curve.Material == selectedMaterial;
            bool openingFactorMatches = selectedOpeningFactor == "All" || curve.OpeningFactor.ToString() == selectedOpeningFactor;

            return areaMatches && materialMatches && openingFactorMatches;
        }


        #endregion

        #region CheckBox Change Methods
        private void cb_Labels_CheckedChanged(object sender, EventArgs e)
        {
            PlotCSVFiles(); // Redraw the graph with or without labels based on the checkbox state
            Form_Resize(sender, e);
        }

        private void cb_FuelControlled_CheckedChanged(object sender, EventArgs e)
        {
            PlotCSVFiles(); // Redraw the graph to show or hide fuel controlled curves
            Form_Resize(sender, e);
        }

        private void cb_VentilationControlled_CheckedChanged(object sender, EventArgs e)
        {
            PlotCSVFiles(); // Redraw the graph to show or hide ventilation controlled curves
            Form_Resize(sender, e);
        }

        private void cb_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlotCSVFiles(); // Update graph when Area changes
            Form_Resize(sender, e);
        }

        private void cb_Material_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlotCSVFiles(); // Update graph when Material changes
            Form_Resize(sender, e);
        }

        private void cb_OpeningFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlotCSVFiles(); // Update graph when Opening Factor changes
            Form_Resize(sender, e);
        }

        #endregion

        #region Data Gridview CheckBox
        private void Dg_curves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Ensure the click is on a checkbox
            {
                // Toggle the checked state
                bool isChecked = Convert.ToBoolean(dg_curves.Rows[e.RowIndex].Cells[0].Value);
                dg_curves.Rows[e.RowIndex].Cells[0].Value = !isChecked;

                PlotCSVFiles(); // Redraw the graph based on updated checkbox selections
            }
        }
        #endregion

        #region Color Cell Click
        private void Dg_curves_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the "Color" column
            if (e.ColumnIndex == dg_curves.Columns["Color"].Index && e.RowIndex >= 0)
            {
                // Open the color dialog
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the selected curve's name from the corresponding row
                        string curveName = dg_curves.Rows[e.RowIndex].Cells[1].Value.ToString();

                        // Update the color in the curvePens dictionary
                        if (curvePens.ContainsKey(curveName))
                        {
                            curvePens[curveName] = new Pen(colorDialog.Color, 2);

                            // Update the color display in the ColorButtonCell
                            ColorButtonCell buttonCell = (ColorButtonCell)dg_curves.Rows[e.RowIndex].Cells["Color"];
                            buttonCell.ButtonColor = colorDialog.Color;

                            // Force the grid to repaint the button with the new color
                            dg_curves.InvalidateCell(buttonCell);

                            // Redraw the graph with the new color
                            PlotCSVFiles();
                            Form_Resize(sender, e);
                        }
                    }
                }
            }
        }


        #endregion

        #region Cell Double Click For Highlight
        private void Dg_curves_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row index is clicked
            if (e.RowIndex >= 0 && e.RowIndex < dg_curves.Rows.Count)
            {
                // Retrieve the curve name from the clicked row
                string selectedCurveName = dg_curves.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (!string.IsNullOrEmpty(selectedCurveName))
                {
                    // If another curve was highlighted before, reset the graph first
                    if (highlightedCurveName != null)
                    {
                        PlotCSVFiles(); // Redraw the graph to clear previous highlighting
                    }

                    // Highlight the selected curve by fading out the others
                    PlotHighlightedCurve(selectedCurveName);

                    // Set the selected curve as the currently highlighted curve
                    highlightedCurveName = selectedCurveName;

                    // Handle any further UI updates, if needed (e.g., resizing)
                    //Form_Resize(sender, e);
                }
            }
        }
        #endregion

        #region Plot Highlight Curve
        private void PlotHighlightedCurve(string selectedCurveName)
        {
            // Ensure the PictureBox control 'graph' is initialized
            if (graph == null)
            {
                MessageBox.Show("PictureBox control is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure comboboxes have valid selected items before using them
            if (cb_Area.SelectedItem == null || cb_Material.SelectedItem == null || cb_OpeningFactor.SelectedItem == null)
            {
                MessageBox.Show("Please ensure that all filters (Area, Material, Opening Factor) are selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Create a bitmap with the size of the PictureBox
                Bitmap bmp = new Bitmap(graph.Width, graph.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    // Clear the background
                    g.Clear(Color.White);

                    // Set up drawing parameters
                    Pen axisPen = new Pen(Color.Black, 2);
                    Pen gridPen = new Pen(Color.LightGray, 1); // Pen for drawing grid lines
                    Font font = new Font("Arial", 10, FontStyle.Bold); // Larger font for better visibility
                    Brush brush = Brushes.Black;

                    // Increase the margin to provide space for X-axis labels
                    int margin = 40;
                    int xAxisOffset = 20; // Additional space above the x-axis

                    // Draw X and Y axis with increased margins
                    g.DrawLine(axisPen, margin, graph.Height - margin - xAxisOffset, graph.Width - margin, graph.Height - margin - xAxisOffset); // X Axis
                    g.DrawLine(axisPen, margin, graph.Height - margin - xAxisOffset, margin, margin); // Y Axis

                    // Initialize variables to track global max values for scaling
                    double globalMaxTime = 180 * 60; // Default max time (180 minutes in seconds)
                    double globalMaxTemp = 1000; // Default max temperature

                    // Retrieve selected values from combo boxes
                    selectedArea = cb_Area.SelectedItem != null ? cb_Area.SelectedItem.ToString() : "All";
                    selectedMaterial = cb_Material.SelectedItem != null ? cb_Material.SelectedItem.ToString() : "All";
                    selectedOpeningFactor = cb_OpeningFactor.SelectedItem != null ? cb_OpeningFactor.SelectedItem.ToString() : "All";

                    // Draw axis labels and values
                    g.DrawString("Time (minutes)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 10); // Adjusted Y position
                    g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);

                    // First, find the global max values across all selected files with filtering
                    bool anyCurveSelected = false; // Check if any curve is selected
                    foreach (DataGridViewRow row in dg_curves.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value)) // Check if the checkbox is selected
                        {
                            string fireType = row.Cells[3].Value.ToString();
                            if ((fireType == "Fuel" && !cb_ShowFuelControlled.Checked) ||
                                (fireType == "Ventilation" && !cb_ShowVentilationControlled.Checked))
                            {
                                continue; // Skip drawing if the checkbox is unchecked for this fire type
                            }

                            // Ensure the curve name is valid before accessing the dictionary
                            string curveName = row.Cells[1].Value?.ToString();
                            if (string.IsNullOrEmpty(curveName) || !eurocodeCurves.ContainsKey(curveName))
                            {
                                MessageBox.Show($"Curve {curveName} does not exist in the dictionary.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            // Get the curve object
                            Eurocode eurocodeCurve = eurocodeCurves[curveName];

                            // Check if curve matches the selected filter
                            if (!CurveMatchesFilter(eurocodeCurve, selectedArea, selectedMaterial, selectedOpeningFactor))
                            {
                                continue; // Skip the curve if it doesn't match the selected filters
                            }

                            anyCurveSelected = true;

                            // Update global max values
                            if (eurocodeCurve.Times.Count > 0) globalMaxTime = Math.Max(globalMaxTime, eurocodeCurve.Times.Max());
                            if (eurocodeCurve.Temperatures.Count > 0) globalMaxTemp = Math.Max(globalMaxTemp, eurocodeCurve.Temperatures.Max());
                        }
                    }

                    // Reset to default scale if no curve is selected
                    if (!anyCurveSelected)
                    {
                        globalMaxTime = 180 * 60; // 180 minutes in seconds
                        globalMaxTemp = 1000;
                    }

                    // Scaling factors
                    float xScale = (graph.Width - 2 * margin) / (float)(globalMaxTime / 60); // Convert max time to minutes
                    float yScale = (graph.Height - 2 * margin - xAxisOffset) / (float)globalMaxTemp; // Y-axis scale remains fixed

                    // Draw grid lines and tick marks for X-axis
                    float tickSpacingX = (float)(globalMaxTime / 60) / 10; // Fixed number of intervals
                    for (int i = 0; i <= 10; i++)
                    {
                        float xPos = margin + i * tickSpacingX * xScale; // Adjust based on xScale
                        g.DrawLine(gridPen, xPos, margin, xPos, graph.Height - margin - xAxisOffset); // Vertical grid line

                        // Draw tick marks and labels
                        g.DrawLine(axisPen, xPos, graph.Height - margin - xAxisOffset, xPos, graph.Height - margin - xAxisOffset + 5);
                        g.DrawString((tickSpacingX * i).ToString("0.0"), font, brush, xPos - 10, graph.Height - margin - xAxisOffset + 10);
                    }

                    // Draw grid lines and tick marks for Y-axis
                    float tickSpacingY = (float)(globalMaxTemp) / 10; // Fixed number of intervals
                    for (int i = 0; i <= 10; i++)
                    {
                        float yPos = graph.Height - margin - xAxisOffset - i * tickSpacingY * yScale; // Fixed y position
                        g.DrawLine(gridPen, margin, yPos, graph.Width - margin, yPos); // Horizontal grid line

                        // Draw tick marks and labels
                        g.DrawLine(axisPen, margin - 5, yPos, margin, yPos);
                        g.DrawString((tickSpacingY * i).ToString("0"), font, brush, 5, yPos - 10);
                    }

                    // Now, draw each selected file with the filtering logic applied
                    foreach (DataGridViewRow row in dg_curves.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value)) // Check if the checkbox is selected
                        {
                            string fireType = row.Cells[3].Value.ToString();
                            if ((fireType == "Fuel" && !cb_ShowFuelControlled.Checked) ||
                                (fireType == "Ventilation" && !cb_ShowVentilationControlled.Checked))
                            {
                                continue;
                            }

                            string curveName = row.Cells[1].Value.ToString();

                            if (eurocodeCurves.ContainsKey(curveName))
                            {
                                Eurocode eurocodeCurve = eurocodeCurves[curveName];

                                // Apply filtering conditions
                                if (!CurveMatchesFilter(eurocodeCurve, selectedArea, selectedMaterial, selectedOpeningFactor))
                                {
                                    continue; // Skip this curve if it doesn't match the filter
                                }

                                // Create a temporary pen to adjust the opacity without changing the original `curvePens`
                                Pen tempPen = new Pen(curvePens[eurocodeCurve.CurveName].Color, 2);

                                // Check if this is the selected curve to highlight
                                if (curveName != selectedCurveName)
                                {
                                    // Fade out other curves by making them transparent
                                    tempPen.Color = Color.FromArgb(30, tempPen.Color); // Reduce opacity
                                }

                                // Draw the curve
                                if (eurocodeCurve.Times.Count > 1)
                                {
                                    List<PointF> points = new List<PointF>();
                                    for (int i = 0; i < eurocodeCurve.Times.Count; i++)
                                    {
                                        float x = margin + (float)(eurocodeCurve.Times[i] / 60 * xScale); // Convert time to minutes
                                        float y = graph.Height - margin - xAxisOffset - (float)(eurocodeCurve.Temperatures[i] * yScale);
                                        points.Add(new PointF(x, y));
                                    }

                                    // Draw lines
                                    for (int i = 1; i < points.Count; i++)
                                    {
                                        g.DrawLine(tempPen, points[i - 1], points[i]);
                                    }

                                    // Draw labels only for the selected curve
                                    if (cb_Labels.Checked && curveName == selectedCurveName)
                                    {
                                        int peakIndex = eurocodeCurve.Temperatures.IndexOf(eurocodeCurve.MaximumTemperature);
                                        if (peakIndex >= 0 && peakIndex < points.Count)
                                        {
                                            PointF labelPosition = points[peakIndex];
                                            g.DrawString(eurocodeCurve.CurveName, font, new SolidBrush(tempPen.Color), labelPosition.X + 5, labelPosition.Y - 15);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Curve {curveName} does not exist in the dictionary.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

                // Display the bitmap in the PictureBox
                graph.Image = bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while plotting the graph: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Reset Highlight 
        private void CompareEurocodeCurvesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && highlightedCurveName != null)
            {
                // Reset the graph to its normal state
                PlotCSVFiles();
                Form_Resize(sender, e);

                // Clear the highlighted curve state
                highlightedCurveName = null;
            }
        }
        #endregion

        #region Form Resize
        private void Form_Resize(object sender, EventArgs e)
        {
            PlotCSVFiles(); // Redraw the graph when the form is resized
        }
        #endregion

        #region Export Form Screenshot
        private void btn_exportGraph_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a bitmap with the size of the entire form including borders and title bar
                using (Bitmap bmp = new Bitmap(this.Bounds.Width, this.Bounds.Height))
                {
                    // Draw the entire form (including non-client areas like title bar and borders) onto the bitmap
                    this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                    // Create a SaveFileDialog to allow the user to select the save location and file format
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Title = "Save Form Screenshot";
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

                                // Save the image of the entire form including the title bar and borders
                                bmp.Save(saveFileDialog.FileName, format);
                                MessageBox.Show("Form screenshot saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred while saving the screenshot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while capturing the screenshot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Mouse Move
        private void graph_MouseMove(object sender, MouseEventArgs e)
        {
            if (graph.Image == null) return; // If no image is drawn, return

            // Calculate mouse position relative to the graph
            int margin = 40;
            int xAxisOffset = 20;
            float maxX = 360; // Max time in minutes
            float maxY = 1000; // Max temperature

            float xScale = (graph.Width - 2 * margin) / maxX; // X-axis scaling factor (minutes)
            float yScale = (graph.Height - 2 * margin - xAxisOffset) / maxY; // Y-axis scaling factor

            // Calculate the x (time in minutes) and y (temperature) values based on mouse position
            double mouseTime = (e.X - margin) / xScale; // Time in minutes
            double mouseTemp = (graph.Height - margin - xAxisOffset - e.Y) / yScale;

            // Prepare the tooltip text
            StringBuilder tooltipText = new StringBuilder();
            tooltipText.AppendLine($"Time: {mouseTime:F2} min");

            // Iterate over each selected curve
            foreach (DataGridViewRow row in dg_curves.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // If the checkbox is selected
                {
                    string fireType = row.Cells[3].Value.ToString();
                    if ((fireType == "Fuel" && !cb_ShowFuelControlled.Checked) ||
                        (fireType == "Ventilation" && !cb_ShowVentilationControlled.Checked))
                    {
                        continue; // Skip this curve if its type is not checked
                    }

                    string curveName = row.Cells[1].Value.ToString();
                    if (!eurocodeCurves.ContainsKey(curveName))
                        continue; // If curve not found, skip

                    Eurocode eurocodeCurve = eurocodeCurves[curveName];
                    List<double> times = eurocodeCurve.Times;
                    List<double> temps = eurocodeCurve.Temperatures;

                    // Find the closest data point to the mouse position for the current curve
                    int closestIndex = GetClosestIndex(times, mouseTime * 60); // Convert mouseTime to seconds
                    double actualTemp = temps[closestIndex];

                    // Append curve name and its corresponding temperature
                    tooltipText.AppendLine($"{curveName} Temp: {actualTemp:F2} °C");
                }
            }

            // Show ToolTip with actual time and temperatures for all curves
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
        #endregion

        #region Graph Click
        private void graph_Click(object sender, EventArgs e)
        {
            EurocodeCurveTempValue eurocodeCurveTempValue = new EurocodeCurveTempValue(eurocodeCurves);
            eurocodeCurveTempValue.ShowDialog();
        }
        #endregion
    }

    #region Color Button Class
    public class ColorButtonCell : DataGridViewButtonCell
    {
        public Color ButtonColor { get; set; }

        // Override the Paint method to draw the button in the desired color
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            // Draw the background
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.Background);

            // Draw the custom colored button
            ButtonRenderer.DrawButton(graphics, cellBounds, PushButtonState.Normal);
            using (Brush brush = new SolidBrush(ButtonColor))
            {
                graphics.FillRectangle(brush, cellBounds.Left + 2, cellBounds.Top + 2, cellBounds.Width - 4, cellBounds.Height - 4);
            }

            // Draw the button text
            TextRenderer.DrawText(graphics, (string)formattedValue, cellStyle.Font, cellBounds, cellStyle.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
    #endregion

}