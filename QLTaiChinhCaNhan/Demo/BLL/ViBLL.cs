using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ViBLL
    {
        private ViAccess viAccess  = new ViAccess();

        public bool newVi(TaiKhoan taikhoan, string TenVi = "Tiền Mặt", string rd = "vi1")
        {
            bool newvi =  viAccess.newVi( taikhoan,  TenVi,  rd);
            return newvi;
        }

        public List<Vi> GetViByMaTK(TaiKhoan taiKhoan)
        {
            return viAccess.GetViByMaTK(taiKhoan.MaTK);
        }

        public bool UpdateTenVi(string maVi, string tenVi)
        {
            if (string.IsNullOrEmpty(tenVi))
            {
                throw new ArgumentException("Tên ví không được để trống");
            }
            return viAccess.UpdateTenVi(maVi, tenVi);
        }

        public bool DeleteVi(string maVi,TaiKhoan tk)
        {
            if (string.IsNullOrEmpty(maVi))
            {
                throw new ArgumentException("Mã ví không được để trống");
            }

            return viAccess.DeleteViAndChiTieu(maVi, tk);
        }

        public string GetTenViByMaVi(string maVi)
        {
            string tenvi = viAccess.GetTenViByMaVi(maVi);
            return tenvi;
        }

        public DataTable GetViListByMaTK(string maTK)
        {
            return viAccess.GetViListByMaTK(maTK);
        }
    }
}
