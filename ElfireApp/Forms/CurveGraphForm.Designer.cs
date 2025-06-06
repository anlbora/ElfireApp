namespace ElfireApp.Forms
{
    partial class CurveGraphForm
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
            graph = new PictureBox();
            btn_SaveImage = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            cb_ShowPhases = new CheckBox();
            cb_MaksTemp = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)graph).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // graph
            // 
            graph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(graph, 2);
            graph.Location = new Point(3, 39);
            graph.Name = "graph";
            graph.Size = new Size(738, 479);
            graph.SizeMode = PictureBoxSizeMode.StretchImage;
            graph.TabIndex = 0;
            graph.TabStop = false;
            graph.SizeChanged += graph_SizeChanged;
            graph.MouseMove += graph_MouseMove;
            // 
            // btn_SaveImage
            // 
            btn_SaveImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btn_SaveImage.Location = new Point(666, 3);
            btn_SaveImage.Name = "btn_SaveImage";
            btn_SaveImage.Size = new Size(75, 30);
            btn_SaveImage.TabIndex = 1;
            btn_SaveImage.Text = "Save Graph";
            btn_SaveImage.UseVisualStyleBackColor = true;
            btn_SaveImage.Click += btn_SaveImage_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(graph, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_SaveImage, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(20, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(744, 521);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(cb_ShowPhases, 0, 0);
            tableLayoutPanel2.Controls.Add(cb_MaksTemp, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(657, 30);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // cb_ShowPhases
            // 
            cb_ShowPhases.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cb_ShowPhases.AutoSize = true;
            cb_ShowPhases.Location = new Point(560, 3);
            cb_ShowPhases.Name = "cb_ShowPhases";
            cb_ShowPhases.Size = new Size(94, 24);
            cb_ShowPhases.TabIndex = 4;
            cb_ShowPhases.Text = "Show Phases";
            cb_ShowPhases.UseVisualStyleBackColor = true;
            // 
            // cb_MaksTemp
            // 
            cb_MaksTemp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cb_MaksTemp.AutoSize = true;
            cb_MaksTemp.Location = new Point(404, 3);
            cb_MaksTemp.Name = "cb_MaksTemp";
            cb_MaksTemp.Size = new Size(150, 24);
            cb_MaksTemp.TabIndex = 3;
            cb_MaksTemp.Text = "Show Max Temperature";
            cb_MaksTemp.UseVisualStyleBackColor = true;
            // 
            // CurveGraphForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(800, 600);
            Name = "CurveGraphForm";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Eurocode Curve";
            ((System.ComponentModel.ISupportInitialize)graph).EndInit();
            tableLayoutPanel1.ResumeLayout(true);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox graph;
        private Button btn_SaveImage;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private CheckBox cb_ShowPhases;
        private CheckBox cb_MaksTemp;
    }
}