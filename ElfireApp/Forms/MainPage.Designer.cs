namespace ElfireApp.Forms
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            tableLayoutPanel1 = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            eurocodeToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem1 = new ToolStripMenuItem();
            openToolStripMenuItem1 = new ToolStripMenuItem();
            ıSO834ToolStripMenuItem = new ToolStripMenuItem();
            aSTME119ToolStripMenuItem = new ToolStripMenuItem();
            hydroCarbonToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            pDFToolStripMenuItem = new ToolStripMenuItem();
            cSVToolStripMenuItem = new ToolStripMenuItem();
            tXTToolStripMenuItem = new ToolStripMenuItem();
            jPGToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            darkToolStripMenuItem = new ToolStripMenuItem();
            lightToolStripMenuItem = new ToolStripMenuItem();
            tabControl = new TabControl();
            HomePage = new TabPage();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            txt_CurveName = new TextBox();
            btn_CreateCurve = new Button();
            btn_OpenCurve = new Button();
            btn_CompareCurves = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            HomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(menuStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(tabControl, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(1586, 855);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlLightLight;
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1586, 36);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, exportToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(56, 32);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { eurocodeToolStripMenuItem, ıSO834ToolStripMenuItem, aSTME119ToolStripMenuItem, hydroCarbonToolStripMenuItem });
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(155, 32);
            newToolStripMenuItem.Text = "Curve";
            // 
            // eurocodeToolStripMenuItem
            // 
            eurocodeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem1, openToolStripMenuItem1 });
            eurocodeToolStripMenuItem.Name = "eurocodeToolStripMenuItem";
            eurocodeToolStripMenuItem.Size = new Size(222, 32);
            eurocodeToolStripMenuItem.Text = "Eurocode";
            // 
            // newToolStripMenuItem1
            // 
            newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            newToolStripMenuItem1.Size = new Size(146, 32);
            newToolStripMenuItem1.Text = "New";
            newToolStripMenuItem1.Click += newToolStripMenuItem1_Click_1;
            // 
            // openToolStripMenuItem1
            // 
            openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            openToolStripMenuItem1.Size = new Size(146, 32);
            openToolStripMenuItem1.Text = "Open";
            // 
            // ıSO834ToolStripMenuItem
            // 
            ıSO834ToolStripMenuItem.Name = "ıSO834ToolStripMenuItem";
            ıSO834ToolStripMenuItem.Size = new Size(222, 32);
            ıSO834ToolStripMenuItem.Text = "ISO-834";
            // 
            // aSTME119ToolStripMenuItem
            // 
            aSTME119ToolStripMenuItem.Name = "aSTME119ToolStripMenuItem";
            aSTME119ToolStripMenuItem.Size = new Size(222, 32);
            aSTME119ToolStripMenuItem.Text = "ASTM-E119";
            // 
            // hydroCarbonToolStripMenuItem
            // 
            hydroCarbonToolStripMenuItem.Name = "hydroCarbonToolStripMenuItem";
            hydroCarbonToolStripMenuItem.Size = new Size(222, 32);
            hydroCarbonToolStripMenuItem.Text = "Hydro Carbon";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(155, 32);
            openToolStripMenuItem.Text = "Save";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pDFToolStripMenuItem, cSVToolStripMenuItem, tXTToolStripMenuItem, jPGToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(155, 32);
            exportToolStripMenuItem.Text = "Export";
            // 
            // pDFToolStripMenuItem
            // 
            pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            pDFToolStripMenuItem.Size = new Size(133, 32);
            pDFToolStripMenuItem.Text = "PDF";
            // 
            // cSVToolStripMenuItem
            // 
            cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            cSVToolStripMenuItem.Size = new Size(133, 32);
            cSVToolStripMenuItem.Text = "CSV";
            // 
            // tXTToolStripMenuItem
            // 
            tXTToolStripMenuItem.Name = "tXTToolStripMenuItem";
            tXTToolStripMenuItem.Size = new Size(133, 32);
            tXTToolStripMenuItem.Text = "TXT";
            // 
            // jPGToolStripMenuItem
            // 
            jPGToolStripMenuItem.Name = "jPGToolStripMenuItem";
            jPGToolStripMenuItem.Size = new Size(133, 32);
            jPGToolStripMenuItem.Text = "JPG";
            jPGToolStripMenuItem.Click += jPGToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(155, 32);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { themeToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(67, 32);
            viewToolStripMenuItem.Text = "View";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkToolStripMenuItem, lightToolStripMenuItem });
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(156, 32);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // darkToolStripMenuItem
            // 
            darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            darkToolStripMenuItem.Size = new Size(142, 32);
            darkToolStripMenuItem.Text = "Dark";
            // 
            // lightToolStripMenuItem
            // 
            lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            lightToolStripMenuItem.Size = new Size(142, 32);
            lightToolStripMenuItem.Text = "Light";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(HomePage);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(3, 39);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1580, 823);
            tabControl.SizeMode = TabSizeMode.FillToRight;
            tabControl.TabIndex = 7;
            // 
            // HomePage
            // 
            HomePage.AutoScroll = true;
            HomePage.BackColor = SystemColors.ControlLightLight;
            HomePage.BackgroundImage = (Image)resources.GetObject("HomePage.BackgroundImage");
            HomePage.BackgroundImageLayout = ImageLayout.Center;
            HomePage.Controls.Add(splitContainer1);
            HomePage.Location = new Point(4, 29);
            HomePage.Name = "HomePage";
            HomePage.Padding = new Padding(3);
            HomePage.Size = new Size(1572, 790);
            HomePage.TabIndex = 0;
            HomePage.Text = "Home";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.BackColor = SystemColors.Control;
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(1566, 784);
            splitContainer1.SplitterDistance = 155;
            splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel3);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(155, 784);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Eurocode Curve Calculator";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(txt_CurveName, 0, 0);
            tableLayoutPanel3.Controls.Add(btn_CreateCurve, 0, 1);
            tableLayoutPanel3.Controls.Add(btn_OpenCurve, 0, 2);
            tableLayoutPanel3.Controls.Add(btn_CompareCurves, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 23);
            tableLayoutPanel3.Margin = new Padding(5);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 6;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 35.4409332F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 64.55907F));
            tableLayoutPanel3.Size = new Size(149, 758);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // txt_CurveName
            // 
            txt_CurveName.Cursor = Cursors.IBeam;
            txt_CurveName.Dock = DockStyle.Fill;
            txt_CurveName.Location = new Point(5, 5);
            txt_CurveName.Margin = new Padding(5);
            txt_CurveName.Name = "txt_CurveName";
            txt_CurveName.PlaceholderText = "Curve Name";
            txt_CurveName.Size = new Size(139, 27);
            txt_CurveName.TabIndex = 0;
            // 
            // btn_CreateCurve
            // 
            btn_CreateCurve.Cursor = Cursors.Hand;
            btn_CreateCurve.Dock = DockStyle.Fill;
            btn_CreateCurve.Location = new Point(5, 42);
            btn_CreateCurve.Margin = new Padding(5);
            btn_CreateCurve.Name = "btn_CreateCurve";
            btn_CreateCurve.Size = new Size(139, 30);
            btn_CreateCurve.TabIndex = 1;
            btn_CreateCurve.Text = "Create";
            btn_CreateCurve.UseVisualStyleBackColor = true;
            btn_CreateCurve.Click += btn_CreateCurve_Click;
            // 
            // btn_OpenCurve
            // 
            btn_OpenCurve.Cursor = Cursors.Hand;
            btn_OpenCurve.Dock = DockStyle.Fill;
            btn_OpenCurve.Location = new Point(5, 82);
            btn_OpenCurve.Margin = new Padding(5);
            btn_OpenCurve.Name = "btn_OpenCurve";
            btn_OpenCurve.Size = new Size(139, 30);
            btn_OpenCurve.TabIndex = 2;
            btn_OpenCurve.Text = "Open";
            btn_OpenCurve.UseVisualStyleBackColor = true;
            btn_OpenCurve.Click += btn_OpenCurves_Click;
            // 
            // btn_CompareCurves
            // 
            btn_CompareCurves.Cursor = Cursors.Hand;
            btn_CompareCurves.Dock = DockStyle.Fill;
            btn_CompareCurves.Location = new Point(5, 122);
            btn_CompareCurves.Margin = new Padding(5);
            btn_CompareCurves.Name = "btn_CompareCurves";
            btn_CompareCurves.Size = new Size(139, 30);
            btn_CompareCurves.TabIndex = 3;
            btn_CompareCurves.Text = "Compare Curves";
            btn_CompareCurves.UseVisualStyleBackColor = true;
            btn_CompareCurves.Click += btn_CompareCurves_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.34055F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.65945F));
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1407, 784);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1586, 855);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Close;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 600);
            Name = "MainPage";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ELFIRE";
            WindowState = FormWindowState.Maximized;
            Load += MainPage_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
            HomePage.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem pDFToolStripMenuItem;
        private ToolStripMenuItem cSVToolStripMenuItem;
        private ToolStripMenuItem tXTToolStripMenuItem;
        private ToolStripMenuItem jPGToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem darkToolStripMenuItem;
        private ToolStripMenuItem lightToolStripMenuItem;
        private TabControl tabControl;
        private TabPage HomePage;
        public SplitContainer splitContainer1;
        private ToolStripMenuItem eurocodeToolStripMenuItem;
        private ToolStripMenuItem ıSO834ToolStripMenuItem;
        private ToolStripMenuItem aSTME119ToolStripMenuItem;
        private ToolStripMenuItem hydroCarbonToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem1;
        private ToolStripMenuItem openToolStripMenuItem1;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox txt_CurveName;
        private Button btn_CreateCurve;
        private Button btn_OpenCurve;
        private Button btn_CompareCurves;
        private TableLayoutPanel tableLayoutPanel2;
    }
}