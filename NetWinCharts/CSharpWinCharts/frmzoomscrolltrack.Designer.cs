namespace CSharpChartExplorer
{
    partial class FrmZoomScrollTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZoomScrollTrack));
            this.topLabel = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.separatorLine = new System.Windows.Forms.Label();
            this.pointerPB = new System.Windows.Forms.RadioButton();
            this.zoomInPB = new System.Windows.Forms.RadioButton();
            this.zoomOutPB = new System.Windows.Forms.RadioButton();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.winChartViewer1 = new ChartDirector.WinChartViewer();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // topLabel
            // 
            this.topLabel.BackColor = System.Drawing.Color.Navy;
            this.topLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLabel.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLabel.ForeColor = System.Drawing.Color.Yellow;
            this.topLabel.Location = new System.Drawing.Point(0, 0);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(776, 24);
            this.topLabel.TabIndex = 18;
            this.topLabel.Text = "Advanced Software Engineering";
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.leftPanel.Controls.Add(this.separatorLine);
            this.leftPanel.Controls.Add(this.pointerPB);
            this.leftPanel.Controls.Add(this.zoomInPB);
            this.leftPanel.Controls.Add(this.zoomOutPB);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftPanel.Location = new System.Drawing.Point(0, 24);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(120, 379);
            this.leftPanel.TabIndex = 19;
            // 
            // separatorLine
            // 
            this.separatorLine.BackColor = System.Drawing.Color.Black;
            this.separatorLine.Dock = System.Windows.Forms.DockStyle.Right;
            this.separatorLine.Location = new System.Drawing.Point(119, 0);
            this.separatorLine.Name = "separatorLine";
            this.separatorLine.Size = new System.Drawing.Size(1, 379);
            this.separatorLine.TabIndex = 31;
            // 
            // pointerPB
            // 
            this.pointerPB.Appearance = System.Windows.Forms.Appearance.Button;
            this.pointerPB.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pointerPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pointerPB.Image = ((System.Drawing.Image)(resources.GetObject("pointerPB.Image")));
            this.pointerPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pointerPB.Location = new System.Drawing.Point(0, 0);
            this.pointerPB.Name = "pointerPB";
            this.pointerPB.Size = new System.Drawing.Size(120, 28);
            this.pointerPB.TabIndex = 0;
            this.pointerPB.Text = "      Pointer";
            this.pointerPB.CheckedChanged += new System.EventHandler(this.pointerPB_CheckedChanged);
            // 
            // zoomInPB
            // 
            this.zoomInPB.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoomInPB.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.zoomInPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomInPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomInPB.Image")));
            this.zoomInPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomInPB.Location = new System.Drawing.Point(0, 27);
            this.zoomInPB.Name = "zoomInPB";
            this.zoomInPB.Size = new System.Drawing.Size(120, 28);
            this.zoomInPB.TabIndex = 1;
            this.zoomInPB.Text = "      Zoom In";
            this.zoomInPB.CheckedChanged += new System.EventHandler(this.zoomInPB_CheckedChanged);
            // 
            // zoomOutPB
            // 
            this.zoomOutPB.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoomOutPB.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.zoomOutPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zoomOutPB.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutPB.Image")));
            this.zoomOutPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zoomOutPB.Location = new System.Drawing.Point(0, 54);
            this.zoomOutPB.Name = "zoomOutPB";
            this.zoomOutPB.Size = new System.Drawing.Size(120, 28);
            this.zoomOutPB.TabIndex = 2;
            this.zoomOutPB.Text = "      Zoom Out";
            this.zoomOutPB.CheckedChanged += new System.EventHandler(this.zoomOutPB_CheckedChanged);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.BackColor = System.Drawing.Color.White;
            this.hScrollBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hScrollBar1.Location = new System.Drawing.Point(120, 387);
            this.hScrollBar1.Maximum = 1000000000;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(656, 16);
            this.hScrollBar1.TabIndex = 3;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // winChartViewer1
            // 
            this.winChartViewer1.Location = new System.Drawing.Point(128, 32);
            this.winChartViewer1.Name = "winChartViewer1";
            this.winChartViewer1.Size = new System.Drawing.Size(640, 350);
            this.winChartViewer1.TabIndex = 21;
            this.winChartViewer1.TabStop = false;
            this.winChartViewer1.ViewPortChanged += new ChartDirector.WinViewPortEventHandler(this.winChartViewer1_ViewPortChanged);
            this.winChartViewer1.MouseMovePlotArea += new System.Windows.Forms.MouseEventHandler(this.winChartViewer1_MouseMovePlotArea);
            // 
            // FrmZoomScrollTrack
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(776, 403);
            this.Controls.Add(this.winChartViewer1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.topLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmZoomScrollTrack";
            this.Text = "Zooming and Scrolling with Track Line (1)";
            this.Load += new System.EventHandler(this.FrmZoomScrollTrack_Load);
            this.leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label separatorLine;
        private System.Windows.Forms.RadioButton pointerPB;
        private System.Windows.Forms.RadioButton zoomInPB;
        private System.Windows.Forms.RadioButton zoomOutPB;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private ChartDirector.WinChartViewer winChartViewer1;
    }
}