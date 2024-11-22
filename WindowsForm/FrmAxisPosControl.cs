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
using UserCustomLibrary.Common;

namespace UWPCLaserMotion.WindowsForm
{
    public delegate void MoveType(AxisMoveType axisMove);
    public partial class FrmAxisPosControl : UserControl
    {
        public AxisMoveType axisMove { get; set; }
        private int Axis;
        private int Card;
        public FrmAxisPosControl()
        {
            InitializeComponent();
        }

        public FrmAxisPosControl(int Axis)
        {
            InitializeComponent();
            this.Axis = Axis;
        }
        public FrmAxisPosControl(int Axis,int Card)
        {
            InitializeComponent();
            this.Axis = Axis;
            this.Card = Card;
        }
        public void MoveType(AxisMoveType axisMove)
        {
            this.axisMove = axisMove;
        }

        private void FrmAxisPosControl_Load(object sender, EventArgs e)
        {
            
            labelName.Text = AxisConfig.Instance[Card,Axis].Name;
            tBoxOffset.Validating += CheckFunction.TBox_Validating_Double_;
            btnAdd.MouseDown += btnAxis_MouseDown;
            btnAdd.MouseUp += btnAxis_MouseUp;
            btnLess.MouseDown += btnAxis_MouseDown;
            btnLess.MouseUp += btnAxis_MouseUp;
            tBoxOffset.Validating += CheckFunction.TBox_Validating_Double_;
            timerUI.Enabled = true;
        }


        #region 轴单步
        private void btnAxis_MouseDown(object sender, MouseEventArgs e)
        {
            LogHelper.WriteLog("主界面：执行轴单步操作", LogType.Event);
            try
            {
                if (UIModel.UI.Runing)
                {
                    LogHelper.WriteLog("运行下禁止轴单步运动", LogType.Warning);
                    return;
                }
                if (UIModel.UI.HandWheelFlag)
                {
                    LogHelper.WriteLog("请将手脉置于OFF档", LogType.Warning);
                    MessageBox.Show(LanguageFunction.Transfer("请将手脉置于OFF档"));
                    return;
                }
                if (Axis == 1 || Axis == 0)
                {
                    if (UIModel.UI.AxisPos[2] < SysConfig.Instance.SafeHightZ1)
                    {
                        LogHelper.WriteLog("Z1轴不安全", LogType.Warning);
                        return;
                    }
                }

                Button btn = sender as Button;
                bool dir = btn.Text.Contains("+");
                float SingleDistance = 0;
                bool ck = float.TryParse(tBoxOffset.Text, out SingleDistance);
                if (axisMove==AxisMoveType.ContinueMove)
                {
                    LogHelper.WriteLog("单步连续运动", LogType.Info);
                    ZmcauxFunction.IVelStruct velStruct = new ZmcauxFunction.VelStruct();
                    velStruct.Vel = AxisConfig.Instance[Card,Axis].Vel;
                    velStruct.Acc = AxisConfig.Instance[Card,Axis].Acc;
                    velStruct.Dec = AxisConfig.Instance[Card,Axis].Dec;
                    if (Card==0)
                    {
                        ZmcauxFunction.Instant.AxisSignalMove(Axis, dir, velStruct);
                    }
                    
                }
                if (axisMove == AxisMoveType.AbsolutelyMove)
                {
                    if (ck)
                    {
                        LogHelper.WriteLog(LanguageFunction.TransferLog("单步绝对运动") + SingleDistance, LogType.Info,1);
                        ZmcauxFunction.IVelStruct velStruct = new ZmcauxFunction.VelStruct();
                        velStruct.Vel = AxisConfig.Instance[Card,Axis].Vel;
                        velStruct.Acc = AxisConfig.Instance[Card,Axis].Acc;
                        velStruct.Dec = AxisConfig.Instance[Card,Axis].Dec;
                        if (Card == 0)
                        {
                            ZmcauxFunction.Instant.AxisSignalMove(Axis, SingleDistance, velStruct);
                        }
                    }
                }
                if (axisMove == AxisMoveType.RelativeMove)
                {
                    if (ck)
                    {
                        LogHelper.WriteLog(LanguageFunction.TransferLog("单步相对运动") + SingleDistance, LogType.Info,1);
                        ZmcauxFunction.IVelStruct velStruct = new ZmcauxFunction.VelStruct();
                        velStruct.Vel = AxisConfig.Instance[Card,Axis].Vel;
                        velStruct.Acc = AxisConfig.Instance[Card,Axis].Acc;
                        velStruct.Dec = AxisConfig.Instance[Card,Axis].Dec;
                        if (Card == 0)
                        {
                            ZmcauxFunction.Instant.AxisSignalMove(Axis, dir, SingleDistance, velStruct);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnAxis_MouseUp(object sender, MouseEventArgs e)
        {
            LogHelper.WriteLog("主界面：执行轴单步松开操作", LogType.Event);
            try
            {
                if (UIModel.UI.Runing)
                {
                    return;
                }
                Button btn = sender as Button;
                int axis = Convert.ToInt32(btn.Tag);
                bool dir = btn.Text.Contains("+");
                if (axisMove == AxisMoveType.ContinueMove)
                {
                    if (Card == 0)
                    {
                        ZmcauxFunction.Instant.AxisStop(Axis,2);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }


        #endregion

        private void timerUI_Tick(object sender, EventArgs e)
        {
            tBoxValue.Text = UIModel.UI.AxisPos[Axis].ToString("0.000");
        }
    }

    public enum AxisMoveType
    {
        /// <summary>
        /// 持续移动
        /// </summary>
        ContinueMove,
        /// <summary>
        /// 绝对移动
        /// </summary>
        AbsolutelyMove, 
        /// <summary>
        /// 相对移动
        /// </summary>
        RelativeMove
    }
}
