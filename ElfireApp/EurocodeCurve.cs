using ElfireApp.Data;
using ElfireApp.Forms;
using System.Windows.Forms;
using ElfireApp.Properties;
using System.Windows.Forms.VisualStyles;
using ElfireApp.Curves;
using System.Linq;
using WIA;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Forms;
using System.Drawing;
using Control = System.Windows.Forms.Control;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Office.CustomUI;
using ComboBox = System.Windows.Forms.ComboBox;
using mshtml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ElfireApp
{
    public partial class EurocodeCurve : UserControl
    {

        #region Properties and Variables

        private MaterialData _materialData;

        private DesignFireLoadData _designFireLoadData;

        private ROFI_OccupancyData _occupancyData;

        private ROFI_FloorAreaData _floorAreaData;

        private Geometry _geometry;

        private Design _design;

        private Thermalnertia thermalnertia;

        private Opening _opening;

        private Material _material;

        private string Ventilation_CompartmentValuesText { get; set; }
        private string Fuel_CompartmentValuesText { get; set; }

        private Eurocode Eurocode { get; set; }

        private ExportAllValues exportAllValues;

        private ToolTip graphToolTip;

        private string FilePath;

        CompareCurvesWithEurocode compareCurvesWithEurocode;

        #endregion

        #region CTOR
        public EurocodeCurve(string CurveName)
        {
            InitializeComponent();
            _materialData = new MaterialData();
            _designFireLoadData = new DesignFireLoadData();
            _occupancyData = new ROFI_OccupancyData();
            _floorAreaData = new ROFI_FloorAreaData();
            _geometry = new Geometry();
            _design = new Design();
            _material = new Material();
            _opening = new Opening();

            Eurocode = new Eurocode();
            thermalnertia = new Thermalnertia();

            compareCurvesWithEurocode = new CompareCurvesWithEurocode();

            Ventilation_CompartmentValuesText = "";
            Fuel_CompartmentValuesText = "";

            // Initialize controls first
            tab_Opening.Enabled = false;
            gb_MaterialProperties_2.Enabled = false;
            tl_DesignFireLoadProperties.Enabled = false;

            txt_ActiveSuppressionCoefficient.Enabled = false;
            txt_CombustionFactor.Enabled = false;
            txt_FireDuration.Enabled = false;
            btn_CalculateEurocode.Enabled = false;
            btn_CompareCurves.Enabled = false;

            btn_ExportCSV.Enabled = false;
            btn_ExportHTML.Enabled = false;
            btn_ExportPackage.Enabled = false;
            btn_ExportTxt.Enabled = false;
            btn_Save.Enabled = false;

            graphToolTip = new ToolTip();
            graphToolTip.AutoPopDelay = 5000;
            graphToolTip.InitialDelay = 100;
            graphToolTip.ReshowDelay = 100;

            Eurocode.CurveName = CurveName;
            txt_CurveName.Text = CurveName;

            exportAllValues = new ExportAllValues();

            // Attach MouseMove event to display ToolTip
            graph.MouseMove += graph_MouseMove;
        }

        #endregion

        #region Main Screen Load
        private void MainScreen_Load(object sender, EventArgs e)
        {

            UpdateComboBoxes();
            UpdateDesignValues();
            UpdateROFI_OccupancyValues();
            UpdateROFI_FloorAreaValues();
        }
        #endregion

        #region Material and Thermal Methods

        #region Update Material ComboBoxes
        private void UpdateComboBoxes()
        {
            if (_materialData == null || cb_Ceiling == null || cb_Floor == null || cb_Walls == null)
            {
                MessageBox.Show("Material data or combo boxes are not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var materialsList = _materialData.GetMaterialsList();
            if (materialsList == null || materialsList.Count == 0)
            {
                MessageBox.Show("Materials list is empty or not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BindingSource bindingSourceCeiling = new BindingSource { DataSource = materialsList };
            BindingSource bindingSourceFloor = new BindingSource { DataSource = materialsList };
            BindingSource bindingSourceWalls = new BindingSource { DataSource = materialsList };

            cb_Ceiling.DataSource = bindingSourceCeiling;
            cb_Floor.DataSource = bindingSourceFloor;
            cb_Walls.DataSource = bindingSourceWalls;

            cb_Ceiling.DisplayMember = "Name";
            cb_Floor.DisplayMember = "Name";
            cb_Walls.DisplayMember = "Name";
        }

        #endregion

        #region New Material
        private void btn_NewMaterial_Click(object sender, EventArgs e)
        {
            NewMaterial newMaterial = new NewMaterial(_materialData, UpdateComboBoxes);
            newMaterial.ShowDialog();
        }
        #endregion

        #region Edit Material
        private void btn_EditMaterial_Click(object sender, EventArgs e)
        {
            EditMaterial editMaterial = new EditMaterial(_materialData, UpdateComboBoxes);
            editMaterial.ShowDialog();
        }
        #endregion

        #region Calculate Thermal Inertia
        private void btn_CalculateThermalInertia_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected materials from the combo boxes
                Material ceilingMaterial = cb_Ceiling.SelectedItem as Material;
                Material floorMaterial = cb_Floor.SelectedItem as Material;
                Material wallsMaterial = cb_Walls.SelectedItem as Material;

                exportAllValues.WallMaterial = wallsMaterial;
                exportAllValues.FloorMaterial = floorMaterial;
                exportAllValues.CeilingMaterial = ceilingMaterial;

                if (ceilingMaterial == null || floorMaterial == null || wallsMaterial == null)
                {
                    MessageBox.Show("Please select materials for ceiling, floor, and walls.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_geometry != null)
                {
                    double floorArea = this._geometry.FloorArea;
                    double wallArea = this._geometry.WallsArea;
                    double ceilingArea = this._geometry.CeilingArea;
                    double enclosureArea = this._geometry.EnclosureArea;

                    double wallThermalInertia = wallsMaterial.ThermalInertia;
                    double ceilingThermalInertia = ceilingMaterial.ThermalInertia;
                    double floorThermalInertia = floorMaterial.ThermalInertia;

                    if ((wallThermalInertia >= 100.00 && wallThermalInertia <= 2200.00)
                        && (ceilingThermalInertia >= 100.00 && ceilingThermalInertia <= 2200.00)
                        && (floorThermalInertia >= 100.00 && floorThermalInertia <= 2200.00))
                    {
                        _material.CompartmentThermalInertia = ((floorArea * floorThermalInertia) +
                             (ceilingArea * ceilingThermalInertia) +
                             ((wallArea - _opening.OpeningArea) * wallThermalInertia))
                             / (enclosureArea - _opening.OpeningArea);

                        lbl_WallThermalInertia.Text = wallThermalInertia.ToString("0.00");
                        lbl_FloorThermalInertia.Text = floorThermalInertia.ToString("0.00");
                        lbl_CeilingThermalInertia.Text = ceilingThermalInertia.ToString("0.00");

                        lbl_CompartmentThermalInertia.Text = _material.CompartmentThermalInertia.ToString("0.00");

                        tl_DesignFireLoadProperties.Enabled = true;

                        _material.WallThermalInertia = wallThermalInertia;
                        _material.FloorThermalInertia = floorThermalInertia;
                        _material.CeilingThermalInertia = ceilingThermalInertia;

                    }
                    else
                    {
                        MessageBox.Show("Material thermal inertia values need to be between 100 and 2200.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please add room dimensions first.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Show All Material List
        private void btn_ShowAllMaterials_Click(object sender, EventArgs e)
        {
            ShowAllMaterial showAllMaterial = new ShowAllMaterial(_materialData);
            showAllMaterial.ShowDialog();
        }
        #endregion

        #endregion

        #region Geometrical Methods

        #region Calculate Compartment Area
        private void btn_CalculateAreas_Click(object sender, EventArgs e)
        {
            try
            {
                double length = double.Parse(txt_Length.Text);
                double width = double.Parse(txt_Width.Text);
                double height = double.Parse(txt_Height.Text);

                this._geometry = new Geometry(length, width, height);

                lbl_FloorArea.Text = _geometry.FloorArea.ToString("0.00");
                lbl_WallsArea.Text = _geometry.WallsArea.ToString("0.00");
                lbl_BoundaryArea.Text = _geometry.EnclosureArea.ToString("0.00");

                tab_Opening.Enabled = true;

                if (_geometry.FloorArea < 250)
                {
                    cb_ROFI_FloorArea.Text = "25";
                }
                else if (_geometry.FloorArea < 2500)
                {
                    cb_ROFI_FloorArea.Text = "250";
                }
                else if (_geometry.FloorArea < 5000)
                {
                    cb_ROFI_FloorArea.Text = "2500";
                }
                else if (_geometry.FloorArea < 10000)
                {
                    cb_ROFI_FloorArea.Text = "5000";
                }
                else
                {
                    cb_ROFI_FloorArea.Text = "10000";
                }

                cb_ROFI_FloorArea.Enabled = false;

            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numerical values for length, width, and height.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Height.Text = string.Empty;
                txt_Width.Text = string.Empty;
                txt_Length.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region Opening Methods

        #region Add Opening to Table
        private void btn_AddOpening_Click(object sender, EventArgs e)
        {
            // Create a new row
            int rowIndex = dg_openings.Rows.Add();
        }
        #endregion

        #region Delete Opening from Table
        private void btn_DeleteOpening_Click(object sender, EventArgs e)
        {
            // Check if a cell is selected
            if (dg_openings.SelectedCells.Count > 0)
            {
                // Get the row index of the selected cell
                int rowIndex = dg_openings.SelectedCells[0].RowIndex;

                // Remove the row at the selected cell's row index
                dg_openings.Rows.RemoveAt(rowIndex);
            }
            else
            {
                MessageBox.Show("Please select a cell to delete the corresponding row.", "No Cell Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Calculate Opening Properties by Opening Factor
        private void btn_ApplyOpeningFactor_Click(object sender, EventArgs e)
        {
            try
            {
                double totalArea = _geometry.EnclosureArea;
                double compartmentHeight = _geometry.Height;

                if (double.TryParse(txt_MinimumAverageHeight.Text, out double minimumAverageHeight) &&
                    double.TryParse(txt_OpeningFactor.Text, out double openingFactor))
                {
                    minimumAverageHeight /= 100.0;

                    if (minimumAverageHeight > compartmentHeight)
                    {
                        MessageBox.Show("Please enter a minimum height value smaller than compartment height.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _opening.AverageHeight = minimumAverageHeight;
                    _opening.OpeningFactor = openingFactor;

                    // Initialize random number generator
                    Random random = new Random();
                    double averageHeight = minimumAverageHeight + random.NextDouble() * (compartmentHeight - minimumAverageHeight);

                    // Calculate opening area
                    double openingArea = (_opening.OpeningFactor * totalArea) / Math.Sqrt(averageHeight);

                    // Display results in labels
                    lbl_AverageHeight.Text = averageHeight.ToString("F2"); // Format to 2 decimal places
                    lbl_OpeningFactor.Text = openingFactor.ToString("F2");
                    lbl_OpeningArea.Text = openingArea.ToString("F2");

                    gb_MaterialProperties_2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please enter valid numerical values for Minimum Average Height and Opening Factor.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numerical values for Minimum Average Height and Opening Factor.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Calculate Opening Factor by Opening Area and Average Height
        private void btn_CalculateOpeningFactor_Click(object sender, EventArgs e)
        {
            try
            {
                // Convert Average Height from centimeters to meters
                _opening.AverageHeight = double.Parse(txt_AverageHeight.Text) / 100;
                _opening.OpeningArea = double.Parse(txt_OpeningArea.Text);

                if (_geometry != null)
                {
                    double wallsArea = _geometry.WallsArea;
                    double compartmentHeight = _geometry.Height;

                    if (_opening.AverageHeight <= compartmentHeight)
                    {
                        if (_opening.OpeningArea < wallsArea)
                        {
                            // Calculate the Opening Factor
                            _opening.OpeningFactor = (_opening.OpeningArea * Math.Sqrt(_opening.AverageHeight)) / this._geometry.EnclosureArea;

                            // Display the results
                            lbl_OpeningFactor.Text = _opening.OpeningFactor.ToString("0.00");
                            lbl_OpeningArea.Text = _opening.OpeningArea.ToString("0.00");
                            lbl_AverageHeight.Text = _opening.AverageHeight.ToString("0.00");



                            gb_MaterialProperties_2.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Opening area must be smaller than the total wall area.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Average height must be smaller than or equal to the compartment height.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please add room dimensions first.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numerical values for Average Height and Opening Area.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Calculate Opening Factor from Opening Table
        private void btn_CalculateOpeningFactor_Click2(object sender, EventArgs e)
        {
            try
            {
                double totalOpeningArea = 0;
                double totalAverageOpeningHeight = 0;
                int totalOpeningNumber = 0;

                List<Opening> openings = new List<Opening>();

                if (_geometry != null)
                {

                    foreach (DataGridViewRow row in dg_openings.Rows)
                    {
                        if (row.IsNewRow) continue;

                        double height, width;
                        int number;

                        // Validate and parse the height value
                        if (!double.TryParse(row.Cells[0].Value?.ToString(), out height))
                        {
                            MessageBox.Show("Invalid height value in one of the rows.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Validate and parse the width value
                        if (!double.TryParse(row.Cells[1].Value?.ToString(), out width))
                        {
                            MessageBox.Show("Invalid width value in one of the rows.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Validate and parse the number value
                        if (!int.TryParse(row.Cells[2].Value?.ToString(), out number))
                        {
                            MessageBox.Show("Invalid number value in one of the rows.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Convert height and width from cm to meters
                        height /= 100;
                        width /= 100;

                        // Accumulate total average height and number of openings
                        totalAverageOpeningHeight += height * number;
                        totalOpeningNumber += number;

                        // Create a new Opening object and calculate the area
                        Opening opening = new Opening(width, height, number);
                        openings.Add(opening);

                        // Accumulate the opening area for this row
                        totalOpeningArea += opening.Area;
                    }

                    // Calculate the average height of all openings
                    _opening.AverageHeight = totalAverageOpeningHeight / totalOpeningNumber;

                    // Calculate the opening factor
                    _opening.OpeningFactor = (totalOpeningArea * Math.Sqrt(_opening.AverageHeight)) / (this._geometry.EnclosureArea);

                    if (0.02 <= _opening.OpeningFactor && _opening.OpeningFactor <= 0.2)
                    {
                        // Display the calculated values
                        lbl_OpeningArea.Text = totalOpeningArea.ToString("0.00");
                        lbl_OpeningFactor.Text = _opening.OpeningFactor.ToString("0.00");
                        lbl_AverageHeight.Text = _opening.AverageHeight.ToString("0.00");

                        gb_MaterialProperties_2.Enabled = true;

                        _opening.OpeningArea = double.Parse(lbl_OpeningArea.Text);
                    }
                    else
                    {
                        MessageBox.Show("Opening Factor should be between 0,02 and 0,2", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("Please add room dimensions first.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region Design Properties

        #region Design Fire Load Methods

        #region Update Design Fire Load Combo Boxes
        private void UpdateDesignValues()
        {
            BindingSource designFireLoad = new BindingSource();
            designFireLoad.DataSource = _designFireLoadData.GetDesignFireLoadList();

            cb_DesignFireLoad.DataSource = designFireLoad;
            cb_DesignFireLoad.DisplayMember = "OccupancyType";

        }
        #endregion

        #region Add New Design Fire Load
        private void btn_AddNewDesignFireLoad_Click(object sender, EventArgs e)
        {
            NewDesignFireLoad newDesignFireLoad = new NewDesignFireLoad(_designFireLoadData, UpdateDesignValues);
            newDesignFireLoad.ShowDialog();
        }
        #endregion

        #region Edit Design Fire Load
        private void btn_EditDesignFireLoad_Click(object sender, EventArgs e)
        {
            EditDesignFireLoad edit = new EditDesignFireLoad(_designFireLoadData, UpdateDesignValues);
            edit.ShowDialog();
        }
        #endregion

        #region Show All Design Fire Load Values
        private void btn_ShowAllDesignFireLoads_Click(object sender, EventArgs e)
        {
            ShowAllDesignValues showAllDesignFireLoadValues = new ShowAllDesignValues(_designFireLoadData, _floorAreaData, _occupancyData, UpdateDesignValues);
            showAllDesignFireLoadValues.ShowDialog();
        }
        #endregion

        #endregion

        #region ROFI Occupancy Methods

        #region New ROFI Occupancy
        private void btn_NewROFI_Occupancy_Click(object sender, EventArgs e)
        {
            NewROFI_Occupancy newROFI_Occupancy = new NewROFI_Occupancy(_occupancyData, UpdateROFI_OccupancyValues);
            newROFI_Occupancy.ShowDialog();
        }
        #endregion

        #region Update ROFI Occupancy Combo Boxes
        private void UpdateROFI_OccupancyValues()
        {
            if (_occupancyData == null || cb_ROFI_Occupancy == null)
            {
                return;
            }

            var occupancyList = _occupancyData.GetROFI_OccupancyList();
            if (occupancyList == null || !occupancyList.Any())
            {
                return;
            }

            BindingSource rofi_occupancy = new BindingSource();
            rofi_occupancy.DataSource = occupancyList;

            cb_ROFI_Occupancy.DataSource = rofi_occupancy;
            cb_ROFI_Occupancy.DisplayMember = "OccupancyType";
        }
        #endregion

        #region Edit ROFI Occupancy 
        private void btn_EditROFI_Occupancy_Click(object sender, EventArgs e)
        {
            EditROFI_Occupancy editROFI_Occupancy = new EditROFI_Occupancy(_occupancyData, UpdateROFI_OccupancyValues);
            editROFI_Occupancy.ShowDialog();
        }
        #endregion

        #endregion

        #region ROFI Floor Area Methods

        #region Update ROFI Floor Area Combo Boxes
        private void UpdateROFI_FloorAreaValues()
        {
            if (_floorAreaData == null || cb_ROFI_FloorArea == null)
            {
                return;
            }

            var rofi_floorAreList = _floorAreaData.GetROFI_FloorAreaList();
            if (rofi_floorAreList == null || !rofi_floorAreList.Any())
            {
                return;
            }

            BindingSource rofi_floorArea = new BindingSource();
            rofi_floorArea.DataSource = rofi_floorAreList;

            cb_ROFI_FloorArea.DataSource = rofi_floorArea;
            cb_ROFI_FloorArea.DisplayMember = "FloorArea";
        }
        #endregion

        #region Edit ROFI Floor Area
        private void btn_EditROFI_FloorArea_Click(object sender, EventArgs e)
        {
            EditROFI_FloorArea editROFI_FloorArea = new EditROFI_FloorArea(_floorAreaData, UpdateROFI_FloorAreaValues);
            editROFI_FloorArea.ShowDialog();
        }
        #endregion

        #endregion

        #region Apply Design Values
        private void btn_ApplyDesignValues_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_ROFI_Occupancy == null)
                {
                    MessageBox.Show("ROFI Occupancy combobox is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_designFireLoadData == null)
                {
                    MessageBox.Show("DesignFireLoadData is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_occupancyData == null)
                {
                    MessageBox.Show("ROFI Occupancy data is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_floorAreaData == null)
                {
                    MessageBox.Show("ROFI Floor Area data is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_geometry == null)
                {
                    MessageBox.Show("Geometry data is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _design.OccupancyType = cb_ROFI_Occupancy.Text;
                _design.Geometry = this._geometry;

                // Design Fire Load Values
                var selectedDesignValue = _designFireLoadData.DesignFireLoadValues
                    .Select(x => x.Value)
                    .FirstOrDefault(y => y.OccupancyType == _design.OccupancyType);

                if (selectedDesignValue != null)
                {
                    _design.DesignValue_q_fk = selectedDesignValue.FractileValue;
                    _design.GrowthRate = selectedDesignValue.GrowthRate;
                    _design.LimitingTime_t_lim = selectedDesignValue.LimitingTime / 60;

                }
                else
                {
                    MessageBox.Show("No matching Design Fire Load value found for the selected occupancy type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Stop further processing
                }

                // ROFI Occupancy Values
                var selectedROFI_Occupancy = _occupancyData.ROFI_Occupancy
                    .Select(x => x.Value)
                    .FirstOrDefault(y => y.OccupancyType == cb_ROFI_Occupancy.Text);

                if (selectedROFI_Occupancy != null)
                {
                    _design.ROFI_Occupancy_gama_1 = selectedROFI_Occupancy.FractileValue;
                }
                else
                {
                    MessageBox.Show("No matching ROFI Occupancy Fractile value found for the selected occupancy type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedROFI_FloorArea = _floorAreaData.ROFI_FloorArea
                    .Select(x => x.Value)
                    .FirstOrDefault(y => y.FloorArea == double.Parse(cb_ROFI_FloorArea.Text));

                if (double.TryParse(cb_ROFI_FloorArea.Text, out double floorArea))
                {
                    // Find the selected ROFI Floor Area based on the floor area value
                    var selectedROFI_FloorAreaEntry = _floorAreaData.ROFI_FloorArea
                        .FirstOrDefault(x => x.Value.FloorArea == floorArea);

                    if (!selectedROFI_FloorAreaEntry.Equals(default(KeyValuePair<int, ROFI_FloorArea>)))
                    {
                        // Get the selected key
                        var selectedKey = selectedROFI_FloorAreaEntry.Key;
                        double selectedFractileValue = selectedROFI_FloorAreaEntry.Value.FractileValue;
                        double selectedFloorArea = selectedROFI_FloorAreaEntry.Value.FloorArea;

                        // Find the next key
                        var nextKey = _floorAreaData.ROFI_FloorArea.Keys
                            .OrderBy(k => k)
                            .FirstOrDefault(k => k > selectedKey);

                        if (_floorAreaData.ROFI_FloorArea.TryGetValue(nextKey, out ROFI_FloorArea nextROFI_FloorArea))
                        {
                            // Get the FractileValue and FloorArea of the next ROFI Floor Area
                            double nextFractileValue = nextROFI_FloorArea.FractileValue;
                            double nextFloorArea = nextROFI_FloorArea.FloorArea;

                            // Calculate the interpolated value
                            _design.ROFI_FloorArea_gama_2 = selectedFractileValue +
                                (nextFractileValue - selectedFractileValue) *
                                (_geometry.FloorArea - selectedFloorArea) /
                                (nextFloorArea - selectedFloorArea);

                            txt_CombustionFactor.Enabled = true;
                            txt_FireDuration.Enabled = true;
                            btn_CalculateEurocode.Enabled = true;
                            btn_CompareCurves.Enabled = true;
                            txt_ActiveSuppressionCoefficient.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("No next ROFI Floor Area found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No matching ROFI Floor Area Fractile value found for the selected floor area.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid floor area input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"A null reference occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion

        #region Update Compartment Values
        private void UpdateCompartmentValuesText_Ventilation()
        {
            Ventilation_CompartmentValuesText = $@"
                
    -- Curve Properties --
    Eurocode Curve Name : {Eurocode.CurveName.ToString().Split(" ")[0]}
    Curve Code : {Eurocode.CurveCode}
    Creation Date : {Eurocode.Date.ToString().Split(" ")[0]}

    -- Compartment Dimensions --
    Length (m): {_geometry.Length:F2}
    Width  (m): {_geometry.Width:F2}
    Height (m): {_geometry.Height:F2}

    -- Area Values --
    Floor Area (m²): {_geometry.FloorArea:F2}
    Ceiling Area (m²): {_geometry.CeilingArea:F2}
    Walls Area (m²): {_geometry.WallsArea:F2}
    Enclosure Area (m²): {_geometry.EnclosureArea:F2}

    -- Opening Properties --
    Opening Area (m²): {_opening.OpeningArea}
    Average Height (m): {_opening.AverageHeight:F2}
    Opening Factor (m½): {_opening.OpeningFactor:F2}

    -- Walls Material --
    Name: {exportAllValues.WallMaterial.Name}
    Density: {exportAllValues.WallMaterial.Density:F2}
    Specific Heat: {exportAllValues.WallMaterial.SpecificHeat:F2}
    Thermal Conductivity: {exportAllValues.WallMaterial.ThermalConductivity:F2}

    -- Floor Material --
    Name: {exportAllValues.FloorMaterial.Name}
    Density: {exportAllValues.FloorMaterial.Density:F2}
    Specific Heat: {exportAllValues.FloorMaterial.SpecificHeat:F2}
    Thermal Conductivity: {exportAllValues.FloorMaterial.ThermalConductivity:F2}

    -- Ceiling Material --
    Name: {exportAllValues.CeilingMaterial.Name}
    Density: {exportAllValues.CeilingMaterial.SpecificHeat:F2}
    Specific Heat: {exportAllValues.CeilingMaterial.SpecificHeat:F2}
    Thermal Conductivity: {exportAllValues.CeilingMaterial.ThermalConductivity:F2}

    -- Thermal Properties --
    Wall Thermal Inertia J/(m²·K): {_material.WallThermalInertia:F2}
    Floor Thermal Inertia J/(m²·K): {_material.FloorThermalInertia:F2}
    Ceiling Thermal Inertia J/(m²·K): {_material.CeilingThermalInertia:F2}
    Compartment Thermal Inertia J/(m²·K): {_material.CompartmentThermalInertia:F2}

    -- Fire Design Properties -- 
    Fire Load Density (g_fk) MJ · m⁻²: {_design.DesignValue_q_fk:F2}
    Risk Of Fire - Occupancy : {_design.ROFI_Occupancy_gama_1:F2}
    Risk Of Fire - Floor Area: {_design.ROFI_FloorArea_gama_2:F2}
    Design Fire Load Density (q_fd) MJ · m⁻²: {_design.FireDesignLoad_q_fd:F2}
    Total Design Fire Load (q_td)   MJ · m⁻²: {_design.TotalDesignFireLoad_q_td:F2}

    -- Time Properties --
    Limiting Time (hour): {_design.LimitingTime_t_lim:F2}
    t_max: {_design.t_max:F2}
    t_max_2: {_design.t_max_2:F2}
    Fire Duration (minutes): {_design.FireDuration}

    -- Other Paramaters --
    Combustion Factor: {_design.CombustionFactor_m}
    Active Suppression Coefficient: {_design.ActiveSuppressionCoefficient_gama_n}

    Maximum Temperature (C): {_design.MaximumTemperature:F2}
    Maximum Temperature Time (minutes): {lbl_MaximumTemperatureTime.Text.Split(" ")[0]}

            ";
        }

        private void UpdateCompartmentValuesText_Fuel()
        {
            Fuel_CompartmentValuesText = $@"
                
    -- Curve Properties --
    Eurocode Curve Name : {Eurocode.CurveName.ToString().Split(" ")[0]}
    Curve Code : {Eurocode.CurveCode}
    Creation Date : {Eurocode.Date.ToString().Split(" ")[0]}

    -- Compartment Dimensions --
    Length (m): {_geometry.Length:F2}
    Width  (m): {_geometry.Width:F2}
    Height (m): {_geometry.Height:F2}

    -- Area Values --
    Floor Area (m²): {_geometry.FloorArea:F2}
    Ceiling Area (m²): {_geometry.CeilingArea:F2}
    Walls Area (m²): {_geometry.WallsArea:F2}
    Enclosure Area (m²): {_geometry.EnclosureArea:F2}

    -- Opening Properties --
    Opening Area (m²): {_opening.OpeningArea}
    Average Height (m): {_opening.AverageHeight:F2}
    Opening Factor (m½): {_opening.OpeningFactor:F2}
    Opening Factor Lim: {_opening.OpeningFactorLim:F2}

    -- Walls Material --
    Name: {exportAllValues.WallMaterial.Name}
    Density: {exportAllValues.WallMaterial.Density:F2}
    Specific Heat: {exportAllValues.WallMaterial.SpecificHeat:F2}
    Thermal Conductivity: {exportAllValues.WallMaterial.ThermalConductivity:F2}

    -- Floor Material --
    Name: {exportAllValues.FloorMaterial.Name}
    Density: {exportAllValues.FloorMaterial.Density:F2}
    Specific Heat: {exportAllValues.FloorMaterial.SpecificHeat:F2}
    Thermal Conductivity: {exportAllValues.FloorMaterial.ThermalConductivity:F2}

    -- Ceiling Material --
    Name: {exportAllValues.CeilingMaterial.Name}
    Density: {exportAllValues.CeilingMaterial.Density:F2}
    Specific Heat: {exportAllValues.CeilingMaterial.SpecificHeat:F2}
    Thermal Conductivity: {exportAllValues.CeilingMaterial.ThermalConductivity:F2}

    -- Thermal Properties --
    Wall Thermal Inertia J/(m²·K): {_material.WallThermalInertia:F2}
    Floor Thermal Inertia J/(m²·K): {_material.FloorThermalInertia:F2}
    Ceiling Thermal Inertia J/(m²·K): {_material.CeilingThermalInertia:F2}
    Compartment Thermal Inertia J/(m²·K): {_material.CompartmentThermalInertia:F2}

    -- Fire Design Properties -- 
    Fire Load Density (g_fk) MJ · m⁻²: {_design.DesignValue_q_fk:F2}
    Risk Of Fire - Occupancy : {_design.ROFI_Occupancy_gama_1:F2}
    Risk Of Fire - Floor Area: {_design.ROFI_FloorArea_gama_2:F2}
    Design Fire Load Density (q_fd) MJ · m⁻²: {_design.FireDesignLoad_q_fd:F2}
    Total Design Fire Load (q_td)   MJ · m⁻²: {_design.TotalDesignFireLoad_q_td:F2}

    -- Time Properties --
    Limiting Time (hour): {_design.LimitingTime_t_lim:F2}
    t_max: {_design.t_max:F2}
    t_max_2: {_design.t_max_2:F2}
    t_max_3 (Fuel Value): {_design.t_max_3:F2}
    t_max_4 (Fuel Value): {_design.t_max_4:F2}
    Fire Duration (minutes): {_design.FireDuration}
    Time Factor Lim: {_design.TimeFactor_lim:F2}

    -- Other Paramaters --
    Combustion Factor: {_design.CombustionFactor_m}
    Active Suppression Coefficient: {_design.ActiveSuppressionCoefficient_gama_n}

    Maximum Temperature (C): {_design.MaximumTemperature:F2}
    Maximum Temperature Time (minutes): {lbl_MaximumTemperatureTime.Text.Split(" ")[0]}

            ";
        }
        #endregion

        #region Calculate Eurocode Button
        private void btn_CalculateEurocode_Click(object sender, EventArgs e)
        {
            try
            {

                _design.CombustionFactor_m = double.Parse(txt_CombustionFactor.Text);
                _design.ActiveSuppressionCoefficient_gama_n = double.Parse(txt_ActiveSuppressionCoefficient.Text);
                _design.FireDuration = double.Parse(txt_FireDuration.Text);

                _design.FireDesignLoad_q_fd = _design.DesignValue_q_fk
                    * _design.CombustionFactor_m
                    * _design.ActiveSuppressionCoefficient_gama_n
                    * _design.ROFI_FloorArea_gama_2
                    * _design.ROFI_Occupancy_gama_1;

                _design.TotalDesignFireLoad_q_td = (_design.FireDesignLoad_q_fd * _geometry.FloorArea) / _geometry.EnclosureArea;

                Eurocode.Date = dt_dateTime.Value.Date + DateTime.Now.TimeOfDay;
                Eurocode.CurveName = txt_CurveName.Text;
                Eurocode.CurveCode = txt_CurveCode.Text;


                CalculateValues();

                if (Eurocode.FireType == "Ventilation Controlled")
                {
                    UpdateCompartmentValuesText_Ventilation();
                    text_CompartmentValues.Text = this.Ventilation_CompartmentValuesText;
                }
                else if (Eurocode.FireType == "Fuel Controlled")
                {
                    UpdateCompartmentValuesText_Fuel();
                    text_CompartmentValues.Text = this.Fuel_CompartmentValuesText;
                }



            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numerical values in the appropriate fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Calculate Values
        private void CalculateValues()
        {
            _design.t_max = Math.Max((0.2 * 0.001 * _design.TotalDesignFireLoad_q_td) / _opening.OpeningFactor, _design.LimitingTime_t_lim);

            Eurocode.Temperatures = new List<double>();
            Eurocode.Times = new List<double>();

            if (_design.t_max > _design.LimitingTime_t_lim)
            {
                Eurocode.FireType = "Ventilation Controlled";
                lbl_FireType.Text = Eurocode.FireType;

                string suffix = " V" + " " + Eurocode.CurveCode;
                Eurocode.CurveName += suffix;

                _design.TimeFactor = Math.Pow((_opening.OpeningFactor / _material.CompartmentThermalInertia), 2) / Math.Pow((0.04 / 1160), 2);
                _design.t_max_2 = _design.t_max * _design.TimeFactor;
                _design.t_max_3 = 0;
                _design.t_max_4 = 0;
                _design.TimeFactor_lim = 0;


                _design.MaximumTemperature = Eurocode.CalculateMaximumTemperature(_design.t_max_2);
                lbl_MaximumTemperature.Text = _design.MaximumTemperature.ToString("0.000 °C");

                double x = 1;

                for (double i = 0; i <= _design.FireDuration * 60; i++)
                {
                    double t = (i / 3600) * _design.TimeFactor;
                    double Temp = Eurocode.CalculateHeatingPhaseTemperature(t);

                    if (Temp >= _design.MaximumTemperature)
                    {
                        if (_design.t_max_2 >= 2.0)
                        {
                            Temp = _design.MaximumTemperature - 250 * (t - _design.t_max_2 * x);
                        }
                        else if (_design.t_max_2 < 2.0 && _design.t_max_2 > 0.5)
                        {
                            Temp = _design.MaximumTemperature - 250 * (3 - _design.t_max_2) * (t - _design.t_max_2 * x);
                        }
                        else if (_design.t_max_2 <= 0.5)
                        {
                            Temp = _design.MaximumTemperature - 625 * (t - _design.t_max_2);
                        }

                        if (Temp <= 20)
                        {
                            Temp = 20.0;
                        }
                    }

                    Eurocode.Temperatures.Add(Temp);
                    Eurocode.Times.Add(i);
                }
            }
            else if (_design.t_max <= _design.LimitingTime_t_lim)
            {
                Eurocode.FireType = "Fuel Controlled";
                lbl_FireType.Text = Eurocode.FireType;

                string suffix = " F" + " " + Eurocode.CurveCode;
                Eurocode.CurveName += suffix;

                _design.TimeFactor = Math.Pow((_opening.OpeningFactor / _material.CompartmentThermalInertia), 2) / Math.Pow((0.04 / 1160), 2);

                _opening.OpeningFactorLim = (0.1 * 0.001 * _design.TotalDesignFireLoad_q_td) / _design.LimitingTime_t_lim;
                _design.TimeFactor_lim = Math.Pow((_opening.OpeningFactorLim / _material.CompartmentThermalInertia), 2) / Math.Pow((0.04 / 1160), 2);

                _design.t_max_3 = _design.LimitingTime_t_lim * _design.TimeFactor_lim;

                _design.MaximumTemperature = Eurocode.CalculateMaximumTemperature(_design.t_max_3);
                lbl_MaximumTemperature.Text = _design.MaximumTemperature.ToString("0.000 °C");

                double x = (_design.LimitingTime_t_lim * _design.TimeFactor_lim) / ((0.2 * 0.001 * _design.TimeFactor_lim * _design.TotalDesignFireLoad_q_td) / _opening.OpeningFactor);

                _design.t_max_2 = _design.TimeFactor_lim * _design.t_max;

                for (double i = 0; i <= _design.FireDuration * 60; i++)
                {
                    double t = (i / 3600) * _design.TimeFactor_lim;
                    double Temp = Eurocode.CalculateHeatingPhaseTemperature(t);

                    _design.t_max_4 = (0.02 * 0.001 * _design.TotalDesignFireLoad_q_td) / _opening.OpeningFactor;

                    if (Temp >= _design.MaximumTemperature)
                    {
                        if (_design.t_max_4 >= 2.0)
                        {
                            Temp = _design.MaximumTemperature - 250 * (t - _design.t_max_2 * x);
                        }
                        else if (_design.t_max_4 < 2.0 && _design.t_max_4 > 0.5)
                        {
                            Temp = _design.MaximumTemperature - 250 * (3 - _design.t_max_2) * (t - _design.t_max_2 * x);
                        }
                        else if (_design.t_max_4 <= 0.5)
                        {
                            Temp = _design.MaximumTemperature - 625 * (t - _design.t_max_2);
                        }

                        if (Temp <= 20)
                        {
                            Temp = 20.0;
                        }
                    }

                    Eurocode.Temperatures.Add(Temp);
                    Eurocode.Times.Add(i);
                }
            }
            double maximumTemperature = Eurocode.Temperatures.Max();
            int maxTemperatureIndex = Eurocode.Temperatures.IndexOf(maximumTemperature);
            double maximumTemperatureTime = Eurocode.Times[maxTemperatureIndex];

            lbl_MaximumTemperatureTime.Text = $"{maximumTemperatureTime / 60:F2} m";

            dg_TimeTemperatureList.Rows.Clear();
            for (int j = 0; j < Eurocode.Times.Count; j++)
            {
                dg_TimeTemperatureList.Rows.Add(Eurocode.Times[j], Eurocode.Temperatures[j].ToString("0.00"));
            }

            btn_ExportCSV.Enabled = true;
            btn_ExportHTML.Enabled = true;
            btn_ExportPackage.Enabled = true;
            btn_ExportTxt.Enabled = true;
            btn_Save.Enabled = true;

            Eurocode.Area = _geometry.FloorArea;
            Eurocode.Material = exportAllValues.FloorMaterial.Name;
            Eurocode.OpeningFactor = _opening.OpeningFactor;

            CreateGraph(Eurocode.Times, Eurocode.Temperatures);

            string htmlContent = GetHtmlContent(); // Get the HTML content based on fire type
            SetHtmlContent(htmlContent); // Load the content into the dynamically created WebBrowser

            graph.SizeChanged += graph_SizeChanged;
        }

        private void SetHtmlContent(string htmlContent)
        {
            // Initialize the WebBrowser control dynamically
            WebBrowser webBrowser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                ScriptErrorsSuppressed = true
            };

            // Add the WebBrowser control to the panel (or any container you want)
            panel4.Controls.Clear(); // Clear any existing controls in the panel
            panel4.Controls.Add(webBrowser); // Add the WebBrowser control to the panel

            // Ensure that the WebBrowser control is ready before loading content
            webBrowser.DocumentText = htmlContent; // Load the HTML content directly into the WebBrowser
        }


        private string GetHtmlContent()
        {
            UI_ExportHTML();

            if (Eurocode.FireType == "Ventilation Controlled")
            {
                return exportAllValues.Ventilation_HTML;
            }
            else if (Eurocode.FireType == "Fuel Controlled")
            {
                return exportAllValues.Fuel_HTML;
            }
            else
            {
                return "<html><body>No fire type specified.</body></html>";
            }
        }

        private void UI_ExportHTML()
        {
            try
            {
                // Initialize ExportAllValues object with the necessary properties
                InitializeExportValues();

                if (Eurocode.FireType == "Ventilation Controlled")
                {
                    exportAllValues.EditHTML_Ventilation();
                }
                else if (Eurocode.FireType == "Fuel Controlled")
                {
                    exportAllValues.EditHTML_Fuel();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during export
                MessageBox.Show($"An error occurred during HTML export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Graphs

        #region Create Eurocode Graph
        private void CreateGraph(List<double> Times, List<double> Temps)
        {

            if (Times == null || Temps == null || Times.Count == 0 || Temps.Count == 0)
            {
                return; // Skip graph creation to avoid crash
            }

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
                g.Clear(System.Drawing.Color.White);

                // Set up drawing parameters
                Pen axisPen = new Pen(System.Drawing.Color.Black, 2);
                Pen graphPen = new Pen(System.Drawing.Color.Blue, 2);
                Pen gridPen = new Pen(System.Drawing.Color.LightGray, 1); // Pen for drawing grid lines
                Pen maxTempPen = new Pen(System.Drawing.Color.Red, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash }; // Pen for dashed lines
                System.Drawing.Font font = new System.Drawing.Font("Arial", 10, FontStyle.Bold); // Larger font for better visibility
                Brush brush = Brushes.Black;
                Brush heatingBrush = new SolidBrush(System.Drawing.Color.FromArgb(128, System.Drawing.Color.Orange)); // Semi-transparent brush for heating phase
                Brush coolingBrush = new SolidBrush(System.Drawing.Color.FromArgb(128, System.Drawing.Color.Cyan)); // Semi-transparent brush for cooling phase

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

                    // Draw vertical grid line
                    g.DrawLine(gridPen, xPos, margin, xPos, graph.Height - margin);

                    // Draw tick marks and labels for X-axis
                    g.DrawLine(axisPen, xPos, graph.Height - margin, xPos, graph.Height - margin + 5);
                    g.DrawString((tickSpacingX * i).ToString("0.0"), font, brush, xPos - 10, graph.Height - margin + 10);
                }

                // Draw grid lines for Y-axis
                float tickSpacingY = maxY / 10; // Fixed number of intervals
                for (int i = 0; i <= 10; i++)
                {
                    float yPos = graph.Height - margin - i * tickSpacingY * fixedYScale; // Fixed y position

                    // Draw horizontal grid line
                    g.DrawLine(gridPen, margin, yPos, graph.Width - margin, yPos);

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
                int maxTempIndex;
                maxTempIndex = Temps.IndexOf(Temps.Max());
                double maxTemp = Temps[maxTempIndex];
                float maxTempX = margin + (float)((Times[maxTempIndex] / 60) * xScale);
                float maxTempY = graph.Height - margin - (float)(maxTemp * fixedYScale);

                g.DrawLine(maxTempPen, maxTempX, graph.Height - margin, maxTempX, maxTempY); // Vertical line
                g.DrawLine(maxTempPen, margin, maxTempY, maxTempX, maxTempY); // Horizontal line
                g.FillEllipse(Brushes.Black, maxTempX - 3, maxTempY - 3, 10, 10);

                // Calculate points for heating and cooling phase filling
                List<PointF> heatingPoints = new List<PointF>();
                List<PointF> coolingPoints = new List<PointF>();

                for (int i = 0; i <= maxTempIndex; i++)
                {
                    float x = margin + (float)((Times[i] / 60) * xScale);
                    float y = graph.Height - margin - (float)(Temps[i] * fixedYScale);
                    heatingPoints.Add(new PointF(x, y));
                }

                for (int i = maxTempIndex; i < Times.Count; i++)
                {
                    float x = margin + (float)((Times[i] / 60) * xScale);
                    float y = graph.Height - margin - (float)(Temps[i] * fixedYScale);
                    coolingPoints.Add(new PointF(x, y));
                }

                // Add base points to heating and cooling points to close the polygon for filling
                heatingPoints.Insert(0, new PointF(margin, graph.Height - margin)); // Starting point at X-axis
                heatingPoints.Add(new PointF(margin + (float)((Times[maxTempIndex] / 60) * xScale), graph.Height - margin)); // End point at X-axis

                coolingPoints.Insert(0, new PointF(margin + (float)((Times[maxTempIndex] / 60) * xScale), graph.Height - margin)); // Starting point at X-axis
                coolingPoints.Add(new PointF(margin + (float)((Times.Last() / 60) * xScale), graph.Height - margin)); // End point at X-axis

                // Fill the heating and cooling phases
                g.FillPolygon(heatingBrush, heatingPoints.ToArray());
                g.FillPolygon(coolingBrush, coolingPoints.ToArray());

                // Display the maximum temperature and time next to the point
                g.DrawString($"Max Temp: {maxTemp:F2} °C", font, brush, maxTempX + 5, maxTempY - 20);
                g.DrawString($"Time: {Times[maxTempIndex] / 60:F2} min", font, brush, maxTempX + 5, maxTempY);

                // Draw phase labels above the filled areas
                float heatingPhaseX = heatingPoints.Last().X - 60; // Centered position before max temperature
                float coolingPhaseX = heatingPoints.Last().X + (graph.Width - margin - heatingPoints.Last().X) / 2 - 30; // Centered position after max temperature

                g.DrawString("Heating\nPhase", font, Brushes.Black, heatingPhaseX, graph.Height - margin - 60);
                g.DrawString("Cooling\nPhase", font, Brushes.Black, coolingPhaseX, graph.Height - margin - 60);

                // Draw axis labels
                g.DrawString("Time (minutes)", font, brush, graph.Width / 2 - 50, graph.Height - margin + 25);
                g.DrawString("Temperature (°C)", font, brush, margin - 35, 5);
            }

            // Display the bitmap in the PictureBox
            graph.Image = bmp;
        }


        private void graph_MouseMove(object sender, MouseEventArgs e)
        {
            if (graph.Image == null) return; // If no image is drawn, return

            // Calculate mouse position relative to the graph
            int margin = 40;
            float maxX = (float)Eurocode.Times.Max() / 60; // Convert max time from seconds to minutes
            float maxY = (float)Eurocode.Temperatures.Max();
            float xScale = (graph.Width - 2 * margin) / maxX; // X-axis scaling factor
            float fixedYScale = (graph.Height - 2 * margin) / maxY; // Y-axis scaling factor

            // Calculate the x (time in minutes) and y (temperature) values based on mouse position
            double mouseTime = (e.X - margin) / xScale; // Time in minutes
            double mouseTemp = (graph.Height - margin - e.Y) / fixedYScale;

            // Find the closest data point to the mouse position
            int closestIndex = 0;
            double minDistance = double.MaxValue;

            for (int i = 0; i < Eurocode.Times.Count; i++)
            {
                double currentDistance = Math.Abs(mouseTime - (Eurocode.Times[i] / 60)); // Distance in minutes
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    closestIndex = i;
                }
            }

            double actualTime = Eurocode.Times[closestIndex] / 60; // Convert to minutes
            double actualTemp = Eurocode.Temperatures[closestIndex];

            // Show ToolTip with actual time (in minutes) and temperature
            graphToolTip.SetToolTip(graph, $"Time: {actualTime:F2} min\nTemp: {actualTemp:F2} °C");
        }


        private void graph_Click(object sender, EventArgs e)
        {
            if (Eurocode?.Times != null && Eurocode.Times.Count > 0 &&
       Eurocode.Temperatures != null && Eurocode.Temperatures.Count > 0)
            {
                var curveGraphForm = new CurveGraphForm(Eurocode.Times, Eurocode.Temperatures);
                curveGraphForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Graph data is missing. Please calculate the Eurocode curve first.", "Graph Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void graph_SizeChanged(object sender, EventArgs e)
        {
            if (Eurocode.Times == null || Eurocode.Times.Count == 0 || Eurocode.Temperatures == null || Eurocode.Temperatures.Count == 0)
            {
                // Prevent resizing before the data is ready
                return;
            }

            CreateGraph(Eurocode.Times, Eurocode.Temperatures);
        }

        #endregion

        #region ISO 834 Graph
        private void btn_ISO834_Click(object sender, EventArgs e)
        {
            ISO834_Curve ıSO834_Curve = new ISO834_Curve();
            ıSO834_Curve.ShowDialog();
        }
        #endregion

        #region Hydro Carbon Curve
        private void btn_HydroCarbon_Click(object sender, EventArgs e)
        {
            HydroCarbonCurve hydroCarbonCurve = new HydroCarbonCurve();
            hydroCarbonCurve.ShowDialog();
        }
        #endregion

        #region ASTM E119 Curve
        private void btn_ASTME119_Click(object sender, EventArgs e)
        {
            ASTM_E119 aSTM_E119 = new ASTM_E119();
            aSTM_E119.ShowDialog();
        }
        #endregion

        #region Compare Curves
        private void btn_CompareCurves_Click(object sender, EventArgs e)
        {
            CompareCurves compareCurves = new CompareCurves(Eurocode.Times, Eurocode.Temperatures);
            compareCurves.ShowDialog();

        }
        #endregion

        #endregion

        #region Export Methods

        #region Export TXT
        private void btn_ExportTxt_Click(object sender, EventArgs e)
        {
            // Create and display a folder browser dialog to select the destination folder
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;

                    // Define the file name and path
                    string fileName = "CompartmentValues.txt";
                    string filePath = System.IO.Path.Combine(selectedFolderPath, fileName);

                    try
                    {
                        // Write the content of the global CompartmentValues variable to the text file
                        System.IO.File.WriteAllText(filePath, text_CompartmentValues.Text);

                        // Inform the user that the file has been saved successfully
                        MessageBox.Show("Compartment values have been exported successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that may occur during file writing
                        MessageBox.Show($"An error occurred while exporting compartment values: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Export CSV
        private void btn_ExportCSV_Click(object sender, EventArgs e)
        {
            // Initialize the FolderBrowserDialog
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the folder to save the CSV file";

                // Show the dialog and check if the user clicked OK
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected path
                    string selectedPath = folderBrowserDialog.SelectedPath;

                    // Define the file path
                    string filePath = System.IO.Path.Combine(selectedPath, $"{Eurocode.CurveName}.csv");

                    try
                    {
                        // Check if file is in use
                        if (System.IO.File.Exists(filePath))
                        {
                            try
                            {
                                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                                {
                                    fs.Close();
                                }
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("The file is already open. Please close it and try again.", "File in Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Use a StreamWriter to create and write to the CSV file
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            // Write data points
                            for (int i = 0; i < Eurocode.Times.Count; i++)
                            {
                                string line = $"{Eurocode.Times[i]} {Eurocode.Temperatures[i]:0.000}";
                                writer.WriteLine(line);
                            }
                        }

                        // Inform the user that the file has been saved successfully
                        MessageBox.Show("CSV file has been exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("You do not have permission to save files in this location. Please choose a different folder.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException ioEx)
                    {
                        MessageBox.Show($"An IO error occurred while exporting the CSV file: {ioEx.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Handle any other errors that might have occurred
                        MessageBox.Show($"An error occurred while exporting the CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Export HTML
        private void btn_ExportHTML_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Initialize ExportAllValues object with the necessary properties
                        InitializeExportValues();

                        if (Eurocode.FireType == "Ventilation Controlled")
                        {
                            exportAllValues.EditHTML_Ventilation_Report();

                            // Export to HTML
                            exportAllValues.ExportToHTML_Ventilation_Report(dialog.SelectedPath);

                            // Inform the user of successful export
                            MessageBox.Show("Report is ready!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (Eurocode.FireType == "Fuel Controlled")
                        {
                            exportAllValues.EditHTML_Fuel_Report();

                            // Export to HTML
                            exportAllValues.ExportToHTML_Fuel_Report(dialog.SelectedPath);

                            MessageBox.Show("Report is ready!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that may occur during export
                        MessageBox.Show($"An error occurred during HTML export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Initialize Export Values for HTML
        private void InitializeExportValues()
        {
            // Assign the values
            exportAllValues.CurveTitle = Eurocode.CurveName ?? "N/A";
            exportAllValues.CurveName = Eurocode.CurveName?.Split(" ")[0] ?? "N/A";
            exportAllValues.CurveCode = Eurocode.CurveCode ?? "N/A";
            exportAllValues.FireType = Eurocode.FireType ?? "N/A";
            exportAllValues.MaximumTemperature = _design.MaximumTemperature;
            exportAllValues.MaximumTemperatureTime = double.Parse(lbl_MaximumTemperatureTime.Text.Split(" ")[0]);

            // Ensure geometry object is not null
            if (_geometry != null)
            {
                exportAllValues.Length = _geometry.Length;
                exportAllValues.Width = _geometry.Width;
                exportAllValues.Height = _geometry.Height;
                exportAllValues.FloorArea = _geometry.FloorArea;
                exportAllValues.CeilingArea = _geometry.CeilingArea;
                exportAllValues.WallsArea = _geometry.WallsArea;
                exportAllValues.EnclosureArea = _geometry.EnclosureArea;
            }

            // Opening properties
            exportAllValues.OpeningArea = double.TryParse(lbl_OpeningArea.Text, out var openingArea) ? openingArea : 0;
            exportAllValues.AverageHeight = double.TryParse(lbl_AverageHeight.Text, out var avgHeight) ? avgHeight : 0;
            exportAllValues.OpeningFactor = double.TryParse(lbl_OpeningFactor.Text, out var openingFactor) ? openingFactor : 0;
            exportAllValues.OpeningFactor_Lim = _opening.OpeningFactorLim;

            // Material thermal inertia properties
            exportAllValues.WallThermalInertia = double.TryParse(lbl_WallThermalInertia.Text, out var wallThermalInertia) ? wallThermalInertia : 0;
            exportAllValues.FloorThermalInertia = double.TryParse(lbl_FloorThermalInertia.Text, out var floorThermalInertia) ? floorThermalInertia : 0;
            exportAllValues.CeilingThermalInertia = double.TryParse(lbl_CeilingThermalInertia.Text, out var ceilingThermalInertia) ? ceilingThermalInertia : 0;
            exportAllValues.CompartmentThermalInertia = double.TryParse(lbl_CompartmentThermalInertia.Text, out var compThermalInertia) ? compThermalInertia : 0;

            exportAllValues.WallMaterial = exportAllValues.WallMaterial;
            exportAllValues.CeilingMaterial = exportAllValues.CeilingMaterial;
            exportAllValues.FloorMaterial = exportAllValues.FloorMaterial;

            // Fire design properties
            exportAllValues.FireGrowthRate = _design.GrowthRate;
            exportAllValues.OccupancyType = _design.OccupancyType;
            exportAllValues.DesignValue_q_fk = _design.DesignValue_q_fk;
            exportAllValues.FireDesignLoad_q_fd = _design.FireDesignLoad_q_fd;
            exportAllValues.TotalDesignFireLoad_q_td = _design.TotalDesignFireLoad_q_td;
            exportAllValues.ROFI_Occupancy_gama_1 = _design.ROFI_Occupancy_gama_1;
            exportAllValues.ROFI_FloorArea_gama_2 = _design.ROFI_FloorArea_gama_2;

            // Time properties
            exportAllValues.LimitingTime_t_lim = _design.LimitingTime_t_lim;
            exportAllValues.FireDuration = _design.FireDuration;
            exportAllValues.TimeFactor = _design.TimeFactor;
            exportAllValues.TimeFactor_Lim = _design.TimeFactor_lim;
            exportAllValues.t_max = _design.t_max;
            exportAllValues.t_max_2 = _design.t_max_2;
            exportAllValues.t_max_3 = _design.t_max_3;
            exportAllValues.t_max_4 = _design.t_max_4;

            // Other parameters
            exportAllValues.CombustionFactor_m = _design.CombustionFactor_m;
            exportAllValues.ActiveSuppressionCoefficient_gama_n = _design.ActiveSuppressionCoefficient_gama_n;

            exportAllValues.Times = Eurocode.Times;
            exportAllValues.Temperatures = Eurocode.Temperatures;
        }
        #endregion

        #region Export Package

        #region Export Click 
        private void btn_ExportPackage_Click(object sender, EventArgs e)
        {
            // Initialize the FolderBrowserDialog
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the folder to save the export files";

                // Show the dialog and check if the user clicked OK
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected path
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;

                    // Create a new folder named "outputs" inside the selected path
                    string outputFolderPath = System.IO.Path.Combine(selectedFolderPath, $"{Eurocode.CurveName}");

                    try
                    {
                        // Check if the outputs folder exists; if not, create it
                        if (!System.IO.Directory.Exists(outputFolderPath))
                        {
                            System.IO.Directory.CreateDirectory(outputFolderPath);
                        }

                        // Export TXT
                        ExportTxt(outputFolderPath);

                        // Export CSV
                        ExportCSV(outputFolderPath);

                        // Export HTML
                        ExportHTML(outputFolderPath);

                        // Export Screenshot
                        ExportCurveScreenshot(outputFolderPath);

                        // Save Graph Image
                        SaveGraph(outputFolderPath);

                        SaveCompareImages(outputFolderPath);

                        SaveFile(outputFolderPath);

                        // Inform the user that the package export is complete
                        MessageBox.Show("All files have been exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that might occur during folder creation or file export
                        MessageBox.Show($"An error occurred during export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Export ScreenShot
        private void ExportCurveScreenshot(string folderPath)
        {
            try
            {
                // Define the file name and path for the screenshot
                string fileName = "CurveScreenshot.jpg";
                string filePath = System.IO.Path.Combine(folderPath, fileName);

                // Get the size of the control to capture (for example, the entire UserControl or specific part)
                Rectangle bounds = this.Bounds;  // You can adjust this to target specific areas

                // Create a bitmap with the size of the control
                using (Bitmap bmp = new Bitmap(bounds.Width, bounds.Height))
                {
                    // Draw the control's content onto the bitmap
                    this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                    // Save the bitmap as a JPEG file
                    bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during the screenshot process
                MessageBox.Show($"An error occurred while taking the screenshot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Export TXT
        private void ExportTxt(string folderPath)
        {
            // Define the file name and path for TXT
            string fileName = "CompartmentValues.txt";
            string filePath = System.IO.Path.Combine(folderPath, fileName);

            try
            {
                // Write the content of the global CompartmentValues variable to the text file
                System.IO.File.WriteAllText(filePath, text_CompartmentValues.Text);
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during file writing
                MessageBox.Show($"An error occurred while exporting TXT: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Export CSV
        private void ExportCSV(string folderPath)
        {
            // Define the file path for CSV
            string filePath = System.IO.Path.Combine(folderPath, $"{Eurocode.CurveName}.csv");

            try
            {
                // Check if file is in use
                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            fs.Close();
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("The CSV file is already open. Please close it and try again.", "File in Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Use a StreamWriter to create and write to the CSV file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write data points
                    for (int i = 0; i < Eurocode.Times.Count; i++)
                    {
                        string line = $"{Eurocode.Times[i]} {Eurocode.Temperatures[i]:0.000}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to save files in this location. Please choose a different folder.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"An IO error occurred while exporting the CSV file: {ioEx.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle any other errors that might have occurred
                MessageBox.Show($"An error occurred while exporting the CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Export HTML
        private void ExportHTML(string folderPath)
        {
            try
            {
                // Initialize ExportAllValues object with the necessary properties
                InitializeExportValues();

                if (Eurocode.FireType == "Ventilation Controlled")
                {
                    exportAllValues.EditHTML_Ventilation();
                    // Export to HTML
                    exportAllValues.ExportToHTML_Ventilation(folderPath);
                }
                else if (Eurocode.FireType == "Fuel Controlled")
                {
                    exportAllValues.EditHTML_Fuel();
                    // Export to HTML
                    exportAllValues.ExportToHTML_Fuel(folderPath);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during export
                MessageBox.Show($"An error occurred during HTML export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Save Graph 
        private void SaveGraph(string folderPath)
        {
            // Check if there is an image in the PictureBox to save
            if (graph.Image == null)
            {
                MessageBox.Show("No image available to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Set default file name and format
                string defaultFileName = "GraphImage.png";
                string filePath = System.IO.Path.Combine(folderPath, defaultFileName);
                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;

                // Save the image in the selected format
                graph.Image.Save(filePath, format);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Save Compare Images

        private void SaveCompareImages(string folderPath)
        {
            try
            {
                compareCurvesWithEurocode.EurocodeTemps = Eurocode.Temperatures;
                compareCurvesWithEurocode.EurocodeTimes = Eurocode.Times;

                // Generate comparison bitmaps
                Bitmap isoBitmap = compareCurvesWithEurocode.CompareISO834();
                Bitmap hydroBitmap = compareCurvesWithEurocode.CompareHydroCarbon();
                Bitmap astmBitmap = compareCurvesWithEurocode.CompareASTME119();

                // Define file paths for each image
                string isoImagePath = System.IO.Path.Combine(folderPath, "ISO834_Comparison.png");
                string hydroImagePath = System.IO.Path.Combine(folderPath, "HydroCarbon_Comparison.png");
                string astmImagePath = System.IO.Path.Combine(folderPath, "ASTM_E119_Comparison.png");

                // Save each bitmap image to the specified folder path
                isoBitmap.Save(isoImagePath, System.Drawing.Imaging.ImageFormat.Png);
                hydroBitmap.Save(hydroImagePath, System.Drawing.Imaging.ImageFormat.Png);
                astmBitmap.Save(astmImagePath, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during the image saving process
                MessageBox.Show($"An error occurred while saving comparison images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Save
        private void SaveFile(string folderPath)
        {
            try
            {
                // Ensure that the folder path is valid and not empty
                if (string.IsNullOrEmpty(folderPath))
                {
                    MessageBox.Show("Invalid folder path. Please select a valid folder.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create the file name with .elf extension using the Eurocode CurveName
                string fileName = $"{Eurocode.CurveName}.elf";
                string filePath = System.IO.Path.Combine(folderPath, fileName); // Combine folder path with the file name

                // Call a method to save the control states (you need to implement this method)
                SaveControlStates(this, filePath);
            }
            catch (UnauthorizedAccessException)
            {
                // Handle permission issues
                MessageBox.Show("You do not have permission to save files in this location. Please choose a different folder.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ioEx)
            {
                // Handle IO errors such as disk full, file system issues
                MessageBox.Show($"An IO error occurred while saving the file: {ioEx.Message}", "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle any other errors that might have occurred
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        #endregion

        #endregion

        #region Save and Open Methods

        #region Save Methods

        #region Save Click
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Control State File|*.elf",
                Title = "Save Control States"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveControlStates(this, saveFileDialog.FileName);
                    this.FilePath = saveFileDialog.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving UserControl: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Save Existing File
        private void Save()
        {
            try
            {
                SaveControlStates(this, this.FilePath);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving UserControl: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        #region Save Control States
        private void SaveControlStates(System.Windows.Forms.Control parentControl, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                WriteControlStates(parentControl, writer);
            }
        }
        #endregion

        #region Write Control States
        private void WriteControlStates(System.Windows.Forms.Control parentControl, StreamWriter writer)
        {
            foreach (System.Windows.Forms.Control control in parentControl.Controls)
            {
                string controlData = SerializeControl(control);
                if (!string.IsNullOrEmpty(controlData))
                {
                    writer.WriteLine(controlData);
                }

                if (control.Controls.Count > 0)
                {
                    WriteControlStates(control, writer);
                }
            }
        }
        #endregion

        #region Serialize Control
        private string SerializeControl(System.Windows.Forms.Control control)
        {
            if (control is TextBox textBox)
            {
                return $"TextBox|{textBox.Name}|{textBox.Text}";
            }
            else if (control is ComboBox comboBox)
            {
                return $"ComboBox|{comboBox.Name}|{comboBox.SelectedIndex}";
            }
            else if (control is DateTimePicker dateTimePicker)
            {
                return $"DateTimePicker|{dateTimePicker.Name}|{dateTimePicker.Text}";
            }
            else if (control is DataGridView dataGridView)
            {
                // Serialize DataGridView content into JSON format
                var rowsList = new List<Dictionary<string, string>>();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow) // Exclude the new row used for adding new data
                    {
                        var rowDict = new Dictionary<string, string>();
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            string columnName = column.HeaderText;
                            string cellValue = row.Cells[column.Index].Value?.ToString() ?? string.Empty;
                            rowDict[columnName] = cellValue;
                        }
                        rowsList.Add(rowDict);
                    }
                }
                return $"DataGridView|{dataGridView.Name}|{JsonConvert.SerializeObject(rowsList)}";
            }
            return string.Empty; // Skip non-relevant controls
        }
        #endregion

        #endregion

        #region Load Methods

        #region Load Click
        private void btn_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Control State File|*.elf",
                Title = "Load Control States"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadControlStates(this, openFileDialog.FileName);
                    this.FilePath = openFileDialog.FileName;
                    EnableAllControls(this);
                    ClickCalculateButtonsInOrder();

                    MessageBox.Show("UserControl loaded successfully.", "Load Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading UserControl: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Load Control States
        private void LoadControlStates(System.Windows.Forms.Control parentControl, string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length != 3) continue;  // Ensure we have a valid line format

                string controlType = parts[0];
                string controlName = parts[1];
                string controlValue = parts[2];

                System.Windows.Forms.Control[] controls = parentControl.Controls.Find(controlName, true);
                if (controls.Length > 0)
                {
                    System.Windows.Forms.Control control = controls[0];

                    if (controlType == "TextBox" && control is TextBox textBox)
                    {
                        textBox.Text = controlValue;
                    }
                    else if (controlType == "ComboBox" && control is ComboBox comboBox)
                    {
                        comboBox.SelectedIndex = int.Parse(controlValue);
                    }
                    else if (controlType == "DateTimePicker" && control is DateTimePicker dateTimePicker)
                    {
                        dateTimePicker.Text = controlValue;
                    }
                    else if (controlType == "DataGridView" && control is DataGridView dataGridView)
                    {
                        dataGridView.Rows.Clear();
                        var rowsList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(controlValue);
                        if (rowsList != null)
                        {
                            foreach (var rowDict in rowsList)
                            {
                                var rowValues = new List<object>();
                                foreach (DataGridViewColumn column in dataGridView.Columns)
                                {
                                    string columnName = column.HeaderText;
                                    rowValues.Add(rowDict.ContainsKey(columnName) ? rowDict[columnName] : string.Empty);
                                }
                                dataGridView.Rows.Add(rowValues.ToArray());
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Enable All Controls
        // Method to enable all controls in the UserControl
        private void EnableAllControls(System.Windows.Forms.Control parentControl)
        {
            foreach (System.Windows.Forms.Control control in parentControl.Controls)
            {
                control.Enabled = true;

                if (control.Controls.Count > 0)
                {
                    EnableAllControls(control);
                }
            }
        }
        #endregion

        #region Click Event Buttons
        // Method to simulate clicking all calculate buttons in order
        private void ClickCalculateButtonsInOrder()
        {
            btn_CalculateAreas.PerformClick();
            CheckDataAndClickButtons();
            btn_CalculateThermalInertia.PerformClick();
            btn_ApplyDesignValues.PerformClick();
            btn_CalculateEurocode.PerformClick();
        }
        #endregion

        #region Check and Handle Empty DataGridView
        // Method to check if DataGridView is empty and look for other tabs if necessary
        #region Check and Handle Empty DataGridView
        // Method to check if DataGridView is empty and look for other tabs if necessary
        private void CheckDataAndClickButtons()
        {
            // Check if DataGridView in the first tab is empty
            if (dg_openings.Rows.Count == 0)
            {
                // Check second tab for necessary controls
                TabPage secondTab = tab_Opening.TabPages[1];  // Adjust if needed
                bool isSecondTabEmpty = CheckControlsInTab(secondTab, new[] { "txt_OpeningFactor", "txt_MinimumAverageHeight" });

                if (isSecondTabEmpty)
                {
                    // Check third tab for necessary controls if second tab is empty
                    TabPage thirdTab = tab_Opening.TabPages[2];  // Adjust if needed
                    bool isThirdTabEmpty = CheckControlsInTab(thirdTab, new[] { "txt_OpeningArea", "txt_AverageHeight" });

                    if (isThirdTabEmpty)
                    {
                        // Show error if all tabs are empty
                        MessageBox.Show("Opening Properties are not filled", "Error");
                    }
                    else
                    {
                        // Ensure button is enabled and perform click for CalculateOpeningFactor
                        if (!btn_CalculateOpeningFactor.Enabled)
                            btn_CalculateOpeningFactor.Enabled = true;

                        // Invoke the button click on the UI thread
                        if (btn_CalculateOpeningFactor.InvokeRequired)
                        {
                            btn_CalculateOpeningFactor.Invoke(new Action(() => btn_CalculateOpeningFactor.PerformClick()));
                        }
                        else
                        {
                            btn_CalculateOpeningFactor.PerformClick();
                        }
                    }

                }
                else
                {
                    // Ensure button is enabled and perform click for ApplyOpeningFactor
                    if (!btn_ApplyOpeningFactor.Enabled)
                        btn_ApplyOpeningFactor.Enabled = true;

                    // Invoke the button click on the UI thread
                    if (btn_ApplyOpeningFactor.InvokeRequired)
                    {
                        btn_ApplyOpeningFactor.Invoke(new Action(() => btn_CalculateOpeningFactor.PerformClick()));
                    }
                    else
                    {
                        btn_ApplyOpeningFactor.PerformClick();
                    }
                }
            }
            else
            {
                // Ensure button is enabled and perform click for CalculateOpening
                if (!btn_CalculateOpening.Enabled)
                    btn_CalculateOpening.Enabled = true;

                btn_CalculateOpening.PerformClick(); // Or use invoke method below if needed
            }
        }
        #endregion

        #endregion

        #region Helper Method to Check Controls in a Tab
        // General method to check if specific controls in a given tab are empty
        private bool CheckControlsInTab(TabPage tab, string[] controlNames)
        {
            foreach (var controlName in controlNames)
            {
                TextBox textBox = tab.Controls.Find(controlName, true).FirstOrDefault() as TextBox;

                // If any control is empty, return true
                if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true;
                }
            }
            // If all controls are filled, return false
            return false;
        }
        #endregion

        #endregion

        #endregion

        #region Tool Strip Menu
        #region Save Existing
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (btn_Save.Enabled != false)
            {
                Save();
            }
            else
            {
                MessageBox.Show("Please complete the curve parameters and calculate eurocode.", "Error");
            }
        }
        #endregion

        #region Save As
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (btn_Save.Enabled != false)
            {
                btn_Save_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please complete the curve parameters and calculate eurocode.", "Error");
            }
        }
        #endregion

        private void tXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(btn_ExportTxt.Enabled != false)
            {
                btn_ExportTxt_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please complete the curve parameters and calculate eurocode.", "Error");
            }

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btn_ExportHTML.Enabled != false)
            {
                btn_ExportHTML_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please complete the curve parameters and calculate eurocode.", "Error");
            }
            
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btn_ExportCSV.Enabled != false)
            {
                btn_ExportCSV_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please complete the curve parameters and calculate eurocode.", "Error");
            }
            
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btn_ExportPackage.Enabled != false)
            {
                btn_ExportPackage_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please complete the curve parameters and calculate eurocode.", "Error");
            }
            
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btn_Open.Enabled != false)
            {
                btn_Load_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please complete the curve parameters and calculate eurocode.", "Error");
            }
            
        }

        #endregion
    }
}

