using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseLibrary.Function;
using BaseLibrary.SupportHelp;
using BaseLibrary.Common;

namespace UWPCLaserMotion.WindowsForm
{
    public partial class FrmSysConfig : Form
    {
        ComboBox cBox01 = new ComboBox();
        public FrmSysConfig()
        {
            InitializeComponent();
        }

        private void FrmSyStemConfig_Load(object sender, EventArgs e)
        {
            try
            {
                #region 初始化
                dgvDoubleIO.CellValidating += CheckFunction.DGV_Validating_Null_Int;
                dgvDoubleIO.RowValidating += CheckFunction.DGV_Validating_Null;
                dgvSingleIO.CellValidating += CheckFunction.DGV_Validating_Null_Int;
                dgvSingleIO.RowValidating += CheckFunction.DGV_Validating_Null;
                dgvSensor.CellValidating += CheckFunction.DGV_Validating_Null_Int;
                dgvSensor.RowValidating += CheckFunction.DGV_Validating_Null;

                ShowToFrmFunction.ComboBox_Init(cBox01,new string[] {"0","1" });
                for (int i = 0; i < SysConfig.Instance.InvertIOCount; i++)
                {
                    cLBoxSetInvertIn.Items.Add("IN" + i, SysConfig.Instance.InvertIn[i]);
                }
                #endregion

                #region 权限限制

                switch (UIModel.UI.UserAuthority)
                {
                    case Authority.工程师:
                        tabSysConfig.Enabled = true;
                        btnOK.Enabled = true;
                        btnCancel.Enabled = true;
                        break;
                    case Authority.用户管理:
                    case Authority.操作员:
                        tabSysConfig.Enabled = false;
                        btnOK.Enabled = false;
                        btnCancel.Enabled = false;
                        break;
                }
                #endregion

                #region 赋值

                foreach (SysConfig.ControlIO item in SysConfig.Instance.DoubleIO)
                {
                    if (item!=null)
                    {
                        dgvDoubleIO.Rows.Add(item.ToArray(2));
                    }
                }
                foreach (SysConfig.ControlIO item in SysConfig.Instance.SingleIO)
                {
                    if (item != null)
                    {
                        dgvSingleIO.Rows.Add(item.ToArray(1));
                    }
                }
                foreach (BaseLibrary.Common.SysConfig.ControlIO item in SysConfig.Instance.Sensor)
                {
                    if (item != null)
                    {
                        dgvSensor.Rows.Add(item.ToArray(1));
                    }
                }
                
                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(LanguageFunction.Transfer("系统参数加载错误"));
            }
            finally
            {
                LogHelper.WriteLog("进入系统参数设置", LogType.Event);
            }
        }

        private void FrmSyStemConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogHelper.WriteLog("退出系统参数设置", LogType.Event);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("确认系统参数设置", LogType.Event);
            try
            {
                #region 转换
                List<SysConfig.ControlIO> doubleio = new List<SysConfig.ControlIO>();
                for (int i = 0; i < dgvDoubleIO.RowCount; i++)
                {
                    if (dgvDoubleIO.Rows[i].Cells[0].Value!=null)
                    {
                        SysConfig.ControlIO iO = new SysConfig.ControlIO();
                        iO.Name = dgvDoubleIO.Rows[i].Cells[0].Value.ToString();
                        iO.OUTIndex_ON = Convert.ToInt32(dgvDoubleIO.Rows[i].Cells[1].Value);
                        iO.OUTIndex_OFF = Convert.ToInt32(dgvDoubleIO.Rows[i].Cells[2].Value);
                        iO.INIndex_ON = Convert.ToInt32(dgvDoubleIO.Rows[i].Cells[3].Value);
                        iO.INIndex_OFF = Convert.ToInt32(dgvDoubleIO.Rows[i].Cells[4].Value);
                        //iO.ValidValue = Convert.ToInt32(dgvDoubleIO.Rows[i].Cells[5].Value);
                        doubleio.Add(iO);
                    }
                    
                }
                List<SysConfig.ControlIO> singleio = new List<SysConfig.ControlIO>();
                for (int i = 0; i < dgvSingleIO.RowCount; i++)
                {
                    if (dgvSingleIO.Rows[i].Cells[0].Value != null)
                    {
                        SysConfig.ControlIO iO = new SysConfig.ControlIO();
                        iO.Name = dgvSingleIO.Rows[i].Cells[0].Value.ToString();
                        iO.Index = Convert.ToInt32(dgvSingleIO.Rows[i].Cells[1].Value);
                        //iO.ValidValue = Convert.ToInt32(dgvSingleIO.Rows[i].Cells[2].Value);
                        singleio.Add(iO);
                    }
                }

                List<SysConfig.ControlIO> sensor = new List<SysConfig.ControlIO>();
                for (int i = 0; i < dgvSensor.RowCount; i++)
                {
                    if (dgvSensor.Rows[i].Cells[0].Value != null)
                    {
                        SysConfig.ControlIO iO = new SysConfig.ControlIO();
                        iO.Name = dgvSensor.Rows[i].Cells[0].Value.ToString();
                        iO.Index = Convert.ToInt32(dgvSensor.Rows[i].Cells[1].Value);
                        //iO.ValidValue = Convert.ToInt32(dgvSensor.Rows[i].Cells[2].Value);
                        sensor.Add(iO);
                    }
                }


                #endregion


                #region 赋值设置
                string strfig = JsonHelper.ToJson(SysConfig.Instance);
                LogHelper.WriteLog(LanguageFunction.TransferLog("原软件参数：") + strfig, LogType.Info, 1);
                SysConfig.Instance.DoubleIO = doubleio;
                SysConfig.Instance.SingleIO = singleio;
                SysConfig.Instance.Sensor = sensor;

                for (int i = 0; i < SysConfig.Instance.InvertIOCount; i++)
                {
                    SysConfig.Instance.InvertIn[i] = cLBoxSetInvertIn.GetItemChecked(i);
                }

                XmlHelper helper = new XmlHelper("Config/SysConfig.xml");
                helper.Write(SysConfig.Instance);
                strfig = JsonHelper.ToJson(SysConfig.Instance);
                LogHelper.WriteLog(LanguageFunction.TransferLog("现软件参数：") + strfig, LogType.Info, 1);
                #endregion
                LogHelper.WriteLog("设置成功", LogType.Info);;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show(LanguageFunction.Transfer("参数错误"));
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("取消系统参数设置", LogType.Event);
            this.Close();
        }

        private void DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (sender.Equals(dgvDoubleIO))
                {
                    if (e.ColumnIndex == 5)
                    {
                        ShowToFrmFunction.CBoxVisable(e.RowIndex, e.ColumnIndex, cBox01, dgv);
                    }
                }
                else
                {
                    if (e.ColumnIndex == 2)
                    {
                        ShowToFrmFunction.CBoxVisable(e.RowIndex, e.ColumnIndex, cBox01, dgv);
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
