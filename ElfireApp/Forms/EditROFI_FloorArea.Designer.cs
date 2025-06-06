namespace ElfireApp.Forms
{
    partial class EditROFI_FloorArea
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
            cb_FloorArea = new ComboBox();
            txt_Fractile = new TextBox();
            btn_Edit = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(cb_FloorArea, 0, 0);
            tableLayoutPanel1.Controls.Add(txt_Fractile, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_Edit, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(322, 137);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // cb_FloorArea
            // 
            cb_FloorArea.Dock = DockStyle.Fill;
            cb_FloorArea.FormattingEnabled = true;
            cb_FloorArea.Location = new Point(11, 13);
            cb_FloorArea.Margin = new Padding(11, 13, 11, 13);
            cb_FloorArea.Name = "cb_FloorArea";
            cb_FloorArea.Size = new Size(300, 28);
            cb_FloorArea.TabIndex = 0;
            cb_FloorArea.SelectedIndexChanged += cb_FloorArea_IndexChanged;
            // 
            // txt_Fractile
            // 
            txt_Fractile.Dock = DockStyle.Fill;
            txt_Fractile.Location = new Point(11, 58);
            txt_Fractile.Margin = new Padding(11, 13, 11, 13);
            txt_Fractile.Name = "txt_Fractile";
            txt_Fractile.PlaceholderText = "Fractile Value";
            txt_Fractile.Size = new Size(300, 27);
            txt_Fractile.TabIndex = 1;
            // 
            // btn_Edit
            // 
            btn_Edit.Dock = DockStyle.Fill;
            btn_Edit.Location = new Point(3, 94);
            btn_Edit.Margin = new Padding(3, 4, 3, 4);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(316, 39);
            btn_Edit.TabIndex = 2;
            btn_Edit.Text = "Edit";
            btn_Edit.UseVisualStyleBackColor = true;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // EditROFI_FloorArea
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
            Name = "EditROFI_FloorArea";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit";
            Load += EditROFI_FloorArea_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cb_FloorArea;
        private TextBox txt_Fractile;
        private Button btn_Edit;
    }
}