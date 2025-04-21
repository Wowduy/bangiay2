using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace quanlibangiay2
{
    public class modifynhanvien
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        // Lấy danh sách tất cả nhân viên
        public DataTable GetAllNhanVien()
        {
            DataTable table = new DataTable();
            string query = "SELECT * FROM Employees";

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }
            }
            return table;
        }

        // Thêm mới nhân viên
        public bool InsertNhanVien(nhanvien nv)
        {
            string query = "INSERT INTO Employees (Name, Position, Email, Phone, Role) " +
                           "VALUES (@Name, @Position, @Email, @Phone, @Role)";

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", nv.Tennv);
                    cmd.Parameters.AddWithValue("@Position", nv.Chucvunv);
                    cmd.Parameters.AddWithValue("@Email", nv.Emailnv);
                    cmd.Parameters.AddWithValue("@Phone", nv.Sdtnv);
                    cmd.Parameters.AddWithValue("@Role", nv.Rolenv);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Cập nhật thông tin nhân viên
        public bool UpdateNhanVien(nhanvien nv)
        {
            string query = "UPDATE Employees SET Name = @Name, Position = @Position, " +
                           "Email = @Email, Phone = @Phone, Role = @Role " +
                           "WHERE EmployeeID = @EmployeeID";

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", nv.Tennv);
                    cmd.Parameters.AddWithValue("@Position", nv.Chucvunv);
                    cmd.Parameters.AddWithValue("@Email", nv.Emailnv);
                    cmd.Parameters.AddWithValue("@Phone", nv.Sdtnv);
                    cmd.Parameters.AddWithValue("@Role", nv.Rolenv);
                    cmd.Parameters.AddWithValue("@EmployeeID", nv.Idnv);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Xóa nhân viên
        public bool DeleteNhanVien(int employeeID)
        {
            string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Tìm kiếm nhân viên theo ID
        public nhanvien SearchNhanVienById(int id)
        {
            string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new nhanvien(
                                (int)reader["EmployeeID"],
                                reader["Name"].ToString(),
                                reader["Position"].ToString(),
                                reader["Email"].ToString(),
                                reader["Phone"].ToString(),
                                reader["Role"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }
        public DataTable GetReportData(string query) { DataTable table = new DataTable(); using (SqlConnection connection = dbHelper.GetConnection()) { using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection)) { adapter.Fill(table); } } return table; }

    }
}
