
namespace UWPCLaserMotion.WindowsForm
{
    partial class FrmAuthority
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuthority));
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxAuthotity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxPassWord = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cBoxAuthotity
            // 
            this.cBoxAuthotity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxAuthotity.FormattingEnabled = true;
            this.cBoxAuthotity.Items.AddRange(new object[] {
            resources.GetString("cBoxAuthotity.Items"),
            resources.GetString("cBoxAuthotity.Items1"),
            resources.GetString("cBoxAuthotity.Items2")});
            resources.ApplyResources(this.cBoxAuthotity, "cBoxAuthotity");
            this.cBoxAuthotity.Name = "cBoxAuthotity";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tBoxPassWord
            // 
            resources.ApplyResources(this.tBoxPassWord, "tBoxPassWord");
            this.tBoxPassWord.Name = "tBoxPassWord";
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            resources.ApplyResources(this.btnLogout, "btnLogout");
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FrmAuthority
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tBoxPassWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBoxAuthotity);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAuthority";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAuthority_FormClosing);
            this.Load += new System.EventHandler(this.FrmAuthority_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAuthority_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxAuthotity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxPassWord;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
    }
}