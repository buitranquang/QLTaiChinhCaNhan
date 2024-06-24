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
    public class ChiTieuBLL
    {
        private ChiTieuAccess chiTieuAC = new ChiTieuAccess();

        public DataTable ThongKeChiTieu(string matk)
        {
            // Gọi phương thức từ DAL để thực hiện thống kê
            DataTable dataTable = ChiTieuAccess.ThongKeChiTieu(matk);
            return dataTable;
        }

        public int TinhTongSoTien(string maVi)
        {
            DataTable dataTable = chiTieuAC.GetThuChiByMaVi(maVi);
            int tongTien = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                int soTien = Convert.ToInt32(row["SoTienChiTieu"]);
                tongTien += soTien;
            }

            return tongTien;
        }

        public List<ChiTieu> GetChiTieuByMaTK(string maTK)
        {
            DataTable dataTable = chiTieuAC.GetChiTieuByMaTK(maTK);
            return ConvertDataTableToChiTieuList(dataTable);
        }

        public List<ChiTieu> FilterByTien(List<ChiTieu> chiTieuList, bool isPositive)
        {
            return chiTieuList.Where(ct => (isPositive && ct.SoTienChitieu > 0) || (!isPositive && ct.SoTienChitieu < 0)).ToList();
        }

        public List<ChiTieu> FilterByNgayChiTieu(List<ChiTieu> chiTieuList, bool isPositive, DateTime fromDate, DateTime toDate)
        {
            return chiTieuList.Where(ct =>
                    ((isPositive && ct.SoTienChitieu > 0) || (!isPositive && ct.SoTienChitieu < 0)) &&
                    ct.NgayChiTieu >= fromDate && ct.NgayChiTieu <= toDate).ToList();
        }

        public List<ChiTieu> ConvertDataTableToChiTieuList(DataTable dataTable)
        {
            List<ChiTieu> chiTieuList = new List<ChiTieu>();
            foreach (DataRow row in dataTable.Rows)
            {
                ChiTieu chiTieu = new ChiTieu
                {
                    MaChiTieu = Convert.ToInt32(row["MaChiTieu"]),
                    SoTienChitieu = Convert.ToInt32(row["SoTienChitieu"]),
                    NgayChiTieu = Convert.ToDateTime(row["NgayChiTieu"]),
                    MaLoaiCT = row["MaLoaiCT"].ToString(),
                    MaVi = row["MaVi"].ToString(),
                    MaTK = row["MaTK"].ToString(),
                };
                chiTieuList.Add(chiTieu);
            }
            return chiTieuList;
        }

        public DataTable FilterByTien(DataTable dataTable, bool isPositive)
        {
            DataTable filteredTable = dataTable.Clone();

            foreach (DataRow row in dataTable.Rows)
            {
                int soTienChitieu = Convert.ToInt32(row["SoTienChitieu"]);
                if ((soTienChitieu >= 0 && isPositive) || (soTienChitieu < 0 && !isPositive))
                {
                    filteredTable.ImportRow(row);
                }
            }

            return filteredTable;
        }

        public bool NewChiTieu(int SoTienChitieu, DateTime NgayChiTieu, string MaLoaiCT, string MaVi, string MaTK)
        {
            bool ChiTieu = chiTieuAC.NewChiTieu(SoTienChitieu, NgayChiTieu, MaLoaiCT, MaVi, MaTK);
            return ChiTieu;
        }

        public void UpdateChiTieu(int maChiTieu, int soTienChiTieu, DateTime ngayChiTieu,string MaLoaiCT,string MaVi)
        {
            chiTieuAC.UpdateChiTieu(maChiTieu, soTienChiTieu, ngayChiTieu, MaLoaiCT,MaVi);
        }

        public void DeleteChiTieu(int mact)
        {
            chiTieuAC.DeleteChiTieu(mact);
        }
    }
}   
