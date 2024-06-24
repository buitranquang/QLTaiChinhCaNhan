using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class KhoanVayBLL
    {
        private KhoanVayAccess khoanVayAccess;

        public KhoanVayBLL()
        {
            khoanVayAccess = new KhoanVayAccess();
        }

        public List<KhoanVay> LayDanhSachKhoanVay(TaiKhoan tk)
        {
            try
            {
                return khoanVayAccess.GetKhoanVay(tk);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khoản vay từ tầng DAL", ex);
            }
        }

        public void CapNhatTrangThai(string khoanVayId, string trangThaiMoi)
        {
            khoanVayAccess.CapNhatTrangThai(khoanVayId, trangThaiMoi);
        }

        public void ThemKhoanVay(KhoanVay khoanVay)
        {
            khoanVayAccess.ThemKhoanVay(khoanVay);
        }

        public void XoaKhoanVayTheoTaiKhoanVaTrangThai(TaiKhoan tk)
        {
            string trangThai = "Đã Thanh Toán";
            khoanVayAccess.XoaKhoanVayTheoTaiKhoanVaTrangThai(tk, trangThai);
        }

        public string GetTenKVByMaKV(string MaKV)
        {
            string TenKV = khoanVayAccess.GetTenKVByMaKV(MaKV);
            return TenKV;
        }
    }
}
