namespace ElfireApp.Forms
{
    partial class EditDesignFireLoad
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
            tableLayoutPanel1 = new TableLayoutPanel();
            cb_GrowthRate = new ComboBox();
            txt_LimitingTime = new TextBox();
            txt_Fractile = new TextBox();
            cb_OccupancyType = new ComboBox();
            txt_OccupancyType = new TextBox();
            btn_Edit = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(cb_GrowthRate, 0, 3);
            tableLayoutPanel1.Controls.Add(txt_LimitingTime, 0, 4);
            tableLayoutPanel1.Controls.Add(txt_Fractile, 0, 2);
            tableLayoutPanel1.Controls.Add(cb_OccupancyType, 0, 0);
            tableLayoutPanel1.Controls.Add(txt_OccupancyType, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_Edit, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Size = new Size(282, 304);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // cb_GrowthRate
            // 
            cb_GrowthRate.Dock = DockStyle.Fill;
            cb_GrowthRate.FormattingEnabled = true;
            cb_GrowthRate.Location = new Point(11, 163);
            cb_GrowthRate.Margin = new Padding(11, 13, 11, 13);
            cb_GrowthRate.Name = "cb_GrowthRate";
            cb_GrowthRate.Size = new Size(260, 28);
            cb_GrowthRate.TabIndex = 5;
            // 
            // txt_LimitingTime
            // 
            txt_LimitingTime.Dock = DockStyle.Fill;
            txt_LimitingTime.Location = new Point(11, 213);
            txt_LimitingTime.Margin = new Padding(11, 13, 11, 13);
            txt_LimitingTime.Name = "txt_LimitingTime";
            txt_LimitingTime.Size = new Size(260, 27);
            txt_LimitingTime.TabIndex = 4;
            // 
            // txt_Fractile
            // 
            txt_Fractile.Dock = DockStyle.Fill;
            txt_Fractile.Location = new Point(11, 113);
            txt_Fractile.Margin = new Padding(11, 13, 11, 13);
            txt_Fractile.Name = "txt_Fractile";
            txt_Fractile.Size = new Size(260, 27);
            txt_Fractile.TabIndex = 2;
            // 
            // cb_OccupancyType
            // 
            cb_OccupancyType.Dock = DockStyle.Fill;
            cb_OccupancyType.FormattingEnabled = true;
            cb_OccupancyType.Location = new Point(11, 13);
            cb_OccupancyType.Margin = new Padding(11, 13, 11, 13);
            cb_OccupancyType.Name = "cb_OccupancyType";
            cb_OccupancyType.Size = new Size(260, 28);
            cb_OccupancyType.TabIndex = 0;
            cb_OccupancyType.SelectedIndexChanged += cb_OccupancyType_SelectedIndexChanged;
            // 
            // txt_OccupancyType
            // 
            txt_OccupancyType.Dock = DockStyle.Fill;
            txt_OccupancyType.Location = new Point(11, 63);
            txt_OccupancyType.Margin = new Padding(11, 13, 11, 13);
            txt_OccupancyType.Name = "txt_OccupancyType";
            txt_OccupancyType.Size = new Size(260, 27);
            txt_OccupancyType.TabIndex = 1;
            // 
            // btn_Edit
            // 
            btn_Edit.Dock = DockStyle.Fill;
            btn_Edit.Location = new Point(6, 257);
            btn_Edit.Margin = new Padding(6, 7, 6, 7);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(270, 40);
            btn_Edit.TabIndex = 6;
            btn_Edit.Text = "Edit";
            btn_Edit.UseVisualStyleBackColor = true;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // EditDesignFireLoad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 304);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(300, 351);
            MinimizeBox = false;
            MinimumSize = new Size(300, 351);
            Name = "EditDesignFireLoad";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Design Fire Load";
            Load += EditDesignFireLoad_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cb_GrowthRate;
        private TextBox txt_LimitingTime;
        private TextBox txt_Fractile;
        private ComboBox cb_OccupancyType;
        private TextBox txt_OccupancyType;
        private Button btn_Edit;
    }
}