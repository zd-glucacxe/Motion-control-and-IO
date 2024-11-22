using BaseLibrary.Common;
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
    public partial class FrmAxisStatusControl : UserControl
    {
        private int Axis;
        private int Card;
        public FrmAxisStatusControl()
        {
            InitializeComponent();
        }
        public FrmAxisStatusControl(int Axis)
        {
            InitializeComponent();
            this.Axis = Axis;
        }
        public FrmAxisStatusControl(int Axis, int Card)
        {
            InitializeComponent();
            this.Axis = Axis;
            this.Card = Card;
        }
        private void FrmAxisStatusControl_Load(object sender, EventArgs e)
        {
            labelName.Text = AxisConfig.Instance[Card,Axis].Name;
            timerUI.Enabled = true;
        }

        private void timerUI_Tick(object sender, EventArgs e)
        {
            ColorPositive.BackColor= UIModel.UI.LimitPositiveFlag[Axis] ?Color.Red:Color.White;
            ColorNegative.BackColor= UIModel.UI.LimitNegativeFlag[Axis] ?Color.Red:Color.White;
            ColorHome.BackColor= UIModel.UI.HomeFlag[Axis] ?Color.Green:Color.White;
            ColorAlarm.BackColor= UIModel.UI.AxisAlarmFlag[Axis] ?Color.Red:Color.White;
        }
    }
}
