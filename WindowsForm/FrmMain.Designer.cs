

namespace UWPCLaserMotion.WindowsForm
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gBoxAxisControl = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioRelative = new System.Windows.Forms.RadioButton();
            this.radioAbsolutely = new System.Windows.Forms.RadioButton();
            this.radioContinue = new System.Windows.Forms.RadioButton();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tPagelog = new System.Windows.Forms.TabPage();
            this.lBoxLog = new System.Windows.Forms.ListBox();
            this.tPageManualControl = new System.Windows.Forms.TabPage();
            this.tPageAxisXY = new System.Windows.Forms.TabPage();
            this.chartXY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetXY = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tBoxYmax = new System.Windows.Forms.TextBox();
            this.tBoxXmax = new System.Windows.Forms.TextBox();
            this.tBoxYmin = new System.Windows.Forms.TextBox();
            this.tBoxXmin = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tPageGCode = new System.Windows.Forms.TabPage();
            this.rBoxGcode = new System.Windows.Forms.RichTextBox();
            this.lBoxGcodeName = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvArray1 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tPageAlarm = new System.Windows.Forms.TabPage();
            this.lBoxAlarm = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GcodeView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.参数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxBasicOperation = new System.Windows.Forms.GroupBox();
            this.panelUserOperation = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnTeachingProgram = new System.Windows.Forms.Button();
            this.panelSwith = new System.Windows.Forms.Panel();
            this.radioNop = new System.Windows.Forms.RadioButton();
            this.radioWork = new System.Windows.Forms.RadioButton();
            this.btnStrat = new System.Windows.Forms.Button();
            this.panelAuto = new System.Windows.Forms.Panel();
            this.radioManual = new System.Windows.Forms.RadioButton();
            this.radioAuto = new System.Windows.Forms.RadioButton();
            this.btnToZero = new System.Windows.Forms.Button();
            this.btnToHome = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rTBoxNowError = new System.Windows.Forms.RichTextBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelRunStatus = new System.Windows.Forms.Panel();
            this.panelUserStatus = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.ColorRun = new System.Windows.Forms.Label();
            this.ColorStop = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ColorHandwheelStop = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.ColorX100 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.ColorX10 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.ColorX1 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.ColorW = new System.Windows.Forms.Label();
            this.labelW = new System.Windows.Forms.Label();
            this.ColorZ = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.ColorY = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.ColorX = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.gBoxAxisStatus = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuTool = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenGcode = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveGcode = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAuthority = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolSysConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolInitConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolAxisConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.btnError = new System.Windows.Forms.ToolStripMenuItem();
            this.阵列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolOpenModel = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolSaveModel = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolLock = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOther = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolIOControl = new System.Windows.Forms.ToolStripMenuItem();
            this.导入DXFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWarning = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBarCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBoxBarCode = new System.Windows.Forms.ToolStripTextBox();
            this.statusShowTool = new System.Windows.Forms.StatusStrip();
            this.ColorPLC = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColorCard = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColorMES = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColorGlue = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelWorkTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelWorkTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelWeldNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelWeldNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelOneTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelOneTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelVel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelVel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtModeFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.UITimer = new System.Windows.Forms.Timer(this.components);
            this.TipGCode = new System.Windows.Forms.ToolTip(this.components);
            this.gBoxAxisControl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tPagelog.SuspendLayout();
            this.tPageAxisXY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartXY)).BeginInit();
            this.panel1.SuspendLayout();
            this.tPageGCode.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArray1)).BeginInit();
            this.tPageAlarm.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GcodeView)).BeginInit();
            this.gBoxBasicOperation.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelSwith.SuspendLayout();
            this.panelAuto.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelRunStatus.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gBoxAxisStatus.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuTool.SuspendLayout();
            this.statusShowTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxAxisControl
            // 
            resources.ApplyResources(this.gBoxAxisControl, "gBoxAxisControl");
            this.gBoxAxisControl.Controls.Add(this.panel2);
            this.gBoxAxisControl.Name = "gBoxAxisControl";
            this.gBoxAxisControl.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioRelative);
            this.panel2.Controls.Add(this.radioAbsolutely);
            this.panel2.Controls.Add(this.radioContinue);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // radioRelative
            // 
            resources.ApplyResources(this.radioRelative, "radioRelative");
            this.radioRelative.Name = "radioRelative";
            this.radioRelative.UseVisualStyleBackColor = true;
            this.radioRelative.CheckedChanged += new System.EventHandler(this.radioRelative_CheckedChanged);
            // 
            // radioAbsolutely
            // 
            resources.ApplyResources(this.radioAbsolutely, "radioAbsolutely");
            this.radioAbsolutely.Name = "radioAbsolutely";
            this.radioAbsolutely.UseVisualStyleBackColor = true;
            this.radioAbsolutely.CheckedChanged += new System.EventHandler(this.radioAbsolutely_CheckedChanged);
            // 
            // radioContinue
            // 
            resources.ApplyResources(this.radioContinue, "radioContinue");
            this.radioContinue.Checked = true;
            this.radioContinue.Name = "radioContinue";
            this.radioContinue.TabStop = true;
            this.radioContinue.UseVisualStyleBackColor = true;
            this.radioContinue.CheckedChanged += new System.EventHandler(this.radioContinue_CheckedChanged);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tPagelog);
            this.tabControlMain.Controls.Add(this.tPageManualControl);
            this.tabControlMain.Controls.Add(this.tPageAxisXY);
            this.tabControlMain.Controls.Add(this.tPageGCode);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Controls.Add(this.tPageAlarm);
            this.tabControlMain.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            // 
            // tPagelog
            // 
            this.tPagelog.Controls.Add(this.lBoxLog);
            resources.ApplyResources(this.tPagelog, "tPagelog");
            this.tPagelog.Name = "tPagelog";
            this.tPagelog.UseVisualStyleBackColor = true;
            // 
            // lBoxLog
            // 
            resources.ApplyResources(this.lBoxLog, "lBoxLog");
            this.lBoxLog.FormattingEnabled = true;
            this.lBoxLog.Name = "lBoxLog";
            this.lBoxLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lBoxLog_MouseDoubleClick);
            // 
            // tPageManualControl
            // 
            resources.ApplyResources(this.tPageManualControl, "tPageManualControl");
            this.tPageManualControl.Name = "tPageManualControl";
            this.tPageManualControl.UseVisualStyleBackColor = true;
            // 
            // tPageAxisXY
            // 
            this.tPageAxisXY.Controls.Add(this.chartXY);
            this.tPageAxisXY.Controls.Add(this.panel1);
            resources.ApplyResources(this.tPageAxisXY, "tPageAxisXY");
            this.tPageAxisXY.Name = "tPageAxisXY";
            this.tPageAxisXY.UseVisualStyleBackColor = true;
            // 
            // chartXY
            // 
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.Crossing = 0D;
            chartArea1.AxisX.Interval = 40D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Maximum = 200D;
            chartArea1.AxisX.Minimum = -200D;
            chartArea1.AxisY.Crossing = 0D;
            chartArea1.AxisY.Interval = 40D;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Maximum = 200D;
            chartArea1.AxisY.Minimum = -200D;
            chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea1.Name = "ChartArea1";
            this.chartXY.ChartAreas.Add(chartArea1);
            resources.ApplyResources(this.chartXY, "chartXY");
            this.chartXY.Name = "chartXY";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series2";
            this.chartXY.Series.Add(series1);
            this.chartXY.Series.Add(series2);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSetXY);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.tBoxYmax);
            this.panel1.Controls.Add(this.tBoxXmax);
            this.panel1.Controls.Add(this.tBoxYmin);
            this.panel1.Controls.Add(this.tBoxXmin);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnSetXY
            // 
            resources.ApplyResources(this.btnSetXY, "btnSetXY");
            this.btnSetXY.Name = "btnSetXY";
            this.btnSetXY.UseVisualStyleBackColor = true;
            this.btnSetXY.Click += new System.EventHandler(this.btnSetXY_Click);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // tBoxYmax
            // 
            resources.ApplyResources(this.tBoxYmax, "tBoxYmax");
            this.tBoxYmax.Name = "tBoxYmax";
            // 
            // tBoxXmax
            // 
            resources.ApplyResources(this.tBoxXmax, "tBoxXmax");
            this.tBoxXmax.Name = "tBoxXmax";
            // 
            // tBoxYmin
            // 
            resources.ApplyResources(this.tBoxYmin, "tBoxYmin");
            this.tBoxYmin.Name = "tBoxYmin";
            // 
            // tBoxXmin
            // 
            resources.ApplyResources(this.tBoxXmin, "tBoxXmin");
            this.tBoxXmin.Name = "tBoxXmin";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // tPageGCode
            // 
            this.tPageGCode.Controls.Add(this.rBoxGcode);
            this.tPageGCode.Controls.Add(this.lBoxGcodeName);
            resources.ApplyResources(this.tPageGCode, "tPageGCode");
            this.tPageGCode.Name = "tPageGCode";
            this.tPageGCode.UseVisualStyleBackColor = true;
            // 
            // rBoxGcode
            // 
            resources.ApplyResources(this.rBoxGcode, "rBoxGcode");
            this.rBoxGcode.Name = "rBoxGcode";
            this.rBoxGcode.ReadOnly = true;
            this.rBoxGcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rBoxGcode_KeyDown);
            // 
            // lBoxGcodeName
            // 
            resources.ApplyResources(this.lBoxGcodeName, "lBoxGcodeName");
            this.lBoxGcodeName.FormattingEnabled = true;
            this.lBoxGcodeName.Name = "lBoxGcodeName";
            this.TipGCode.SetToolTip(this.lBoxGcodeName, resources.GetString("lBoxGcodeName.ToolTip"));
            this.lBoxGcodeName.SelectedIndexChanged += new System.EventHandler(this.lBoxGcodeName_SelectedIndexChanged);
            this.lBoxGcodeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lBoxGcodeName_KeyDown);
            this.lBoxGcodeName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lBoxGcodeName_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvArray1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvArray1
            // 
            this.dgvArray1.AllowUserToAddRows = false;
            this.dgvArray1.AllowUserToDeleteRows = false;
            this.dgvArray1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArray1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArray1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column10,
            this.Column7,
            this.Column8,
            this.Column9});
            resources.ApplyResources(this.dgvArray1, "dgvArray1");
            this.dgvArray1.Name = "dgvArray1";
            this.dgvArray1.ReadOnly = true;
            this.dgvArray1.RowTemplate.Height = 27;
            this.dgvArray1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArray_CellContentClick);
            this.dgvArray1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ColumnHeaderMouseDoubleClick);
            this.dgvArray1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvArray_RowsAdded);
            this.dgvArray1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvArray_RowsRemoved);
            this.dgvArray1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvArray_KeyPress);
            // 
            // Column3
            // 
            this.Column3.FillWeight = 80F;
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
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
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            resources.ApplyResources(this.Column6, "Column6");
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            resources.ApplyResources(this.Column10, "Column10");
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            resources.ApplyResources(this.Column7, "Column7");
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Enter";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.Column8, "Column8");
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "In Place";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.Column9, "Column9");
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // tPageAlarm
            // 
            this.tPageAlarm.Controls.Add(this.lBoxAlarm);
            resources.ApplyResources(this.tPageAlarm, "tPageAlarm");
            this.tPageAlarm.Name = "tPageAlarm";
            this.tPageAlarm.UseVisualStyleBackColor = true;
            // 
            // lBoxAlarm
            // 
            resources.ApplyResources(this.lBoxAlarm, "lBoxAlarm");
            this.lBoxAlarm.FormattingEnabled = true;
            this.lBoxAlarm.Name = "lBoxAlarm";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GcodeView);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GcodeView
            // 
            this.GcodeView.AllowUserToAddRows = false;
            this.GcodeView.AllowUserToDeleteRows = false;
            this.GcodeView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GcodeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GcodeView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.参数,
            this.Column2});
            resources.ApplyResources(this.GcodeView, "GcodeView");
            this.GcodeView.Name = "GcodeView";
            this.GcodeView.ReadOnly = true;
            this.GcodeView.RowHeadersVisible = false;
            this.GcodeView.RowTemplate.Height = 27;
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 参数
            // 
            resources.ApplyResources(this.参数, "参数");
            this.参数.Name = "参数";
            this.参数.ReadOnly = true;
            this.参数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gBoxBasicOperation
            // 
            this.gBoxBasicOperation.Controls.Add(this.panelUserOperation);
            this.gBoxBasicOperation.Controls.Add(this.panel6);
            this.gBoxBasicOperation.Controls.Add(this.groupBox3);
            resources.ApplyResources(this.gBoxBasicOperation, "gBoxBasicOperation");
            this.gBoxBasicOperation.Name = "gBoxBasicOperation";
            this.gBoxBasicOperation.TabStop = false;
            // 
            // panelUserOperation
            // 
            resources.ApplyResources(this.panelUserOperation, "panelUserOperation");
            this.panelUserOperation.Name = "panelUserOperation";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnTeachingProgram);
            this.panel6.Controls.Add(this.panelSwith);
            this.panel6.Controls.Add(this.btnStrat);
            this.panel6.Controls.Add(this.panelAuto);
            this.panel6.Controls.Add(this.btnToZero);
            this.panel6.Controls.Add(this.btnToHome);
            this.panel6.Controls.Add(this.btnStop);
            this.panel6.Controls.Add(this.btnReset);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // btnTeachingProgram
            // 
            resources.ApplyResources(this.btnTeachingProgram, "btnTeachingProgram");
            this.btnTeachingProgram.Name = "btnTeachingProgram";
            this.btnTeachingProgram.TabStop = false;
            this.btnTeachingProgram.UseVisualStyleBackColor = true;
            this.btnTeachingProgram.Click += new System.EventHandler(this.btnTeachingProgram_Click);
            // 
            // panelSwith
            // 
            this.panelSwith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSwith.Controls.Add(this.radioNop);
            this.panelSwith.Controls.Add(this.radioWork);
            resources.ApplyResources(this.panelSwith, "panelSwith");
            this.panelSwith.Name = "panelSwith";
            // 
            // radioNop
            // 
            resources.ApplyResources(this.radioNop, "radioNop");
            this.radioNop.Checked = true;
            this.radioNop.Name = "radioNop";
            this.radioNop.TabStop = true;
            this.radioNop.UseVisualStyleBackColor = true;
            this.radioNop.CheckedChanged += new System.EventHandler(this.radioNop_CheckedChanged);
            // 
            // radioWork
            // 
            resources.ApplyResources(this.radioWork, "radioWork");
            this.radioWork.Name = "radioWork";
            this.radioWork.UseVisualStyleBackColor = true;
            this.radioWork.CheckedChanged += new System.EventHandler(this.radioWork_CheckedChanged);
            // 
            // btnStrat
            // 
            resources.ApplyResources(this.btnStrat, "btnStrat");
            this.btnStrat.Name = "btnStrat";
            this.btnStrat.TabStop = false;
            this.btnStrat.UseVisualStyleBackColor = true;
            this.btnStrat.Click += new System.EventHandler(this.btnStrat_Click);
            // 
            // panelAuto
            // 
            this.panelAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAuto.Controls.Add(this.radioManual);
            this.panelAuto.Controls.Add(this.radioAuto);
            resources.ApplyResources(this.panelAuto, "panelAuto");
            this.panelAuto.Name = "panelAuto";
            // 
            // radioManual
            // 
            resources.ApplyResources(this.radioManual, "radioManual");
            this.radioManual.Checked = true;
            this.radioManual.Name = "radioManual";
            this.radioManual.TabStop = true;
            this.radioManual.UseVisualStyleBackColor = true;
            this.radioManual.CheckedChanged += new System.EventHandler(this.radioManual_CheckedChanged);
            // 
            // radioAuto
            // 
            resources.ApplyResources(this.radioAuto, "radioAuto");
            this.radioAuto.Name = "radioAuto";
            this.radioAuto.UseVisualStyleBackColor = true;
            this.radioAuto.CheckedChanged += new System.EventHandler(this.radioAuto_CheckedChanged);
            // 
            // btnToZero
            // 
            this.btnToZero.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnToZero, "btnToZero");
            this.btnToZero.Name = "btnToZero";
            this.btnToZero.TabStop = false;
            this.btnToZero.UseVisualStyleBackColor = false;
            this.btnToZero.Click += new System.EventHandler(this.btnToZero_Click);
            // 
            // btnToHome
            // 
            this.btnToHome.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnToHome, "btnToHome");
            this.btnToHome.Name = "btnToHome";
            this.btnToHome.TabStop = false;
            this.btnToHome.UseVisualStyleBackColor = false;
            this.btnToHome.Click += new System.EventHandler(this.btnToHome_Click);
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.btnReset.TabStop = false;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rTBoxNowError);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // rTBoxNowError
            // 
            resources.ApplyResources(this.rTBoxNowError, "rTBoxNowError");
            this.rTBoxNowError.ForeColor = System.Drawing.Color.Red;
            this.rTBoxNowError.Name = "rTBoxNowError";
            this.rTBoxNowError.ReadOnly = true;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelRunStatus);
            this.panelRight.Controls.Add(this.gBoxAxisStatus);
            this.panelRight.Controls.Add(this.gBoxAxisControl);
            resources.ApplyResources(this.panelRight, "panelRight");
            this.panelRight.Name = "panelRight";
            // 
            // panelRunStatus
            // 
            resources.ApplyResources(this.panelRunStatus, "panelRunStatus");
            this.panelRunStatus.Controls.Add(this.panelUserStatus);
            this.panelRunStatus.Controls.Add(this.panel4);
            this.panelRunStatus.Controls.Add(this.groupBox1);
            this.panelRunStatus.Name = "panelRunStatus";
            // 
            // panelUserStatus
            // 
            resources.ApplyResources(this.panelUserStatus, "panelUserStatus");
            this.panelUserStatus.Name = "panelUserStatus";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label42);
            this.panel4.Controls.Add(this.ColorRun);
            this.panel4.Controls.Add(this.ColorStop);
            this.panel4.Controls.Add(this.label10);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // label42
            // 
            resources.ApplyResources(this.label42, "label42");
            this.label42.Name = "label42";
            // 
            // ColorRun
            // 
            this.ColorRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorRun, "ColorRun");
            this.ColorRun.Name = "ColorRun";
            // 
            // ColorStop
            // 
            this.ColorStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorStop, "ColorStop");
            this.ColorStop.Name = "ColorStop";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ColorHandwheelStop);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.ColorX100);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.ColorX10);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.ColorX1);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.ColorW);
            this.groupBox1.Controls.Add(this.labelW);
            this.groupBox1.Controls.Add(this.ColorZ);
            this.groupBox1.Controls.Add(this.labelZ);
            this.groupBox1.Controls.Add(this.ColorY);
            this.groupBox1.Controls.Add(this.labelY);
            this.groupBox1.Controls.Add(this.ColorX);
            this.groupBox1.Controls.Add(this.labelX);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // ColorHandwheelStop
            // 
            this.ColorHandwheelStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorHandwheelStop, "ColorHandwheelStop");
            this.ColorHandwheelStop.Name = "ColorHandwheelStop";
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // ColorX100
            // 
            this.ColorX100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorX100, "ColorX100");
            this.ColorX100.Name = "ColorX100";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // ColorX10
            // 
            this.ColorX10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorX10, "ColorX10");
            this.ColorX10.Name = "ColorX10";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // ColorX1
            // 
            this.ColorX1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorX1, "ColorX1");
            this.ColorX1.Name = "ColorX1";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // ColorW
            // 
            this.ColorW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorW, "ColorW");
            this.ColorW.Name = "ColorW";
            // 
            // labelW
            // 
            resources.ApplyResources(this.labelW, "labelW");
            this.labelW.Name = "labelW";
            // 
            // ColorZ
            // 
            this.ColorZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorZ, "ColorZ");
            this.ColorZ.Name = "ColorZ";
            // 
            // labelZ
            // 
            resources.ApplyResources(this.labelZ, "labelZ");
            this.labelZ.Name = "labelZ";
            // 
            // ColorY
            // 
            this.ColorY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorY, "ColorY");
            this.ColorY.Name = "ColorY";
            // 
            // labelY
            // 
            resources.ApplyResources(this.labelY, "labelY");
            this.labelY.Name = "labelY";
            // 
            // ColorX
            // 
            this.ColorX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorX, "ColorX");
            this.ColorX.Name = "ColorX";
            // 
            // labelX
            // 
            resources.ApplyResources(this.labelX, "labelX");
            this.labelX.Name = "labelX";
            // 
            // gBoxAxisStatus
            // 
            resources.ApplyResources(this.gBoxAxisStatus, "gBoxAxisStatus");
            this.gBoxAxisStatus.Controls.Add(this.panel3);
            this.gBoxAxisStatus.Name = "gBoxAxisStatus";
            this.gBoxAxisStatus.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // menuTool
            // 
            resources.ApplyResources(this.menuTool, "menuTool");
            this.menuTool.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuAuthority,
            this.MenuConfig,
            this.btnError,
            this.阵列ToolStripMenuItem,
            this.MenuOther,
            this.btnWarning,
            this.ToolBarCode,
            this.toolBoxBarCode});
            this.menuTool.Name = "menuTool";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenGcode,
            this.btnSaveGcode,
            this.btnSaveAs});
            this.MenuFile.Name = "MenuFile";
            resources.ApplyResources(this.MenuFile, "MenuFile");
            // 
            // btnOpenGcode
            // 
            this.btnOpenGcode.Name = "btnOpenGcode";
            resources.ApplyResources(this.btnOpenGcode, "btnOpenGcode");
            this.btnOpenGcode.Click += new System.EventHandler(this.btnOpenGcode_Click);
            // 
            // btnSaveGcode
            // 
            this.btnSaveGcode.Name = "btnSaveGcode";
            resources.ApplyResources(this.btnSaveGcode, "btnSaveGcode");
            this.btnSaveGcode.Click += new System.EventHandler(this.btnSaveGcode_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Name = "btnSaveAs";
            resources.ApplyResources(this.btnSaveAs, "btnSaveAs");
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // MenuAuthority
            // 
            this.MenuAuthority.Name = "MenuAuthority";
            resources.ApplyResources(this.MenuAuthority, "MenuAuthority");
            this.MenuAuthority.Click += new System.EventHandler(this.MenuAuthority_Click);
            // 
            // MenuConfig
            // 
            this.MenuConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolSysConfig,
            this.ToolInitConfig,
            this.ToolAxisConfig});
            this.MenuConfig.Name = "MenuConfig";
            resources.ApplyResources(this.MenuConfig, "MenuConfig");
            // 
            // ToolSysConfig
            // 
            this.ToolSysConfig.Name = "ToolSysConfig";
            resources.ApplyResources(this.ToolSysConfig, "ToolSysConfig");
            this.ToolSysConfig.Click += new System.EventHandler(this.ToolSysConfig_Click_1);
            // 
            // ToolInitConfig
            // 
            this.ToolInitConfig.Name = "ToolInitConfig";
            resources.ApplyResources(this.ToolInitConfig, "ToolInitConfig");
            this.ToolInitConfig.Click += new System.EventHandler(this.ToolInitConfig_Click);
            // 
            // ToolAxisConfig
            // 
            this.ToolAxisConfig.Name = "ToolAxisConfig";
            resources.ApplyResources(this.ToolAxisConfig, "ToolAxisConfig");
            this.ToolAxisConfig.Click += new System.EventHandler(this.ToolAxisConfig_Click);
            // 
            // btnError
            // 
            this.btnError.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnError.BackColor = System.Drawing.Color.Red;
            this.btnError.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnError.Name = "btnError";
            resources.ApplyResources(this.btnError, "btnError");
            this.btnError.Click += new System.EventHandler(this.BtnError_Click);
            // 
            // 阵列ToolStripMenuItem
            // 
            this.阵列ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolOpenModel,
            this.ToolSaveModel,
            this.ToolLock});
            this.阵列ToolStripMenuItem.Name = "阵列ToolStripMenuItem";
            resources.ApplyResources(this.阵列ToolStripMenuItem, "阵列ToolStripMenuItem");
            // 
            // ToolOpenModel
            // 
            this.ToolOpenModel.Name = "ToolOpenModel";
            resources.ApplyResources(this.ToolOpenModel, "ToolOpenModel");
            this.ToolOpenModel.Click += new System.EventHandler(this.ToolOpenModel_Click);
            // 
            // ToolSaveModel
            // 
            this.ToolSaveModel.Name = "ToolSaveModel";
            resources.ApplyResources(this.ToolSaveModel, "ToolSaveModel");
            this.ToolSaveModel.Click += new System.EventHandler(this.ToolSaveModel_Click);
            // 
            // ToolLock
            // 
            this.ToolLock.CheckOnClick = true;
            this.ToolLock.Name = "ToolLock";
            resources.ApplyResources(this.ToolLock, "ToolLock");
            this.ToolLock.Click += new System.EventHandler(this.ToolLock_Click);
            // 
            // MenuOther
            // 
            this.MenuOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolIOControl,
            this.导入DXFToolStripMenuItem});
            this.MenuOther.Name = "MenuOther";
            resources.ApplyResources(this.MenuOther, "MenuOther");
            // 
            // ToolIOControl
            // 
            this.ToolIOControl.Name = "ToolIOControl";
            resources.ApplyResources(this.ToolIOControl, "ToolIOControl");
            this.ToolIOControl.Click += new System.EventHandler(this.ToolIOControl_Click);
            // 
            // 导入DXFToolStripMenuItem
            // 
            this.导入DXFToolStripMenuItem.Name = "导入DXFToolStripMenuItem";
            resources.ApplyResources(this.导入DXFToolStripMenuItem, "导入DXFToolStripMenuItem");
            this.导入DXFToolStripMenuItem.Click += new System.EventHandler(this.导入DXFToolStripMenuItem_Click);
            // 
            // btnWarning
            // 
            this.btnWarning.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnWarning.BackColor = System.Drawing.Color.Yellow;
            this.btnWarning.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnWarning.Name = "btnWarning";
            resources.ApplyResources(this.btnWarning, "btnWarning");
            this.btnWarning.Click += new System.EventHandler(this.BtnError_Click);
            // 
            // ToolBarCode
            // 
            resources.ApplyResources(this.ToolBarCode, "ToolBarCode");
            this.ToolBarCode.Margin = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.ToolBarCode.Name = "ToolBarCode";
            // 
            // toolBoxBarCode
            // 
            this.toolBoxBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.toolBoxBarCode, "toolBoxBarCode");
            this.toolBoxBarCode.Name = "toolBoxBarCode";
            this.toolBoxBarCode.ReadOnly = true;
            // 
            // statusShowTool
            // 
            this.statusShowTool.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusShowTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorPLC,
            this.ColorCard,
            this.ColorMES,
            this.ColorGlue,
            this.LabelWorkTime,
            this.StatusLabelWorkTime,
            this.LabelWeldNum,
            this.StatusLabelWeldNum,
            this.LabelOneTime,
            this.StatusLabelOneTime,
            this.LabelVel,
            this.StatusLabelVel,
            this.toolStripStatusLabel2,
            this.txtModeFileName});
            resources.ApplyResources(this.statusShowTool, "statusShowTool");
            this.statusShowTool.Name = "statusShowTool";
            // 
            // ColorPLC
            // 
            this.ColorPLC.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ColorPLC.Name = "ColorPLC";
            resources.ApplyResources(this.ColorPLC, "ColorPLC");
            // 
            // ColorCard
            // 
            this.ColorCard.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ColorCard.Name = "ColorCard";
            resources.ApplyResources(this.ColorCard, "ColorCard");
            // 
            // ColorMES
            // 
            this.ColorMES.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ColorMES.Name = "ColorMES";
            resources.ApplyResources(this.ColorMES, "ColorMES");
            // 
            // ColorGlue
            // 
            this.ColorGlue.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ColorGlue.Name = "ColorGlue";
            resources.ApplyResources(this.ColorGlue, "ColorGlue");
            // 
            // LabelWorkTime
            // 
            this.LabelWorkTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LabelWorkTime.Name = "LabelWorkTime";
            resources.ApplyResources(this.LabelWorkTime, "LabelWorkTime");
            // 
            // StatusLabelWorkTime
            // 
            this.StatusLabelWorkTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabelWorkTime.Name = "StatusLabelWorkTime";
            resources.ApplyResources(this.StatusLabelWorkTime, "StatusLabelWorkTime");
            // 
            // LabelWeldNum
            // 
            this.LabelWeldNum.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LabelWeldNum.Name = "LabelWeldNum";
            resources.ApplyResources(this.LabelWeldNum, "LabelWeldNum");
            // 
            // StatusLabelWeldNum
            // 
            this.StatusLabelWeldNum.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabelWeldNum.Name = "StatusLabelWeldNum";
            resources.ApplyResources(this.StatusLabelWeldNum, "StatusLabelWeldNum");
            // 
            // LabelOneTime
            // 
            this.LabelOneTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LabelOneTime.Name = "LabelOneTime";
            resources.ApplyResources(this.LabelOneTime, "LabelOneTime");
            // 
            // StatusLabelOneTime
            // 
            this.StatusLabelOneTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabelOneTime.Name = "StatusLabelOneTime";
            resources.ApplyResources(this.StatusLabelOneTime, "StatusLabelOneTime");
            // 
            // LabelVel
            // 
            this.LabelVel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LabelVel.Name = "LabelVel";
            resources.ApplyResources(this.LabelVel, "LabelVel");
            // 
            // StatusLabelVel
            // 
            this.StatusLabelVel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabelVel.Name = "StatusLabelVel";
            resources.ApplyResources(this.StatusLabelVel, "StatusLabelVel");
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // txtModeFileName
            // 
            this.txtModeFileName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.txtModeFileName.Name = "txtModeFileName";
            resources.ApplyResources(this.txtModeFileName, "txtModeFileName");
            // 
            // UITimer
            // 
            this.UITimer.Interval = 30;
            this.UITimer.Tick += new System.EventHandler(this.UITimer_Tick);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.gBoxBasicOperation);
            this.Controls.Add(this.menuTool);
            this.Controls.Add(this.statusShowTool);
            this.MainMenuStrip = this.menuTool;
            this.Name = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gBoxAxisControl.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tPagelog.ResumeLayout(false);
            this.tPageAxisXY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartXY)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tPageGCode.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArray1)).EndInit();
            this.tPageAlarm.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GcodeView)).EndInit();
            this.gBoxBasicOperation.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panelSwith.ResumeLayout(false);
            this.panelSwith.PerformLayout();
            this.panelAuto.ResumeLayout(false);
            this.panelAuto.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelRunStatus.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBoxAxisStatus.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuTool.ResumeLayout(false);
            this.menuTool.PerformLayout();
            this.statusShowTool.ResumeLayout(false);
            this.statusShowTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxAxisControl;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tPageAxisXY;
        private System.Windows.Forms.GroupBox gBoxBasicOperation;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox gBoxAxisStatus;
        private System.Windows.Forms.TabPage tPagelog;
        private System.Windows.Forms.MenuStrip menuTool;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuAuthority;
        private System.Windows.Forms.ToolStripMenuItem MenuConfig;
        private System.Windows.Forms.ToolStripMenuItem btnError;
        private System.Windows.Forms.StatusStrip statusShowTool;
        private System.Windows.Forms.ToolStripStatusLabel LabelWorkTime;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelWorkTime;
        private System.Windows.Forms.ToolStripStatusLabel LabelWeldNum;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelWeldNum;
        private System.Windows.Forms.ToolStripStatusLabel LabelOneTime;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelOneTime;
        private System.Windows.Forms.RadioButton radioAbsolutely;
        private System.Windows.Forms.RadioButton radioRelative;
        private System.Windows.Forms.RadioButton radioContinue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStrat;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolStripMenuItem MenuOther;
        private System.Windows.Forms.ToolStripMenuItem btnOpenGcode;
        private System.Windows.Forms.ToolStripMenuItem btnSaveGcode;
        private System.Windows.Forms.Timer UITimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartXY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSetXY;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tBoxYmax;
        private System.Windows.Forms.TextBox tBoxXmax;
        private System.Windows.Forms.TextBox tBoxYmin;
        private System.Windows.Forms.TextBox tBoxXmin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox lBoxLog;
        private System.Windows.Forms.ToolStripMenuItem ToolIOControl;
        private System.Windows.Forms.ToolStripStatusLabel LabelVel;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelVel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rTBoxNowError;
        private System.Windows.Forms.TabPage tPageManualControl;
        private System.Windows.Forms.Panel panelRunStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ColorHandwheelStop;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label ColorX100;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label ColorX10;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label ColorX1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label ColorW;
        private System.Windows.Forms.Label ColorZ;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label ColorY;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label ColorX;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.ToolStripMenuItem btnWarning;
        private System.Windows.Forms.ToolStripMenuItem ToolBarCode;
        private System.Windows.Forms.ToolStripTextBox toolBoxBarCode;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.Label ColorStop;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label ColorRun;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripStatusLabel ColorPLC;
        private System.Windows.Forms.ToolStripStatusLabel ColorCard;
        private System.Windows.Forms.ToolStripStatusLabel ColorMES;
        private System.Windows.Forms.ToolStripMenuItem ToolSysConfig;
        private System.Windows.Forms.ToolStripMenuItem ToolInitConfig;
        private System.Windows.Forms.ToolStripMenuItem ToolAxisConfig;
        private System.Windows.Forms.Button btnToZero;
        private System.Windows.Forms.Button btnToHome;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelUserStatus;
        private System.Windows.Forms.Panel panelUserOperation;
        private System.Windows.Forms.RadioButton radioManual;
        private System.Windows.Forms.RadioButton radioAuto;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panelSwith;
        private System.Windows.Forms.Panel panelAuto;
        private System.Windows.Forms.RadioButton radioNop;
        private System.Windows.Forms.RadioButton radioWork;
        private System.Windows.Forms.TabPage tPageGCode;
        private System.Windows.Forms.RichTextBox rBoxGcode;
        private System.Windows.Forms.ListBox lBoxGcodeName;
        private System.Windows.Forms.ToolStripMenuItem btnSaveAs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView GcodeView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参数;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripStatusLabel ColorGlue;
        private System.Windows.Forms.Button btnTeachingProgram;
        private System.Windows.Forms.TabPage tPageAlarm;
        private System.Windows.Forms.ListBox lBoxAlarm;
        private System.Windows.Forms.ToolTip TipGCode;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvArray1;
        private System.Windows.Forms.ToolStripMenuItem 阵列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolOpenModel;
        private System.Windows.Forms.ToolStripMenuItem ToolSaveModel;
        private System.Windows.Forms.ToolStripMenuItem ToolLock;
        private System.Windows.Forms.ToolStripMenuItem 导入DXFToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel txtModeFileName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
        private System.Windows.Forms.DataGridViewButtonColumn Column9;
    }
}

