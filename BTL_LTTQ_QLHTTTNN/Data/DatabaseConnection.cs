using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public class DatabaseConnection
    {
        public static SqlConnection Conn;

        // Chuỗi kết nối SQL Server
        public static string ConnString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLTrungTamTiengAnh;User ID=sa;Password=123456789;TrustServerCertificate=True";

        // Mở kết nối chung
        public static void Connect()
        {
            try
            {
                Conn = new SqlConnection(ConnString);
                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đóng kết nối
        public static void Disconnect()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }

        // Đổ dữ liệu từ SQL vào DataTable
        public static DataTable GetDataToTable(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return table;
        }

        // Lấy 1 giá trị đơn (Dùng cho COUNT, SUM...)
        public static string GetFieldValues(string sql)
        {
            string ma = "0";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        ma = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ma;
        }

        // Thực thi câu lệnh Thêm / Sửa / Xóa (INSERT, UPDATE, DELETE)
        public static void RunSQL(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}