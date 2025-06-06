namespace ElfireApp.Forms
{
    partial class EurocodeCurveTempValue
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
            EurocodeCurvesTable = new DataGridView();
            CurveName = new DataGridViewTextBoxColumn();
            tempValue = new DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            txt_TimeValue = new TextBox();
            btn_CalculateTemp = new Button();
            ((System.ComponentModel.ISupportInitialize)EurocodeCurvesTable).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // EurocodeCurvesTable
            // 
            EurocodeCurvesTable.AllowUserToAddRows = false;
            EurocodeCurvesTable.AllowUserToDeleteRows = false;
            EurocodeCurvesTable.AllowUserToResizeColumns = false;
            EurocodeCurvesTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 192, 128);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 192, 128);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            EurocodeCurvesTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            EurocodeCurvesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EurocodeCurvesTable.BackgroundColor = SystemColors.ControlLight;
            EurocodeCurvesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EurocodeCurvesTable.Columns.AddRange(new DataGridViewColumn[] { CurveName, tempValue });
            tableLayoutPanel1.SetColumnSpan(EurocodeCurvesTable, 2);
            EurocodeCurvesTable.Dock = DockStyle.Fill;
            EurocodeCurvesTable.Location = new Point(3, 67);
            EurocodeCurvesTable.Margin = new Padding(3, 4, 3, 4);
            EurocodeCurvesTable.Name = "EurocodeCurvesTable";
            EurocodeCurvesTable.ReadOnly = true;
            EurocodeCurvesTable.RowHeadersVisible = false;
            EurocodeCurvesTable.RowHeadersWidth = 51;
            EurocodeCurvesTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            EurocodeCurvesTable.RowTemplate.Height = 25;
            EurocodeCurvesTable.SelectionMode = DataGridViewSelectionMode.CellSelect;
            EurocodeCurvesTable.ShowCellErrors = false;
            EurocodeCurvesTable.ShowCellToolTips = false;
            EurocodeCurvesTable.ShowEditingIcon = false;
            EurocodeCurvesTable.ShowRowErrors = false;
            EurocodeCurvesTable.Size = new Size(325, 677);
            EurocodeCurvesTable.TabIndex = 0;
            // 
            // CurveName
            // 
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            CurveName.DefaultCellStyle = dataGridViewCellStyle2;
            CurveName.HeaderText = "Curve Name";
            CurveName.MinimumWidth = 6;
            CurveName.Name = "CurveName";
            CurveName.ReadOnly = true;
            // 
            // tempValue
            // 
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            tempValue.DefaultCellStyle = dataGridViewCellStyle3;
            tempValue.HeaderText = "Temperature";
            tempValue.MinimumWidth = 6;
            tempValue.Name = "tempValue";
            tempValue.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(EurocodeCurvesTable, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_TimeValue, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_CalculateTemp, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(331, 748);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // txt_TimeValue
            // 
            txt_TimeValue.Cursor = Cursors.IBeam;
            txt_TimeValue.Dock = DockStyle.Fill;
            txt_TimeValue.Location = new Point(11, 13);
            txt_TimeValue.Margin = new Padding(11, 13, 11, 13);
            txt_TimeValue.Name = "txt_TimeValue";
            txt_TimeValue.PlaceholderText = "Time Value (minutes)";
            txt_TimeValue.Size = new Size(143, 27);
            txt_TimeValue.TabIndex = 1;
            // 
            // btn_CalculateTemp
            // 
            btn_CalculateTemp.Cursor = Cursors.Hand;
            btn_CalculateTemp.Dock = DockStyle.Fill;
            btn_CalculateTemp.Location = new Point(168, 4);
            btn_CalculateTemp.Margin = new Padding(3, 4, 3, 4);
            btn_CalculateTemp.Name = "btn_CalculateTemp";
            btn_CalculateTemp.Size = new Size(160, 55);
            btn_CalculateTemp.TabIndex = 2;
            btn_CalculateTemp.Text = "Calculate";
            btn_CalculateTemp.UseVisualStyleBackColor = true;
            btn_CalculateTemp.Click += btn_CalculateTemp_Click;
            // 
            // EurocodeCurveTempValue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 748);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(455, 1584);
            MinimumSize = new Size(340, 784);
            Name = "EurocodeCurveTempValue";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Eurocode Curves Temperatures";
            ((System.ComponentModel.ISupportInitialize)EurocodeCurvesTable).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView EurocodeCurvesTable;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txt_TimeValue;
        private Button btn_CalculateTemp;
        private DataGridViewTextBoxColumn CurveName;
        private DataGridViewTextBoxColumn tempValue;
    }
}