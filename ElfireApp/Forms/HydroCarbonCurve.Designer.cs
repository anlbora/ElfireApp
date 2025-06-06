namespace ElfireApp.Forms
{
    partial class HydroCarbonCurve
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
            ((System.ComponentModel.ISupportInitialize)graph).BeginInit();
            SuspendLayout();
            // 
            // graph
            // 
            graph.Dock = DockStyle.Fill;
            graph.Location = new Point(20, 20);
            graph.Name = "graph";
            graph.Size = new Size(544, 321);
            graph.SizeMode = PictureBoxSizeMode.AutoSize;
            graph.TabIndex = 0;
            graph.TabStop = false;
            graph.StyleChanged += GraphArea_SizeChanged;
            // 
            // HydroCarbonCurve
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(graph);
            MinimumSize = new Size(600, 400);
            Name = "HydroCarbonCurve";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Hydro Carbon";
            Load += HydroCarbonCurve_Load;
            ((System.ComponentModel.ISupportInitialize)graph).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox graph;
    }
}