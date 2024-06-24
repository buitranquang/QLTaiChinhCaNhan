using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using GUI.MiniForm;
using BLL;
using DTO;

namespace GUI.App
{
    public partial class UCTongQuan : UserControl
    {

        // Khởi tạo một đối tượng ChiTieuBLL
        private ChiTieuBLL chiTieuBLL = new ChiTieuBLL();
        private LoaiCTBLL loaiCTBLL = new LoaiCTBLL();
        private ViBLL viBLL = new ViBLL();
        TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        MainForm mainForm;
        // khởi tạo các khoảng thu chi và  tổng
        private int tongThu = 0;
        private int tongChi = 0;
        private int tong = 0;
        TaiKhoan taikhoan = new TaiKhoan();
        List<ChiTieu> chiTieuList;
        public List<Vi> viList;

        public UCTongQuan()
        {
            InitializeComponent();
        }
        public UCTongQuan(TaiKhoan tk, int thu, int chi, int tong, MainForm mainForm)
        {
            this.tongThu = thu;
            this.tongChi = chi;
            this.tong = tong;
            this.taikhoan = tk;
            InitializeComponent();
            this.mainForm = mainForm;
        }


        private void LoadChartData() // hàm load dữ liệu datatable từ ChiTieubll.ThongKeChiTieu()
        {// Xóa dữ liệu cũ trong biểu đồ
            ChartThang.Series.Clear();

            // Tạo series mới cho biểu đồ
            Series series = new Series("ThongKe");
            series.ChartType = SeriesChartType.Doughnut;
    
            

            // Thêm dữ liệu vào series
            series.Points.AddXY("Thu", tongThu);
            series.Points.AddXY("Chi", tongChi);

            // Thiết lập màu cho các cột trong biểu đồ
            series.Points[0].Color = Color.Green; // Màu xanh cho thu
            series.Points[1].Color = Color.Red;   // Màu đỏ cho chi

            // Thêm series vào biểu đồ
            ChartThang.Series.Add(series);
        }


        public void UCTongQuan_Load(object sender, EventArgs e)
        {


            //các label trong sơ lược
            txtThu.Text = string.Format("{0:N0}đ", tongThu);
            txtChi.Text = string.Format("{0:N0}đ", tongChi);
            txtTong.Text = string.Format("{0:N0}đ", tong);

            LoadChartData();

            flpnThu.Controls.Clear(); // Xóa dữ liệu cũ trong FlowLayoutPanel
            flpnChi.Controls.Clear(); // Xóa dữ liệu cũ trong FlowLayoutPanel
            flpnThu.AutoScroll = true;
            flpnChi.AutoScroll = true;

            DisplayChiTieuData(flpnThu, true);
            DisplayChiTieuData(flpnChi, false);

            flpnVi.Controls.Clear();
            LoadViPanels(flpnVi);
            flpnVi.AutoScroll = true;
        }

        //tạo các panel thu và chi với điều kiện true fale
        private void DisplayChiTieuData(FlowLayoutPanel flpn, bool isPositive)
        {
            chiTieuList = chiTieuBLL.GetChiTieuByMaTK(taikhoan.MaTK);
            chiTieuList = chiTieuBLL.FilterByTien(chiTieuList, isPositive);

            Panel namePanel = new Panel();
            namePanel.Size = new Size(364, 35);
            namePanel.BackColor = SystemColors.ControlLight;

            Label nameLabel = new Label();
            nameLabel.Text = isPositive ? "Thu Nhập" : "Chi Tiêu";
            nameLabel.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
            nameLabel.AutoSize = true;
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.Location = new Point(
                (namePanel.Width - nameLabel.Width) / 2,
                (namePanel.Height - nameLabel.Height) / 2
            );

            namePanel.Controls.Add(nameLabel);
            flpn.Controls.Add(namePanel);

            CreatePanelCT(flpn);
        }

        private void LoadViPanels(FlowLayoutPanel abc)
        {
            // Lấy danh sách các ví
            viList = viBLL.GetViByMaTK(taikhoan);

            // Định dạng cho mỗi panel tương ứng với mỗi đối tượng Vi
            foreach (var vi in viList)
            {
                // Tạo panel mới
                Panel panel = new Panel();
                panel.BackColor = SystemColors.ScrollBar;
                panel.Size = new Size(342, 45);

                Label labelTenVi = new Label();
                labelTenVi.Text = vi.TenVi;
                labelTenVi.Location = new Point(70, 10);
                labelTenVi.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                labelTenVi.AutoSize = true;

                // Tạo label cho tổng số tiền
                int tongVi = chiTieuBLL.TinhTongSoTien(vi.MaVi);
                Label labelTongVi = new Label();
                labelTongVi.Text = string.Format("{0:N0}đ", tongVi);
                labelTongVi.Location = new Point(labelTenVi.Right + 20, 10); // Đặt vị trí bắt đầu của labelTongVi sau labelTenVi
                labelTongVi.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                labelTongVi.AutoSize = true;

                // Thêm các control vào panel
                panel.Controls.Add(labelTenVi);
                panel.Controls.Add(labelTongVi);

                // Thêm panel vào flowLayoutPanel
                abc.Controls.Add(panel);
            }
        }

        private void CreatePanelCT(FlowLayoutPanel flpn)
        {
            foreach (ChiTieu chiTieu in chiTieuList)
            {
                Panel newPanel = new Panel();
                newPanel.Size = new Size(195, 35);
                newPanel.BackColor = SystemColors.ControlDark;
                Label label1 = new Label();
                label1.Text = loaiCTBLL.GetTenCTByMaCT(chiTieu); ;
                label1.ForeColor = SystemColors.ControlLightLight;
                label1.Font = new Font(label1.Font, FontStyle.Bold);
                label1.Font = new Font(label1.Font.FontFamily, 9);
                label1.Width = label1.Width;
                label1.Location = new Point(0, 10);

                Label label2 = new Label();
                label2.Text = string.Format("{0:N0}đ", chiTieu.SoTienChitieu);//format số nguyên thành chuỗi
                label2.ForeColor = SystemColors.ControlLightLight;
                label2.Font = new Font(label2.Font, FontStyle.Bold);
                label2.Font = new Font(label2.Font.FontFamily, 9);
                label2.Location = new Point(label1.Right, 10);

                newPanel.Controls.Add(label1);
                newPanel.Controls.Add(label2);

                flpn.Controls.Add(newPanel);
            }
        }

        private void btnThu_Click(object sender, EventArgs e)
        {
        }

        public void UpdateData(int thu, int chi, int tong)
        {
            this.tongThu = thu;
            this.tongChi = chi;
            this.tong = tong;
            UCTongQuan_Load(null, null); // Gọi lại hàm load để cập nhật giao diện
        }
    }
}
