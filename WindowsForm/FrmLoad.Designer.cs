
namespace UWPCLaserMotion.WindowsForm
{
    partial class FrmLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoad));
            this.lBoxLog = new System.Windows.Forms.ListBox();
            this.pBarView = new System.Windows.Forms.ProgressBar();
            this.pBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lBoxLog
            // 
            this.lBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBoxLog.FormattingEnabled = true;
            this.lBoxLog.ItemHeight = 15;
            this.lBoxLog.Location = new System.Drawing.Point(0, 165);
            this.lBoxLog.Name = "lBoxLog";
            this.lBoxLog.Size = new System.Drawing.Size(800, 458);
            this.lBoxLog.TabIndex = 4;
            // 
            // pBarView
            // 
            this.pBarView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBarView.Location = new System.Drawing.Point(0, 623);
            this.pBarView.MarqueeAnimationSpeed = 10;
            this.pBarView.Name = "pBarView";
            this.pBarView.Size = new System.Drawing.Size(800, 23);
            this.pBarView.TabIndex = 5;
            // 
            // pBoxLogo
            // 
            this.pBoxLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pBoxLogo.Image")));
            this.pBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pBoxLogo.Name = "pBoxLogo";
            this.pBoxLogo.Size = new System.Drawing.Size(800, 165);
            this.pBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxLogo.TabIndex = 3;
            this.pBoxLogo.TabStop = false;
            // 
            // FrmLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 646);
            this.Controls.Add(this.lBoxLog);
            this.Controls.Add(this.pBarView);
            this.Controls.Add(this.pBoxLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UW";
            this.Load += new System.EventHandler(this.FrmLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lBoxLog;
        private System.Windows.Forms.ProgressBar pBarView;
        private System.Windows.Forms.PictureBox pBoxLogo;
    }
}