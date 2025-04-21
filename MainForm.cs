using System;
using System.Drawing;
using System.Windows.Forms;
using C_CuoiKi;
using baitap_lon;
using quanlibangiay2;

namespace C_CuoiKi
{
    public partial class MainForm : Form
    {
        private Panel sideMenu = new Panel();

        private Panel contentPanel = new Panel();
        private PictureBox logoPictureBox = new PictureBox();


        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
            this.Resize += (s, e) => AdjustPanelSizes(); // Điều chỉnh khi thay đổi kích thước
        }

        private void InitializeUI()
        {
            this.Text = "Form Chính";
            this.Size = new Size(1500, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel Menu bên trái (1/7 chiều rộng)
            sideMenu = new Panel
            {
                BackColor = Color.LightSteelBlue
            };
            this.Controls.Add(sideMenu);

            // Panel Nội dung (6/7 chiều rộng)
            contentPanel = new Panel
            {
                BackColor = Color.White
            };
            this.Controls.Add(contentPanel);

            

            // Các nút menu
            int buttonY = 120;
            AddMenuButton("Đặt Hàng", buttonY, () => OpenChildForm(new FormQLDH()));
            AddMenuButton("Quản lý khách hàng", buttonY += 50, () => OpenChildForm(new QUANLIKHACHHANG()));
            AddMenuButton("Quản lý Vouchers", buttonY += 50, () => OpenChildForm(new QUANLIVOUCHER()));
            AddMenuButton("Quản lý sản phẩm", buttonY += 50, () => OpenChildForm(new FormQLSP()));
            AddMenuButton("Quản lý kho", buttonY += 50, () => OpenChildForm(new FormQLKho()));
            AddMenuButton("Quản lý nhân viên", buttonY += 50, () => OpenChildForm(new quanlinhanvien()));
            AddMenuButton("Báo cáo thống kê", buttonY += 50, () => OpenChildForm(new formreport()));

            // Logout Button
            Button logoutButton = new Button
            {
                Text = "Logout",
                Width = 180,
                Height = 40,
                ForeColor = Color.White,
                BackColor = Color.DarkRed,
                FlatStyle = FlatStyle.Flat
            };
            logoutButton.Click += (s, e) => this.Close();
            sideMenu.Controls.Add(logoutButton);

            // Cập nhật vị trí ban đầu
            AdjustPanelSizes();

            // Mặc định mở FormQLDH
            OpenChildForm(new FormQLDH());
        }

        private void AddMenuButton(string text, int yPosition, Action onClick)
        {
            Button btn = new Button
            {
                Text = text,
                Width = 180,
                Height = 40,
                ForeColor = Color.Black,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, yPosition)
            };
            btn.Click += (s, e) => onClick();
            sideMenu.Controls.Add(btn);
        }

        private void OpenChildForm(Form childForm)
        {
            contentPanel.Controls.Clear();
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(childForm);
            childForm.Show();
        }

        private void AdjustPanelSizes()
        {
            int menuWidth = this.Width / 7;
            int contentWidth = this.Width - menuWidth;
            int height = this.Height;

            sideMenu.Size = new Size(menuWidth, height);
            contentPanel.Size = new Size(contentWidth, height);
            contentPanel.Location = new Point(menuWidth, 0);

            // Cập nhật vị trí nút Logout (dưới cùng menu)
            if (sideMenu.Controls.Count > 0)
            {
                Control logoutButton = sideMenu.Controls[sideMenu.Controls.Count - 1];
                logoutButton.Location = new Point(20, height - 80);
            }
        }
    }
}