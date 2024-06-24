using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ViAccess : DatabaseAccess
    {

        public bool newVi(TaiKhoan taikhoan, string TenVi, string rd)
        {
            bool ketQua = false;

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = "INSERT INTO Vi (MaVi, TenVi, MaTK) VALUES(@MaVi, @TenVi, @MaTK)";
                               

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaVi", taikhoan.MaTK + rd);
                    cmd.Parameters.AddWithValue("@TenVi", TenVi);
                    cmd.Parameters.AddWithValue("@MaTK", taikhoan.MaTK);


                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        ketQua = rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        // Ghi log hoặc xử lý lỗi
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        // Ghi log hoặc xử lý lỗi khác
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return ketQua;
        }


        public List<Vi> GetViByMaTK(string maTK)
        {
            List<Vi> viList = new List<Vi>();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = "SELECT * FROM Vi WHERE MaTK = @MaTK";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaTK", maTK);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Vi vi = new Vi
                    {
                        MaVi = reader["MaVi"].ToString(),
                        TenVi = reader["TenVi"].ToString(),
                        MaTK = reader["MaTK"].ToString()
                    };
                    viList.Add(vi);
                }
            }
            return viList;
        }

        public bool UpdateTenVi(string maVi, string tenVi)
        {
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                string query = "UPDATE Vi SET TenVi = @TenVi WHERE MaVi = @MaVi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaVi", maVi);
                command.Parameters.AddWithValue("@TenVi", tenVi);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    throw new Exception("Error updating wallet name", ex);
                }
            }
        }

        public bool DeleteViAndChiTieu(string maVi, TaiKhoan tk)
        {
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Giảm số lượng ví trong tài khoản
                    string updateTaiKhoanQuery = "UPDATE TaiKhoan SET SLVi = SLVi - 1 WHERE MaTK = @MaTK";
                    SqlCommand updateTaiKhoanCommand = new SqlCommand(updateTaiKhoanQuery, connection, transaction);
                    updateTaiKhoanCommand.Parameters.AddWithValue("@MaTK", tk.MaTK);
                    updateTaiKhoanCommand.ExecuteNonQuery();

                    // Xóa các chi tiêu liên quan đến ví
                    string deleteChiTieuQuery = "DELETE FROM ChiTieu WHERE MaVi = @MaVi";
                    SqlCommand deleteChiTieuCommand = new SqlCommand(deleteChiTieuQuery, connection, transaction);
                    deleteChiTieuCommand.Parameters.AddWithValue("@MaVi", maVi);
                    deleteChiTieuCommand.ExecuteNonQuery();

                    // Xóa ví
                    string deleteViQuery = "DELETE FROM Vi WHERE MaVi = @MaVi";
                    SqlCommand deleteViCommand = new SqlCommand(deleteViQuery, connection, transaction);
                    deleteViCommand.Parameters.AddWithValue("@MaVi", maVi);
                    int result = deleteViCommand.ExecuteNonQuery();

                    transaction.Commit();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi khi xóa ví và các chi tiêu liên quan", ex);
                }
            }
        }

        public string GetTenViByMaVi(string maVi)
        {
            string tenVi = null;

            // Tạo kết nối với cơ sở dữ liệu
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                // Mở kết nối
                connection.Open();

                // Tạo truy vấn SQL để lấy tên ví từ MaVi
                string query = "SELECT TenVi FROM Vi WHERE MaVi = @MaVi";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số @MaVi vào truy vấn
                    command.Parameters.AddWithValue("@MaVi", maVi);

                    // Thực thi truy vấn và lấy tên ví
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        tenVi = result.ToString();
                    }
                }
            }

            return tenVi;
        }

        public DataTable GetViListByMaTK(string maTK)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = "SELECT * FROM Vi WHERE MaTK = @MaTK";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTK", maTK);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
