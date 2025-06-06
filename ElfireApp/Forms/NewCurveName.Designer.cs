namespace ElfireApp.Forms
{
    partial class NewCurveName
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
            txt_CurveName = new TextBox();
            btn_Create = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(txt_CurveName, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_Create, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(322, 111);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_CurveName
            // 
            txt_CurveName.Dock = DockStyle.Fill;
            txt_CurveName.Location = new Point(11, 13);
            txt_CurveName.Margin = new Padding(11, 13, 11, 13);
            txt_CurveName.Name = "txt_CurveName";
            txt_CurveName.PlaceholderText = "Curve Name";
            txt_CurveName.Size = new Size(300, 27);
            txt_CurveName.TabIndex = 0;
            txt_CurveName.KeyPress += txt_CurveName_KeyPress;
            // 
            // btn_Create
            // 
            btn_Create.Dock = DockStyle.Fill;
            btn_Create.Location = new Point(11, 68);
            btn_Create.Margin = new Padding(11, 13, 11, 13);
            btn_Create.Name = "btn_Create";
            btn_Create.Size = new Size(300, 30);
            btn_Create.TabIndex = 1;
            btn_Create.Text = "Create Curve";
            btn_Create.UseVisualStyleBackColor = true;
            btn_Create.Click += btn_Create_Click;
            // 
            // NewCurveName
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 111);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(340, 158);
            MinimumSize = new Size(340, 158);
            Name = "NewCurveName";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Curve";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txt_CurveName;
        private Button btn_Create;
    }
}