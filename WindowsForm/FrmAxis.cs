using BaseLibrary.Common;
using BaseLibrary.Function;
using BaseLibrary.SupportHelp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UWPCLaserMotion.WindowsForm
{
    public partial class FrmAxis : Form
    {
        public FrmAxis()
        {
            InitializeComponent();
        }
        private void FrmAxis_Load(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteLog("加载轴参数", LogType.Info);
                lBoxHomeSort.Items.Clear();
                foreach (var item in AxisConfig.Instance.HomeSort)
                {
                    if (item.enable)
                    {
                        lBoxHomeSort.Items.Add(AxisConfig.Instance[item.axis].Name, true);
                    }
                    else
                    {
                        lBoxHomeSort.Items.Add(AxisConfig.Instance[item.axis].Name, false);
                    }
                }

                tBoxAxisCount.Value= (decimal)AxisConfig.Instance.axisCount;
                tBoxNopEndBufVel.Value = (decimal)AxisConfig.Instance.NopEndVelRate;
                tBoxWeldEndBufVel.Value = (decimal)AxisConfig.Instance.BufferEndVelRate;
                tBoxAutoNopSpeed.Value = (decimal)AxisConfig.Instance.Vel_Nop;
                tBoxAutoAcc_Nop.Value = (decimal)AxisConfig.Instance.Acc_Nop;
                tBoxAutoDec_Nop.Value = (decimal)AxisConfig.Instance.Dec_Nop;
                tBoxautoSpeedWeld.Value = (decimal)AxisConfig.Instance.Vel_Weld;
                tBoxAutoAcc_Welding.Value = (decimal)AxisConfig.Instance.Acc_Weld;
                tBoxAutoDec_Welding.Value = (decimal)AxisConfig.Instance.Dec_Weld;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        private void cboxAxisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogHelper.WriteLog(LanguageFunction.TransferLog("轴参数配置：选择") + cboxAxisNo.Text, LogType.Event, 1);
            try
            {
                int index = cboxAxisNo.SelectedIndex;
                AxisConfig.SingleAxisConfig config = AxisConfig.Instance[index];
                gBoxAxis.Text = cboxAxisNo.Text + LanguageFunction.Transfer("参数");
                tBoxName.Text = config.Name;
                cboxAxistype.SelectedIndex = (int)config.Type;
                cboxAxisHomeDirection.SelectedIndex = config.HomeDir ? 0 : 1;

                tBoxReductionRate.Value = (decimal)config.ReductRatio;
                tBoxScrewPitch.Value = (decimal)config.ScrewPitch;
                tBoxAxisSinglePulse.Value = (decimal)config.SinglePulse;

                tBoxAxisSpeed.Value = (decimal)config.Vel;
                tBoxAutoSpeed.Value = (decimal)config.AutoVel;
                tBoxHomeSpeed_H.Value = (decimal)config.Vel_Home_H;
                tBoxHomeSpeed.Value = (decimal)config.Vel_Home;

                tBoxOffsetSpeed.Value = (decimal)config.Vel_Offset;
                tBoxAxisOffset.Value = (decimal)config.HomeOffset;

                tBoxAxisAcc.Value = (decimal)config.Acc;
                tBoxAxisDec.Value = (decimal)config.Dec;
                tBoxAxisSoftLimit_P.Value = (decimal)config.SoftLimit_P;
                tBoxAxisSoftLimit_N.Value = (decimal)config.SoftLimit_N;

                tBoxSramp.Value = (decimal)config.Sramp;
                tBoxLspeed.Value = (decimal)config.Lspeed;

                tBoxLimit_P.Value = config.LimitIndex_P;
                tBoxLimit_N.Value = config.LimitIndex_N;
                tBoxHome.Value = config.HomeIndex;
                tBoxServoAlarm.Value = config.AlarmIndex;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(LanguageFunction.Transfer("轴参数加载异常"));
            }
        }

        private void tBoxAxisCount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cboxAxisNo.Items.Clear();
                for (int i = 0; i < AxisConfig.Instance.axisCount; i++)
                {
                    cboxAxisNo.Items.Add(AxisConfig.Instance[i].Name);
                }
                cboxAxisNo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteLog("保存参数配置", LogType.Event);

                string strfig = JsonHelper.ToJson(AxisConfig.Instance);
                    LogHelper.WriteLog(LanguageFunction.TransferLog("原轴参数：") + strfig, LogType.Info, 1);
                    int index = cboxAxisNo.SelectedIndex;
                    AxisConfig.Instance.singleAxis[index].Name = tBoxName.Text;


                    AxisConfig.Instance.singleAxis[index].Type = (AxisConfig.HomeType)cboxAxistype.SelectedIndex;
                    AxisConfig.Instance.singleAxis[index].HomeDir = cboxAxisHomeDirection.SelectedIndex == 0;

                    AxisConfig.Instance.singleAxis[index].ReductRatio = (float)tBoxReductionRate.Value;
                    AxisConfig.Instance.singleAxis[index].ScrewPitch = (int)tBoxScrewPitch.Value;
                    AxisConfig.Instance.singleAxis[index].SinglePulse = (int)tBoxAxisSinglePulse.Value;

                    AxisConfig.Instance.singleAxis[index].AutoVel = (float)tBoxAutoSpeed.Value;
                    AxisConfig.Instance.singleAxis[index].Vel = (float)tBoxAxisSpeed.Value;
                    AxisConfig.Instance.singleAxis[index].Vel_Home_H = (float)tBoxHomeSpeed_H.Value;
                    AxisConfig.Instance.singleAxis[index].Vel_Home = (float)tBoxHomeSpeed.Value;

                    AxisConfig.Instance.singleAxis[index].Vel_Offset = (float)tBoxOffsetSpeed.Value;
                    AxisConfig.Instance.singleAxis[index].HomeOffset = (float)tBoxAxisOffset.Value;

                    AxisConfig.Instance.singleAxis[index].Acc = (float)tBoxAxisAcc.Value;
                    AxisConfig.Instance.singleAxis[index].Dec = (float)tBoxAxisDec.Value;
                    AxisConfig.Instance.singleAxis[index].SoftLimit_P = (float)tBoxAxisSoftLimit_P.Value;
                    AxisConfig.Instance.singleAxis[index].SoftLimit_N = (float)tBoxAxisSoftLimit_N.Value;

                    AxisConfig.Instance.singleAxis[index].Sramp = (float)tBoxSramp.Value;
                    AxisConfig.Instance.singleAxis[index].Lspeed = (float)tBoxLspeed.Value;

                    AxisConfig.Instance.singleAxis[index].LimitIndex_P = Convert.ToInt32(tBoxLimit_P.Value);
                    AxisConfig.Instance.singleAxis[index].LimitIndex_N = Convert.ToInt32(tBoxLimit_N.Value);
                    AxisConfig.Instance.singleAxis[index].HomeIndex = Convert.ToInt32(tBoxHome.Value);
                    AxisConfig.Instance.singleAxis[index].AlarmIndex = Convert.ToInt32(tBoxServoAlarm.Value);

                    AxisConfig.Instance.axisCount = (int)tBoxAxisCount.Value;
                    AxisConfig.Instance.NopEndVelRate = (float)tBoxNopEndBufVel.Value;
                    AxisConfig.Instance.BufferEndVelRate = (float)tBoxWeldEndBufVel.Value;
                    AxisConfig.Instance.Vel_Nop = (float)tBoxAutoNopSpeed.Value;
                    AxisConfig.Instance.Acc_Nop = (float)tBoxAutoAcc_Nop.Value;
                    AxisConfig.Instance.Dec_Nop = (float)tBoxAutoDec_Nop.Value;
                    AxisConfig.Instance.Vel_Weld = (float)tBoxautoSpeedWeld.Value;
                    AxisConfig.Instance.Acc_Weld = (float)tBoxAutoAcc_Welding.Value;
                    AxisConfig.Instance.Dec_Weld = (float)tBoxAutoDec_Welding.Value;

                    AxisConfig.Instance.HomeSort.Clear();
                    for (int i = 0; i < lBoxHomeSort.Items.Count; i++)
                    {
                        int axis = AxisConfig.GETAxisIndex(lBoxHomeSort.Items[i].ToString());
                        bool enable = lBoxHomeSort.GetItemChecked(i);
                        AxisConfig.Instance.HomeSort.Add(new AxisConfig.HomeAxis(axis, enable));
                    }


                    XmlHelper XSysConfig = new XmlHelper("Config/AxisConfig.xml");
                    bool rt = XSysConfig.Write(AxisConfig.Instance);
                    if (rt)
                    {
                        LogHelper.WriteLog("保存轴参数文件成功", LogType.Info);
                    }
                    else
                    {
                        LogHelper.WriteLog("保存轴参数文件失败", LogType.Info);
                        MessageBox.Show(LanguageFunction.Transfer("保存轴参数文件失败"));
                    }
                    strfig = JsonHelper.ToJson(AxisConfig.Instance);
                    LogHelper.WriteLog(LanguageFunction.TransferLog("现轴参数：") + strfig, LogType.Info, 1);

                    cboxAxisNo.Items[index] = tBoxName.Text;
                


                this.Close();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(LanguageFunction.Transfer("参数保存异常"));
            }
        }

        private void lBoxHomeSort_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int index = lBoxHomeSort.SelectedIndex;
                if (e.Control && e.KeyCode == Keys.Up)
                {
                    LogHelper.WriteLog("轴参数：轴上移", LogType.Event);
                    if (index <= 0)
                    {
                        return;
                    }
                    string key = lBoxHomeSort.Items[index].ToString();
                    lBoxHomeSort.Items[index] = lBoxHomeSort.Items[index - 1];
                    lBoxHomeSort.Items[index - 1] = key;
                }
                if (e.Control && e.KeyCode == Keys.Down)
                {
                    LogHelper.WriteLog("轴参数：轴下移", LogType.Event);
                    if (index == lBoxHomeSort.Items.Count - 1)
                    {
                        return;
                    }
                    string key = lBoxHomeSort.Items[index].ToString();
                    lBoxHomeSort.Items[index] = lBoxHomeSort.Items[index + 1];
                    lBoxHomeSort.Items[index + 1] = key;
                }
                if (e.Alt && e.KeyCode == Keys.Home)
                {
                    LogHelper.WriteLog("轴参数：轴重置", LogType.Event);
                    lBoxHomeSort.Items.Clear();
                    for (int i = 0; i < AxisConfig.Instance.axisCount; i++)
                    {
                        lBoxHomeSort.Items.Add(AxisConfig.Instance[i].Name, false);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
    }
}
