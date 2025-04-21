using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace quanlibangiay2
{
    public class DatabaseHelper
    {
        // Chuỗi kết nối cơ sở dữ liệu (Cần thay đổi theo thông tin của bạn)
        private string connectionString = "Server=LAPTOP-0GVJC0P1\\SQLEXPRESS;Database=ShoeStoreDB;User Id=sa;Password=duy16632;TrustServerCertificate=True;";

        // Hàm trả về một SqlConnection đã mở
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Mở kết nối
                connection.Open();
                Console.WriteLine("Database connection established successfully.");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối
                Console.WriteLine("Error connecting to database: " + ex.Message);
                throw; // Ném ngoại lệ để xử lý thêm nếu cần
            }

            return connection;
        }

        public bool Login(string username, string password)
        {
            using (SqlConnection connection = GetConnection())
            {
                // Tên stored procedure bạn đã tạo
                string procedureName = "proc_login";

                using (SqlCommand cmd = new SqlCommand(procedureName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số vào stored procedure
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    // Thực thi procedure và kiểm tra kết quả
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Nếu có dữ liệu trả về, đăng nhập thành công
                        return reader.HasRows;
                    }
                }
            }
        }
        public string GetPassword(string username)
        {
            using (SqlConnection connection = GetConnection())
            {
                string procedureName = "proc_get_password";

                using (SqlCommand cmd = new SqlCommand(procedureName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Kiểm tra kết quả trả về
                            {
                                return reader["PasswordHash"]?.ToString(); // Trả về mật khẩu
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    return null; // Không tìm thấy kết quả hoặc có lỗi
                }
            }
        }


    }
}
