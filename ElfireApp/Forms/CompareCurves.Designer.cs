namespace ElfireApp.Forms
{
    partial class CompareCurves
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
            btn_ExportGraph = new Button();
            graph = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            cb_ASTME119 = new CheckBox();
            cb_HydroCarbon = new CheckBox();
            cb_ISO834 = new CheckBox();
            cb_ShowGrids = new CheckBox();
            cb_MaksTemp = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)graph).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(btn_ExportGraph, 1, 0);
            tableLayoutPanel1.Controls.Add(graph, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tableLayoutPanel1.Size = new Size(784, 561);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_ExportGraph
            // 
            btn_ExportGraph.Dock = DockStyle.Fill;
            btn_ExportGraph.Location = new Point(692, 3);
            btn_ExportGraph.Name = "btn_ExportGraph";
            btn_ExportGraph.Size = new Size(89, 36);
            btn_ExportGraph.TabIndex = 1;
            btn_ExportGraph.Text = "Export Graph";
            btn_ExportGraph.UseVisualStyleBackColor = true;
            btn_ExportGraph.Click += btn_SaveImage_Click;
            // 
            // graph
            // 
            tableLayoutPanel1.SetColumnSpan(graph, 2);
            graph.Dock = DockStyle.Fill;
            graph.Location = new Point(10, 52);
            graph.Margin = new Padding(10);
            graph.Name = "graph";
            tableLayoutPanel1.SetRowSpan(graph, 2);
            graph.Size = new Size(764, 499);
            graph.TabIndex = 2;
            graph.TabStop = false;
            graph.SizeChanged += graph_SizeChanged;
            graph.MouseMove += graph_MouseMove;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(cb_ASTME119, 0, 0);
            tableLayoutPanel2.Controls.Add(cb_HydroCarbon, 0, 0);
            tableLayoutPanel2.Controls.Add(cb_ISO834, 0, 0);
            tableLayoutPanel2.Controls.Add(cb_ShowGrids, 5, 0);
            tableLayoutPanel2.Controls.Add(cb_MaksTemp, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(683, 36);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // cb_ASTME119
            // 
            cb_ASTME119.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cb_ASTME119.AutoSize = true;
            cb_ASTME119.Location = new Point(191, 5);
            cb_ASTME119.Margin = new Padding(5);
            cb_ASTME119.Name = "cb_ASTME119";
            cb_ASTME119.Size = new Size(84, 26);
            cb_ASTME119.TabIndex = 12;
            cb_ASTME119.Text = "ASTM E119";
            cb_ASTME119.UseVisualStyleBackColor = true;
            // 
            // cb_HydroCarbon
            // 
            cb_HydroCarbon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cb_HydroCarbon.AutoSize = true;
            cb_HydroCarbon.Location = new Point(80, 5);
            cb_HydroCarbon.Margin = new Padding(5);
            cb_HydroCarbon.Name = "cb_HydroCarbon";
            cb_HydroCarbon.Size = new Size(101, 26);
            cb_HydroCarbon.TabIndex = 11;
            cb_HydroCarbon.Text = "Hydro Carbon";
            cb_HydroCarbon.UseVisualStyleBackColor = true;
            // 
            // cb_ISO834
            // 
            cb_ISO834.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cb_ISO834.AutoSize = true;
            cb_ISO834.Location = new Point(5, 5);
            cb_ISO834.Margin = new Padding(5);
            cb_ISO834.Name = "cb_ISO834";
            cb_ISO834.Size = new Size(65, 26);
            cb_ISO834.TabIndex = 10;
            cb_ISO834.Text = "ISO 834";
            cb_ISO834.UseVisualStyleBackColor = true;
            // 
            // cb_ShowGrids
            // 
            cb_ShowGrids.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cb_ShowGrids.AutoSize = true;
            cb_ShowGrids.Location = new Point(477, 5);
            cb_ShowGrids.Margin = new Padding(5);
            cb_ShowGrids.Name = "cb_ShowGrids";
            cb_ShowGrids.Size = new Size(85, 26);
            cb_ShowGrids.TabIndex = 15;
            cb_ShowGrids.Text = "Show Grids";
            cb_ShowGrids.UseVisualStyleBackColor = true;
            // 
            // cb_MaksTemp
            // 
            cb_MaksTemp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cb_MaksTemp.AutoSize = true;
            cb_MaksTemp.Location = new Point(285, 5);
            cb_MaksTemp.Margin = new Padding(5);
            cb_MaksTemp.Name = "cb_MaksTemp";
            cb_MaksTemp.Size = new Size(182, 26);
            cb_MaksTemp.TabIndex = 14;
            cb_MaksTemp.Text = "Show Maximum Temperature";
            cb_MaksTemp.UseVisualStyleBackColor = true;
            cb_MaksTemp.CheckedChanged += chkShowMaxTemp_CheckedChanged;
            // 
            // CompareCurves
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(800, 600);
            Name = "CompareCurves";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Compare Curves";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)graph).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_ExportGraph;
        private PictureBox graph;
        private TableLayoutPanel tableLayoutPanel2;
        private CheckBox cb_ShowGrids;
        private CheckBox cb_MaksTemp;
        private CheckBox cb_ASTME119;
        private CheckBox cb_HydroCarbon;
        private CheckBox cb_ISO834;
    }
}