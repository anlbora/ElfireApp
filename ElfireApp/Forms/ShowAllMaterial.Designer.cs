namespace ElfireApp.Forms
{
    partial class ShowAllMaterial
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
            dg_MaterialTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dg_MaterialTable).BeginInit();
            SuspendLayout();
            // 
            // dg_MaterialTable
            // 
            dg_MaterialTable.BackgroundColor = SystemColors.Control;
            dg_MaterialTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_MaterialTable.Dock = DockStyle.Fill;
            dg_MaterialTable.Location = new Point(0, 0);
            dg_MaterialTable.Name = "dg_MaterialTable";
            dg_MaterialTable.RowHeadersVisible = false;
            dg_MaterialTable.Size = new Size(604, 211);
            dg_MaterialTable.TabIndex = 0;
            // 
            // ShowAllMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 211);
            Controls.Add(dg_MaterialTable);
            MaximizeBox = false;
            MaximumSize = new Size(620, 1800);
            MinimizeBox = false;
            MinimumSize = new Size(620, 250);
            Name = "ShowAllMaterial";
            StartPosition = FormStartPosition.CenterParent;
            Text = "All Materials";
            Load += ShowAllMaterial_Load;
            ((System.ComponentModel.ISupportInitialize)dg_MaterialTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dg_MaterialTable;
    }
}