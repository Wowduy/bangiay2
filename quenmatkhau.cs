using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlibangiay2
{
    public partial class quenmatkhau : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        public quenmatkhau()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tài khoản.");
                return;
            }

            string passwordHash = dbHelper.GetPassword(username);
            if (!string.IsNullOrEmpty(passwordHash))
            {
                labelResult.Text = "Mật khẩu của bạn là: " + passwordHash;
            }
            else
            {
                labelResult.Text = "Tài khoản không tồn tại.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();

            // Hiển thị form FormLogin
            loginForm.Show();

            this.Hide();
        }
    }
}
