namespace ElfireApp.Forms
{
    partial class EditMaterial
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
            cb_Material = new ComboBox();
            txt_Name = new TextBox();
            txt_Density = new TextBox();
            txt_SpecificHeat = new TextBox();
            txt_ThermalConductivity = new TextBox();
            btn_Edit = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(cb_Material, 0, 0);
            tableLayoutPanel1.Controls.Add(txt_Name, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_Density, 0, 2);
            tableLayoutPanel1.Controls.Add(txt_SpecificHeat, 0, 3);
            tableLayoutPanel1.Controls.Add(txt_ThermalConductivity, 0, 4);
            tableLayoutPanel1.Controls.Add(btn_Edit, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(234, 261);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // cb_Material
            // 
            cb_Material.Dock = DockStyle.Fill;
            cb_Material.FormattingEnabled = true;
            cb_Material.Location = new Point(10, 10);
            cb_Material.Margin = new Padding(10);
            cb_Material.Name = "cb_Material";
            cb_Material.Size = new Size(214, 23);
            cb_Material.TabIndex = 0;
            cb_Material.SelectedIndexChanged += cb_Material_SelectedIndexChanged;
            // 
            // txt_Name
            // 
            txt_Name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_Name.Location = new Point(10, 53);
            txt_Name.Margin = new Padding(10);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(214, 23);
            txt_Name.TabIndex = 1;
            // 
            // txt_Density
            // 
            txt_Density.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_Density.Location = new Point(10, 96);
            txt_Density.Margin = new Padding(10);
            txt_Density.Name = "txt_Density";
            txt_Density.Size = new Size(214, 23);
            txt_Density.TabIndex = 1;
            // 
            // txt_SpecificHeat
            // 
            txt_SpecificHeat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_SpecificHeat.Location = new Point(10, 139);
            txt_SpecificHeat.Margin = new Padding(10);
            txt_SpecificHeat.Name = "txt_SpecificHeat";
            txt_SpecificHeat.Size = new Size(214, 23);
            txt_SpecificHeat.TabIndex = 1;
            // 
            // txt_ThermalConductivity
            // 
            txt_ThermalConductivity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_ThermalConductivity.Location = new Point(10, 182);
            txt_ThermalConductivity.Margin = new Padding(10);
            txt_ThermalConductivity.Name = "txt_ThermalConductivity";
            txt_ThermalConductivity.Size = new Size(214, 23);
            txt_ThermalConductivity.TabIndex = 1;
            // 
            // btn_Edit
            // 
            btn_Edit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_Edit.Location = new Point(10, 225);
            btn_Edit.Margin = new Padding(10);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(214, 26);
            btn_Edit.TabIndex = 2;
            btn_Edit.Text = "Edit";
            btn_Edit.UseVisualStyleBackColor = true;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // EditMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 261);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MaximumSize = new Size(250, 300);
            MinimizeBox = false;
            MinimumSize = new Size(250, 300);
            Name = "EditMaterial";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit";
            Load += EditMaterial_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cb_Material;
        private TextBox txt_Name;
        private TextBox txt_Density;
        private TextBox txt_SpecificHeat;
        private TextBox txt_ThermalConductivity;
        private Button btn_Edit;
    }
}