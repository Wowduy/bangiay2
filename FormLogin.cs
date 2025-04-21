using System;
using System.Windows.Forms;
using C_CuoiKi;

namespace quanlibangiay2
{
    public partial class FormLogin : Form
    {
        private readonly IAppWindowManager _windowManager;
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public FormLogin(IAppWindowManager windowManager)
        {
            _windowManager = windowManager;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            string username = txtTAIKHOAN.Text.Trim();
            string password = txtMATKHAU.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                ShowError("Tài khoản không được để trống.", txtTAIKHOAN);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowError("Mật khẩu không được để trống.", txtMATKHAU);
                return;
            }

            if (_dbHelper.Login(username, password))
            {
                this.Hide();
                _windowManager.ShowMainWindow();
            }
            else
            {
                ShowError("Tài khoản hoặc mật khẩu không chính xác.", txtMATKHAU, true);
            }
        }

        private void ShowError(string message, Control focusControl, bool selectAll = false)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            focusControl.Focus();
            if (selectAll) focusControl.SelectAll();
        }

        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            _windowManager.CloseApplication();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            _windowManager.ShowForgotPasswordWindow(this);
        }
    }
}