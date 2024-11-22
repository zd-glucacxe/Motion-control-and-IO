
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
using System.Globalization;
using BaseLibrary.SupportHelp;
using UserCustomLibrary.Function;
using BaseLibrary.Function;

namespace UWPCLaserMotion.WindowsForm
{
    public delegate void LogProgress_(int bar, string msg);
    public partial class FrmLoad : Form
    {
        public static LogProgress_ logBar_;
        public FrmLoad()
        {
            InitializeComponent();
        }

        private async void FrmLoad_Load(object sender, EventArgs e)
        {
            logBar_ = LogView;
            try
            {
                pBarView.Value = 0;
                LogHelper.WriteLog("软件打开", LogType.Event);
                BaseLibrary.Function.InitFunction.Exception();
                logBar bar_ = new logBar(LogView);
                await Task.Factory.StartNew(delegate
                {
                    UserCustomLibrary.Function.InitFunction.InitLoad(bar_);
                });
                pBarView.Value = 100;
                if (!UserCustomLibrary.Function.InitFunction.Ready)
                {
                    DialogResult result = MessageBox.Show(LanguageFunction.Transfer("参数文件加载异常,是否继续"), LanguageFunction.Transfer("提示"), MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        Application.Exit();
                        return;
                    }
                }
                Hide();
                BaseLibrary.Function.InitFunction.SelectLanguage();
                FrmMain frm = new FrmMain();
                frm.Show();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                Application.ExitThread();
            }
        }

        private void LogView(int bar, string msg)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(logBar_,bar, msg);
                }
                else
                {
                    lBoxLog.Items.Add(LanguageFunction.Transfer(msg));
                    pBarView.Value = bar;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
    }
}
