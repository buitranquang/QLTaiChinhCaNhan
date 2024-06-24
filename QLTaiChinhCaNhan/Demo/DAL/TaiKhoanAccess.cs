using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class TaiKhoanAccess : DatabaseAccess
    {

        /*public string CheckDangNhap(string tk, string mk)
        {
            string info = CheckDangNhapDAL(tk,mk);
            return info;
        }*/

        public string CheckDangNhap(string tenTK, string matKhau)
        {
            string result = "";

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = "SELECT MaTK FROM TaiKhoan WHERE TenTK = @TenTK AND MatKhau = @MatKhau";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@TenTK", tenTK);
                command.Parameters.AddWithValue("@MatKhau", matKhau);

                conn.Open();
                object objResult = command.ExecuteScalar();

                if (objResult != null)
                {
                    result = objResult.ToString();
                }
                else
                {
                    result = "tài khoản hoặc mật khẩu không chính xác";
                }
            }

            return result;
        }

        public TaiKhoan GetTaiKhoanByMaTK(string maTK)
        {
            TaiKhoan taiKhoan = null;

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                using (SqlCommand command = new SqlCommand("SELECT MaTK, TenTK, MatKhau, ThanhPho, SDT, DateTK, SLVi, TenUser FROM TaiKhoan WHERE MaTK = @MaTK", conn))
                {
                    command.Parameters.AddWithValue("@MaTK", maTK);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                taiKhoan = new TaiKhoan
                                {
                                    MaTK = reader["MaTK"].ToString(),
                                    TenTK = reader["TenTK"].ToString(),
                                    MatKhau = reader["MatKhau"].ToString(),
                                    ThanhPho = reader["ThanhPho"].ToString(),
                                    SDT = reader["SDT"] != DBNull.Value ? (long?)reader["SDT"] : null,
                                    DateTK = reader["DateTK"] != DBNull.Value ? Convert.ToDateTime(reader["DateTK"]) : DateTime.MinValue,
                                    SLVi = reader["SLVi"] != DBNull.Value ? (int)reader["SLVi"] : 0,
                                    TenUser = reader["TenUser"].ToString()
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception if necessary
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return taiKhoan;
        }

        // Phương thức để đăng ký tài khoản mới
        public bool NewTaiKhoan(TaiKhoan taikhoan,int SLVi = 2 )
        {
            bool ketQua = false;

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                // Chuỗi truy vấn SQL để thêm mới bản ghi vào bảng TaiKhoan
                string query = "INSERT INTO TaiKhoan (MaTK, TenTK, MatKhau, SDT, ThanhPho,DateTK, SLVi, TenUser) VALUES (@MaTK,@TenTK, @MatKhau, @Sdt, @ThanhPho, @DateTK, 1, @TenUser)";

                // Tạo đối tượng SqlCommand để thực thi truy vấn
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm các tham số vào truy vấn để tránh tình trạng SQL Injection
                    cmd.Parameters.AddWithValue("@TenTK", taikhoan.TenTK);
                    cmd.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);
                    cmd.Parameters.AddWithValue("@Sdt", taikhoan.SDT);
                    cmd.Parameters.AddWithValue("@ThanhPho", taikhoan.ThanhPho);
                    cmd.Parameters.AddWithValue("@MaTK", taikhoan.TenTK + taikhoan.SDT);
                    cmd.Parameters.AddWithValue("@DateTK", taikhoan.DateTK);
                    cmd.Parameters.AddWithValue("@SLVi", SLVi);
                    cmd.Parameters.AddWithValue("@TenUser", taikhoan.TenUser);
                    try
                    {
                        // Mở kết nối đến cơ sở dữ liệu
                        conn.Open();

                        // Thực thi truy vấn
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Kiểm tra xem có bản ghi nào đã được thêm mới không
                        if (rowsAffected > 0)
                        {
                            ketQua = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý exception nếu có
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                }
            }

            return ketQua;
        }

        public bool IsUsernameExists(string tentk)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenTK = @TenTK";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@TenTK", tentk);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public void UpdateSLVi(TaiKhoan tk)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "UPDATE TaiKhoan SET SLVi = SLVi + 1 WHERE MaTK = @MaTK";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaTK", tk.MaTK);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Cập nhật số lượng ví thành công.");
                    }
                    else
                    {
                        Console.WriteLine("Cập nhật số lượng ví thất bại. Không tìm thấy tài khoản.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                    Console.WriteLine($"Chi tiết lỗi: {ex.StackTrace}");
                }
            }
        }

        public bool UpdateTaiKhoan(string maTK, string tenTK, long sdt, string thanhPho, string TenUser)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE TaiKhoan SET TenTK = @TenTK, SDT = @SDT, ThanhPho = @ThanhPho, TenUser = @TenUser WHERE MaTK = @MaTK", conn);
                    cmd.Parameters.AddWithValue("@MaTK", maTK);
                    cmd.Parameters.AddWithValue("@TenTK", tenTK);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@ThanhPho", thanhPho);
                    cmd.Parameters.AddWithValue("@TenUser", TenUser);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log exception
                    throw new Exception("Error updating TaiKhoan: " + ex.Message);
                }
            }
        }


        public bool UpdatePassword(string maTK, string oldPassword, string newPassword)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                try
                {
                    conn.Open();
                    // Kiểm tra mật khẩu cũ
                    string queryCheckOldPassword = "SELECT COUNT(*) FROM TaiKhoan WHERE MaTK = @MaTK AND MatKhau = @OldPassword";
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheckOldPassword, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@MaTK", maTK);
                        cmdCheck.Parameters.AddWithValue("@OldPassword", oldPassword);

                        int count = (int)cmdCheck.ExecuteScalar();
                        if (count == 0)
                        {
                            return false; // Mật khẩu cũ không đúng
                        }
                    }

                    // Cập nhật mật khẩu mới
                    string queryUpdatePassword = "UPDATE TaiKhoan SET MatKhau = @NewPassword WHERE MaTK = @MaTK";
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdatePassword, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@MaTK", maTK);
                        cmdUpdate.Parameters.AddWithValue("@NewPassword", newPassword);
                        cmdUpdate.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ tại đây
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void XoaTaiKhoan(string maTK)
        {
            // Kết nối cơ sở dữ liệu và thực hiện câu lệnh SQL
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = @"BEGIN TRANSACTION;
                                        DELETE FROM ChiTieu WHERE MaTK = @MaTK;
                                        DELETE FROM Vi WHERE MaTK = @MaTK;
                                        DELETE FROM LoaiCT WHERE MaTK = @MaTK;
                                        DELETE FROM KhoanVay WHERE MaTK = @MaTK
                                        DELETE FROM TaiKhoan WHERE MaTK = @MaTK;
                                        COMMIT TRANSACTION;";
                    command.Parameters.AddWithValue("@MaTK", maTK);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int LaySoLuongVi(TaiKhoan tk)
        {
            int soLuongVi = 0;

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection =  SqlConnectionData.Connect())
            {
                // Mở kết nối
                connection.Open();

                // Tạo truy vấn SQL để lấy số lượng ví
                string query = "SELECT SLVi FROM TaiKhoan WHERE MaTK = @MaTK";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số mã tài khoản vào truy vấn
                    command.Parameters.AddWithValue("@MaTK", tk.MaTK);

                    // Thực thi truy vấn và đọc kết quả
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Nếu có dữ liệu
                        if (reader.Read())
                        {
                            // Lấy số lượng ví từ dữ liệu và gán cho biến soLuongVi
                            soLuongVi = Convert.ToInt32(reader["SLVi"]);
                        }
                    }
                }
            }

            // Trả về số lượng ví
            return soLuongVi;
        }
    }
}
