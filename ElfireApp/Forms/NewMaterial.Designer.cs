namespace ElfireApp.Forms
{
    partial class NewMaterial
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
            txt_Name = new TextBox();
            txt_Density = new TextBox();
            txt_SpecificHeat = new TextBox();
            txt_ThermalConductivity = new TextBox();
            btn_Add = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(txt_Name, 0, 0);
            tableLayoutPanel1.Controls.Add(txt_Density, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_SpecificHeat, 0, 2);
            tableLayoutPanel1.Controls.Add(txt_ThermalConductivity, 0, 3);
            tableLayoutPanel1.Controls.Add(btn_Add, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(234, 221);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_Name
            // 
            txt_Name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_Name.Location = new Point(10, 10);
            txt_Name.Margin = new Padding(10);
            txt_Name.Name = "txt_Name";
            txt_Name.PlaceholderText = "Name";
            txt_Name.Size = new Size(214, 23);
            txt_Name.TabIndex = 0;
            // 
            // txt_Density
            // 
            txt_Density.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_Density.Location = new Point(10, 53);
            txt_Density.Margin = new Padding(10);
            txt_Density.Name = "txt_Density";
            txt_Density.PlaceholderText = "Density";
            txt_Density.Size = new Size(214, 23);
            txt_Density.TabIndex = 0;
            // 
            // txt_SpecificHeat
            // 
            txt_SpecificHeat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_SpecificHeat.Location = new Point(10, 96);
            txt_SpecificHeat.Margin = new Padding(10);
            txt_SpecificHeat.Name = "txt_SpecificHeat";
            txt_SpecificHeat.PlaceholderText = "Specific Heat";
            txt_SpecificHeat.Size = new Size(214, 23);
            txt_SpecificHeat.TabIndex = 0;
            // 
            // txt_ThermalConductivity
            // 
            txt_ThermalConductivity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt_ThermalConductivity.Location = new Point(10, 139);
            txt_ThermalConductivity.Margin = new Padding(10);
            txt_ThermalConductivity.Name = "txt_ThermalConductivity";
            txt_ThermalConductivity.PlaceholderText = "Thermal Conductivity";
            txt_ThermalConductivity.Size = new Size(214, 23);
            txt_ThermalConductivity.TabIndex = 0;
            // 
            // btn_Add
            // 
            btn_Add.Dock = DockStyle.Fill;
            btn_Add.Location = new Point(10, 182);
            btn_Add.Margin = new Padding(10);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(214, 29);
            btn_Add.TabIndex = 1;
            btn_Add.Text = "Add";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // NewMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 221);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MaximumSize = new Size(250, 260);
            MinimizeBox = false;
            MinimumSize = new Size(250, 260);
            Name = "NewMaterial";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txt_Name;
        private TextBox txt_Density;
        private TextBox txt_SpecificHeat;
        private TextBox txt_ThermalConductivity;
        private Button btn_Add;
    }
}