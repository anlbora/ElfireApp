namespace ElfireApp.Forms
{
    partial class EditROFI_Occupancy
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
            txt_FractileValue = new TextBox();
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
            tableLayoutPanel1.Controls.Add(txt_FractileValue, 0, 2);
            tableLayoutPanel1.Controls.Add(cb_OccupancyType, 0, 0);
            tableLayoutPanel1.Controls.Add(txt_OccupancyType, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_Edit, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(322, 204);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_FractileValue
            // 
            txt_FractileValue.Dock = DockStyle.Fill;
            txt_FractileValue.Location = new Point(11, 115);
            txt_FractileValue.Margin = new Padding(11, 13, 11, 13);
            txt_FractileValue.Name = "txt_FractileValue";
            txt_FractileValue.PlaceholderText = "Fractile Value";
            txt_FractileValue.Size = new Size(300, 27);
            txt_FractileValue.TabIndex = 2;
            // 
            // cb_OccupancyType
            // 
            cb_OccupancyType.Dock = DockStyle.Fill;
            cb_OccupancyType.FormattingEnabled = true;
            cb_OccupancyType.Location = new Point(11, 13);
            cb_OccupancyType.Margin = new Padding(11, 13, 11, 13);
            cb_OccupancyType.Name = "cb_OccupancyType";
            cb_OccupancyType.Size = new Size(300, 28);
            cb_OccupancyType.TabIndex = 0;
            cb_OccupancyType.SelectedIndexChanged += cb_OccupancyType_SelectedIndexChanged;
            // 
            // txt_OccupancyType
            // 
            txt_OccupancyType.Dock = DockStyle.Fill;
            txt_OccupancyType.Location = new Point(11, 64);
            txt_OccupancyType.Margin = new Padding(11, 13, 11, 13);
            txt_OccupancyType.Name = "txt_OccupancyType";
            txt_OccupancyType.PlaceholderText = "Occupancy Type";
            txt_OccupancyType.Size = new Size(300, 27);
            txt_OccupancyType.TabIndex = 1;
            // 
            // btn_Edit
            // 
            btn_Edit.Dock = DockStyle.Fill;
            btn_Edit.Location = new Point(6, 160);
            btn_Edit.Margin = new Padding(6, 7, 6, 7);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(310, 37);
            btn_Edit.TabIndex = 3;
            btn_Edit.Text = "Edit";
            btn_Edit.UseVisualStyleBackColor = true;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // EditROFI_Occupancy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 204);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(340, 251);
            MinimumSize = new Size(340, 251);
            Name = "EditROFI_Occupancy";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit";
            Load += EditROFI_Occupancy_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cb_OccupancyType;
        private TextBox txt_FractileValue;
        private TextBox txt_OccupancyType;
        private Button btn_Edit;
    }
}