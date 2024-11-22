
namespace UWPCLaserMotion.WindowsForm
{
    partial class FrmAxisStatusControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelName = new System.Windows.Forms.Label();
            this.ColorNegative = new System.Windows.Forms.Label();
            this.ColorPositive = new System.Windows.Forms.Label();
            this.ColorHome = new System.Windows.Forms.Label();
            this.ColorAlarm = new System.Windows.Forms.Label();
            this.timerUI = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(5, 10);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(30, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "X：";
            // 
            // ColorNegative
            // 
            this.ColorNegative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorNegative.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColorNegative.Location = new System.Drawing.Point(65, 5);
            this.ColorNegative.Name = "ColorNegative";
            this.ColorNegative.Size = new System.Drawing.Size(25, 25);
            this.ColorNegative.TabIndex = 1;
            this.ColorNegative.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorPositive
            // 
            this.ColorPositive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPositive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColorPositive.Location = new System.Drawing.Point(130, 5);
            this.ColorPositive.Name = "ColorPositive";
            this.ColorPositive.Size = new System.Drawing.Size(25, 25);
            this.ColorPositive.TabIndex = 2;
            this.ColorPositive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorHome
            // 
            this.ColorHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColorHome.Location = new System.Drawing.Point(195, 5);
            this.ColorHome.Name = "ColorHome";
            this.ColorHome.Size = new System.Drawing.Size(25, 25);
            this.ColorHome.TabIndex = 3;
            this.ColorHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorAlarm
            // 
            this.ColorAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColorAlarm.Location = new System.Drawing.Point(255, 5);
            this.ColorAlarm.Name = "ColorAlarm";
            this.ColorAlarm.Size = new System.Drawing.Size(25, 25);
            this.ColorAlarm.TabIndex = 4;
            this.ColorAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerUI
            // 
            this.timerUI.Tick += new System.EventHandler(this.timerUI_Tick);
            // 
            // FrmAxisStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ColorAlarm);
            this.Controls.Add(this.ColorHome);
            this.Controls.Add(this.ColorPositive);
            this.Controls.Add(this.ColorNegative);
            this.Controls.Add(this.labelName);
            this.Name = "FrmAxisStatusControl";
            this.Size = new System.Drawing.Size(325, 35);
            this.Load += new System.EventHandler(this.FrmAxisStatusControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label ColorNegative;
        private System.Windows.Forms.Label ColorPositive;
        private System.Windows.Forms.Label ColorHome;
        private System.Windows.Forms.Label ColorAlarm;
        private System.Windows.Forms.Timer timerUI;
    }
}
