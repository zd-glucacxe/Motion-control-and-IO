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
using BaseLibrary.Common;
using UWPCLaserMotion.Function;
namespace UWPCLaserMotion.WindowsForm
{
    public partial class FrmTeachingProgram : Form
    {
        #region 加载
        double[] TeachPoint1 = new double[8];
        double[] TeachPoint2 = new double[8];
        double[] TeachPoint3 = new double[8];
        private RichTextBox rBoxCode;
        public FrmTeachingProgram()
        {
            InitializeComponent();
        }
        public FrmTeachingProgram(RichTextBox box)
        {
            InitializeComponent();
            rBoxCode = box;
        }
        private void FrmTeachingProgram_Load(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程加载", LogType.Event);
            rBoxCode.ReadOnly = false;
            cBoxGlueMode.SelectedIndex = 0;
            tBoxDelay.Validating += CheckFunction.TBox_Validating_Int;
            tBoxRadius.Validating += CheckFunction.TBox_Validating_Double;
            tBoxLastAngle.Validating += CheckFunction.TBox_Validating_Double;
            tBoxVel.Validating += CheckFunction.TBox_Validating_Double;
            tBoxBase.Validating += CheckFunction.TBox_Validating_Double;
            tBoxLimit.Validating += CheckFunction.TBox_Validating_Double;
            tBoxLastDistance.Validating += CheckFunction.TBox_Validating_Double;



        }
        private void FrmTeachingProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogHelper.WriteLog("示教编程退出", LogType.Event);
            rBoxCode.ReadOnly = true;
        }
        #endregion




        #region 按钮事件
        private void btnSureLaserMode_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:确认激光模式", LogType.Event);
            try
            {
                int index = cBoxGlueMode.SelectedIndex;
                TopCode();
                rBoxCode.AppendText($"P02 L:{index:D2};\n");//确认激光模式
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void btnWait_Click(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteLog("示教编程:延时", LogType.Event);
                if (string.IsNullOrEmpty(tBoxDelay.Text))
                {
                    LogHelper.WriteLog("示教编程:数值不能为空", LogType.Error);
                    MessageBox.Show(LanguageFunction.Transfer("示教编程:数值不能为空"));
                    return;
                }
                int time = int.Parse(tBoxDelay.Text);
                if (time <= 0)
                {
                    LogHelper.WriteLog("示教编程:延时不能小于等于0", LogType.Error);
                    MessageBox.Show(LanguageFunction.Transfer("示教编程:延时不能小于等于0"));
                    return;
                }
                TopCode();
                rBoxCode.AppendText($"G04 T:{time};\n");//延时
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void btnLineEnd_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:直线终点", LogType.Event);
            try
            {
                TopCode();
                Array.Copy(UIModel.UI.AxisPos, TeachPoint2, 8);
              
                int time = int.Parse(tBoxDelay.Text);
                double vel = double.Parse(tBoxVel.Text);
                if (rdoBtnRunNop.Checked)
                {
                    CloseGlue();
                    string end = MoveAxis("G00");
                    rBoxCode.AppendText($"{end}F:{vel:F3};\n");
                }
                if (rdoBtnRunGlue.Checked)
                {
                    OpenGlue();
                    string end = MoveAxis("G01");
                    rBoxCode.AppendText($"{end}F:{vel:F3};\n");
                }
                if (rdoBtnRunSingleGlue.Checked)
                {
                    CloseGlue();
                    string end = MoveAxis("G00");
                    rBoxCode.AppendText($"{end}F:{vel:F3};\n");
                    OpenGlue();
                    rBoxCode.AppendText($"G04 T:{time};\n");//延时
                    CloseGlue();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            finally
            {
                MoveFalse();
            }
        }

        private void btnArcPass_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:圆弧中间点", LogType.Event);
            try
            {
                Array.Copy(UIModel.UI.AxisPos, TeachPoint2, 8);
                btnArcPass.Enabled = false;
                btnArcEnd.Enabled = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnArcEnd_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:圆弧终点", LogType.Event);
            try
            {
                TopCode();
                Array.Copy(UIModel.UI.AxisPos, TeachPoint3, 8);
                double vel = double.Parse(tBoxVel.Text);
                double[] CenterPoint = ThreePointGetCenterPoint(TeachPoint1, TeachPoint2, TeachPoint3);
                if (CenterPoint[0] == 9999999999 && CenterPoint[1] == 9999999999)
                {
                    LogHelper.WriteLog("三点在同一直线上导致圆弧终点操作无效", LogType.Error);
                    MessageBox.Show(LanguageFunction.Transfer("三点不能在同一直线上"));
                    return;
                }
                double res = ThreePointGetDirection(TeachPoint1, TeachPoint2, TeachPoint3);
                short dir = res > 0 ? (short)1 : (short)0;
                int time = int.Parse(tBoxDelay.Text);
                double angle = Convert.ToDouble(tBoxLastAngle.Text);
                OpenGlue();
                if (cBoxRelativeMove.Checked)
                {
                    if (rdoBtn3PointCircleMove.Checked)
                    {
                        rBoxCode.AppendText($"G02 X:0 Y:0 I:{CenterPoint[0]- TeachPoint1[0]:F3} J:{CenterPoint[1]:F3} D:{dir} F:{vel:F3};\n");// FX:{TeachPoint1[0]:F3} FY:{TeachPoint1[1]:F3}
                        if (angle > 0)
                        {
                            if (dir == 1)
                            {
                                GetRotatePoint(TeachPoint1, CenterPoint, angle);
                                rBoxCode.AppendText($"G03 X:{TeachPoint3[0] - TeachPoint1[0]:F3} Y:{TeachPoint3[1] - TeachPoint1[1]:F3} I:{CenterPoint[0] - TeachPoint1[0]:F3} J:{CenterPoint[1] - TeachPoint1[1]:F3} D:{dir} F:{vel:F3};\n");// FX:{TeachPoint1[0]:F3} FY:{TeachPoint1[1]:F3}
                            }
                            else
                            {
                                GetRotatePoint(TeachPoint1, CenterPoint, -angle);
                                rBoxCode.AppendText($"G03 X:{TeachPoint3[0] - TeachPoint1[0]:F3} Y:{TeachPoint3[1] - TeachPoint1[1]:F3} I:{CenterPoint[0] - TeachPoint1[0]:F3} J:{CenterPoint[1] - TeachPoint1[1]:F3} D:{dir} F:{vel:F3};\n");// FX:{TeachPoint1[0]:F3} FY:{TeachPoint1[1]:F3}
                            }
                        }
                    }
                    if (rdoBtnArcMove.Checked)
                    {
                        rBoxCode.AppendText($"G03 X:{TeachPoint3[0] - TeachPoint1[0]:F3} Y:{TeachPoint3[1] - TeachPoint1[1]:F3} I:{CenterPoint[0] - TeachPoint1[0]:F3} J:{CenterPoint[1] - TeachPoint1[1]:F3} D:{dir} F:{vel:F3};\n");//FX:{TeachPoint1[0]:F3} FY:{TeachPoint1[1]:F3}
                    }
                }
                else
                {
                    if (rdoBtn3PointCircleMove.Checked)
                    {
                        rBoxCode.AppendText($"G02 X:{TeachPoint1[0]:F3} Y:{TeachPoint1[1]:F3} I:{CenterPoint[0]:F3} J:{CenterPoint[1]:F3} D:{dir} F:{vel:F3};\n");// FX:{TeachPoint1[0]:F3} FY:{TeachPoint1[1]:F3}
                        if (angle > 0)
                        {
                            if (dir == 1)
                            {
                                GetRotatePoint(TeachPoint1, CenterPoint, angle);
                                rBoxCode.AppendText($"G03 X:{TeachPoint3[0]:F3} Y:{TeachPoint3[1]:F3} I:{CenterPoint[0]:F3} J:{CenterPoint[1]:F3} D:{dir} F:{vel:F3};\n");// FX:{TeachPoint1[0]:F3} FY:{TeachPoint1[1]:F3}
                            }
                            else
                            {
                                GetRotatePoint(TeachPoint1, CenterPoint, -angle);
                                rBoxCode.AppendText($"G03 X:{TeachPoint3[0]:F3} Y:{TeachPoint3[1]:F3} I:{CenterPoint[0]:F3} J:{CenterPoint[1]:F3} D:{dir} F:{vel:F3};\n");// FX:{TeachPoint1[0]:F3} FY:{TeachPoint1[1]:F3}
                            }
                        }
                    }
                    if (rdoBtnArcMove.Checked)
                    {
                        rBoxCode.AppendText($"G03 X:{TeachPoint3[0]:F3} Y:{TeachPoint3[1]:F3} I:{CenterPoint[0]:F3} J:{CenterPoint[1]:F3} D:{dir} F:{vel:F3};\n");//FX:{TeachPoint1[0]:F3} FY:{TeachPoint1[1]:F3}
                    }
                }
                
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
            finally
            {
                MoveFalse();
            }
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:圆心定圆", LogType.Event);
            try
            {
                TopCode();
                Array.Copy(UIModel.UI.AxisPos, TeachPoint2, 8);
                double radius = double.Parse(tBoxRadius.Text);
                int time = int.Parse(tBoxDelay.Text);
                double vel = double.Parse(tBoxVel.Text);
                double angle = Convert.ToDouble(tBoxLastAngle.Text);
                if (radius <= 0)
                {
                    LogHelper.WriteLog("示教编程:圆心定圆半径不能小于0", LogType.Error);
                    MessageBox.Show(LanguageFunction.Transfer("示教编程:圆心定圆半径不能小于0"));
                    return;
                }
                CloseGlue();
                if (cBoxRelativeMove.Checked)
                {
                    rBoxCode.AppendText($"G00 X:{ TeachPoint2[0] - TeachPoint1[0] - radius:F3} Y:{TeachPoint2[1] - TeachPoint1[1]:F3} F:{vel:F3};\n");
                    OpenGlue();
                    rBoxCode.AppendText($"G02 X:0 Y:0 I:{radius:F3} J:0 D:0 F:{vel:F3};\n");
                    if (angle > 0)
                    {
                        GetRotatePoint(new double[] { TeachPoint2[0] - radius, TeachPoint2[1] }, TeachPoint2, -angle);
                        rBoxCode.AppendText($"G03 X:{TeachPoint3[0] - TeachPoint2[0] + radius:F3} Y:{TeachPoint3[1] - TeachPoint2[1]:F3} I:{radius:F3} J:0 D:0 F:{vel:F3};\n");
                    }
                }
                else
                {
                    rBoxCode.AppendText($"G00 X:{TeachPoint2[0] - radius:F3} Y:{TeachPoint2[1]:F3} Z:{TeachPoint2[2]:F3} F:{vel:F3};\n");
                    OpenGlue();
                    rBoxCode.AppendText($"G02 X:{TeachPoint2[0] - radius:F3} Y:{TeachPoint2[1]:F3} I:{TeachPoint2[0]:F3} J:{TeachPoint2[1]:F3} D:0 F:{vel:F3};\n");
                    if (angle > 0)
                    {
                        GetRotatePoint(new double[] { TeachPoint2[0] - radius, TeachPoint2[1] }, TeachPoint2, -angle);
                        rBoxCode.AppendText($"G03 X:{TeachPoint3[0]:F3} Y:{TeachPoint3[1]:F3} I:{TeachPoint2[0]:F3} J:{TeachPoint2[1]:F3} D:0 F:{vel:F3};\n");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:确认", LogType.Event);
            try
            {
                TopCode();
                CloseGlue();
                if (!rBoxCode.Text.EndsWith("M02;\n"))
                {
                    rBoxCode.AppendText("M02;\n");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:取消", LogType.Event);
            rBoxCode.Text = string.Empty;
        }

        private void rdoBtnMove_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LogHelper.WriteLog("示教编程:运动方式", LogType.Event);
                if (rdoBtnLineMove.Checked)
                {
                    btnLineEnd.Enabled = true;
                    btnArcPass.Enabled = false;
                    btnArcEnd.Enabled = false;
                    btnCenter.Enabled = false;
                    Array.Copy(UIModel.UI.AxisPos, TeachPoint1, 8);
                }
                if (rdoBtn3PointCircleMove.Checked)
                {
                    btnLineEnd.Enabled = false;
                    btnArcPass.Enabled = true;
                    btnArcEnd.Enabled = false;
                    btnCenter.Enabled = false;
                    Array.Copy(UIModel.UI.AxisPos, TeachPoint1, 8);
                }
                if (rdoBtnArcMove.Checked)
                {
                    btnLineEnd.Enabled = false;
                    btnArcPass.Enabled = true;
                    btnArcEnd.Enabled = false;
                    btnCenter.Enabled = false;
                    Array.Copy(UIModel.UI.AxisPos, TeachPoint1, 8);
                }
                if (rdoBtnCircle.Checked)
                {
                    btnLineEnd.Enabled = false;
                    btnArcPass.Enabled = false;
                    btnArcEnd.Enabled = false;
                    btnCenter.Enabled = true;
                    Array.Copy(UIModel.UI.AxisPos, TeachPoint1, 8);
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);

            }
        }

        private void btnCylinderON_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:气缸开", LogType.Event);
            try
            {
                TopCode();
                CloseGlue();
                if (cBoxCylinder.SelectedIndex>=0&& cBoxCylinder.SelectedIndex<=10)
                {
                    rBoxCode.AppendText(string.Format("Q{0:D2} ON;\n", cBoxCylinder.SelectedIndex+1));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnCylinderOFF_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:气缸关", LogType.Event);
            try
            {
                TopCode();
                CloseGlue();
                if (cBoxCylinder.SelectedIndex >= 0 && cBoxCylinder.SelectedIndex <= 10)
                {
                    rBoxCode.AppendText(string.Format("Q{0:D2} OFF;\n", cBoxCylinder.SelectedIndex+1));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnRang_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:测距", LogType.Event);
            try
            {
                TopCode();
                CloseGlue();
                double RangBase = double.Parse(tBoxBase.Text);
                double RangLimit = double.Parse(tBoxLimit.Text);
                rBoxCode.AppendText($"M50 RB:{RangBase:F3} RL:{RangLimit:F3};\n");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void btnCompensate_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:测距补偿", LogType.Event);
            try
            {
                TopCode();
                CloseGlue();
                double vel = double.Parse(tBoxVel.Text);
                rBoxCode.AppendText($"G50 F:{vel:F3};\n");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void cBoxWork1_CheckedChanged(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:选择工位1", LogType.Event);
            try
            {
                TopCode();
                CloseGlue();
                if (cBoxWork1.Checked)
                {
                    cBoxA.Enabled = true;
                    cBoxB.Enabled = false;
                    //rBoxCode.AppendText($"M10;\n");
                    
                }
                else
                {
                    cBoxA.Enabled = false;
                    cBoxA.Checked = false;
                    //rBoxCode.AppendText($"M11;\n");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        
        private void cBoxCkvsOffset_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cBoxCkvsOffset.Checked)
                {
                    LogHelper.WriteLog("示教编程:启用视觉", LogType.Event);
                    TopCode();
                    CloseGlue();
                    rBoxCode.AppendText($"M32;\n");
                }
                else
                {
                    LogHelper.WriteLog("示教编程:禁用视觉", LogType.Event);
                    TopCode();
                    CloseGlue();
                    rBoxCode.AppendText($"M33;\n");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnExePhoto_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:拍照", LogType.Event);
            try
            {
                TopCode();
                CloseGlue();
                rBoxCode.AppendText($"M30;\n");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnPhotoOffset_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:更新视觉偏移量", LogType.Event);
            try
            {
                TopCode();
                CloseGlue();
                rBoxCode.AppendText($"M31;\n");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private void btnAdvanceGlueOFF_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("示教编程:提前关胶", LogType.Event);
            try
            {
                TopCode();
                double dis = Convert.ToDouble(tBoxLastDistance.Text);
                if (cBoxWork1.Checked)
                {
                    if (radioX.Checked)
                    {
                        rBoxCode.AppendText($"M63 AXIS:0 END:{dis:F3};\n");
                    }
                    else if (radioY.Checked)
                    {
                        rBoxCode.AppendText($"M63 AXIS:1 END:{dis:F3};\n");
                    }
                }
               
                rBoxCode.AppendText($"M64;\n");
                rBoxCode.AppendText($"P08;\n");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        #endregion

        #region 内部方法
        private void TopCode()
        {
            if (string.IsNullOrEmpty(rBoxCode.Text))
            {
                if (cBoxRelativeMove.Checked)
                {
                    rBoxCode.Text = "G91;\n";
                }
                else
                {
                    rBoxCode.Text = "G90;\n";
                } 
            }
            if (!rBoxCode.Text.EndsWith("\n"))
            {
                rBoxCode.AppendText("\n");
            }
        }
        private void CloseGlue()
        {
            try
            {
                int indexM07 = rBoxCode.Text.LastIndexOf("\nP17");
                int indexM08 = rBoxCode.Text.LastIndexOf("\nP18");
                if (indexM07 > indexM08)
                {
                    rBoxCode.AppendText("P18;\n");//关胶
                    rBoxCode.AppendText("M64;\n");//缓冲区结束
                    //rBoxCode.AppendText("P08;//关胶\n");678o
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        private void OpenGlue()
        {
            try
            {
                int time = int.Parse(tBoxDelay.Text);
                int indexM07 = rBoxCode.Text.LastIndexOf("\nP17");
                int indexM08 = rBoxCode.Text.LastIndexOf("\nP18");
                if (indexM07 <= indexM08)
                {
                    rBoxCode.AppendText("P17;\n");//开胶
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }

        private string MoveAxis(string g0)
        {
            StringBuilder sb = new StringBuilder();
            if (cBoxRelativeMove.Checked)
            {
                sb.Append(g0 + " ");
                if (cBoxWork1.Checked)
                {
                    if (cBoxX.Checked)
                    {
                        sb.AppendFormat("X:{0:F3} ", UIModel.UI.AxisPos[0]- TeachPoint1[0]);
                    }
                    if (cBoxY.Checked)
                    {
                        sb.AppendFormat("Y:{0:F3} ", UIModel.UI.AxisPos[1] - TeachPoint1[1]);
                    }
                    if (cBoxZ.Checked)
                    {
                        sb.AppendFormat("Z:{0:F3} ", UIModel.UI.AxisPos[2] - TeachPoint1[2]);
                    }
                }
                
            }
            else
            {
                sb.Append(g0+" ");
                if (cBoxWork1.Checked)
                {
                    if (cBoxX.Checked)
                    {
                        sb.AppendFormat("X:{0:F3} ", UIModel.UI.AxisPos[0]);
                    }
                    if (cBoxY.Checked)
                    {
                        sb.AppendFormat("Y:{0:F3} ", UIModel.UI.AxisPos[1]);
                    }
                    if (cBoxZ.Checked)
                    {
                        sb.AppendFormat("Z:{0:F3} ", UIModel.UI.AxisPos[2]);
                    }
                }
                
            }
            return sb.ToString();
        }

        private void MoveFalse()
        {
            //rdoBtnRunNop.Checked = false;
            //rdoBtnRunWeld.Checked = false;
            //rdoBtnRunSingleWeld.Checked = false;
            rdoBtnLineMove.Checked = false;
            rdoBtn3PointCircleMove.Checked = false;
            rdoBtnArcMove.Checked = false;
            rdoBtnCircle.Checked = false;
            btnLineEnd.Enabled = false;
            btnArcPass.Enabled = false;
            btnArcEnd.Enabled = false;
            btnCenter.Enabled = false;
        }


        /// <summary>
        /// 三点定圆心
        /// </summary>
        /// <param name="teachPoint1"></param>
        /// <param name="teachPoint2"></param>
        /// <param name="teachPoint3"></param>
        public static double[] ThreePointGetCenterPoint(double[] teachPoint1, double[] teachPoint2, double[] teachPoint3)
        {
            double x1, x2, x3, y1, y2, y3;
            double a, b, c, g, e, f;
            x1 = teachPoint1[0];
            y1 = teachPoint1[1];
            x2 = teachPoint2[0];
            y2 = teachPoint2[1];
            x3 = teachPoint3[0];
            y3 = teachPoint3[1];
            if (!AnalyzeThreePointOnSameLine(x1, y1, x2, y2, x3, y3))
            {
                return new double[] { 9999999999, 9999999999 };
            }
            double[] cenPoint = AnalyzeThreePointHasSamePoint(x1, y1, x2, y2, x3, y3);
            if (cenPoint[0] == 9999999999 && cenPoint[1] == 9999999999) //做三点定圆+旋转方向
            {
                e = 2 * (x2 - x1);
                f = 2 * (y2 - y1);
                g = x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1;
                a = 2 * (x3 - x2);
                b = 2 * (y3 - y2);
                c = x3 * x3 - x2 * x2 + y3 * y3 - y2 * y2;
                double[] cPoint = new double[]
                {
                    (g * b - c * f) / (e * b - a * f),
                    (a * g - c * e) / (a * f - b * e)
                };
                return cPoint;
            }
            else
            {
                return cenPoint;
            }
        }


        #region 方法：分析三点是否在一条直线上（不包括两点重合的情况）

        private static bool AnalyzeThreePointOnSameLine(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double k1, k2;
            try
            {
                k1 = (y2 - y1) / (x2 - x1);
                if (y2 - y1 == 0 && x2 - x1 == 0)
                {
                    k1 = 9999;
                }
            }
            catch (Exception)
            {
                k1 = 9999;
            }
            try
            {
                k2 = (y3 - y2) / (x3 - x2);
                if (y3 - y2 == 0 && x3 - x2 == 0)
                {
                    k2 = 9999;
                }
            }
            catch (Exception)
            {
                k2 = 9999;
            }
            if (k1 == k2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region 方法：分析三点是否有重合点(得到圆心坐标）

        private static double[] AnalyzeThreePointHasSamePoint(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double[] centerPoint = new double[] { 9999999999, 9999999999 };
            if (x1 == x2 && y1 == y2)
            {
                centerPoint[0] = (x1 + x3) / 2;
                centerPoint[1] = (y1 + y3) / 2;
            }
            else if (x1 == x3 && y1 == y3)
            {
                centerPoint[0] = (x1 + x2) / 2;
                centerPoint[1] = (y1 + y2) / 2;
            }
            else if (x2 == x3 && y2 == y3)
            {
                centerPoint[0] = (x1 + x2) / 2;
                centerPoint[1] = (y1 + y2) / 2;
            }
            return centerPoint;
        }

        #endregion 
       
        /// <summary>
        /// 三点确认方向
        /// </summary>
        /// <param name="teachPoint1"></param>
        /// <param name="teachPoint2"></param>
        /// <param name="teachPoint3"></param>
        /// <returns></returns>
        public static double ThreePointGetDirection(double[] teachPoint1, double[] teachPoint2, double[] teachPoint3)
        {
            double x1, x2, x3, y1, y2, y3;
            x1 = teachPoint1[0];
            y1 = teachPoint1[1];
            x2 = teachPoint2[0];
            y2 = teachPoint2[1];
            x3 = teachPoint3[0];
            y3 = teachPoint3[1];
            return (x2 - x1) * (y3 - y2) - (y2 - y1) * (x3 - x2);
        }

        /// <summary>
        /// 收尾角度
        /// </summary>
        /// <param name="rotationPoint"></param>
        /// <param name="basePoint"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private double[] GetRotatePoint(double[] rotationPoint, double[] basePoint,double angle)
        {
            double radian = (Math.PI / 180) * angle;
            TeachPoint3[1] = (rotationPoint[0] - basePoint[0]) * Math.Sin(radian) + (rotationPoint[1] - basePoint[1]) * Math.Cos(radian) + basePoint[1];
            TeachPoint3[0] = (rotationPoint[0] - basePoint[0]) * Math.Cos(radian) - (rotationPoint[1] - basePoint[1]) * Math.Sin(radian) + basePoint[0];
            return TeachPoint3;
        }




        #endregion

        private void cBoxRelativeMove_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxRelativeMove.Checked)
            {
                rBoxCode.AppendText("G91;\n");
            }
            else
            {
                rBoxCode.AppendText("G90;\n");
            }
        }
    }
}
