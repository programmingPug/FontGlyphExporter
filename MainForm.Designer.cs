namespace FontGlyphExporter
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTTF;
        private System.Windows.Forms.TextBox txtCSS;
        private System.Windows.Forms.Button btnBrowseTTF;
        private System.Windows.Forms.Button btnBrowseCSS;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FlowLayoutPanel iconFlowPanel;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.ComboBox cboRegexPattern;
        private System.Windows.Forms.Label lblRegexPattern;
        private System.Windows.Forms.TextBox txtCustomRegex;
        private System.Windows.Forms.Label lblCustomRegex;
        private System.Windows.Forms.Panel pnlSizes;
        private System.Windows.Forms.Label lblSizes;
        private System.Windows.Forms.CheckBox chkSize4;
        private System.Windows.Forms.CheckBox chkSize8;
        private System.Windows.Forms.CheckBox chkSize12;
        private System.Windows.Forms.CheckBox chkSize24;
        private System.Windows.Forms.Label lblSelectedSizes;

        private void InitializeComponent()
        {
            this.txtTTF = new System.Windows.Forms.TextBox();
            this.txtCSS = new System.Windows.Forms.TextBox();
            this.btnBrowseTTF = new System.Windows.Forms.Button();
            this.btnBrowseCSS = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.iconFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cboRegexPattern = new System.Windows.Forms.ComboBox();
            this.lblRegexPattern = new System.Windows.Forms.Label();
            this.txtCustomRegex = new System.Windows.Forms.TextBox();
            this.lblCustomRegex = new System.Windows.Forms.Label();
            this.pnlSizes = new System.Windows.Forms.Panel();
            this.lblSizes = new System.Windows.Forms.Label();
            this.chkSize4 = new System.Windows.Forms.CheckBox();
            this.chkSize8 = new System.Windows.Forms.CheckBox();
            this.chkSize12 = new System.Windows.Forms.CheckBox();
            this.chkSize24 = new System.Windows.Forms.CheckBox();
            this.lblSelectedSizes = new System.Windows.Forms.Label();
            this.pnlSizes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTTF
            this.txtTTF.Location = new System.Drawing.Point(12, 12);
            this.txtTTF.Size = new System.Drawing.Size(400, 23);
            // 
            // btnBrowseTTF
            this.btnBrowseTTF.Location = new System.Drawing.Point(418, 12);
            this.btnBrowseTTF.Size = new System.Drawing.Size(100, 23);
            this.btnBrowseTTF.Text = "Browse TTF";
            this.btnBrowseTTF.Click += new System.EventHandler(this.btnBrowseTTF_Click);
            // 
            // txtCSS
            this.txtCSS.Location = new System.Drawing.Point(12, 41);
            this.txtCSS.Size = new System.Drawing.Size(400, 23);
            // 
            // btnBrowseCSS
            this.btnBrowseCSS.Location = new System.Drawing.Point(418, 41);
            this.btnBrowseCSS.Size = new System.Drawing.Size(100, 23);
            this.btnBrowseCSS.Text = "Browse CSS";
            this.btnBrowseCSS.Click += new System.EventHandler(this.btnBrowseCSS_Click);
            // 
            // lblRegexPattern
            this.lblRegexPattern.Location = new System.Drawing.Point(540, 12);
            this.lblRegexPattern.Size = new System.Drawing.Size(80, 23);
            this.lblRegexPattern.Text = "Regex Pattern:";
            this.lblRegexPattern.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboRegexPattern
            this.cboRegexPattern.Location = new System.Drawing.Point(625, 12);
            this.cboRegexPattern.Size = new System.Drawing.Size(150, 23);
            this.cboRegexPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegexPattern.Items.AddRange(new object[] {
                "Font Awesome 5/6",
                "Font Awesome 4",
                "Material Icons",
                "Custom"
            });
            this.cboRegexPattern.SelectedIndexChanged += new System.EventHandler(this.cboRegexPattern_SelectedIndexChanged);
            // 
            // lblCustomRegex
            this.lblCustomRegex.Location = new System.Drawing.Point(540, 41);
            this.lblCustomRegex.Size = new System.Drawing.Size(80, 23);
            this.lblCustomRegex.Text = "Custom Regex:";
            this.lblCustomRegex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCustomRegex.Visible = false;
            // 
            // txtCustomRegex
            this.txtCustomRegex.Location = new System.Drawing.Point(625, 41);
            this.txtCustomRegex.Size = new System.Drawing.Size(150, 23);
            this.txtCustomRegex.Visible = false;
            // 
            // lblSizes
            this.lblSizes.Location = new System.Drawing.Point(418, 70);
            this.lblSizes.Size = new System.Drawing.Size(100, 23);
            this.lblSizes.Text = "Export Sizes:";
            this.lblSizes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSizes
            this.pnlSizes.Location = new System.Drawing.Point(520, 70);
            this.pnlSizes.Size = new System.Drawing.Size(255, 25);
            // 
            // chkSize4
            this.chkSize4.Location = new System.Drawing.Point(5, 3);
            this.chkSize4.Size = new System.Drawing.Size(50, 20);
            this.chkSize4.Text = "4x4";
            this.chkSize4.CheckedChanged += new System.EventHandler(this.sizeCheckbox_CheckedChanged);
            this.pnlSizes.Controls.Add(this.chkSize4);
            // 
            // chkSize8
            this.chkSize8.Location = new System.Drawing.Point(65, 3);
            this.chkSize8.Size = new System.Drawing.Size(50, 20);
            this.chkSize8.Text = "8x8";
            this.chkSize8.CheckedChanged += new System.EventHandler(this.sizeCheckbox_CheckedChanged);
            this.pnlSizes.Controls.Add(this.chkSize8);
            // 
            // chkSize12
            this.chkSize12.Location = new System.Drawing.Point(125, 3);
            this.chkSize12.Size = new System.Drawing.Size(60, 20);
            this.chkSize12.Text = "12x12";
            this.chkSize12.CheckedChanged += new System.EventHandler(this.sizeCheckbox_CheckedChanged);
            this.pnlSizes.Controls.Add(this.chkSize12);
            // 
            // chkSize24
            this.chkSize24.Location = new System.Drawing.Point(195, 3);
            this.chkSize24.Size = new System.Drawing.Size(60, 20);
            this.chkSize24.Text = "24x24";
            this.chkSize24.CheckedChanged += new System.EventHandler(this.sizeCheckbox_CheckedChanged);
            this.pnlSizes.Controls.Add(this.chkSize24);
            // 
            // lblSelectedSizes
            this.lblSelectedSizes.Location = new System.Drawing.Point(520, 95);
            this.lblSelectedSizes.Size = new System.Drawing.Size(255, 15);
            this.lblSelectedSizes.Text = "Selected sizes: 12, 24px";
            // 
            // btnLoad
            this.btnLoad.Location = new System.Drawing.Point(12, 70);
            this.btnLoad.Size = new System.Drawing.Size(100, 23);
            this.btnLoad.Text = "Load Icons";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExport
            this.btnExport.Location = new System.Drawing.Point(118, 70);
            this.btnExport.Size = new System.Drawing.Size(120, 23);
            this.btnExport.Text = "Export Selected";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblCounter
            this.lblCounter.Location = new System.Drawing.Point(250, 70);
            this.lblCounter.Size = new System.Drawing.Size(150, 23);
            this.lblCounter.Text = "Selected: 0 / 0";
            // 
            // iconFlowPanel
            this.iconFlowPanel.Location = new System.Drawing.Point(12, 120);
            this.iconFlowPanel.Size = new System.Drawing.Size(760, 430);
            this.iconFlowPanel.AutoScroll = true;
            this.iconFlowPanel.WrapContents = true;
            this.iconFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            // 
            // MainForm
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtTTF);
            this.Controls.Add(this.btnBrowseTTF);
            this.Controls.Add(this.txtCSS);
            this.Controls.Add(this.btnBrowseCSS);
            this.Controls.Add(this.lblRegexPattern);
            this.Controls.Add(this.cboRegexPattern);
            this.Controls.Add(this.lblCustomRegex);
            this.Controls.Add(this.txtCustomRegex);
            this.Controls.Add(this.lblSizes);
            this.Controls.Add(this.pnlSizes);
            this.Controls.Add(this.lblSelectedSizes);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.iconFlowPanel);
            this.Name = "MainForm";
            this.Text = "Font Awesome Icon Exporter";
            this.pnlSizes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}