using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;

namespace quanlibangiay2
{
    public partial class quanlinhanvien : Form
    {
        modifynhanvien modifyNV = new modifynhanvien();

        public quanlinhanvien()
        {
            InitializeComponent();
            LoadNhanVien();
        }
        private void LoadNhanVien()
        {
            dataGridViewNhanVien.DataSource = modifyNV.GetAllNhanVien();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            nhanvien nv = new nhanvien(0, textBoxName.Text, textBoxPosition.Text, textBoxEmail.Text, textBoxPhone.Text, textBoxRole.Text);
            if (modifyNV.InsertNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadNhanVien();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nhanvien nv = new nhanvien(int.Parse(textBoxID.Text), textBoxName.Text, textBoxPosition.Text, textBoxEmail.Text, textBoxPhone.Text, textBoxRole.Text);
            if (modifyNV.UpdateNhanVien(nv))
            {
                MessageBox.Show("Cập nhật nhân viên thành công!");
                LoadNhanVien();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxID.Text);
            if (modifyNV.DeleteNhanVien(id))
            {
                MessageBox.Show("Xóa nhân viên thành công!");
                LoadNhanVien();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxSearchID.Text);
            var nv = modifyNV.SearchNhanVienById(id);
            if (nv != null)
            {
                textBoxID.Text = nv.Idnv.ToString();
                textBoxName.Text = nv.Tennv;
                textBoxPosition.Text = nv.Chucvunv;
                textBoxEmail.Text = nv.Emailnv;
                textBoxPhone.Text = nv.Sdtnv;
                textBoxRole.Text = nv.Rolenv;
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        { 
            try 
            { 
                DataTable dt = modifyNV.GetAllNhanVien();
                using (var workbook = new XLWorkbook()) 
                {
                    var worksheet = workbook.Worksheets.Add(dt, "Danh sách nhân viên"); 
                    var saveFileDialog = new SaveFileDialog 
                    { Filter = "Excel Workbook|*.xlsx", Title = "Save an Excel File" };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK) 
                    { 
                        workbook.SaveAs(saveFileDialog.FileName); 
                        MessageBox.Show("Xuất danh sách nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } 
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Lỗi khi xuất danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
