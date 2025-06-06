namespace ElfireApp.Forms
{
    partial class CompareEurocodeCurvesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dg_curves = new DataGridView();
            Visibility = new DataGridViewCheckBoxColumn();
            curve_name = new DataGridViewTextBoxColumn();
            maximum_temperature = new DataGridViewTextBoxColumn();
            fire_type = new DataGridViewTextBoxColumn();
            curve_code = new DataGridViewTextBoxColumn();
            color = new DataGridViewButtonColumn();
            LineType = new DataGridViewComboBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            graph = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            cb_ShowFuelControlled = new CheckBox();
            cb_ShowVentilationControlled = new CheckBox();
            btn_exportGraph = new Button();
            cb_Labels = new CheckBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            cb_Area = new ComboBox();
            cb_OpeningFactor = new ComboBox();
            cb_Material = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dg_curves).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)graph).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // dg_curves
            // 
            dg_curves.AllowUserToAddRows = false;
            dg_curves.AllowUserToDeleteRows = false;
            dg_curves.AllowUserToResizeColumns = false;
            dg_curves.AllowUserToResizeRows = false;
            dg_curves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg_curves.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dg_curves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dg_curves.ColumnHeadersHeight = 29;
            dg_curves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dg_curves.Columns.AddRange(new DataGridViewColumn[] { Visibility, curve_name, maximum_temperature, fire_type, curve_code, color, LineType });
            dg_curves.Cursor = Cursors.Hand;
            dg_curves.Dock = DockStyle.Fill;
            dg_curves.Location = new Point(11, 13);
            dg_curves.Margin = new Padding(11, 13, 11, 13);
            dg_curves.MultiSelect = false;
            dg_curves.Name = "dg_curves";
            dg_curves.RowHeadersVisible = false;
            dg_curves.RowHeadersWidth = 51;
            dg_curves.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tableLayoutPanel1.SetRowSpan(dg_curves, 2);
            dg_curves.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_curves.ShowCellErrors = false;
            dg_curves.ShowCellToolTips = false;
            dg_curves.ShowEditingIcon = false;
            dg_curves.ShowRowErrors = false;
            dg_curves.Size = new Size(538, 696);
            dg_curves.TabIndex = 0;
            dg_curves.CellClick += Dg_curves_CellClick;
            dg_curves.CellContentClick += Dg_curves_CellContentClick;
            dg_curves.CellDoubleClick += Dg_curves_CellDoubleClick;
            dg_curves.CellValueChanged += dg_curves_CellValueChanged;
            dg_curves.SizeChanged += Form_Resize;
            // 
            // Visibility
            // 
            Visibility.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.NullValue = false;
            Visibility.DefaultCellStyle = dataGridViewCellStyle2;
            Visibility.FillWeight = 55.43999F;
            Visibility.HeaderText = "Show";
            Visibility.MinimumWidth = 6;
            Visibility.Name = "Visibility";
            Visibility.Resizable = DataGridViewTriState.False;
            Visibility.Width = 42;
            // 
            // curve_name
            // 
            curve_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            curve_name.FillWeight = 160.064987F;
            curve_name.HeaderText = "Name";
            curve_name.MinimumWidth = 6;
            curve_name.Name = "curve_name";
            curve_name.ReadOnly = true;
            curve_name.Width = 75;
            // 
            // maximum_temperature
            // 
            maximum_temperature.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            maximum_temperature.FillWeight = 90.72819F;
            maximum_temperature.HeaderText = "Max Temp";
            maximum_temperature.MinimumWidth = 6;
            maximum_temperature.Name = "maximum_temperature";
            maximum_temperature.ReadOnly = true;
            maximum_temperature.Width = 68;
            // 
            // fire_type
            // 
            fire_type.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            fire_type.FillWeight = 100.331871F;
            fire_type.HeaderText = "Fire Type";
            fire_type.MinimumWidth = 6;
            fire_type.Name = "fire_type";
            fire_type.ReadOnly = true;
            fire_type.Width = 76;
            // 
            // curve_code
            // 
            curve_code.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            curve_code.FillWeight = 93.4349747F;
            curve_code.HeaderText = "Curve Code";
            curve_code.MinimumWidth = 6;
            curve_code.Name = "curve_code";
            curve_code.ReadOnly = true;
            curve_code.Width = 75;
            // 
            // color
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.Transparent;
            dataGridViewCellStyle3.ForeColor = Color.Transparent;
            dataGridViewCellStyle3.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = Color.Transparent;
            color.DefaultCellStyle = dataGridViewCellStyle3;
            color.HeaderText = "Color";
            color.MinimumWidth = 6;
            color.Name = "color";
            color.Width = 51;
            // 
            // LineType
            // 
            LineType.HeaderText = "Line Type";
            LineType.MinimumWidth = 6;
            LineType.Name = "LineType";
            LineType.Resizable = DataGridViewTriState.True;
            LineType.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 560F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(dg_curves, 0, 0);
            tableLayoutPanel1.Controls.Add(graph, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(11, 13);
            tableLayoutPanel1.Margin = new Padding(11, 13, 11, 13);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1331, 722);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // graph
            // 
            graph.Dock = DockStyle.Fill;
            graph.Location = new Point(571, 82);
            graph.Margin = new Padding(11, 13, 11, 13);
            graph.Name = "graph";
            graph.Padding = new Padding(11, 13, 11, 13);
            graph.Size = new Size(753, 627);
            graph.TabIndex = 1;
            graph.TabStop = false;
            graph.Click += graph_Click;
            graph.MouseMove += graph_MouseMove;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 371F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(563, 4);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(769, 61);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(cb_ShowFuelControlled, 0, 0);
            tableLayoutPanel3.Controls.Add(cb_ShowVentilationControlled, 1, 0);
            tableLayoutPanel3.Controls.Add(btn_exportGraph, 3, 0);
            tableLayoutPanel3.Controls.Add(cb_Labels, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(401, 4);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel3.Size = new Size(365, 53);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // cb_ShowFuelControlled
            // 
            cb_ShowFuelControlled.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cb_ShowFuelControlled.AutoSize = true;
            cb_ShowFuelControlled.Cursor = Cursors.Hand;
            cb_ShowFuelControlled.Location = new Point(3, 4);
            cb_ShowFuelControlled.Margin = new Padding(3, 4, 3, 4);
            cb_ShowFuelControlled.Name = "cb_ShowFuelControlled";
            cb_ShowFuelControlled.Size = new Size(58, 45);
            cb_ShowFuelControlled.TabIndex = 7;
            cb_ShowFuelControlled.Text = "Fuel";
            cb_ShowFuelControlled.UseVisualStyleBackColor = true;
            // 
            // cb_ShowVentilationControlled
            // 
            cb_ShowVentilationControlled.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cb_ShowVentilationControlled.AutoSize = true;
            cb_ShowVentilationControlled.Cursor = Cursors.Hand;
            cb_ShowVentilationControlled.Location = new Point(84, 4);
            cb_ShowVentilationControlled.Margin = new Padding(3, 4, 3, 4);
            cb_ShowVentilationControlled.Name = "cb_ShowVentilationControlled";
            cb_ShowVentilationControlled.Size = new Size(102, 45);
            cb_ShowVentilationControlled.TabIndex = 6;
            cb_ShowVentilationControlled.Text = "Ventilation";
            cb_ShowVentilationControlled.UseVisualStyleBackColor = true;
            // 
            // btn_exportGraph
            // 
            btn_exportGraph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btn_exportGraph.Cursor = Cursors.Hand;
            btn_exportGraph.Location = new Point(265, 4);
            btn_exportGraph.Margin = new Padding(3, 4, 3, 4);
            btn_exportGraph.Name = "btn_exportGraph";
            btn_exportGraph.Size = new Size(97, 45);
            btn_exportGraph.TabIndex = 4;
            btn_exportGraph.Text = "Export";
            btn_exportGraph.UseVisualStyleBackColor = true;
            btn_exportGraph.Click += btn_exportGraph_Click;
            // 
            // cb_Labels
            // 
            cb_Labels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cb_Labels.AutoSize = true;
            cb_Labels.Cursor = Cursors.Hand;
            cb_Labels.Location = new Point(192, 4);
            cb_Labels.Margin = new Padding(3, 4, 3, 4);
            cb_Labels.Name = "cb_Labels";
            cb_Labels.Size = new Size(67, 45);
            cb_Labels.TabIndex = 1;
            cb_Labels.Text = "Label";
            cb_Labels.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel4.Controls.Add(cb_Area, 0, 0);
            tableLayoutPanel4.Controls.Add(cb_OpeningFactor, 1, 0);
            tableLayoutPanel4.Controls.Add(cb_Material, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 4);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(392, 53);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // cb_Area
            // 
            cb_Area.Cursor = Cursors.Hand;
            cb_Area.Dock = DockStyle.Fill;
            cb_Area.FormattingEnabled = true;
            cb_Area.Location = new Point(6, 13);
            cb_Area.Margin = new Padding(6, 13, 6, 7);
            cb_Area.Name = "cb_Area";
            cb_Area.Size = new Size(118, 28);
            cb_Area.TabIndex = 0;
            cb_Area.SelectedIndexChanged += cb_Area_SelectedIndexChanged;
            // 
            // cb_OpeningFactor
            // 
            cb_OpeningFactor.Cursor = Cursors.Hand;
            cb_OpeningFactor.Dock = DockStyle.Fill;
            cb_OpeningFactor.FormattingEnabled = true;
            cb_OpeningFactor.Location = new Point(136, 13);
            cb_OpeningFactor.Margin = new Padding(6, 13, 6, 7);
            cb_OpeningFactor.Name = "cb_OpeningFactor";
            cb_OpeningFactor.Size = new Size(118, 28);
            cb_OpeningFactor.TabIndex = 1;
            cb_OpeningFactor.SelectedIndexChanged += cb_OpeningFactor_SelectedIndexChanged;
            // 
            // cb_Material
            // 
            cb_Material.Cursor = Cursors.Hand;
            cb_Material.Dock = DockStyle.Fill;
            cb_Material.FormattingEnabled = true;
            cb_Material.Location = new Point(266, 13);
            cb_Material.Margin = new Padding(6, 13, 6, 7);
            cb_Material.Name = "cb_Material";
            cb_Material.Size = new Size(120, 28);
            cb_Material.TabIndex = 2;
            cb_Material.SelectedIndexChanged += cb_Material_SelectedIndexChanged;
            // 
            // CompareEurocodeCurvesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 748);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1369, 784);
            Name = "CompareEurocodeCurvesForm";
            Padding = new Padding(11, 13, 11, 13);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Compare Eurocode Curves";
            Load += Form_Load;
            SizeChanged += Form_Resize;
            ((System.ComponentModel.ISupportInitialize)dg_curves).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)graph).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dg_curves;
        private PictureBox graph;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private CheckBox cb_ShowFuelControlled;
        private CheckBox cb_ShowVentilationControlled;
        private Button btn_exportGraph;
        private CheckBox cb_Labels;
        private TableLayoutPanel tableLayoutPanel4;
        private ComboBox cb_Area;
        private ComboBox cb_OpeningFactor;
        private ComboBox cb_Material;
        private DataGridViewCheckBoxColumn Visibility;
        private DataGridViewTextBoxColumn curve_name;
        private DataGridViewTextBoxColumn maximum_temperature;
        private DataGridViewTextBoxColumn fire_type;
        private DataGridViewTextBoxColumn curve_code;
        private DataGridViewButtonColumn color;
        private DataGridViewComboBoxColumn LineType;
    }
}