
namespace UWPCLaserMotion.WindowsForm
{
    partial class FrmAxisPosControl
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLess = new System.Windows.Forms.Button();
            this.tBoxOffset = new System.Windows.Forms.TextBox();
            this.tBoxValue = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.timerUI = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(277, 5);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 28);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Tag = "1";
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnLess
            // 
            this.btnLess.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLess.Location = new System.Drawing.Point(144, 5);
            this.btnLess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLess.Name = "btnLess";
            this.btnLess.Size = new System.Drawing.Size(40, 28);
            this.btnLess.TabIndex = 8;
            this.btnLess.Tag = "1";
            this.btnLess.Text = "-";
            this.btnLess.UseVisualStyleBackColor = true;
            // 
            // tBoxOffset
            // 
            this.tBoxOffset.Location = new System.Drawing.Point(190, 7);
            this.tBoxOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxOffset.Name = "tBoxOffset";
            this.tBoxOffset.Size = new System.Drawing.Size(80, 25);
            this.tBoxOffset.TabIndex = 7;
            this.tBoxOffset.Text = "0.00";
            // 
            // tBoxValue
            // 
            this.tBoxValue.Location = new System.Drawing.Point(56, 7);
            this.tBoxValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tBoxValue.Name = "tBoxValue";
            this.tBoxValue.ReadOnly = true;
            this.tBoxValue.Size = new System.Drawing.Size(82, 25);
            this.tBoxValue.TabIndex = 6;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelName.Location = new System.Drawing.Point(5, 11);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(23, 15);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "X:";
            // 
            // timerUI
            // 
            this.timerUI.Tick += new System.EventHandler(this.timerUI_Tick);
            // 
            // FrmAxisPosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLess);
            this.Controls.Add(this.tBoxOffset);
            this.Controls.Add(this.tBoxValue);
            this.Controls.Add(this.labelName);
            this.Name = "FrmAxisPosControl";
            this.Size = new System.Drawing.Size(325, 35);
            this.Load += new System.EventHandler(this.FrmAxisPosControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLess;
        private System.Windows.Forms.TextBox tBoxOffset;
        private System.Windows.Forms.TextBox tBoxValue;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Timer timerUI;
    }
}
