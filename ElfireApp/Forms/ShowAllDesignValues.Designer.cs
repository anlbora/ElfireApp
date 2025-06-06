namespace ElfireApp.Forms
{
    partial class ShowAllDesignValues
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
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            button5 = new Button();
            dg_rofiFloorArea = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            button1 = new Button();
            button4 = new Button();
            dg_rofiOccupancy = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            dg_designfireloads = new DataGridView();
            tableLayoutPanel5 = new TableLayoutPanel();
            btn_EditDesignFireLoad = new Button();
            btn_AddNewDesignFireLoad = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_rofiFloorArea).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_rofiOccupancy).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dg_designfireloads).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Size = new Size(454, 691);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel7, 0, 1);
            tableLayoutPanel4.Controls.Add(dg_rofiFloorArea, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 485);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanel4.Size = new Size(448, 203);
            tableLayoutPanel4.TabIndex = 6;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(button5, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 159);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(442, 41);
            tableLayoutPanel7.TabIndex = 3;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Location = new Point(5, 5);
            button5.Margin = new Padding(5);
            button5.Name = "button5";
            button5.Padding = new Padding(1);
            button5.Size = new Size(432, 31);
            button5.TabIndex = 3;
            button5.Text = "Edit";
            button5.UseVisualStyleBackColor = true;
            button5.Click += btn_EditROFI_FloorArea_Click;
            // 
            // dg_rofiFloorArea
            // 
            dg_rofiFloorArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dg_rofiFloorArea.BackgroundColor = SystemColors.Control;
            dg_rofiFloorArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_rofiFloorArea.Location = new Point(3, 3);
            dg_rofiFloorArea.Name = "dg_rofiFloorArea";
            dg_rofiFloorArea.RowHeadersVisible = false;
            dg_rofiFloorArea.Size = new Size(442, 150);
            dg_rofiFloorArea.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 0, 1);
            tableLayoutPanel2.Controls.Add(dg_rofiOccupancy, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 244);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanel2.Size = new Size(448, 235);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(button1, 0, 0);
            tableLayoutPanel6.Controls.Add(button4, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 191);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(442, 41);
            tableLayoutPanel6.TabIndex = 3;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(226, 5);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Padding = new Padding(1);
            button1.Size = new Size(211, 31);
            button1.TabIndex = 4;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btn_EditROFI_Occupancy_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Location = new Point(5, 5);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Padding = new Padding(1);
            button4.Size = new Size(211, 31);
            button4.TabIndex = 3;
            button4.Text = "Add";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btn_AddNewROFI_Occupancy_Click;
            // 
            // dg_rofiOccupancy
            // 
            dg_rofiOccupancy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dg_rofiOccupancy.BackgroundColor = SystemColors.Control;
            dg_rofiOccupancy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_rofiOccupancy.Location = new Point(3, 3);
            dg_rofiOccupancy.Name = "dg_rofiOccupancy";
            dg_rofiOccupancy.RowHeadersVisible = false;
            dg_rofiOccupancy.Size = new Size(442, 182);
            dg_rofiOccupancy.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(dg_designfireloads, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanel3.Size = new Size(448, 235);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // dg_designfireloads
            // 
            dg_designfireloads.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dg_designfireloads.BackgroundColor = SystemColors.Control;
            dg_designfireloads.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_designfireloads.Location = new Point(3, 3);
            dg_designfireloads.Name = "dg_designfireloads";
            dg_designfireloads.RowHeadersVisible = false;
            dg_designfireloads.Size = new Size(442, 182);
            dg_designfireloads.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(btn_EditDesignFireLoad, 0, 0);
            tableLayoutPanel5.Controls.Add(btn_AddNewDesignFireLoad, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 191);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(442, 41);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // btn_EditDesignFireLoad
            // 
            btn_EditDesignFireLoad.Dock = DockStyle.Fill;
            btn_EditDesignFireLoad.Location = new Point(226, 5);
            btn_EditDesignFireLoad.Margin = new Padding(5);
            btn_EditDesignFireLoad.Name = "btn_EditDesignFireLoad";
            btn_EditDesignFireLoad.Padding = new Padding(1);
            btn_EditDesignFireLoad.Size = new Size(211, 31);
            btn_EditDesignFireLoad.TabIndex = 4;
            btn_EditDesignFireLoad.Text = "Edit";
            btn_EditDesignFireLoad.UseVisualStyleBackColor = true;
            btn_EditDesignFireLoad.Click += btn_EditDesignFireLoad_Click;
            // 
            // btn_AddNewDesignFireLoad
            // 
            btn_AddNewDesignFireLoad.Dock = DockStyle.Fill;
            btn_AddNewDesignFireLoad.Location = new Point(5, 5);
            btn_AddNewDesignFireLoad.Margin = new Padding(5);
            btn_AddNewDesignFireLoad.Name = "btn_AddNewDesignFireLoad";
            btn_AddNewDesignFireLoad.Padding = new Padding(1);
            btn_AddNewDesignFireLoad.Size = new Size(211, 31);
            btn_AddNewDesignFireLoad.TabIndex = 3;
            btn_AddNewDesignFireLoad.Text = "Add";
            btn_AddNewDesignFireLoad.UseVisualStyleBackColor = true;
            btn_AddNewDesignFireLoad.Click += btn_AddNewDesignFieLoad_Click;
            // 
            // ShowAllDesignValues
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 691);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MaximumSize = new Size(470, 1980);
            MinimumSize = new Size(470, 400);
            Name = "ShowAllDesignValues";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Design Values";
            Load += ShowAllDesignFireLoadValues_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_rofiFloorArea).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_rofiOccupancy).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dg_designfireloads).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel4;
        private DataGridView dg_rofiFloorArea;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dg_rofiOccupancy;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dg_designfireloads;
        private TableLayoutPanel tableLayoutPanel7;
        private Button button5;
        private TableLayoutPanel tableLayoutPanel6;
        private Button button1;
        private Button button4;
        private TableLayoutPanel tableLayoutPanel5;
        private Button btn_EditDesignFireLoad;
        private Button btn_AddNewDesignFireLoad;
    }
}