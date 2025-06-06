namespace ElfireApp.Forms
{
    partial class ASTM_E119
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
            graph.TabIndex = 0;
            graph.TabStop = false;
            graph.SizeChanged += GraphArea_SizeChanged;
            graph.MouseMove += graph_MouseMove;
            // 
            // ASTM_E119
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(graph);
            MinimumSize = new Size(600, 400);
            Name = "ASTM_E119";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterParent;
            Text = "ASTM E119";
            Load += ASTM_E119_Load;
            ((System.ComponentModel.ISupportInitialize)graph).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox graph;
    }
}