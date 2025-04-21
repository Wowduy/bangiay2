using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace C_CuoiKi
{
    public partial class FormQLKho : Form
    {
        string connectstring = "Server=LAPTOP-0GVJC0P1\\SQLEXPRESS;Database=ShoeStoreDB;User Id=sa;Password=duy16632;TrustServerCertificate=True;";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dtbInventory = new DataTable();
        DataTable dtbProducts = new DataTable();




        public FormQLKho()
        {
            InitializeComponent();
            con = new SqlConnection(connectstring);
            loadInventoryData();
            loadProductData();
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            comboBox1.Visible = false;

            button5.Visible = false;
            panel1.Visible = false;

        }

        private void ExportToExcel(DataGridView dataGridView1, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i).Value = dataGridView1.Columns[i - 1].HeaderText;
                    }

                    for (int i = 1; i <= dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 1; j <= dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i - 1].Cells[j - 1].Value != null)
                            {
                                worksheet.Cell(i + 1, j).Value = dataGridView1.Rows[i - 1].Cells[j - 1].Value.ToString();
                            }
                        }
                    }

                    workbook.SaveAs(filePath);
                    MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadInventoryData()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Inventory", con);
                adt = new SqlDataAdapter(cmd);

                dtbInventory.Clear();
                adt.Fill(dtbInventory);
                dataGridView1.DataSource = dtbInventory;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Inventory: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void loadProductData()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Products", con);
                adt = new SqlDataAdapter(cmd);

                dtbProducts.Clear();
                adt.Fill(dtbProducts);
                dataGridView2.DataSource = dtbProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Products: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            loadInventoryData();
            loadProductData();
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["InventoryID"].Value.ToString();
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int i = e.RowIndex;

                    textBox1.Text = dataGridView1.Rows[i].Cells[1].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            comboBox1.Visible = true;
            label6.Visible = false;
            label5.Visible = true;
            button4.Visible = true;
            button1.Visible = false;
            panel1.Visible = true;
        }

        private void LoadProductsToComboBox()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT ProductID, Name FROM Products", con);
                adt = new SqlDataAdapter(cmd);
                DataTable products = new DataTable();
                adt.Fill(products);

                comboBox1.DataSource = products;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ProductID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                int inventoryID = Convert.ToInt32(textBox3.Text);
                int productID = Convert.ToInt32(textBox1.Text);
                if (!int.TryParse(textBox2.Text, out int newQuantity))
                {
                    MessageBox.Show("Số lượng phải là số nguyên!");
                    return;
                }

                con.Open();

                cmd = new SqlCommand("SELECT Quantity FROM Inventory WHERE InventoryID = @InventoryID", con);
                cmd.Parameters.AddWithValue("@InventoryID", inventoryID);
                int oldQuantity = Convert.ToInt32(cmd.ExecuteScalar());

                if (oldQuantity != newQuantity)
                {
                    cmd = new SqlCommand("UPDATE Inventory SET Quantity = @Quantity WHERE InventoryID = @InventoryID", con);
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryID);
                    cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                    cmd.ExecuteNonQuery();

                    int quantityChange = newQuantity - oldQuantity;

                    cmd = new SqlCommand("UPDATE Products SET StockQuantity = StockQuantity + @QuantityChange WHERE ProductID = @ProductID", con);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.Parameters.AddWithValue("@QuantityChange", quantityChange);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin số lượng thành công!");
                }
                else
                {
                    
                    MessageBox.Show("Số lượng không thay đổi!");
                }

                loadInventoryData();
                loadProductData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                loadInventoryData();
                loadProductData();

                MessageBox.Show("Dữ liệu đã được cập nhật!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu tệp Excel"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dataGridView1, saveFileDialog.FileName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            label6.Visible = true;
            label5.Visible = false;
            button4.Visible = false;
            button1.Visible = true;
            panel1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            comboBox1.Visible = false;
            label6.Visible = true;
            label5.Visible = true;
            button4.Visible = true;
            button1.Visible = true;
            panel1.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            panel1.Visible = true;
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                int inventoryID = Convert.ToInt32(textBox3.Text);
                int productID = Convert.ToInt32(textBox1.Text);
                int quantity = Convert.ToInt32(textBox2.Text);

                con.Open();
                cmd = new SqlCommand("UPDATE Inventory SET ProductID = @ProductID, Quantity = @Quantity WHERE InventoryID = @InventoryID", con);
                cmd.Parameters.AddWithValue("@InventoryID", inventoryID);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thành công!");
                loadInventoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong DataGridView không
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng để xóa!");
                    return;
                }

                int inventoryID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["InventoryID"].Value);

                con.Open();
                cmd = new SqlCommand("DELETE FROM Inventory WHERE InventoryID = @InventoryID", con);
                cmd.Parameters.AddWithValue("@InventoryID", inventoryID);
                cmd.ExecuteNonQuery();

                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }
    }

}
