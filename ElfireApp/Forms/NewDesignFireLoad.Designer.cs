namespace ElfireApp.Forms
{
    partial class NewDesignFireLoad
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
            txt_LimitingTime = new TextBox();
            txt_Fractile = new TextBox();
            txt_OccupancyType = new TextBox();
            btn_add = new Button();
            cb_FireGrowthRate = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(txt_LimitingTime, 0, 3);
            tableLayoutPanel1.Controls.Add(txt_Fractile, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_OccupancyType, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_add, 0, 4);
            tableLayoutPanel1.Controls.Add(cb_FireGrowthRate, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(282, 204);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_LimitingTime
            // 
            txt_LimitingTime.Dock = DockStyle.Fill;
            txt_LimitingTime.Location = new Point(3, 124);
            txt_LimitingTime.Margin = new Padding(3, 4, 3, 4);
            txt_LimitingTime.Name = "txt_LimitingTime";
            txt_LimitingTime.PlaceholderText = "Limiting Time (minutes)";
            txt_LimitingTime.Size = new Size(276, 27);
            txt_LimitingTime.TabIndex = 3;
            // 
            // txt_Fractile
            // 
            txt_Fractile.Dock = DockStyle.Fill;
            txt_Fractile.Location = new Point(3, 44);
            txt_Fractile.Margin = new Padding(3, 4, 3, 4);
            txt_Fractile.Name = "txt_Fractile";
            txt_Fractile.PlaceholderText = "Fractile Value";
            txt_Fractile.Size = new Size(276, 27);
            txt_Fractile.TabIndex = 1;
            // 
            // txt_OccupancyType
            // 
            txt_OccupancyType.Dock = DockStyle.Fill;
            txt_OccupancyType.Location = new Point(3, 4);
            txt_OccupancyType.Margin = new Padding(3, 4, 3, 4);
            txt_OccupancyType.Name = "txt_OccupancyType";
            txt_OccupancyType.PlaceholderText = "Occupancy Type";
            txt_OccupancyType.Size = new Size(276, 27);
            txt_OccupancyType.TabIndex = 0;
            // 
            // btn_add
            // 
            btn_add.Dock = DockStyle.Fill;
            btn_add.Location = new Point(3, 164);
            btn_add.Margin = new Padding(3, 4, 3, 4);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(276, 36);
            btn_add.TabIndex = 4;
            btn_add.Text = "Add";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_Add_Click;
            // 
            // cb_FireGrowthRate
            // 
            cb_FireGrowthRate.Dock = DockStyle.Fill;
            cb_FireGrowthRate.FormattingEnabled = true;
            cb_FireGrowthRate.Location = new Point(3, 84);
            cb_FireGrowthRate.Margin = new Padding(3, 4, 3, 4);
            cb_FireGrowthRate.Name = "cb_FireGrowthRate";
            cb_FireGrowthRate.Size = new Size(276, 28);
            cb_FireGrowthRate.TabIndex = 5;
            // 
            // NewDesignFireLoad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 204);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(300, 251);
            MinimizeBox = false;
            MinimumSize = new Size(300, 251);
            Name = "NewDesignFireLoad";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Design Fire Load";
            Load += NewDesignFireLoad_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txt_LimitingTime;
        private TextBox txt_Fractile;
        private TextBox txt_OccupancyType;
        private Button btn_add;
        private ComboBox cb_FireGrowthRate;
    }
}