using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Runtime.CompilerServices;

namespace DAL
{
    public class SqlConnectionData
    {
        //tao chuoi ket noi co so du lieu
        public static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection("Data Source=QUANGPC\\QUANGSQL2022;Initial Catalog=QLTaiChinh;Integrated Security=True;Encrypt=False"); // khoi tao connect
            return conn;
        }
    }

    public class DatabaseAccess
    {
       /* public static string CheckDangNhapDAL(string tk, string mk)
        {
            string user = "";
            // Ham connect csdl
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            // Thay đổi câu lệnh SQL để sử dụng truy vấn trực tiếp
            string query = "SELECT * FROM TaiKhoan WHERE TenTK = @TenTK AND MatKhau = @MatKhau";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text; // Sử dụng CommandType.Text cho truy vấn trực tiếp
            cmd.Parameters.AddWithValue("@TenTK", tk);
            cmd.Parameters.AddWithValue("@MatKhau", mk);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(0); // Giả sử cột đầu tiên là tên người dùng
                    return user;
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                reader.Close();
                conn.Close();
                return "đăng nhập thất bại !";
            }

            return user;
        }*/

    }
}
