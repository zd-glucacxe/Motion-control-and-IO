
namespace UWPCLaserMotion.WindowsForm
{
    partial class FrmIOControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIOControl));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelControl = new System.Windows.Forms.Panel();
            this.cBoxOutput = new System.Windows.Forms.CheckBox();
            this.cBoxEdit = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gBoxIOIn = new System.Windows.Forms.GroupBox();
            this.gBoxIOOut = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gBoxAD = new System.Windows.Forms.GroupBox();
            this.gBoxDA = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gBoxIOIn2 = new System.Windows.Forms.GroupBox();
            this.gBoxIOOut2 = new System.Windows.Forms.GroupBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvPLC = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLC)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panelControl
            // 
            resources.ApplyResources(this.panelControl, "panelControl");
            this.panelControl.Controls.Add(this.cBoxOutput);
            this.panelControl.Controls.Add(this.cBoxEdit);
            this.panelControl.Name = "panelControl";
            // 
            // cBoxOutput
            // 
            resources.ApplyResources(this.cBoxOutput, "cBoxOutput");
            this.cBoxOutput.Name = "cBoxOutput";
            this.cBoxOutput.UseVisualStyleBackColor = true;
            // 
            // cBoxEdit
            // 
            resources.ApplyResources(this.cBoxEdit, "cBoxEdit");
            this.cBoxEdit.Name = "cBoxEdit";
            this.cBoxEdit.UseVisualStyleBackColor = true;
            this.cBoxEdit.CheckedChanged += new System.EventHandler(this.CBoxEdit_CheckedChanged);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.gBoxIOIn);
            this.tabPage1.Controls.Add(this.gBoxIOOut);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gBoxIOIn
            // 
            resources.ApplyResources(this.gBoxIOIn, "gBoxIOIn");
            this.gBoxIOIn.Name = "gBoxIOIn";
            this.gBoxIOIn.TabStop = false;
            // 
            // gBoxIOOut
            // 
            resources.ApplyResources(this.gBoxIOOut, "gBoxIOOut");
            this.gBoxIOOut.Name = "gBoxIOOut";
            this.gBoxIOOut.TabStop = false;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.gBoxAD);
            this.tabPage2.Controls.Add(this.gBoxDA);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gBoxAD
            // 
            resources.ApplyResources(this.gBoxAD, "gBoxAD");
            this.gBoxAD.Name = "gBoxAD";
            this.gBoxAD.TabStop = false;
            // 
            // gBoxDA
            // 
            resources.ApplyResources(this.gBoxDA, "gBoxDA");
            this.gBoxDA.Name = "gBoxDA";
            this.gBoxDA.TabStop = false;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.gBoxIOIn2);
            this.tabPage3.Controls.Add(this.gBoxIOOut2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gBoxIOIn2
            // 
            resources.ApplyResources(this.gBoxIOIn2, "gBoxIOIn2");
            this.gBoxIOIn2.Name = "gBoxIOIn2";
            this.gBoxIOIn2.TabStop = false;
            // 
            // gBoxIOOut2
            // 
            resources.ApplyResources(this.gBoxIOOut2, "gBoxIOOut2");
            this.gBoxIOOut2.Name = "gBoxIOOut2";
            this.gBoxIOOut2.TabStop = false;
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Controls.Add(this.dgvPLC);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvPLC
            // 
            resources.ApplyResources(this.dgvPLC, "dgvPLC");
            this.dgvPLC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPLC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvPLC.Name = "dgvPLC";
            this.dgvPLC.ReadOnly = true;
            this.dgvPLC.RowTemplate.Height = 27;
            this.dgvPLC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPLC_CellClick);
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Items.AddRange(new object[] {
            "String",
            "Bool",
            "Short",
            "Int",
            "Float",
            "Ushort"});
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column4
            // 
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            resources.ApplyResources(this.Column5, "Column5");
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            resources.ApplyResources(this.Column6, "Column6");
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // FrmIOControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelControl);
            this.Name = "FrmIOControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIOControl_FormClosing);
            this.Load += new System.EventHandler(this.FrmIOControl_Load);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.CheckBox cBoxOutput;
        private System.Windows.Forms.CheckBox cBoxEdit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gBoxIOIn;
        private System.Windows.Forms.GroupBox gBoxIOOut;
        private System.Windows.Forms.GroupBox gBoxAD;
        private System.Windows.Forms.GroupBox gBoxDA;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gBoxIOIn2;
        private System.Windows.Forms.GroupBox gBoxIOOut2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvPLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}