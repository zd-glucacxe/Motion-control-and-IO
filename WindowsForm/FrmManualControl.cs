using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseLibrary.Common;
using BaseLibrary.Function;
using BaseLibrary.SupportHelp;
using UserCustomLibrary.WindowsForm;

namespace UWPCLaserMotion.WindowsForm
{
    public partial class FrmManualControl : Form
    {
        Button[,] BtnsDoubleIO;
        Button[] BtnsSingleIO;
        Label[] ColorSensor;
        #region 加载关闭

        public FrmManualControl()
        {
            InitializeComponent();
        }

        private void FrmManualControl_Load(object sender, EventArgs e)
        {
            try
            {
                BaseLibrary.Function.InitFunction.SelectLanguage();
                ShowToFrmFunction.BtnControl ioConfig = new ShowToFrmFunction.BtnControl();
                ioConfig.Name = SysConfig.Instance.DoubleIO?.Where(o => o != null && !string.IsNullOrEmpty(o.Name))?.Select(o =>LanguageFunction.Transfer(o?.Name))?.ToArray();
                ioConfig.ColCount = 4;
                ioConfig.LocationX = 20;
                ioConfig.LocationY = 30;
                ioConfig.Size = new Size(90, 40);
                ioConfig.SpaceHeight = 50;
                ioConfig.SpaceWidth = 110;
                ShowToFrmFunction.ControlDoubleIO(ioConfig, gBoxDoubleIO, ref BtnsDoubleIO, DoubleIOClick);


                ioConfig.Name = SysConfig.Instance.SingleIO?.Where(o=>o!=null&&!string.IsNullOrEmpty(o.Name))?.Select(o => LanguageFunction.Transfer(o?.Name))?.ToArray();
                ioConfig.ColCount = 8;
                ioConfig.LocationX = 20;
                ioConfig.LocationY = 30;
                ioConfig.Size = new Size(90, 40);
                ioConfig.SpaceHeight = 50;
                ioConfig.SpaceWidth = 110;
                ShowToFrmFunction.ControlSingleIO(ioConfig, gBoxSingleIO, ref BtnsSingleIO, SingleIOClick);

                ioConfig.Name = SysConfig.Instance.Sensor?.Where(o => o != null && !string.IsNullOrEmpty(o.Name))?.Select(o => LanguageFunction.Transfer(o?.Name))?.ToArray();
                ioConfig.ColCount = 8;
                ioConfig.LocationX = 20;
                ioConfig.LocationY = 30;
                ioConfig.Size = new Size(90, 40);
                ioConfig.SpaceHeight = 50;
                ioConfig.SpaceWidth = 110;
                ShowToFrmFunction.ControlSensor(ioConfig, gBoxSensor, ref ColorSensor);
                timer1.Enabled = true;

                {//主界面自定义按钮
                    UserManualControl frm = new UserManualControl();
                    frm.Parent = gBoxUser;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            finally
            {
                LogHelper.WriteLog("进入手动控制界面", LogType.Event);
            }
            
        }

        private void FrmManualControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogHelper.WriteLog("退出手动控制界面", LogType.Event);
        }

        #endregion

       

       

        private void SingleIOClick(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                LogHelper.WriteLog($"手动控制：{btn.Text}按下", LogType.Event,2);
                if (UIModel.UI.Runing)
                {
                    LogHelper.WriteLog("自动运行下禁止IO控制", LogType.Warning);
                    return;
                }
                int index = Convert.ToInt32(btn.Tag);
                if (index >= SysConfig.Instance.SingleIO.Count)
                {
                    LogHelper.WriteLog("设置修改，重启软件", LogType.Error);
                    return;
                }
                int index_io = SysConfig.Instance.SingleIO[index].Index;
                if (ZmcauxFunction.Instant.GetDoBit(index_io))
                {
                    ZmcauxFunction.Instant.SetDoBit(index_io, false);
                }
                else
                {
                    ZmcauxFunction.Instant.SetDoBit(index_io, true);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void DoubleIOClick(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                LogHelper.WriteLog($"手动控制：{btn.Text}按下", LogType.Event,2);
                if (UIModel.UI.Runing)
                {
                    LogHelper.WriteLog("自动运行下禁止IO控制", LogType.Warning);
                    return;
                }
                string[] logo = btn.Tag.ToString().Split(',');
                int index = Convert.ToInt32(logo[0]);
                bool isopen = Convert.ToBoolean(logo[1]);
                IOControlFunction.Cylinder(isopen, index);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (UIModel.UI.Runing||UIModel.UI.Auto||UIModel.UI.AutoRun)
            {
                this.Enabled = false;//菜单栏
            }
            else
            {
                this.Enabled = true;//菜单栏
                switch (UIModel.UI.UserAuthority)
                {
                    case Authority.工程师:
                    case Authority.操作员:
                        gBoxDoubleIO.Enabled = false;
                        gBoxSingleIO.Enabled = false;
                        break;
                }
            }
            
            await Task.Factory.StartNew(delegate {
                try
                {
                    int Count = SysConfig.Instance.DoubleIO.Count;
                    for (int i = 0; i < Count; i++)
                    {
                        if (i>= BtnsDoubleIO.GetLength(0))
                        {
                            break;
                        }
                        BtnsDoubleIO[i, 0].BackColor = ZmcauxFunction.Instant.GetDiBit(SysConfig.Instance.DoubleIO[i].INIndex_ON) ? Color.Green : Color.White;
                        BtnsDoubleIO[i, 1].BackColor = ZmcauxFunction.Instant.GetDiBit(SysConfig.Instance.DoubleIO[i].INIndex_OFF) ? Color.Green : Color.White;
                    }
                    Count = SysConfig.Instance.SingleIO.Count;
                    for (int i = 0; i < Count; i++)
                    {
                        if (i >= BtnsSingleIO.GetLength(0))
                        {
                            break;
                        }
                        if (ZmcauxFunction.Instant.GetDoBit(SysConfig.Instance.SingleIO[i].Index))
                        {
                            BtnsSingleIO[i].BackColor = Color.Green;
                        }
                        else
                        {
                            BtnsSingleIO[i].BackColor = Color.White;
                        }
                    }
                    Count = SysConfig.Instance.Sensor.Count;
                    for (int i = 0; i < Count; i++)
                    {
                        if (i >= ColorSensor.GetLength(0))
                        {
                            break;
                        }
                        if (ZmcauxFunction.Instant.GetDiBit(SysConfig.Instance.Sensor[i].Index))
                        {
                            ColorSensor[i].BackColor = Color.Green;
                        }
                        else
                        {
                            ColorSensor[i].BackColor = Color.White;
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
}

