using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTieuAccess : DatabaseAccess
    {
       
        public static DataTable ThongKeChiTieu(string matk)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = "SELECT SoTienChitieu FROM ChiTieu WHERE MaTK = @MaTK";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MaTK", matk);
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }


        public DataTable GetThuChiByMaVi(string maVi)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = "SELECT SoTienChiTieu FROM ChiTieu WHERE MaVi = @MaVi";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MaVi", maVi);
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public DataTable GetChiTieuByMaTK(string maTK)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = @"SELECT CT.MaChiTieu, CT.SoTienChitieu, CT.NgayChiTieu, CT.MaLoaiCT, CT.MaVi, CT.MaTK
                                FROM ChiTieu CT
                                INNER JOIN LoaiCT LT ON CT.MaLoaiCT = LT.MaLoaiCT
                                WHERE CT.MaTK = @MaTK
                                ORDER BY CT.NgayChiTieu DESC;";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@MaTK", maTK);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public bool NewChiTieu(int SoTienChitieu, DateTime NgayChiTieu, string MaLoaiCT, string MaVi, string MaTK)
        {
            bool ketQua = false;

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                string query = "INSERT INTO ChiTieu (SoTienChitieu, NgayChiTieu, MaLoaiCT, MaVi, MaTK)"
                                          + " VALUES (@SoTienChitieu, @NgayChiTieu, @MaLoaiCT, @MaVi, @MaTK)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoTienChitieu", SoTienChitieu);
                    cmd.Parameters.AddWithValue("@NgayChiTieu", NgayChiTieu);
                    cmd.Parameters.AddWithValue("@MaLoaiCT", MaLoaiCT);
                    cmd.Parameters.AddWithValue("@MaVi", MaVi);
                    cmd.Parameters.AddWithValue("@MaTK", MaTK);
                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            ketQua = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                }
            }
            return ketQua;
        }

        public void UpdateChiTieu(int maChiTieu, int soTienChiTieu, DateTime ngayChiTieu, string MaLoaiCT,string MaVi)
        {
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE ChiTieu SET SoTienChitieu = @SoTienChiTieu, NgayChiTieu = @NgayChiTieu, MaLoaiCT = @m, MaVi = @MaVi WHERE MaChiTieu = @MaChiTieu";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SoTienChiTieu", soTienChiTieu);
                        command.Parameters.AddWithValue("@NgayChiTieu", ngayChiTieu);
                        command.Parameters.AddWithValue("@MaChiTieu", maChiTieu);
                        command.Parameters.AddWithValue("@m", MaLoaiCT);
                        command.Parameters.AddWithValue("@MaVi", MaVi);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ (ví dụ: ghi log, hiển thị thông báo)
                    Console.WriteLine("Lỗi khi cập nhật chi tiêu: " + ex.Message);
                }
            }
        }

        public void DeleteChiTieu(int maChiTieu)
        {
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM ChiTieu WHERE MaChiTieu = @MaChiTieu";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaChiTieu", maChiTieu);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu cần
                    throw ex;
                }
            }
        }


    }
}
