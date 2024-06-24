using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;


namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanAccess tkAccess = new TaiKhoanAccess();
        /*public string CheckDangNhap(string tk, string mk)
        {
            //kt nhiệm vụ 
            if (tk == "")
            {
                return "requeid_taikhoan";

            }
            if (mk == "")
            {
                return "requeid_matkhau";

            }
            string info = tkAccess.CheckDangNhap(tk,mk);
            return info;
        }*/
        public string CheckDangNhap(string tenTK, string matKhau)
        {
            // Kiểm tra và xử lý logic nghiệp vụ ở đây (nếu cần)

            // Gọi phương thức tương ứng từ DAL để thực hiện công việc
            return tkAccess.CheckDangNhap(tenTK, matKhau);
        }

        public TaiKhoan GetTaiKhoanByMaTK(string mataikhoan)
        {
            TaiKhoan taikhoan = tkAccess.GetTaiKhoanByMaTK(mataikhoan);
            return taikhoan;
        }

        public bool NewTaiKhoan(TaiKhoan taikhoan)
        {
            // Gọi phương thức từ đối tượng tkAccess để thực hiện thêm mới tài khoản
            bool ketQua = tkAccess.NewTaiKhoan(taikhoan);

            // Trả về kết quả cho lớp gọi
            return ketQua;
        }

        public bool CheckUsernameAvailability(string tentk )
        {
            return !tkAccess.IsUsernameExists(tentk);
        }

        public void UpdateSLVi(TaiKhoan tk)
        {
            tkAccess.UpdateSLVi(tk);
        }

        public bool UpdateTaiKhoan(string maTK, string tenTK, long sdt, string thanhPho, string TenUser)
        {
            return tkAccess.UpdateTaiKhoan(maTK, tenTK, sdt, thanhPho, TenUser);
        }

        public bool UpdatePassword(string maTK, string oldPassword, string newPassword)
        {
            return tkAccess.UpdatePassword(maTK, oldPassword, newPassword);
        }

        public void XoaTaiKhoan(string maTK)
        {
            tkAccess.XoaTaiKhoan(maTK);
        }

        public int LaySoLuongVi(TaiKhoan tk)
        {
            int SLVi = tkAccess.LaySoLuongVi(tk);
            return SLVi;
        }
    }
}
