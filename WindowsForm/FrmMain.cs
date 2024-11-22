using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserCustomLibrary.Common;
using BaseLibrary.Common;
using BaseLibrary.Function;
using UserCustomLibrary.Function;
using BaseLibrary.SupportHelp;
using UWPCLaserMotion.WindowsForm;
using UserCustomLibrary.WindowsForm;
using System.IO;
using System.Reflection;
using DXFLibrary.WinFrm;

namespace UWPCLaserMotion.WindowsForm
{

    public partial class FrmMain : Form
    {
        #region 变量
        /// <summary>
        ///手动移动类型
        /// </summary>
        private event MoveType moveType;
        private bool lockDraw = false;
        #endregion

        #region 窗体加载关闭
        public FrmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LogHelper.logEvent += UpdateLog;
            LogHelper.ErrorEvent += UpdateError;
            LogHelper.WarnEvent += UpdateWarn;
            LogHelper.AlarmEvent += UpdateAlarm;
            ThreadFunction.AlamLog += UpdateAlarm;
            LogHelper.WriteLog("主窗口加载", LogType.Event);
            
            InitFrm();

            ZmcauxFunction.Instant.Stop += StopAxis;
            UITimer.Enabled = true;
            UIModel.UI.UserAuthority = Authority.操作员;
            ////手脉
            Task.Factory.StartNew(ThreadFunction.HandWheelCheck, TaskCreationOptions.LongRunning);
            //三色灯
            Task.Factory.StartNew(ThreadFunction.ControlWarningLight, TaskCreationOptions.LongRunning);
            //安全系统检测
            Task.Factory.StartNew(ThreadFunction.CheckSafetySystem, TaskCreationOptions.LongRunning);
            //外部启用
            Task.Factory.StartNew(ThreadFunction.ExternalStart, TaskCreationOptions.LongRunning);
            //运行状态
            Task.Factory.StartNew(ThreadFunction.RunState, TaskCreationOptions.LongRunning);

        }

        private void StopAxis(string msg)
        {
            LogHelper.WriteLog(msg, LogType.Error);
            EventFunction.Stop(3);
        }

        private void InitFrm()
        {
            try
            {
                SingleFrmFunction<FrmManualControl>.Close();//手动控制
               

                chartXY.Series[0].Points.AddXY(UIModel.UI.AxisPos[0], UIModel.UI.AxisPos[1]);
                chartXY.Series[1].Points.AddXY(UIModel.UI.AxisPos[3], UIModel.UI.AxisPos[4]);

                #region 手动控制
                //手动控制
                {
                    FrmManualControl frm = SingleFrmFunction<FrmManualControl>.CreateInstrance();
                    frm.TopLevel = false;
                    frm.Parent = tPageManualControl;
                    frm.ControlBox = false;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                } 
                #endregion
                #region 坐标
                for (int i = AxisConfig.Instance.axisCount - 1; i >= 0; i--)//坐标
                {
                    FrmAxisPosControl frm = new FrmAxisPosControl(i);
                    frm.Parent = gBoxAxisControl;
                    frm.Dock = DockStyle.Top;
                    frm.Show();
                    this.moveType += frm.MoveType;
                } 
                #endregion
                #region 状态
                for (int i = 0; i < AxisConfig.Instance.axisCount; i++)//状态
                {
                    FrmAxisStatusControl frm = new FrmAxisStatusControl(i);
                    frm.Parent = gBoxAxisStatus;
                    frm.Dock = DockStyle.Bottom;
                    frm.Show();
                } 
                #endregion

                #region 主界面自定义状态
                {//主界面自定义状态
                    UserShowControl frm = new UserShowControl();
                    frm.Parent = panelUserStatus;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                } 
                #endregion
                

                #region G代码对照表
                {
                    GcodeView.Rows.Clear();
                    GcodeView.Rows.Add("G90", "", LanguageFunction.Transfer("绝对坐标系"));
                    GcodeView.Rows.Add("G91", "", LanguageFunction.Transfer("相对坐标系"));
                    GcodeView.Rows.Add("G00", "X/Y/F", LanguageFunction.Transfer("无缓冲直线"));
                    GcodeView.Rows.Add("G01", "X/Y/F", LanguageFunction.Transfer("缓冲直线"));
                    GcodeView.Rows.Add("G02", "X/Y/I/J/D/F", LanguageFunction.Transfer("缓冲圆"));
                    GcodeView.Rows.Add("G03", "X/Y/I/J/D/F", LanguageFunction.Transfer("缓冲圆弧"));
                    GcodeView.Rows.Add("G04", "T", LanguageFunction.Transfer("延时"));
                    GcodeView.Rows.Add("G05", "T", LanguageFunction.Transfer("缓冲区延时"));
                    GcodeView.Rows.Add("M62", "AXIS/END", LanguageFunction.Transfer("提前出胶"));
                    GcodeView.Rows.Add("M63", "AXIS/END", LanguageFunction.Transfer("提前关胶"));
                    GcodeView.Rows.Add("M66", "", LanguageFunction.Transfer("暂停"));
                    GcodeView.Rows.Add("M67", "", LanguageFunction.Transfer("继续"));
                    GcodeView.Rows.Add("M64", "", LanguageFunction.Transfer("缓冲结束"));
                    GcodeView.Rows.Add("P07", "", LanguageFunction.Transfer("出胶"));
                    GcodeView.Rows.Add("P08", "", LanguageFunction.Transfer("关胶"));
                    GcodeView.Rows.Add("P17", "", LanguageFunction.Transfer("缓冲区出胶"));
                    GcodeView.Rows.Add("P18", "", LanguageFunction.Transfer("缓冲区关胶"));
                    //GcodeView.Rows.Add("P01", "L", "打胶配方号");
                    //GcodeView.Rows.Add("P02", "L", "打胶模式");
                    //GcodeView.Rows.Add("P03", "", "请求回填");
                    //GcodeView.Rows.Add("Q00", "", "气缸开");
                    //GcodeView.Rows.Add("Q01", "", "气缸关");
                    GcodeView.Rows.Add("M02", "", LanguageFunction.Transfer("结束"));
                    //GcodeView.Rows.Add("M70", "", "本地保存");
                    //GcodeView.Rows.Add("M40", "", "扫码");
                    //GcodeView.Rows.Add("M10", "N", "拍照请求");
                    //GcodeView.Rows.Add("M11", "", "拍照获取");
                    //GcodeView.Rows.Add("M12", "", "视觉相对开始");
                    //GcodeView.Rows.Add("M13", "", "视觉相对结束");
                    //GcodeView.Rows.Add("M15", "", "测距");
                    //GcodeView.Rows.Add("G15", "", "测距补偿");
                    //GcodeView.Rows.Add("M14", "RB/RL", "测距基准设置");
                }
                #endregion

                #region G代码
                {
                    foreach (var item in UIModel.UI.GCodeList)
                    {
                        lBoxGcodeName.Items.Add(item.Name);
                    }
                }//G代码 
                #endregion

                #region 坐标系
                IniHelper ini = new IniHelper(Application.StartupPath + @"\System.ini");
                tBoxXmin.Text = ini.IniReadValue("FrmMain", "tBoxXmin");
                tBoxXmax.Text = ini.IniReadValue("FrmMain", "tBoxXmax");
                tBoxYmin.Text = ini.IniReadValue("FrmMain", "tBoxYmin");
                tBoxYmax.Text = ini.IniReadValue("FrmMain", "tBoxYmax");
                btnSetXY_Click(null, null);
                #endregion

                UIModel.UI.GlueCount = Convert.ToInt32(ini.IniReadValue("UIModel", "WeldCount"));

                this.Text = LanguageFunction.Transfer("联赢激光：") + Application.ProductName + Application.ProductVersion;


                dgvArray1.RowCount = SysConfig.Instance.MaxModeArray;

                ToolLock.Checked = true;
                ToolLock_Click(null,null);

                BaseLibrary.Function.InitFunction.SelectLanguage();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            
        }

        private async void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogHelper.WriteLog("主窗口关闭", LogType.Event);
            try
            {
                IniHelper ini = new IniHelper(Application.StartupPath + @"\System.ini");
                ini.IniWriteValue("UIModel", "WeldCount", UIModel.UI.GlueCount.ToString());
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            if (e.CloseReason==CloseReason.UserClosing)
            {
                if (UIModel.UI.AutoRun)
                {
                    e.Cancel = true;
                    LogHelper.WriteLog("运行中禁止关闭程序", LogType.Warning);
                    return;
                }
                if (UIModel.UI.ResetFlag)
                {
                    DialogResult result = MessageBox.Show(LanguageFunction.Transfer("是否关闭程序时回排胶位\n\n是：关闭程序且回排胶位\n否：关闭不回排胶位\n取消：不关闭程序"), LanguageFunction.Transfer("提示关闭程序"), MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        UIModel.UI.StopFlag = false;
                        await Task.Factory.StartNew(EventFunction.GoDischargePos1);
                        if (UIModel.UI.StopFlag)
                        {
                            e.Cancel = true;
                            LogHelper.WriteLog("运行停止关闭错误", LogType.Error);
                            return;
                        }
                        UIModel.UI.IsClose = true;
                        LogHelper.WriteLog("正常关闭程序", LogType.Info);
                        EventFunction.Close(true);
                    }
                    else if (result == DialogResult.No)
                    {
                        UIModel.UI.IsClose = true;
                        LogHelper.WriteLog("正常关闭程序", LogType.Info);
                        EventFunction.Close(true);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show(LanguageFunction.Transfer("是否关闭程序"), LanguageFunction.Transfer("提示关闭程序"), MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        UIModel.UI.IsClose = true;
                        LogHelper.WriteLog("正常关闭程序", LogType.Info);
                        EventFunction.Close(true);
                    }
                    else
                    {
                        
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                UIModel.UI.IsClose = true;
                LogHelper.WriteLog(LanguageFunction.Transfer("强制关闭程序") + e.CloseReason, LogType.Info,1);
                EventFunction.Close(false);
            }
            
        }
        #endregion

        #region 刷新
        private void UITimer_Tick(object sender, EventArgs e)
        {
            try
            {
                

                if (!lockDraw&& UIModel.UI.AutoRun)
                {
                    lockDraw = true;
                    chartXY.Series[0].Points.Clear();
                    chartXY.Series[0].Points.AddXY(UIModel.UI.AxisPos[0], UIModel.UI.AxisPos[1]);
                }
                if (!UIModel.UI.AutoRun)
                {
                    lockDraw = false;
                }
                //平面图
                if (UIModel.UI.TBoxPPos[0] != UIModel.UI.AxisPos[0] || UIModel.UI.TBoxPPos[1] != UIModel.UI.AxisPos[1])
                {
                    UIModel.UI.TBoxPPos[0] = UIModel.UI.AxisPos[0];
                    UIModel.UI.TBoxPPos[1] = UIModel.UI.AxisPos[1];
                    int index = chartXY.Series[0].Points.AddXY(UIModel.UI.AxisPos[0], UIModel.UI.AxisPos[1]);
                    if (UIModel.UI.Gumming)
                    {
                        chartXY.Series[0].Points[index].Color = Color.Red;
                    }
                    else
                    {
                        chartXY.Series[0].Points[index].Color = Color.DarkOliveGreen;
                    }
                }
               
                toolBoxBarCode.Text = UIModel.UI.BarCode;

                
                rTBoxNowError.Text = UIModel.UI.NowAlarm;
                StatusLabelWeldNum.Text =UIModel.UI.GlueCount.ToString();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < AxisConfig.Instance.axisCount; i++)
                {
                    sb.Append($"{AxisConfig.Instance[i].Name}:{UIModel.UI.NowVel[i]},");
                }
                StatusLabelVel.Text = sb.ToString();

                if (UIModel.UI.AutoRun)
                {
                    StatusLabelOneTime.Text = (DateTime.Now - UIModel.UI.StratTime).ToString();
                    StatusLabelWorkTime.Text = (DateTime.Now - UIModel.UI.StratTime+ UIModel.UI.WorkTime).ToString();
                }
                else
                {
                    StatusLabelWorkTime.Text = UIModel.UI.WorkTime.ToString();
                    StatusLabelOneTime.Text = (UIModel.UI.EndTime - UIModel.UI.StratTime).ToString();
                }

                
                ColorHandwheelStop.BackColor = !UIModel.UI.HandWheelFlag ? Color.Green : Color.White;
                ColorX1.BackColor = UIModel.UI.HandWheelRate == SysConfig.Instance._HandWheelRate1 ?Color.Green :Color.White;
                ColorX10.BackColor = UIModel.UI.HandWheelRate == SysConfig.Instance._HandWheelRate2 ?Color.Green :Color.White;
                ColorX100.BackColor = UIModel.UI.HandWheelRate == SysConfig.Instance._HandWheelRate3 ?Color.Green :Color.White;

                ColorX.BackColor = UIModel.UI.HandWheelAxis == 0 ? Color.Green : Color.White;
                ColorY.BackColor = UIModel.UI.HandWheelAxis == 1 ? Color.Green : Color.White;
                ColorZ.BackColor = UIModel.UI.HandWheelAxis == 2 ? Color.Green : Color.White;
                ColorW.BackColor = UIModel.UI.HandWheelAxis == 3 ? Color.Green : Color.White;

                ColorRun.BackColor = UIModel.UI.AutoRun ? Color.Green :Color.White;
                ColorStop.BackColor = UIModel.UI.StopFlag ? Color.Green :Color.White;
               

                ColorPLC.BackColor = PLCFunction.PLC.IsOpen ? Color.Green : Color.Red;
                ColorCard.BackColor = ZmcauxFunction.Instant.IsOpen ? Color.Green : Color.Red;
                ColorMES.BackColor = MESFunction.Instance.IsConn ? Color.Green : Color.Red;
                

                #region 启动时不能操作的功能
                if (UIModel.UI.AutoRun || UIModel.UI.Runing)
                {
                    menuTool.Enabled = false;//菜单栏
                    gBoxAxisControl.Enabled = false;//轴单步
                    btnStrat.Enabled = false;//启动
                    btnToHome.Enabled = false;//回原
                    btnToZero.Enabled = false;//回零
                    btnReset.Enabled = false;//复位
                    btnTeachingProgram.Enabled = false;
                    panelUserOperation.Enabled = false;
                    panelSwith.Enabled = false;
                    panelAuto.Enabled = false;
                }
                else if (UIModel.UI.Auto)
                {
                    menuTool.Enabled = false;//菜单栏
                    gBoxAxisControl.Enabled = false;//轴单步
                    btnStrat.Enabled = false;//启动
                    btnToHome.Enabled = false;//回原
                    btnToZero.Enabled = false;//回零
                    btnReset.Enabled = false;//复位
                    btnTeachingProgram.Enabled = false;
                    panelUserOperation.Enabled = false;
                    panelSwith.Enabled = false;
                    panelAuto.Enabled = true;
                }
                else
                {
                    menuTool.Enabled = true;//菜单栏
                    gBoxAxisControl.Enabled = true;//轴单步
                    panelUserOperation.Enabled = true;
                    btnStrat.Enabled = true;//启动
                    btnToHome.Enabled = true;//回原
                    btnToZero.Enabled = true;//回零
                    btnReset.Enabled = true;//复位
                    panelSwith.Enabled = true;//复位
                    panelAuto.Enabled = true;//复位
                    UserEnable();
                }


                #endregion

               
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void UserEnable()
        {
            switch (UIModel.UI.UserAuthority)
            {
                case Authority.工程师:
                    MenuConfig.Enabled = true;//参数设置
                    MenuOther.Enabled = true;//其他功能
                    btnTeachingProgram.Enabled = true;//其他功能
                    break;
                case Authority.用户管理:
                    MenuConfig.Enabled = true;//参数设置
                    MenuOther.Enabled = true;//其他功能
                    btnTeachingProgram.Enabled = true;//其他功能
                    break;
                case Authority.操作员:
                    MenuConfig.Enabled = false;//参数设置
                    MenuOther.Enabled = false;//其他功能
                    btnTeachingProgram.Enabled = false;//其他功能
                    break;
            }
        }
        #endregion

        #region 运控基本操作
        #region 启动
        private async void btnStrat_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：启动按下", LogType.Event);
            
            if (!UIModel.UI.AutoRun)
            {
                if (UIModel.UI.Runing)
                {
                    LogHelper.WriteLog("自动运行下禁止启动", LogType.Warning);
                    return;
                }
                if (!UIModel.UI.ResetFlag)
                {
                    LogHelper.WriteLog("未复位，禁止启动->", LogType.Warning);
                    MessageBox.Show(LanguageFunction.Transfer("未复位，禁止启动"));
                    return;
                }
                if (UIModel.UI.HandWheelFlag)
                {
                    LogHelper.WriteLog("请将手脉置于OFF档", LogType.Warning);
                    MessageBox.Show(LanguageFunction.Transfer("请将手脉置于OFF档"));
                    return;
                }
                btnStrat.Enabled = false;
                UIModel.UI.Runing = true;
                if (SysConfig.Instance.IsArrayGcode)
                {
                    await Task.Factory.StartNew(EventFunction.Strat_Array);
                }
                else
                {
                    if (lBoxGcodeName.SelectedIndex!=-1)
                    {
                        int index = lBoxGcodeName.SelectedIndex;
                        await Task.Factory.StartNew(()=> { EventFunction.Strat(index); });
                    }
                    else
                    {
                        LogHelper.WriteLog("未选择运行G代码", LogType.Error);
                    }
                }
               
                UIModel.UI.Runing = false;
                btnStrat.Enabled = true;
            }
            else
            {
                LogHelper.WriteLog("自动运行中，启动无效", LogType.Warning);
            }
        }


        #endregion

        #region 停止
        private void btnStop_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：停止按下", LogType.Event);
            EventFunction.Stop(3);
        }


        #endregion

        #region 回原点
        private async void btnToHome_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：回原点按下", LogType.Event);
            if (!UIModel.UI.AutoRun)
            {
                if (UIModel.UI.Runing)
                {
                    LogHelper.WriteLog("自动运行下禁止回原", LogType.Warning);
                    return;
                }
                if (UIModel.UI.HandWheelFlag)
                {
                    LogHelper.WriteLog("请将手脉置于OFF档", LogType.Warning);
                    MessageBox.Show(LanguageFunction.Transfer("请将手脉置于OFF档"));
                    return;
                }
                btnToHome.Enabled = false;
                UIModel.UI.Runing = true;
                await Task.Factory.StartNew(EventFunction.ToHome);
                UIModel.UI.Runing = false;
                btnToHome.Enabled = true;
            }
            else
            {
                LogHelper.WriteLog("自动运行中，回原无效", LogType.Warning);
            }
        }
        #endregion

        #region 回零点
        private async void btnToZero_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：回零点按下", LogType.Event);
            if (!UIModel.UI.AutoRun)
            {
                if (UIModel.UI.Runing)
                {
                    LogHelper.WriteLog("自动运行下禁止回零", LogType.Warning);
                    return;
                }
                if (UIModel.UI.HandWheelFlag)
                {
                    LogHelper.WriteLog("请将手脉置于OFF档", LogType.Warning);
                    MessageBox.Show(LanguageFunction.Transfer("请将手脉置于OFF档"));
                    return;
                }
                btnToZero.Enabled = false;
                UIModel.UI.Runing = true;
                await Task.Factory.StartNew(EventFunction.ToZero);
                UIModel.UI.Runing = false;
                btnToZero.Enabled = true;
            }
            else
            {
                LogHelper.WriteLog("自动运行中，回零无效", LogType.Warning);
            }
        }
        #endregion

        #region 快速复位
        private async void btnReset_Click(object sender, EventArgs e)
        {

            LogHelper.WriteLog("主界面：快速复位按下", LogType.Event);
            if (!UIModel.UI.AutoRun)
            {
                if (UIModel.UI.Runing)
                {
                    LogHelper.WriteLog("自动运行下禁止复位", LogType.Warning);
                    return;
                }
                if (UIModel.UI.HandWheelFlag)
                {
                    LogHelper.WriteLog("请将手脉置于OFF档", LogType.Warning);
                    MessageBox.Show(LanguageFunction.Transfer("请将手脉置于OFF档"));
                    return;
                }
                btnReset.Enabled = false;
                UIModel.UI.Runing = true;
                await Task.Factory.StartNew(EventFunction.Reset);
                UIModel.UI.Runing = false;
                btnReset.Enabled = true;
            }
            else
            {
                LogHelper.WriteLog("自动运行中，复位无效", LogType.Warning);
            }
        }
        #endregion

       

        #region 示教编程
        private void btnTeachingProgram_Click(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteLog("主界面：示教编程按下", LogType.Event);
                panel6.Visible = false;
                panelUserOperation.Visible = false;
                {
                    FrmTeachingProgram frm = new FrmTeachingProgram(rBoxGcode);
                    frm.TopLevel = false;
                    frm.Parent = gBoxBasicOperation;
                    //frm.ControlBox = false;
                    //frm.Dock = DockStyle.Fill;
                    gBoxBasicOperation.Controls.SetChildIndex(frm, 0);
                    frm.Show();
                    frm.FormClosing += FrmTeachingProgram_FormClosing;
                    gBoxBasicOperation.AutoSize = true;

                }//示教编程
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void FrmTeachingProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            panelUserOperation.Visible = true;
            panel6.Visible = true;
            gBoxBasicOperation.AutoSize = false;
        }
        #endregion

        #endregion

        #region 菜单栏
        #region 文件操作
        #region 打开G代码
        private void btnOpenGcode_Click(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteLog("主界面：执行打开G代码文件", LogType.Event);
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = LanguageFunction.Transfer("请选择要打开的G代码文件!");
                dialog.Filter = LanguageFunction.Transfer("G代码文件|*.txt");
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    string gcode = File.ReadAllText(dialog.FileName, Encoding.UTF8);
                    string filename = Path.GetFileNameWithoutExtension(dialog.FileName);
                    lBoxGcodeName.Items.Add(filename);
                    UIModel.UI.GCodeList.Add(new UIModel.Code(filename, gcode));
                    LogHelper.WriteLog("导入G代码完成", LogType.Info);
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        #endregion

        #region 保存G代码
        private void btnSaveGcode_Click(object sender, EventArgs e)
        {
            try
            {
                rBoxGcode_KeyDown(sender, new KeyEventArgs(Keys.Control | Keys.S));
                LogHelper.WriteLog("主界面：执行保存G代码文件", LogType.Event);

                StringBuilder sb = new StringBuilder();
                if (!Directory.Exists("GCode"))
                {
                    Directory.CreateDirectory("GCode");
                }
                foreach (var GCode in UIModel.UI.GCodeList)
                {
                    sb.AppendLine(GCode.Name);
                    File.WriteAllText("GCode/" + GCode.Name + ".txt", GCode.Txt, Encoding.UTF8);
                    LogHelper.WriteLog(LanguageFunction.Transfer("执行保存G代码【") + GCode.Name + LanguageFunction.Transfer("】操作成功"), LogType.Info,1);
                    MessageBox.Show(LanguageFunction.Transfer("执行保存G代码【") + GCode.Name + LanguageFunction.Transfer("】操作成功"));

                }
                File.WriteAllText("Config/GCode.txt", sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        #endregion

        #region 另存G代码
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                rBoxGcode_KeyDown(sender, new KeyEventArgs(Keys.Control | Keys.S));
                LogHelper.WriteLog("主界面：执行另存G代码文件", LogType.Event);
                string Gcode = rBoxGcode.Text;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = LanguageFunction.Transfer("G代码文件|*.txt");
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Title = LanguageFunction.Transfer("请选择或新建一个文件");
                if (DialogResult.OK == saveFileDialog.ShowDialog())
                {
                    File.WriteAllText(saveFileDialog.FileName, Gcode, Encoding.UTF8);
                    LogHelper.WriteLog("执行保存G代码操作成功", LogType.Info);
                    MessageBox.Show(LanguageFunction.Transfer("执行保存G代码操作成功"));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        #endregion
        #endregion

        #region 权限
        private void MenuAuthority_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：点击权限", LogType.Event);
            try
            {
                BaseLibrary.Function.InitFunction.SelectLanguage();
                FrmAuthority frm = new FrmAuthority();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        #endregion

        #region 参数设置
        private void ToolSysConfig_Click_1(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：点击系统设置", LogType.Event);
            try
            {
                BaseLibrary.Function.InitFunction.SelectLanguage();
                UserCustomLibrary.WindowsForm.FrmSysConfig frm = new UserCustomLibrary.WindowsForm.FrmSysConfig();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void ToolInitConfig_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：点击软件配置", LogType.Event);
            try
            {
                BaseLibrary.Function.InitFunction.SelectLanguage();
                FrmSysConfig frm = new FrmSysConfig();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void ToolAxisConfig_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：点击轴配置", LogType.Event);
            try
            {
                BaseLibrary.Function.InitFunction.SelectLanguage();
                FrmAxis frm = new FrmAxis();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        #endregion



        #region IO控制
        private void ToolIOControl_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：进入IO控制界面", LogType.Event);
            FrmIOControl frm = SingleFrmFunction<FrmIOControl>.CreateInstrance();
            frm.Show();
        }





        #endregion

       

        #endregion

        #region XY视图
        private void btnSetXY_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：执行设置XY视图操作", LogType.Event);
            try
            {
                int xmin = Convert.ToInt32(tBoxXmin.Text);
                int xmax = Convert.ToInt32(tBoxXmax.Text);
                int ymin = Convert.ToInt32(tBoxYmin.Text);
                int ymax = Convert.ToInt32(tBoxYmax.Text);
                if (xmax < xmin || ymax < ymin)
                {
                    LogHelper.WriteLog("设置失败", LogType.Warning);
                    return;
                }
                int xInetrval = 0;
                int yInetrval = 0;
                if (xmax - xmin > 600)
                {
                    xInetrval = 100;
                }
                else if (xmax - xmin > 200)
                {
                    xInetrval = 50;
                }
                else if (xmax - xmin > 80)
                {
                    xInetrval = 20;
                }
                else
                {
                    xInetrval = 10;
                }
                if (ymax - ymin > 600)
                {
                    yInetrval = 100;
                }
                else if (ymax - ymin > 200)
                {
                    yInetrval = 50;
                }
                else if (ymax - ymin > 80)
                {
                    yInetrval = 20;
                }
                else
                {
                    yInetrval = 10;
                }
                chartXY.ChartAreas[0].AxisX.Maximum = xmax;
                chartXY.ChartAreas[0].AxisX.Minimum = xmin;
                chartXY.ChartAreas[0].AxisX.Interval = xInetrval;
                chartXY.ChartAreas[0].AxisY.Maximum = ymax;
                chartXY.ChartAreas[0].AxisY.Minimum = ymin;
                chartXY.ChartAreas[0].AxisY.Interval = yInetrval;

                IniHelper ini = new IniHelper(Application.StartupPath + @"\System.ini");
                ini.IniWriteValue("FrmMain", "tBoxXmin", tBoxXmin.Text);
                ini.IniWriteValue("FrmMain", "tBoxXmax", tBoxXmax.Text);
                ini.IniWriteValue("FrmMain", "tBoxYmin", tBoxYmin.Text);
                ini.IniWriteValue("FrmMain", "tBoxYmax", tBoxYmax.Text);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        private void btnSetXY2_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("主界面：执行设置XY2视图操作", LogType.Event);
            try
            {
                int xmin = Convert.ToInt32(tBoxXmin.Text);
                int xmax = Convert.ToInt32(tBoxXmax.Text);
                int ymin = Convert.ToInt32(tBoxYmin.Text);
                int ymax = Convert.ToInt32(tBoxYmax.Text);
                if (xmax < xmin || ymax < ymin)
                {
                    LogHelper.WriteLog("设置失败", LogType.Warning);
                    return;
                }
                int xInetrval = 0;
                int yInetrval = 0;
                if (xmax - xmin > 600)
                {
                    xInetrval = 100;
                }
                else if (xmax - xmin > 200)
                {
                    xInetrval = 50;
                }
                else if (xmax - xmin > 80)
                {
                    xInetrval = 20;
                }
                else
                {
                    xInetrval = 10;
                }
                if (ymax - ymin > 600)
                {
                    yInetrval = 100;
                }
                else if (ymax - ymin > 200)
                {
                    yInetrval = 50;
                }
                else if (ymax - ymin > 80)
                {
                    yInetrval = 20;
                }
                else
                {
                    yInetrval = 10;
                }
                chartXY.ChartAreas[1].AxisX.Maximum = xmax;
                chartXY.ChartAreas[1].AxisX.Minimum = xmin;
                chartXY.ChartAreas[1].AxisX.Interval = xInetrval;
                chartXY.ChartAreas[1].AxisY.Maximum = ymax;
                chartXY.ChartAreas[1].AxisY.Minimum = ymin;
                chartXY.ChartAreas[1].AxisY.Interval = yInetrval;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        #endregion

        #region 界面更新
      
        /// <summary>
        /// 更新日志
        /// </summary>
        /// <param name="msg"></param>
        private void UpdateLog(string msg)
        {
            if (lBoxLog.InvokeRequired)
            {
                LogEvent @event = new LogEvent(UpdateLog);
                lBoxLog.BeginInvoke(@event, msg);
            }
            else
            {
                lBoxLog.Items.Add(msg);
                if (lBoxLog.Items.Count > 400)
                {
                    lBoxLog.Items.RemoveAt(0);
                }
                lBoxLog.SelectedIndex = lBoxLog.Items.Count - 1;
            }
        }
        private void UpdateAlarm(string msg)
        {
            if (lBoxAlarm.InvokeRequired)
            {
                LogEvent @event = new LogEvent(UpdateAlarm);
                lBoxAlarm.BeginInvoke(@event, msg);
            }
            else
            {
                lBoxAlarm.Items.Add(msg);
                if (lBoxAlarm.Items.Count > 400)
                {
                    lBoxAlarm.Items.RemoveAt(0);
                }
                lBoxAlarm.SelectedIndex = lBoxAlarm.Items.Count - 1;
            }
        }
        private void UpdateWarn(string msg)
        {
            if (this.InvokeRequired)
            {
                LogEvent @event = new LogEvent(UpdateWarn);
                this.BeginInvoke(@event, msg);
            }
            else
            {
                btnWarning.Text = msg; 
            }
            
        }

        private void UpdateError(string msg)
        {
            if (this.InvokeRequired)
            {
                LogEvent @event = new LogEvent(UpdateError);
                this.BeginInvoke(@event, msg);
            }
            else
            {
                btnError.Text = msg;
            }
        }

        #endregion

        #region 清空报错
        private void BtnError_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("清空报错", LogType.Event);
            UIModel.UI.ExeAlarm = false;
            UIModel.UI.RunError = false;
            btnError.Text = string.Empty;
            btnWarning.Text = string.Empty;

        }

        private void lBoxLog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lBoxLog.SelectedIndex==0)
            {
                lBoxLog.Items.Clear();
            }
        }


        #endregion


        

        #region 单步移动类型
        private void radioContinue_CheckedChanged(object sender, EventArgs e)
        {
            if (radioContinue.Checked)
            {
                if (moveType != null)
                {
                    LogHelper.WriteLog("选择连续运动", LogType.Event);
                    moveType(AxisMoveType.ContinueMove);
                }
            }
        }

        private void radioRelative_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRelative.Checked)
            {
                if (moveType != null)
                {
                    LogHelper.WriteLog("选择相对运动", LogType.Event);
                    moveType(AxisMoveType.RelativeMove);
                }
            }
        }

        private void radioAbsolutely_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAbsolutely.Checked)
            {
                if (moveType != null)
                {
                    LogHelper.WriteLog("选择绝对运动", LogType.Event);
                    moveType(AxisMoveType.AbsolutelyMove);
                }
            }
        }
        #endregion

        #region 手动自动
        private void radioAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAuto.Checked)
            {
                LogHelper.WriteLog("选择自动", LogType.Event);
                UIModel.UI.Auto = true;
            }
        }

        private void radioManual_CheckedChanged(object sender, EventArgs e)
        {
            if (radioManual.Checked)
            {
                LogHelper.WriteLog("选择手动", LogType.Event);
                UIModel.UI.Auto = false;
            }
        }
        #endregion

        #region 加工空走
        private void radioWork_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWork.Checked)
            {
                LogHelper.WriteLog("选择加工", LogType.Event);
                UIModel.UI.WorkEnabling = true;
                
            }
        }

        private void radioNop_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNop.Checked)
            {
                LogHelper.WriteLog("选择空走", LogType.Event);
                UIModel.UI.WorkEnabling = false;
            }
        }





        #endregion

        #region G代码
        TextBox txtEdit = new TextBox();

        private void txtEdit_KeyDown(object sender, KeyEventArgs e)
        {
            //Enter键 更新项并隐藏编辑框   
            if (e.KeyCode == Keys.Enter)
            {
                lBoxGcodeName.Items[lBoxGcodeName.SelectedIndex] = txtEdit.Text;
                txtEdit.Visible = false;
            }
            //Esc键 直接隐藏编辑框   
            if (e.KeyCode == Keys.Escape)
                txtEdit.Visible = false;
        }
        private void lBoxGcodeName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                LogHelper.WriteLog("主界面：G代码改名", LogType.Event);
                int itemSelected = lBoxGcodeName.SelectedIndex;
                if (itemSelected > -1)
                {
                    string itemText = lBoxGcodeName.Items[itemSelected].ToString();
                    Rectangle rect = lBoxGcodeName.GetItemRectangle(itemSelected);
                    txtEdit.Parent = lBoxGcodeName;
                    txtEdit.Bounds = rect;
                    txtEdit.Visible = true;
                    txtEdit.Text = itemText;
                    txtEdit.KeyDown += new KeyEventHandler(txtEdit_KeyDown);
                    txtEdit.Focus();
                    txtEdit.SelectAll();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void lBoxGcodeName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int index = lBoxGcodeName.SelectedIndex;
                if (e.Control && e.KeyCode == Keys.Up)
                {
                    LogHelper.WriteLog("主界面：G代码上移", LogType.Event);
                    if (index <= 0)
                    {
                        return;
                    }
                    string key = lBoxGcodeName.Items[index].ToString();
                    lBoxGcodeName.Items[index] = lBoxGcodeName.Items[index - 1];
                    lBoxGcodeName.Items[index - 1] = key;
                    var Gcode = UIModel.UI.GCodeList[index];
                    UIModel.UI.GCodeList.RemoveAt(index);
                    UIModel.UI.GCodeList.Insert(index - 1, Gcode);
                }
                if (e.Control && e.KeyCode == Keys.Down)
                {
                    LogHelper.WriteLog("主界面：G代码下移", LogType.Event);
                    if (index == lBoxGcodeName.Items.Count - 1)
                    {
                        return;
                    }
                    string key = lBoxGcodeName.Items[index].ToString();
                    lBoxGcodeName.Items[index] = lBoxGcodeName.Items[index + 1];
                    lBoxGcodeName.Items[index + 1] = key;
                    var Gcode = UIModel.UI.GCodeList[index];
                    UIModel.UI.GCodeList.RemoveAt(index);
                    UIModel.UI.GCodeList.Insert(index + 1, Gcode);
                }
                if (e.KeyCode == Keys.Delete)
                {
                    LogHelper.WriteLog("主界面：G代码删除", LogType.Event);
                    lBoxGcodeName.Items.RemoveAt(index);
                    UIModel.UI.GCodeList.RemoveAt(index);
                }
                if (e.Alt && e.KeyCode == Keys.Q)
                {
                    LogHelper.WriteLog("主界面：G代码增加", LogType.Event);
                    lBoxGcodeName.Items.Add("G代码");
                    UIModel.UI.GCodeList.Add(new UIModel.Code("G代码", string.Empty));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void lBoxGcodeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteLog("主界面：选择G代码", LogType.Event);
                txtEdit.Visible = false;
                int index = lBoxGcodeName.SelectedIndex;
                if (index > -1)
                {
                    rBoxGcode.Text = UIModel.UI.GCodeList[index].Txt;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void rBoxGcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.S)
                {
                    LogHelper.WriteLog("主界面：保存G代码", LogType.Event);
                    int index = lBoxGcodeName.SelectedIndex;
                    if (index == -1)
                    {
                        return;
                    }
                    string key = lBoxGcodeName.Items[index].ToString();
                    if (UIModel.UI.GCodeList.Count > index)
                    {
                        UIModel.UI.GCodeList[index] = new UIModel.Code();
                        UIModel.UI.GCodeList[index].Name = key;
                        UIModel.UI.GCodeList[index].Txt = rBoxGcode.Text;
                    }
                    else if (UIModel.UI.GCodeList.Count == index)
                    {
                        UIModel.UI.GCodeList.Add(new UIModel.Code(key, rBoxGcode.Text));
                    }
                    else
                    {
                        for (int i = 0; i < lBoxGcodeName.Items.Count; i++)
                        {
                            if (i < UIModel.UI.GCodeList.Count)
                            {
                                if (UIModel.UI.GCodeList[i] != null)
                                {
                                    UIModel.UI.GCodeList[i].Name = lBoxGcodeName.Items[i].ToString();
                                }
                                else
                                {
                                    UIModel.UI.GCodeList[i] = new UIModel.Code();
                                    UIModel.UI.GCodeList[i].Name = lBoxGcodeName.Items[i].ToString();
                                }
                            }
                            else
                            {
                                UIModel.UI.GCodeList.Add(new UIModel.Code());
                                UIModel.UI.GCodeList[i].Name = lBoxGcodeName.Items[i].ToString();
                            }
                        }
                        UIModel.UI.GCodeList[index].Name = key;
                        UIModel.UI.GCodeList[index].Txt = rBoxGcode.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }






        #endregion

        #region 阵列模板
        private void ToolOpenModel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = LanguageFunction.Transfer("请选择要打开的模板文件!");
                dialog.Filter = LanguageFunction.Transfer("模板文件|*.xml");
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    string path = dialog.FileName;
                    txtModeFileName.Text= dialog.FileName;
                    XmlHelper xml = new XmlHelper(path);
                    bool ck = xml.Read(ref GrModel.Instance);
                    if (ck)
                    {
                        InitModel();
                        LogHelper.WriteLog("模板打开成功", LogType.Info);
                        MessageBox.Show(LanguageFunction.Transfer("模板打开成功"));
                    }
                    else
                    {
                        LogHelper.WriteLog("模板打开失败", LogType.Error);
                        MessageBox.Show(LanguageFunction.Transfer("模板打开失败"));
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void ToolSaveModel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = LanguageFunction.Transfer("模板文件|*.xml");
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.Title = LanguageFunction.Transfer("请选择或新建一个文件");
                if (DialogResult.OK == saveFileDialog.ShowDialog())
                {
                    txtModeFileName.Text = saveFileDialog.FileName;
                    SaveModel();
                    XmlHelper xml = new XmlHelper(saveFileDialog.FileName);
                    if (xml.Write(GrModel.Instance))
                    {
                        LogHelper.WriteLog("执行保存模板操作成功", LogType.Info);
                        MessageBox.Show(LanguageFunction.Transfer("执行保存模板操作成功"));
                    }
                    else
                    {
                        LogHelper.WriteLog("执行保存模板操作失败", LogType.Error);
                        MessageBox.Show(LanguageFunction.Transfer("执行保存模板操作失败"));
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void ToolLock_Click(object sender, EventArgs e)
        {
            try
            {
                if (ToolLock.Checked)
                {
                    LogHelper.WriteLog("选择阵列锁定", LogType.Event);
                    dgvArray1.ReadOnly = true;
                    dgvArray1.Columns[6].Visible = false;
                    dgvArray1.Columns[7].Visible = false;
                    
                }
                else
                {
                    LogHelper.WriteLog("选择阵列编辑", LogType.Event);
                   
                    dgvArray1.ReadOnly = false;
                    dgvArray1.Columns[6].Visible = true;
                    dgvArray1.Columns[7].Visible = true;
                    
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void dgvArray_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                int index = e.RowIndex;
               
                if (e.ColumnIndex == 7)
                {
                    if (UIModel.UI.HandWheelFlag)
                    {
                        MessageBox.Show(LanguageFunction.Transfer("请关闭手脉"));
                        return;
                    }
                    DialogResult dr=   MessageBox.Show("是否移动到位","提示",MessageBoxButtons.OKCancel);
                    if (dr== DialogResult.OK)
                    {
                        UIModel.UI.StopFlag = false;
                        Task.Factory.StartNew(delegate
                        {
                            try
                            {
                                Position pos = GrModel.Instance.positions1.Find(op => op.Id == index + 1);
                                ZmcauxFunction.IVelStruct @struct = new ZmcauxFunction.VelStruct();
                                if (pos != null)
                                {
                                    if (UIModel.UI.AxisPos[2] < pos.ZSaftHight )
                                    {
                                        @struct.Acc = AxisConfig.Instance[2].Acc;
                                        @struct.Dec = AxisConfig.Instance[2].Dec;
                                        @struct.Vel = AxisConfig.Instance[2].AutoVel;
                                        ZmcauxFunction.Instant.AxisSignalMove(2, pos.ZSaftHight, @struct);
                                        ZmcauxFunction.Instant.GetPrfStatus(2);
                                    }
                                    if (UIModel.UI.StopFlag)
                                    {
                                        return;
                                    }
                                    if (pos.X < 9999)
                                    {
                                        @struct.Acc = AxisConfig.Instance[0].Acc;
                                        @struct.Dec = AxisConfig.Instance[0].Dec;
                                        @struct.Vel = AxisConfig.Instance[0].AutoVel;
                                        ZmcauxFunction.Instant.AxisSignalMove(0, pos.X, @struct);
                                    }
                                    if (pos.Y < 9999)
                                    {
                                        @struct.Acc = AxisConfig.Instance[1].Acc;
                                        @struct.Dec = AxisConfig.Instance[1].Dec;
                                        @struct.Vel = AxisConfig.Instance[1].AutoVel;
                                        ZmcauxFunction.Instant.AxisSignalMove(1, pos.Y, @struct);
                                    }
                                    ZmcauxFunction.Instant.GetPrfStatus(0);
                                    ZmcauxFunction.Instant.GetPrfStatus(1);
                                    if (UIModel.UI.StopFlag)
                                    {
                                        return;
                                    }
                                    if (pos.Z < 9999)
                                    {
                                        @struct.Acc = AxisConfig.Instance[2].Acc;
                                        @struct.Dec = AxisConfig.Instance[2].Dec;
                                        @struct.Vel = AxisConfig.Instance[2].AutoVel;
                                        ZmcauxFunction.Instant.AxisSignalMove(2, pos.Z, @struct);
                                        ZmcauxFunction.Instant.GetPrfStatus(2);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LogHelper.WriteLog(ex);
                            }
                        });
                        
                    }
                    
                }
                else if (e.ColumnIndex == 6)
                {
                    DialogResult dr = MessageBox.Show("是否录入位置", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        dgv.Rows[index].Cells[1].Value = UIModel.UI.AxisPos[0].ToString("F2");
                        dgv.Rows[index].Cells[2].Value = UIModel.UI.AxisPos[1].ToString("F2");
                        dgv.Rows[index].Cells[3].Value = UIModel.UI.AxisPos[2].ToString("F2");
                    }
                   
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void dgv_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                for (int i = 1; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].Cells[e.ColumnIndex].Value = dgv.Rows[0].Cells[e.ColumnIndex].Value;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void dgvArray_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].HeaderCell.Value = "" + (i + 1);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }

        private void dgvArray_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].HeaderCell.Value = "" + (i + 1);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }

        private void InitModel()
        {
            try
            {
                GrModel.Instance.positions1.Sort((x, y) => x.Id - y.Id);
                for (int i = 0; i < SysConfig.Instance.MaxModeArray; i++)
                {
                    #region 涂胶阵列
                    if (GrModel.Instance[ i] != null)
                    {
                        dgvArray1.Rows[i].Cells[0].Value = GrModel.Instance[i].Enable;
                        dgvArray1.Rows[i].Cells[1].Value = GrModel.Instance[i].X;
                        dgvArray1.Rows[i].Cells[2].Value = GrModel.Instance[i].Y;
                        dgvArray1.Rows[i].Cells[3].Value = GrModel.Instance[i].Z;
                        dgvArray1.Rows[i].Cells[4].Value = GrModel.Instance[i].ZSaftHight;
                        dgvArray1.Rows[i].Cells[5].Value = GrModel.Instance[i].Index;
                    }
                    #endregion
                    
                }
               
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void SaveModel()
        {
            try
            {
                GrModel.Instance.positions1.Clear();
               
                for (int i = 0; i < SysConfig.Instance.MaxModeArray; i++)
                {
                    #region 涂胶阵列
                    {
                        Position pos = new Position();
                        pos.Id = i + 1;
                        pos.Enable = Convert.ToBoolean(dgvArray1.Rows[i].Cells[0].Value);
                        pos.X = Convert.ToSingle(dgvArray1.Rows[i].Cells[1].Value);
                        pos.Y = Convert.ToSingle(dgvArray1.Rows[i].Cells[2].Value);
                        pos.Z = Convert.ToSingle(dgvArray1.Rows[i].Cells[3].Value);
                        pos.ZSaftHight = Convert.ToSingle(dgvArray1.Rows[i].Cells[4].Value);
                        pos.Index = Convert.ToInt32(dgvArray1.Rows[i].Cells[5].Value);
                        GrModel.Instance.positions1.Add(pos);
                    }

                    #endregion
                    
                }
               
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void dgvArray_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (e.KeyChar == 22&& !dgv.ReadOnly)
                {
                    string clipboardText = Clipboard.GetText(); //获取剪贴板中的内容
                    if (string.IsNullOrEmpty(clipboardText))
                    {
                        return;
                    }
                    int selectedRowIndex = dgv.CurrentRow.Index;
                    int selectedColIndex = dgv.CurrentCell.ColumnIndex;
                    if (selectedColIndex != 1)
                    {
                        return;
                    }
                    string[] narry = clipboardText.Split('\n');
                    for (int i = selectedRowIndex,j=0; i < dgv.RowCount&&j< narry.Length; i++,j++)
                    {
                        if (string.IsNullOrWhiteSpace(narry[j]))
                        {
                            break;
                        }
                        string[] tarry= narry[j].Split('\t');
                        for (int ik = 0; ik < tarry.Length&& ik<4; ik++)
                        {
                            dgv[ik + 1, i].Value = tarry[ik].Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        #endregion



        #region 导入DXF
        private void 导入DXFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoadDxf dxf = new FrmLoadDxf();
            DialogResult dialog = dxf.ShowDialog();
            if (dialog == DialogResult.Yes)
            {
                for (int i = 0; i < dgvArray1.RowCount; i++)
                {
                    if (i < dxf.dgvArray.RowCount)
                    {
                        dgvArray1[0, i].Value = true;
                        dgvArray1[1, i].Value = dxf.dgvArray[0, i].Value;
                        dgvArray1[2, i].Value = dxf.dgvArray[1, i].Value;
                    }
                    else
                    {
                        dgvArray1[0, i].Value = false;
                    }
                }
            }
        }
        #endregion


    }

}
