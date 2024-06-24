using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DTO;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class LoaiCTAccess : DatabaseAccess
    {
        public string GetTenCTByMaCT(ChiTieu chitieu)
        {
            string tenTK = null;

            using (SqlConnection conn = SqlConnectionData.Connect())
            {

                using (SqlCommand command = new SqlCommand("SELECT TenLoaiCT FROM LoaiCT WHERE MaLoaiCT = @MaLoaiCT", conn))
                {
                    command.Parameters.AddWithValue("@MaLoaiCT", chitieu.MaLoaiCT);

                    try
                    {
                        conn.Open();
                        tenTK = command.ExecuteScalar()?.ToString();
                    }
                    catch (Exception ex)
                    {
                        // Xử lý exception nếu cần thiết
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return tenTK;
        }

        public DataTable GetLoaiCTList(int SoKyTu, string dieukien, TaiKhoan taiKhoan)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = @"SELECT * FROM LoaiCT WHERE LEFT(MaLoaiCT, @SoKyTu) = @MaLoaiCT AND (MaTK IS NULL OR MaTK = @MaTK)";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaLoaiCT", dieukien);
                command.Parameters.AddWithValue("@SokyTu", SoKyTu);
                command.Parameters.AddWithValue("@MaTK", taiKhoan.MaTK);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public bool newLoaiCT(TaiKhoan taikhoan,string loai, string rd, string tenloaict)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = @"INSERT INTO LoaiCT(MaLoaiCT, TenLoaiCT, MaTK) VALUES (@MaLoaiCT, @TenLoaiCT, @MaTK)";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaLoaiCT", loai + taikhoan.MaTK + rd);
                command.Parameters.AddWithValue("@TenLoaiCT", tenloaict);
                command.Parameters.AddWithValue("@MaTK", taikhoan.MaTK);
                try
                {
                    conn.Open();
                    command.ExecuteNonQuery(); // Thực thi lệnh INSERT
                    return true;
                }
                catch (Exception ex)
                {
                    // Xử lý exception nếu cần thiết
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteLoaiCT(LoaiCT ct)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = @"DELETE FROM ChiTieu WHERE MaLoaiCT = @MaLoaiCT; DELETE FROM LoaiCT WHERE MaLoaiCT = @MaLoaiCT";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaLoaiCT", ct.MaLoaiCT);
                try
                {
                    conn.Open();
                    command.ExecuteNonQuery(); // Thực thi lệnh INSERT
                    return true;
                }
                catch (Exception ex)
                {
                    // Xử lý exception nếu cần thiết
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
           
        }
    }
}
