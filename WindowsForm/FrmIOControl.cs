using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseLibrary.Common;
using BaseLibrary.Function;
using UserCustomLibrary.Function;
using BaseLibrary.SupportHelp;

namespace UWPCLaserMotion.WindowsForm
{
    public partial class FrmIOControl : Form
    {
        Button[] btnIn;
        Button[] btnOut;
        TextBox[] tBoxInName;
        TextBox[] tBoxOutName;

        Button[] btnIn2;
        Button[] btnOut2;
        TextBox[] tBoxInName2;
        TextBox[] tBoxOutName2;

        TextBox[,] tBoxADNames;
        TextBox[,] tBoxDANames;

        private readonly int mainCount = 32;
        private readonly int auxiliaryStrat = 64;
        private readonly int auxiliary1Count = 32;
        private readonly int daCount = 2;
        private readonly int adCount = 12;

        private DataTable table = new DataTable();
        private bool lockplc=false;
        public FrmIOControl()
        {
            InitializeComponent();
        }

        private void FrmIOControl_Load(object sender, EventArgs e)
        {
            ShowToFrmFunction.ShowIO(mainCount, gBoxIOIn, ref btnIn, ref tBoxInName, null, MouseHoverShow);
            ShowToFrmFunction.ShowIO(mainCount, gBoxIOOut, ref btnOut, ref tBoxOutName, btnOut_Click, MouseHoverShow);
            ShowToFrmFunction.ShowIO(auxiliary1Count, gBoxIOIn2, ref btnIn2, ref tBoxInName2, null, MouseHoverShow);
            ShowToFrmFunction.ShowIO(auxiliary1Count, gBoxIOOut2, ref btnOut2, ref tBoxOutName2, btnOut_Click2, MouseHoverShow);

            ShowToFrmFunction.ShowDA(daCount, gBoxDA, ref tBoxDANames, btnDA_Click);
            ShowToFrmFunction.ShowAD(adCount, gBoxAD, ref tBoxADNames);

            Array.Resize(ref IONameConfig.Instance.IOName_Out, mainCount);
            Array.Resize(ref IONameConfig.Instance.IOName_In, mainCount);

            Array.Resize(ref IONameConfig.Instance.IOName_Out2, auxiliary1Count);
            Array.Resize(ref IONameConfig.Instance.IOName_In2, auxiliary1Count);
            Array.Resize(ref IONameConfig.Instance.ADName, adCount);
            Array.Resize(ref IONameConfig.Instance.ADScale, adCount);
            Array.Resize(ref IONameConfig.Instance.DAName, daCount);

            for (int i = 0; i < mainCount; i++)
            {
                tBoxOutName[i].Text = IONameConfig.Instance.IOName_Out[i];
                tBoxInName[i].Text = IONameConfig.Instance.IOName_In[i];
            }
            for (int i = 0; i < auxiliary1Count; i++)
            {
                tBoxOutName2[i].Text = IONameConfig.Instance.IOName_Out2[i];
                tBoxInName2[i].Text = IONameConfig.Instance.IOName_In2[i];
            }

            for (int i = 0; i < adCount; i++)
            {
                tBoxADNames[i, 0].Text = IONameConfig.Instance.ADName[i];
                tBoxADNames[i, 3].Text = IONameConfig.Instance.ADScale[i];
            }
            for (int i = 0; i < daCount; i++)
            {
                tBoxDANames[i, 0].Text = IONameConfig.Instance.DAName[i];
            }

            foreach (var item in IONameConfig.Instance.tables)
            {
                dgvPLC.Rows.Add(item.ToArr());
            }
            dgvPLC.ReadOnly = true;
            timer1.Enabled = true;
            lockplc = true;
            LogHelper.WriteLog("进入IO控制界面", LogType.Event);
            Task.Factory.StartNew(PLCRead);
        }

        

        private void FrmIOControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            lockplc = false;
            timer1.Enabled = false;
            LogHelper.WriteLog("退出IO控制界面", LogType.Event);
        }
        private void PLCRead()
        {
            while (lockplc)
            {
                try
                {
                    Thread.Sleep(100);
                    for (int i = 0; i < dgvPLC.RowCount - 1; i++)
                    {
                        if (!lockplc)
                        {
                            return;
                        }
                        float address = IONameConfig.Instance.tables[i].Address;
                        string type = IONameConfig.Instance.tables[i].Type;
                        switch (type)
                        {
                            case "Bool":
                                {
                                    bool value = false;
                                    bool rt = false;
                                    rt = PLCFunction.PLC.GetValue_Bool(address, ref value);
                                    if (lockplc)
                                    {
                                        ColorToDGV(i, value, rt);
                                    }
                                    break;
                                }
                            case "Ushort":
                                {
                                    ushort value = 0;
                                    bool rt = false;
                                    rt = PLCFunction.PLC.GetValue_UShort(address, ref value);
                                    if (lockplc)
                                    {
                                        ColorToDGV(i, value, rt);
                                    }
                                    break;
                                }
                            case "Short":
                                {
                                    short value = 0;
                                    bool rt = false;
                                    rt = PLCFunction.PLC.GetValue_Short(address, ref value);
                                    if (lockplc)
                                    {
                                        ColorToDGV(i, value, rt);
                                    }
                                    break;
                                }
                            case "Int":
                                {
                                    int value = 0;
                                    bool rt = false;
                                    rt = PLCFunction.PLC.GetValue_Int(address, ref value);
                                    if (lockplc)
                                    {
                                        ColorToDGV(i, value, rt);
                                    }
                                    break;
                                }
                            case "Float":
                                {
                                    float value = 0;
                                    bool rt = false;
                                    rt = PLCFunction.PLC.GetValue_Float(address, ref value);
                                    if (lockplc)
                                    {
                                        ColorToDGV(i, value, rt);
                                    }
                                    break;
                                }
                            case "String":
                                {
                                    string value = string.Empty;
                                    bool rt = false;
                                    rt = PLCFunction.PLC.GetValue_String(address, ref value);
                                    if (lockplc)
                                    {
                                        ColorToDGV(i, value, rt);
                                    }

                                    break;
                                }
                            default:

                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex);
                }
            }
        }

        private void ColorToDGV(int row, object value, bool rt)
        {
            if (dgvPLC.InvokeRequired)
            {
                dgvPLC.BeginInvoke(new Action(delegate {
                    dgvPLC.Rows[row].Cells[3].Value = value;
                    dgvPLC.Rows[row].Cells[3].Style.BackColor = rt ? Color.Green : Color.Red;
                }));
            }
            else
            {
                dgvPLC.Rows[row].Cells[3].Value = value;
                dgvPLC.Rows[row].Cells[3].Style.BackColor = rt ? Color.Green : Color.Red;
            }
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (UIModel.UI.AutoRun)
            {
                panelControl.Enabled = false;
                gBoxIOIn.Enabled = false;
                gBoxIOOut.Enabled = false;
                cBoxEdit.Checked = false;
                cBoxOutput.Checked = false;
            }
            else
            {
                if (UIModel.UI.Auto)
                {
                    panelControl.Enabled = false;
                    gBoxIOIn.Enabled = false;
                    gBoxIOOut.Enabled = false;
                    cBoxEdit.Checked = false;
                    cBoxOutput.Checked = false;
                }
                else
                {
                    switch (UIModel.UI.UserAuthority)
                    {
                        case Authority.操作员:
                            panelControl.Enabled = false;
                            break;
                        case Authority.用户管理:
                            cBoxOutput.Enabled = false;
                            panelControl.Enabled = true;
                            break;
                        case Authority.工程师:
                            panelControl.Enabled = true;
                            cBoxOutput.Enabled = true;
                            break;
                        default:
                            break;
                    }
                    gBoxIOIn.Enabled = true;
                    gBoxIOOut.Enabled = true;
                }

            }
            try
            {
                for (int i = 0; i < mainCount; i++)
                {
                    btnOut[i].BackColor = ZmcauxFunction.Instant.GetDoBit(i) ? Color.Green : Color.White;
                    btnIn[i].BackColor = ZmcauxFunction.Instant.GetDiBit(i) ? Color.Green : Color.White;
                }
                for (int i = 0; i < auxiliary1Count; i++)
                {
                    btnOut2[i].BackColor = ZmcauxFunction.Instant.GetDoBit(auxiliaryStrat + i) ? Color.Green : Color.White;
                    btnIn2[i].BackColor = ZmcauxFunction.Instant.GetDiBit(auxiliaryStrat + i) ? Color.Green : Color.White;
                }

                for (int i = 0; i < adCount; i++)
                {
                    float value = ZmcauxFunction.Instant.GetADBit(i);
                    tBoxADNames[i, 1].Text = value.ToString();
                    if (!cBoxEdit.Checked)
                    {
                        tBoxADNames[i, 2].Text = table.Compute(tBoxADNames[i, 3].Text.Replace("X", value.ToString()), null)?.ToString();
                    }
                }
                for (int i = 0; i < daCount; i++)
                {
                    tBoxDANames[i, 1].Text = ZmcauxFunction.Instant.GetDA(i).ToString("F3");
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }



        private void MouseHoverShow(object sender, EventArgs e)
        {
            try
            {
                TextBox box = sender as TextBox;
                this.Text = "IO控制：" + box.Text;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (cBoxOutput.Checked)
                {
                    Button btn = sender as Button;
                    int index = Convert.ToInt16(btn.Tag);
                    bool value = btn.BackColor != Color.Green;
                    ZmcauxFunction.Instant.SetDoBit(index, value);
                    LogHelper.WriteLog("IO控制界面IO:" + index + "输出" + value, LogType.IO,2);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void btnOut_Click2(object sender, EventArgs e)
        {
            try
            {
                if (cBoxOutput.Checked)
                {
                    Button btn = sender as Button;
                    int index = Convert.ToInt16(btn.Tag) + auxiliaryStrat;
                    bool value = btn.BackColor != Color.Green;
                    ZmcauxFunction.Instant.SetDoBit(index, value);
                    LogHelper.WriteLog("IO控制界面IO:" + index + "输出" + value, LogType.IO,2);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            try
            {
                if (cBoxOutput.Checked)
                {
                    Button btn = sender as Button;
                    int index = Convert.ToInt16(btn.Tag);
                    float value = float.Parse(tBoxDANames[index, 2].Text);
                    ZmcauxFunction.Instant.SetDA(index, value);
                    LogHelper.WriteLog("IO控制界面模拟量:" + index + "输出" + value, LogType.IO,2);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void CBoxEdit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cBoxEdit.Checked)
                {
                    for (int i = 0; i < mainCount; i++)
                    {
                        tBoxOutName[i].ReadOnly = false;
                        tBoxOutName[i].Text = IONameConfig.Instance.IOName_Out[i];
                        tBoxInName[i].ReadOnly = false;
                        tBoxInName[i].Text = IONameConfig.Instance.IOName_In[i];
                    }
                    for (int i = 0; i < auxiliary1Count; i++)
                    {
                        tBoxOutName2[i].ReadOnly = false;
                        tBoxOutName2[i].Text = IONameConfig.Instance.IOName_Out2[i];
                        tBoxInName2[i].ReadOnly = false;
                        tBoxInName2[i].Text = IONameConfig.Instance.IOName_In2[i];
                    }
                    for (int i = 0; i < adCount; i++)
                    {
                        tBoxADNames[i, 0].ReadOnly = false;
                        tBoxADNames[i, 0].Text = IONameConfig.Instance.ADName[i];
                        tBoxADNames[i, 3].ReadOnly = false;
                        tBoxADNames[i, 3].Text = IONameConfig.Instance.ADScale[i];
                    }
                    for (int i = 0; i < daCount; i++)
                    {
                        tBoxDANames[i, 0].ReadOnly = false;
                        tBoxDANames[i, 0].Text = IONameConfig.Instance.DAName[i];
                    }
                    dgvPLC.ReadOnly = false;
                    dgvPLC.Rows.Clear();
                    foreach (var item in IONameConfig.Instance.tables)
                    {
                        dgvPLC.Rows.Add(item.ToArr());
                    }
                    LogHelper.WriteLog("IO控制界面可编辑", LogType.Event);
                }
                else
                {
                    for (int i = 0; i < mainCount; i++)
                    {
                        tBoxOutName[i].ReadOnly = true;
                        IONameConfig.Instance.IOName_Out[i] = tBoxOutName[i].Text;
                        tBoxInName[i].ReadOnly = true;
                        IONameConfig.Instance.IOName_In[i] = tBoxInName[i].Text;
                    }
                    for (int i = 0; i < auxiliary1Count; i++)
                    {
                        tBoxOutName2[i].ReadOnly = true;
                        IONameConfig.Instance.IOName_Out2[i] = tBoxOutName2[i].Text;
                        tBoxInName2[i].ReadOnly = true;
                        IONameConfig.Instance.IOName_In2[i] = tBoxInName2[i].Text;
                    }

                    for (int i = 0; i < adCount; i++)
                    {
                        tBoxADNames[i, 0].ReadOnly = true;
                        IONameConfig.Instance.ADName[i] = tBoxADNames[i, 0].Text;
                        tBoxADNames[i, 3].ReadOnly = true;
                        IONameConfig.Instance.ADScale[i] = tBoxADNames[i, 3].Text;
                    }
                    for (int i = 0; i < daCount; i++)
                    {
                        tBoxDANames[i, 0].ReadOnly = true;
                        IONameConfig.Instance.DAName[i] = tBoxDANames[i, 0].Text;
                    }
                    IONameConfig.Instance.tables.Clear();
                    for (int i = 0; i < dgvPLC.RowCount - 1; i++)
                    {
                        IONameConfig.Table table = new IONameConfig.Table();
                        table.Name = dgvPLC.Rows[i].Cells[0].Value.ToString();
                        table.Address = Convert.ToSingle(dgvPLC.Rows[i].Cells[1].Value);
                        table.Type = dgvPLC.Rows[i].Cells[2].Value.ToString();
                        IONameConfig.Instance.tables.Add(table);
                    }
                    dgvPLC.ReadOnly = true;
                    switch (SysConfig.Instance.Language)
                    {
                        case LanguageType.Chinese:
                            {
                                XmlHelper helper = new XmlHelper("Config/IONameConfig.xml");
                                helper.Write(IONameConfig.Instance);
                                break;
                            }
                        case LanguageType.English:
                            {
                                XmlHelper helper = new XmlHelper("Config/IONameConfig-en.xml");
                                helper.Write(IONameConfig.Instance);
                                break;
                            }
                        default:
                            break;
                    }
                    
                    LogHelper.WriteLog("IO控制界面不可编辑", LogType.Event);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void dgvPLC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (cBoxOutput.Checked)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == 4 && e.RowIndex < dgvPLC.RowCount - 1)
                    {
                        float address = IONameConfig.Instance.tables[e.RowIndex].Address;
                        string type = IONameConfig.Instance.tables[e.RowIndex].Type;
                        if (type == "Bool")
                        {
                            Task.Factory.StartNew(delegate {
                                LogHelper.WriteLog("IO控制界面手动写值", LogType.Event);
                                bool value = false;
                                bool rt = PLCFunction.PLC.GetValue_Bool(address, ref value);
                                PLCFunction.PLC.SetValue_Bool(address, !value, LanguageFunction.TransferLog("IO控制界面"));
                            });
                        }
                        else if (type == "String")
                        {
                            string value = Convert.ToString(dgvPLC[5, e.RowIndex].Value);
                            Task.Factory.StartNew(delegate {
                                LogHelper.WriteLog("IO控制界面手动写值", LogType.Event);
                                PLCFunction.PLC.SetValue_String(address, value, LanguageFunction.TransferLog("IO控制界面"));
                            });
                        }
                        else if (type == "Int")
                        {
                            int value = Convert.ToInt32(dgvPLC[5, e.RowIndex].Value);
                            Task.Factory.StartNew(delegate {
                                LogHelper.WriteLog("IO控制界面手动写值", LogType.Event);
                                PLCFunction.PLC.SetValue_Int(address, value, LanguageFunction.TransferLog("IO控制界面"));
                            });
                        }
                        else if (type == "Short")
                        {
                            short value = Convert.ToInt16(dgvPLC[5, e.RowIndex].Value);
                            Task.Factory.StartNew(delegate {
                                LogHelper.WriteLog("IO控制界面手动写值", LogType.Event);
                                PLCFunction.PLC.SetValue_Short(address, value, LanguageFunction.TransferLog("IO控制界面"));
                            });
                        }
                        else if (type == "Ushort")
                        {
                            ushort value = Convert.ToUInt16(dgvPLC[5, e.RowIndex].Value);
                            Task.Factory.StartNew(delegate {
                                LogHelper.WriteLog("IO控制界面手动写值", LogType.Event);
                                PLCFunction.PLC.SetValue_UShort(address, value, LanguageFunction.TransferLog("IO控制界面"));
                            });
                        }
                        else if (type == "Float")
                        {
                            float value = Convert.ToSingle(dgvPLC[5, e.RowIndex].Value);
                            Task.Factory.StartNew(delegate {
                                LogHelper.WriteLog("IO控制界面手动写值", LogType.Event);
                                PLCFunction.PLC.SetValue_Float(address, value, LanguageFunction.TransferLog("IO控制界面"));
                            });
                        }
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
