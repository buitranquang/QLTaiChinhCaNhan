using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class LoaiCTBLL
    {
        LoaiCTAccess loaiCT = new LoaiCTAccess();
        public string GetTenCTByMaCT(ChiTieu chitieu)
        {
            string tenloaict = loaiCT.GetTenCTByMaCT(chitieu);
            return tenloaict;
        }

        public List<LoaiCT> GetLoaiCTList(int SoKyTu, string dieukien, TaiKhoan taiKhoan)
        {
            DataTable dt = loaiCT.GetLoaiCTList(SoKyTu,dieukien,taiKhoan);
            return ConvertDataTableToLoaiChiTieuList(dt);
        }

        public List<LoaiCT> ConvertDataTableToLoaiChiTieuList(DataTable dataTable)
        {
            List<LoaiCT> loaiChiTieuList = new List<LoaiCT>();
            foreach (DataRow row in dataTable.Rows)
            {
                LoaiCT loaict = new LoaiCT
                {
                    MaLoaiCT = row["MaLoaiCT"].ToString(),
                    TenLoaiCT = row["TenLoaiCT"].ToString(),
                };
                loaiChiTieuList.Add(loaict);
            }
            return loaiChiTieuList;
        }
        public bool newLoaiCT(TaiKhoan taiKhoan,string tenloaiCT, string rd, bool define)
        {
            string loaict = define == true ? "Thu" : "Chi";
            bool kq = loaiCT.newLoaiCT(taiKhoan,loaict, rd, tenloaiCT);
            return kq;
        }

        public DataTable GetLoaiCTListdt(int SoKyTu, string dieukien, TaiKhoan taiKhoan)
        { 
            DataTable dt = loaiCT.GetLoaiCTList(SoKyTu,dieukien,taiKhoan);
            return dt;
        }

        public bool DeleteLoaiCT(LoaiCT ct)
        {
            bool kq = loaiCT.DeleteLoaiCT(ct);
            return kq;
        }

    }
}
