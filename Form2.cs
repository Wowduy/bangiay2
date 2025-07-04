﻿using baitap_lon;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baitap_lon;

namespace C_CuoiKi
{
    public partial class FormQLDH : Form
    {
        string connectstring = "Server=LAPTOP-0GVJC0P1\\SQLEXPRESS;Database=ShoeStoreDB;User Id=sa;Password=duy16632;TrustServerCertificate=True;";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dtb = new DataTable();

        private List<Product> products = new List<Product>();

        private List<OrderDetail> orderDetails = new List<OrderDetail>();
        public FormQLDH()
        {
            con = new SqlConnection(connectstring);
            InitializeComponent();
            loadData();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadData();
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

        private void loadData()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd = new SqlCommand("SELECT ProductID, ImagePath, Name, Price, Size, Color, StockQuantity FROM Products", con);
                SqlDataReader reader = cmd.ExecuteReader();
                products.Clear();
                flowLayoutPanel1.Controls.Clear();

                while (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["ProductID"]);
                    string imagePath = reader["ImagePath"].ToString();
                    string productName = reader["Name"].ToString();
                    decimal price = Convert.ToDecimal(reader["Price"]);
                    string size = reader["Size"].ToString();
                    string color = reader["Color"].ToString();
                    int stockQuantity = Convert.ToInt32(reader["StockQuantity"]);


                    /*PictureBox pictureBox = new PictureBox
                    {
                        Width = 100,
                        Height = 100,
                        Image = Image.FromFile(imagePath),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    pictureBox.Click += (sender, e) => OnProductImageClick(productId, productName, price);
                    pictureBox.MouseEnter += (sender, e) => pictureBox.Cursor = Cursors.Hand;
                    pictureBox.MouseLeave += (sender, e) => pictureBox.Cursor = Cursors.Default;*/

                    Label nameLabel = new Label
                    {
                        Text = $"Tên: {productName}",
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    Label sizeLabel = new Label
                    {
                        Text = $"Size: {size}",
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    Label colorLabel = new Label
                    {
                        Text = $"Màu: {color}",
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    Label stockLabel = new Label
                    {
                        Text = $"Đang còn: {stockQuantity}",
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = stockQuantity > 0 ? Color.Green : Color.Red
                    };

                    Panel productPanel = new Panel
                    {
                        Width = 120,
                        Height = 200,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    //productPanel.Controls.Add(pictureBox);
                    productPanel.Controls.Add(nameLabel);
                    productPanel.Controls.Add(sizeLabel);
                    productPanel.Controls.Add(colorLabel);
                    productPanel.Controls.Add(stockLabel);

                    //pictureBox.Location = new Point(10, 10);
                    nameLabel.Location = new Point(10, 120);
                    sizeLabel.Location = new Point(10, 140);
                    colorLabel.Location = new Point(10, 160);
                    stockLabel.Location = new Point(10, 180);

                    flowLayoutPanel1.Controls.Add(productPanel);
                }




                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void OnProductImageClick(int productId, string productName, decimal price)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString() == productName)
                {
                    if (int.TryParse(row.Cells[2].Value.ToString(), out int currentQuantity))
                    {
                        int newQuantity = currentQuantity + 1;
                        row.Cells[2].Value = newQuantity;
                        row.Cells[3].Value = (price * newQuantity).ToString("");
                    }
                    else
                    {
                        MessageBox.Show($"Giá trị trong cột số lượng (Cells[2]) không hợp lệ. Vui lòng kiểm tra dữ liệu.", "Lỗi định dạng");
                        row.Cells[2].Value = 1;
                        row.Cells[3].Value = price.ToString("");
                    }

                    UpdateTotalAmount();
                    return;
                }
            }

            int quantity = 1;
            decimal totalPrice = price * quantity;

            dataGridView1.Rows.Add(productName, price.ToString(""), quantity, totalPrice.ToString(""), CreateQuantityControl(quantity, productId));

            orderDetails.Add(new OrderDetail
            {
                ProductID = productId,
                ProductName = productName,
                Price = price,
                Quantity = quantity,
                TotalPrice = totalPrice
            });

            UpdateTotalAmount();
        }

        private Control CreateQuantityControl(int quantity, int productId)
        {
            NumericUpDown numericUpDown = new NumericUpDown
            {
                Value = quantity,
                Minimum = 1,
                Maximum = 100,
                Width = 50
            };

            numericUpDown.ValueChanged += (sender, e) =>
            {
                decimal price = orderDetails.Find(x => x.ProductID == productId).Price;
                int newQuantity = (int)numericUpDown.Value;
                decimal totalPrice = price * newQuantity;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString() == orderDetails.Find(x => x.ProductID == productId).ProductName)
                    {
                        if (decimal.TryParse(row.Cells[3].Value.ToString().Replace("$", "").Replace(",", ""), out _))
                        {
                            row.Cells[3].Value = totalPrice.ToString("");
                        }
                        else
                        {
                            MessageBox.Show($"Giá trị trong cột tổng tiền (Cells[3]) không hợp lệ.", "Lỗi định dạng");
                            row.Cells[3].Value = totalPrice.ToString("");
                        }
                        break;
                    }
                }
                UpdateTotalAmount();
            };

            return numericUpDown;
        }

        private void UpdateTotalAmount()
        {
            try
            {
                decimal totalAmount = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[3].Value != null)
                    {
                        string value = row.Cells[3].Value.ToString().Replace("$", "").Replace(",", "");
                        if (decimal.TryParse(value, out decimal rowTotalPrice))
                        {
                            totalAmount += rowTotalPrice;
                        }
                        else
                        {
                            MessageBox.Show($"Giá trị không hợp lệ trong cột tổng tiền: {row.Cells[3].Value}", "Lỗi định dạng");
                        }
                    }
                }

                label4.Text = totalAmount.ToString("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tổng hóa đơn: " + ex.Message);
            }
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            THANHTOAN formThanhToan = new THANHTOAN();
            formThanhToan.ShowDialog();
        }

        private string PromptForCustomerName()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 200;
                prompt.Text = "Nhập Tên Khách Hàng";

                Label label = new Label { Left = 20, Top = 20, Text = "Tên Khách Hàng:" };
                TextBox inputBox = new TextBox { Left = 20, Top = 50, Width = 340 };
                Button confirmButton = new Button { Text = "Xác Nhận", Left = 260, Width = 100, Top = 100, DialogResult = DialogResult.OK };

                prompt.Controls.Add(label);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmButton);
                prompt.AcceptButton = confirmButton;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text.Trim() : string.Empty;
            }
        }

        private string PromptForCustomerEmail()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 200;
                prompt.Text = "Nhập Email Khách Hàng";

                Label label = new Label { Left = 20, Top = 20, Text = "Email Khách Hàng:" };
                TextBox inputBox = new TextBox { Left = 20, Top = 50, Width = 340 };
                Button confirmButton = new Button { Text = "Xác Nhận", Left = 260, Width = 100, Top = 100, DialogResult = DialogResult.OK };

                prompt.Controls.Add(label);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmButton);
                prompt.AcceptButton = confirmButton;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text.Trim() : string.Empty;
            }
        }


        private void SaveOrderToDatabase(string customerName, decimal totalAmount, string customerEmail)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectstring))
                {
                    con.Open();

                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            int customerId = GetOrCreateCustomerId(con, transaction, customerName, customerEmail);

                            SqlCommand cmdOrder = new SqlCommand("INSERT INTO Orders (CustomerID, TotalAmount, OrderDate) VALUES (@CustomerID, @TotalAmount, @OrderDate); SELECT SCOPE_IDENTITY();", con, transaction);
                            cmdOrder.Parameters.AddWithValue("@CustomerID", customerId);
                            cmdOrder.Parameters.AddWithValue("@TotalAmount", totalAmount);
                            cmdOrder.Parameters.AddWithValue("@OrderDate", DateTime.Now);

                            int orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());

                            foreach (var detail in orderDetails)
                            {
                                SqlCommand cmdDetail = new SqlCommand("INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice) VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);", con, transaction);
                                cmdDetail.Parameters.AddWithValue("@OrderID", orderId);
                                cmdDetail.Parameters.AddWithValue("@ProductID", detail.ProductID);
                                cmdDetail.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                cmdDetail.Parameters.AddWithValue("@UnitPrice", detail.Price);
                                cmdDetail.ExecuteNonQuery();

                                SqlCommand cmdUpdateStock = new SqlCommand(
                                "UPDATE Products SET StockQuantity = StockQuantity - @Quantity WHERE ProductID = @ProductID;",
                                con, transaction
                            );
                                cmdUpdateStock.Parameters.AddWithValue("@Quantity", detail.Quantity);
                                cmdUpdateStock.Parameters.AddWithValue("@ProductID", detail.ProductID);
                                cmdUpdateStock.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }


        private int GetOrCreateCustomerId(SqlConnection con, SqlTransaction transaction, string customerName, string customerEmail)
        {
            SqlCommand findCmd = new SqlCommand("SELECT CustomerID FROM Customers WHERE Email = @Email", con, transaction);
            findCmd.Parameters.AddWithValue("@Email", customerEmail);
            object result = findCmd.ExecuteScalar();

            if (result != null)
            {
                return Convert.ToInt32(result);
            }

            SqlCommand insertCmd = new SqlCommand("INSERT INTO Customers (Name, Email) VALUES (@Name, @Email); SELECT SCOPE_IDENTITY();", con, transaction);
            insertCmd.Parameters.AddWithValue("@Name", customerName);
            insertCmd.Parameters.AddWithValue("@Email", customerEmail);
            return Convert.ToInt32(insertCmd.ExecuteScalar());
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string searchKeyword = textBox1.Text.Trim();
            try
            {
                flowLayoutPanel1.Controls.Clear();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string query = "SELECT ProductID, ImagePath, Name, Price, Size, Color, StockQuantity FROM Products WHERE Name LIKE @SearchKeyword";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["ProductID"]);
                    string imagePath = reader["ImagePath"].ToString();
                    string productName = reader["Name"].ToString();
                    decimal price = Convert.ToDecimal(reader["Price"]);
                    string size = reader["Size"].ToString();
                    string color = reader["Color"].ToString();
                    int stockQuantity = Convert.ToInt32(reader["StockQuantity"]);

                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        // Tạo PictureBox để hiển thị hình ảnh sản phẩm
                        PictureBox pictureBox = new PictureBox
                        {
                            Width = 100,
                            Height = 100,
                            Image = Image.FromFile(imagePath),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        pictureBox.Click += (s, ev) => OnProductImageClick(productId, productName, price);
                        pictureBox.MouseEnter += (s, ev) => pictureBox.Cursor = Cursors.Hand;
                        pictureBox.MouseLeave += (s, ev) => pictureBox.Cursor = Cursors.Default;

                        // Tạo các Label để hiển thị thông tin sản phẩm
                        Label nameLabel = new Label
                        {
                            Text = $"Tên: {productName}",
                            AutoSize = true,
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        Label sizeLabel = new Label
                        {
                            Text = $"Size: {size}",
                            AutoSize = true,
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        Label colorLabel = new Label
                        {
                            Text = $"Màu: {color}",
                            AutoSize = true,
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        Label stockLabel = new Label
                        {
                            Text = $"Đang còn: {stockQuantity}",
                            AutoSize = true,
                            TextAlign = ContentAlignment.MiddleCenter,
                            ForeColor = stockQuantity > 0 ? Color.Green : Color.Red
                        };

                        Panel productPanel = new Panel
                        {
                            Width = 140,
                            Height = 200,
                            Margin = new Padding(5),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        productPanel.Controls.Add(pictureBox);
                        productPanel.Controls.Add(nameLabel);
                        productPanel.Controls.Add(sizeLabel);
                        productPanel.Controls.Add(colorLabel);
                        productPanel.Controls.Add(stockLabel);

                        pictureBox.Location = new Point(20, 10);
                        nameLabel.Location = new Point(10, 120);
                        sizeLabel.Location = new Point(10, 140);
                        colorLabel.Location = new Point(10, 160);
                        stockLabel.Location = new Point(10, 180);

                        flowLayoutPanel1.Controls.Add(productPanel);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
    }
}
