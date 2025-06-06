namespace ElfireApp.Forms
{
    partial class NewROFI_Occupancy
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
            txt_OccupancyType = new TextBox();
            btn_add = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(txt_FractileValue, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_OccupancyType, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_add, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(322, 137);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_FractileValue
            // 
            txt_FractileValue.Dock = DockStyle.Fill;
            txt_FractileValue.Location = new Point(6, 52);
            txt_FractileValue.Margin = new Padding(6, 7, 6, 7);
            txt_FractileValue.Name = "txt_FractileValue";
            txt_FractileValue.PlaceholderText = "Fractile Value";
            txt_FractileValue.Size = new Size(310, 27);
            txt_FractileValue.TabIndex = 1;
            // 
            // txt_OccupancyType
            // 
            txt_OccupancyType.Dock = DockStyle.Fill;
            txt_OccupancyType.Location = new Point(6, 7);
            txt_OccupancyType.Margin = new Padding(6, 7, 6, 7);
            txt_OccupancyType.Name = "txt_OccupancyType";
            txt_OccupancyType.PlaceholderText = "Occupancy Type";
            txt_OccupancyType.Size = new Size(310, 27);
            txt_OccupancyType.TabIndex = 0;
            // 
            // btn_add
            // 
            btn_add.Dock = DockStyle.Fill;
            btn_add.Location = new Point(6, 97);
            btn_add.Margin = new Padding(6, 7, 6, 7);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(310, 33);
            btn_add.TabIndex = 2;
            btn_add.Text = "Add";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_Add_Click;
            // 
            // NewROFI_Occupancy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 137);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(340, 184);
            MinimizeBox = false;
            MinimumSize = new Size(340, 184);
            Name = "NewROFI_Occupancy";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txt_OccupancyType;
        private TextBox txt_FractileValue;
        private Button btn_add;
    }
}