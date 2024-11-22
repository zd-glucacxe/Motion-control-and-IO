
namespace UWPCLaserMotion.WindowsForm
{
    partial class FrmManualControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManualControl));
            this.gBoxDoubleIO = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gBoxSingleIO = new System.Windows.Forms.GroupBox();
            this.gBoxSensor = new System.Windows.Forms.GroupBox();
            this.gBoxUser = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gBoxDoubleIO
            // 
            resources.ApplyResources(this.gBoxDoubleIO, "gBoxDoubleIO");
            this.gBoxDoubleIO.Name = "gBoxDoubleIO";
            this.gBoxDoubleIO.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gBoxSingleIO
            // 
            resources.ApplyResources(this.gBoxSingleIO, "gBoxSingleIO");
            this.gBoxSingleIO.Name = "gBoxSingleIO";
            this.gBoxSingleIO.TabStop = false;
            // 
            // gBoxSensor
            // 
            resources.ApplyResources(this.gBoxSensor, "gBoxSensor");
            this.gBoxSensor.Name = "gBoxSensor";
            this.gBoxSensor.TabStop = false;
            // 
            // gBoxUser
            // 
            resources.ApplyResources(this.gBoxUser, "gBoxUser");
            this.gBoxUser.Name = "gBoxUser";
            this.gBoxUser.TabStop = false;
            // 
            // FrmManualControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gBoxUser);
            this.Controls.Add(this.gBoxSensor);
            this.Controls.Add(this.gBoxSingleIO);
            this.Controls.Add(this.gBoxDoubleIO);
            this.Name = "FrmManualControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmManualControl_FormClosing);
            this.Load += new System.EventHandler(this.FrmManualControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gBoxDoubleIO;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gBoxSingleIO;
        private System.Windows.Forms.GroupBox gBoxSensor;
        private System.Windows.Forms.GroupBox gBoxUser;
    }
}