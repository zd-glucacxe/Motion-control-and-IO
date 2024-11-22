using BaseLibrary.Function;
using UserCustomLibrary.Function;
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
namespace UWPCLaserMotion.WindowsForm
{
    public partial class FrmAuthority : Form
    {
        public FrmAuthority()
        {
            InitializeComponent();
        }
        private void FrmAuthority_Load(object sender, EventArgs e)
        {
            LogHelper.WriteLog("进入权限管理", LogType.Event);
            cBoxAuthotity.Text = UIModel.UI.UserAuthority.ToString();
            
        }
        private void FrmAuthority_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogHelper.WriteLog("退出权限管理", LogType.Event);
            
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("登录界面：点击登录", LogType.Event);
            string uesr = cBoxAuthotity.Text;
            string password = tBoxPassWord.Text;
            if (string.IsNullOrEmpty(uesr))
            {
                LogHelper.WriteLog("权限不能为空", LogType.Warning);
                MessageBox.Show(LanguageFunction.Transfer("权限不能为空"));
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                LogHelper.WriteLog("密码不能为空", LogType.Warning);
                MessageBox.Show(LanguageFunction.Transfer("密码不能为空"));
                return;
            }
            bool ck=  EventFunction.AuthorityCheck(uesr, password);
            if (ck)
            {
                Close();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogHelper.WriteLog("登录界面：点击注销", LogType.Event);
            UIModel.UI.UserAuthority = Authority.操作员;
            UIModel.UI.MillisecondTick = -1;
        }

        private void FrmAuthority_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
