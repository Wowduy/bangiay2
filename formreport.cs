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

namespace quanlibangiay2
{
    public partial class formreport : Form
    {
        private modifynhanvien modify = new modifynhanvien();
        public formreport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedReport = comboBoxReports.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedReport))
            {
                MessageBox.Show("Vui lòng chọn một báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = ""; 
            // Chọn View tương ứng dựa trên loại báo cáo
            switch (selectedReport)
            { 
                case "Doanh số theo sản phẩm": query = "SELECT * FROM vw_SalesByProduct";
                    break;
                case "Tồn kho hiện tại": query = "SELECT * FROM vw_CurrentInventory";
                    break;
                case "Khách hàng tiềm năng": query = "SELECT * FROM vw_PotentialCustomers"; 
                    break;
                case "Trạng thái thanh toán": query = "SELECT * FROM vw_PaymentStatus";
                    break;
                default: MessageBox.Show("Loại báo cáo không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    return;
            }
            // Lấy dữ liệu từ view tương ứng
            DataTable reportData = modify.GetReportData(query);
            // Hiển thị dữ liệu lên DataGridView
            dataGridView1.DataSource = reportData;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        { // Lấy dữ liệu từ DataGridView
           DataTable dataTable = GetDataFromDataGridView();
            // Hiển thị hộp thoại lưu file
             SaveFileDialog saveFileDialog = new SaveFileDialog(); 
            saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = "Report.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) 
            { 
                string filePath = saveFileDialog.FileName; ExportToExcel(filePath, dataTable);
            } 
        }
        private DataTable GetDataFromDataGridView()
        {
            DataTable dataTable = new DataTable(); 
            // Tạo cột từ DataGridView
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            { 
                dataTable.Columns.Add(column.HeaderText, column.ValueType ?? typeof(string));
            } // Thêm dữ liệu từ DataGridView
              foreach (DataGridViewRow row in dataGridView1.Rows) 
            { 
                if (!row.IsNewRow) 
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < dataGridView1.Columns.Count; i++) 
                    {
                        dataRow[i] = row.Cells[i].Value ?? DBNull.Value;
                    } 
                    dataTable.Rows.Add(dataRow);
                } 
            }
            return dataTable;
        }
        private void ExportToExcel(string path, DataTable dataTable)
        { 
            try 
            { 
                using (var workbook = new XLWorkbook()) 
                { 
                    var worksheet = workbook.Worksheets.Add(dataTable, "Report Data");
                    workbook.SaveAs(path);
                }
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            catch (Exception ex)
            { 
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        private void formreport_Load(object sender, EventArgs e)
        {
            comboBoxReports.Items.Add("Doanh số theo sản phẩm");
            comboBoxReports.Items.Add("Tồn kho hiện tại");
            comboBoxReports.Items.Add("Khách hàng tiềm năng");
            comboBoxReports.Items.Add("Trạng thái thanh toán");
            comboBoxReports.SelectedIndex = 0; // Chọn mục đầu tiên mặc định
        }
    }
}
