
namespace UWPCLaserMotion.WindowsForm
{
    partial class FrmSysConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSysConfig));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabSysConfig = new System.Windows.Forms.TabControl();
            this.tPageDoubleIO = new System.Windows.Forms.TabPage();
            this.dgvDoubleIO = new System.Windows.Forms.DataGridView();
            this.tPageSingleIO = new System.Windows.Forms.TabPage();
            this.dgvSingleIO = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvSensor = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cLBoxSetInvertIn = new System.Windows.Forms.CheckedListBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSysConfig.SuspendLayout();
            this.tPageDoubleIO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoubleIO)).BeginInit();
            this.tPageSingleIO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSingleIO)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensor)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // tabSysConfig
            // 
            resources.ApplyResources(this.tabSysConfig, "tabSysConfig");
            this.tabSysConfig.Controls.Add(this.tPageDoubleIO);
            this.tabSysConfig.Controls.Add(this.tPageSingleIO);
            this.tabSysConfig.Controls.Add(this.tabPage1);
            this.tabSysConfig.Controls.Add(this.tabPage3);
            this.tabSysConfig.Name = "tabSysConfig";
            this.tabSysConfig.SelectedIndex = 0;
            // 
            // tPageDoubleIO
            // 
            resources.ApplyResources(this.tPageDoubleIO, "tPageDoubleIO");
            this.tPageDoubleIO.Controls.Add(this.dgvDoubleIO);
            this.tPageDoubleIO.Name = "tPageDoubleIO";
            this.tPageDoubleIO.UseVisualStyleBackColor = true;
            // 
            // dgvDoubleIO
            // 
            resources.ApplyResources(this.dgvDoubleIO, "dgvDoubleIO");
            this.dgvDoubleIO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoubleIO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoubleIO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvDoubleIO.Name = "dgvDoubleIO";
            this.dgvDoubleIO.RowTemplate.Height = 27;
            this.dgvDoubleIO.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DGV_CellBeginEdit);
            // 
            // tPageSingleIO
            // 
            resources.ApplyResources(this.tPageSingleIO, "tPageSingleIO");
            this.tPageSingleIO.Controls.Add(this.dgvSingleIO);
            this.tPageSingleIO.Name = "tPageSingleIO";
            this.tPageSingleIO.UseVisualStyleBackColor = true;
            // 
            // dgvSingleIO
            // 
            resources.ApplyResources(this.dgvSingleIO, "dgvSingleIO");
            this.dgvSingleIO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSingleIO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSingleIO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7});
            this.dgvSingleIO.Name = "dgvSingleIO";
            this.dgvSingleIO.RowTemplate.Height = 27;
            this.dgvSingleIO.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DGV_CellBeginEdit);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.dgvSensor);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvSensor
            // 
            resources.ApplyResources(this.dgvSensor, "dgvSensor");
            this.dgvSensor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSensor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSensor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvSensor.Name = "dgvSensor";
            this.dgvSensor.RowTemplate.Height = 27;
            this.dgvSensor.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DGV_CellBeginEdit);
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.cLBoxSetInvertIn);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cLBoxSetInvertIn
            // 
            resources.ApplyResources(this.cLBoxSetInvertIn, "cLBoxSetInvertIn");
            this.cLBoxSetInvertIn.FormattingEnabled = true;
            this.cLBoxSetInvertIn.MultiColumn = true;
            this.cLBoxSetInvertIn.Name = "cLBoxSetInvertIn";
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            resources.ApplyResources(this.Column5, "Column5");
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            resources.ApplyResources(this.Column6, "Column6");
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            resources.ApplyResources(this.Column7, "Column7");
            this.Column7.Name = "Column7";
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // FrmSysConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabSysConfig);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmSysConfig";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSyStemConfig_FormClosing);
            this.Load += new System.EventHandler(this.FrmSyStemConfig_Load);
            this.tabSysConfig.ResumeLayout(false);
            this.tPageDoubleIO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoubleIO)).EndInit();
            this.tPageSingleIO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSingleIO)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensor)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabSysConfig;
        private System.Windows.Forms.TabPage tPageDoubleIO;
        private System.Windows.Forms.TabPage tPageSingleIO;
        private System.Windows.Forms.DataGridView dgvSingleIO;
        private System.Windows.Forms.DataGridView dgvDoubleIO;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvSensor;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckedListBox cLBoxSetInvertIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}