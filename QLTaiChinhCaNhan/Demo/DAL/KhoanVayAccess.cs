using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KhoanVayAccess
    {
        public List<KhoanVay> GetKhoanVay(TaiKhoan tk)
        {
            List<KhoanVay> danhSachKhoanVay = new List<KhoanVay>();

            try
            {
                using (SqlConnection connection = SqlConnectionData.Connect())
                {
                    string query = "SELECT MaKV, TenKV, SoTienTra, NgayHan, TrangThai FROM KhoanVay Where MaTK = @MaTK";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTK", tk.MaTK);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        KhoanVay khoanVay = new KhoanVay
                        {
                            MaKV = reader.GetString(0),
                            TenKV = reader.GetString(1),
                            SoTienTra = reader.IsDBNull(2) ? (long?)null : reader.GetInt64(2),
                            NgayHan = reader.IsDBNull(3) ? null : (DateTime?)reader.GetDateTime(3),
                            TrangThai = reader.GetString(4),
                        };

                        danhSachKhoanVay.Add(khoanVay);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (nếu có)
                throw new Exception("Lỗi khi lấy danh sách khoản vay từ cơ sở dữ liệu", ex);
            }

            return danhSachKhoanVay;
        }

        public void CapNhatTrangThai(string khoanVayId, string trangThaiMoi)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = "UPDATE KhoanVay SET TrangThai = @TrangThaiMoi WHERE MaKV = @KhoanVayId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrangThaiMoi", trangThaiMoi);
                cmd.Parameters.AddWithValue("@KhoanVayId", khoanVayId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ThemKhoanVay(KhoanVay khoanVay)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = "INSERT INTO KhoanVay (MaKV, TenKV, SoTienTra, NgayHan, TrangThai, MaTK) VALUES (@MaKV, @TenKV, @SoTienTra, @NgayHan, @TrangThai,@MaTK)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaKV", khoanVay.MaKV);
                cmd.Parameters.AddWithValue("@MaTK", khoanVay.MaTK);
                cmd.Parameters.AddWithValue("@TenKV", khoanVay.TenKV);
                cmd.Parameters.AddWithValue("@SoTienTra", khoanVay.SoTienTra);
                cmd.Parameters.AddWithValue("@NgayHan", khoanVay.NgayHan);
                cmd.Parameters.AddWithValue("@TrangThai", khoanVay.TrangThai);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void XoaKhoanVayTheoTaiKhoanVaTrangThai(TaiKhoan tk, string trangThai)
        {
            try
            {
                using (SqlConnection conn = SqlConnectionData.Connect())
                {
                    conn.Open();
                    string query = "DELETE FROM KhoanVay WHERE MaTK = @MaTK AND TrangThai = @TrangThai";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTK", tk.MaTK);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (nếu có)
                throw new Exception("Lỗi khi xóa các khoản vay: " + ex.Message);
            }
        }
        public string GetTenKVByMaKV(string MaKV)
        {
            string TenKV = null;
            try
            {
                // Mở kết nối tới cơ sở dữ liệu
                using (SqlConnection conn = SqlConnectionData.Connect())
                {
                    conn.Open();
                    // Câu truy vấn SQL để lấy TenKV dựa trên MaKV
                    string query = "SELECT TenKV FROM KhoanVay WHERE MaKV = @MaKV";

                    // Tạo đối tượng SqlCommand để thực thi truy vấn
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào truy vấn để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@MaKV", MaKV);

                        // Thực thi truy vấn và đọc kết quả
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Nếu có dữ liệu trả về
                            if (reader.Read())
                            {
                                // Lấy giá trị từ cột TenKV và gán cho biến TenKV
                                TenKV = reader["TenKV"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                throw new Exception("Lỗi: " + ex.Message);
            }
            // Trả về kết quả TenKV
            return TenKV;
        }


    }
}
