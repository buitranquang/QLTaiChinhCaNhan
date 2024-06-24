using Aspose.Words.Tables;
using Aspose.Words;
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ThuVienWinform.Report.AsposeWordExtension;

namespace GUI.App
{
    public partial class UCChiTieu : UserControl
    {
        private ChiTieuBLL chiTieuBLL = new ChiTieuBLL();
        private LoaiCTBLL loaiCTBLL = new LoaiCTBLL();
        private ViBLL viBLL = new ViBLL();
        private TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

        private TaiKhoan taiKhoan;
        private List<ChiTieu> chiTieuList = new List<ChiTieu>();
        private ChiTieu chiTieu2 = new ChiTieu();
        private string checkTG = "Tuần";
        private string maloaiCt;
        private string selectedMaVi;

        private DateTime toDate = DateTime.Now;
        private DateTime fromDate = DateTime.Now.AddDays(-6);

        public UCChiTieu(TaiKhoan tk)
        {
            this.taiKhoan = tk;
            InitializeComponent();
        }

        private void UCChiTieu_Load(object sender, EventArgs e)
        {
            lbTitle.Text = "Thu nhập 7 ngày gần nhất";
            chiTieuList = chiTieuBLL.GetChiTieuByMaTK(taiKhoan.MaTK);
            flpnThu.AutoScroll = true;
            UpdateChart();
            DisplayChiTieuData(flpnThu, true);

            DataTable dt = loaiCTBLL.GetLoaiCTListdt(3, "Chi", taiKhoan) ;


            cbLoaiCT.DisplayMember = "TenLoaiCT";
            cbLoaiCT.ValueMember = "MaLoaiCT";
            cbLoaiCT.DataSource = dt;
            cbLoaiCT.Font = new System.Drawing.Font("Arial Unicode MS", 10);
            cbLoaiCT.SelectedIndexChanged += cbLoaiCT_SelectedIndexChanged; // Đăng ký sự kiện SelectedIndexChanged cho cbLoaiCT

            DataTable dtVi = viBLL.GetViListByMaTK(taiKhoan.MaTK);
            cbVi.DisplayMember = "TenVi";
            cbVi.ValueMember = "MaVi";
            cbVi.DataSource = dtVi;
            cbVi.Font = new System.Drawing.Font("Arial Unicode MS", 10);
            cbVi.SelectedIndexChanged += cbVi_SelectedIndexChanged; // Đăng ký sự kiện SelectedIndexChanged cho cbVi
        }

        public void Update()
        {
            UCChiTieu_Load(null, null);
            UpdateChart();
            DisplayChiTieuData(flpnThu, true);
        }

        private List<Panel> panelList = new List<Panel>(); // Danh sách để lưu trữ các panel

        private void DisplayChiTieuData(FlowLayoutPanel flpn, bool isPositive)
        {
            flpn.Controls.Clear();

            chiTieuList = chiTieuBLL.GetChiTieuByMaTK(taiKhoan.MaTK);
            chiTieuList = chiTieuBLL.FilterByNgayChiTieu(chiTieuList, false, fromDate, toDate);

            foreach (ChiTieu chiTieu in chiTieuList)
            {
                Button newButton = new Button();
                newButton.Size = new Size(247, 35);
                newButton.BackColor = SystemColors.ControlDarkDark;
                newButton.FlatStyle = FlatStyle.Popup;
                newButton.Text = loaiCTBLL.GetTenCTByMaCT(chiTieu).ToString() + "         " + string.Format("{0:N0}đ", chiTieu.SoTienChitieu);
                newButton.ForeColor = SystemColors.Control;
                newButton.Font = new System.Drawing.Font(newButton.Font.FontFamily, 9);

                // Thêm sự kiện click cho button
                newButton.Click += (sender, e) => Button_Click(newButton, EventArgs.Empty);

                flpn.Controls.Add(newButton);
            }
        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Tìm chi tiết ví tương ứng với button được click
                ChiTieu chiTieu = chiTieuList[flpnThu.Controls.IndexOf(clickedButton)];

                chiTieu2 = chiTieu;

                // Hiển thị thông tin chi tiêu tương ứng
                cbVi.SelectedValue = chiTieu.MaVi;
                txtSoTienChiTieu.Text = chiTieu.SoTienChitieu.ToString();
                dateNgayCT.Value = chiTieu.NgayChiTieu.Value;
                cbLoaiCT.SelectedValue = chiTieu.MaLoaiCT;

                // Đổi màu button được click
                foreach (Button button in flpnThu.Controls.OfType<Button>())
                {
                    if (button == clickedButton)
                    {
                        button.BackColor = Color.FromArgb(25, 25, 27);
                    }
                    else
                    {
                        button.BackColor = SystemColors.ControlDark;
                    }
                }
            }
        }

        private void UpdateChart()
        {
            // Lấy danh sách chi tiêu
            chiTieuList = chiTieuBLL.GetChiTieuByMaTK(taiKhoan.MaTK);
            // Lọc danh sách theo ngày chi tiêu
            chiTieuList = chiTieuBLL.FilterByNgayChiTieu(chiTieuList, false, fromDate, toDate);

            // Xóa tất cả các dữ liệu trên biểu đồ trước khi vẽ lại
            chartChiTieu.Series.Clear();

            // Tạo một loạt dữ liệu mới cho biểu đồ
            Series series = new Series("Tổng chi tiêu");
            series.ChartType = SeriesChartType.Column;

            // Nếu đang xem theo Tuần
            if (checkTG == "Tuần")
            {
                // Tạo mảng chứa tổng chi tiêu của mỗi ngày trong tuần
                double[] totalIncome = new double[7];
                DateTime startDate = fromDate.Date;
                DateTime endDate = toDate.Date.AddDays(1); // Thêm 1 ngày vào ngày kết thúc để bao gồm toàn bộ tuần

                // Lặp qua danh sách chi tiêu
                foreach (ChiTieu chiTieu in chiTieuList)
                {
                    // Kiểm tra xem ngày chi tiêu có nằm trong khoảng từ fromDate đến toDate không
                    if (chiTieu.NgayChiTieu >= startDate && chiTieu.NgayChiTieu < endDate && chiTieu.SoTienChitieu < -1)
                    {
                        // Tính số ngày từ fromDate đến ngày chi tiêu
                        int dayIndex = (int)(chiTieu.NgayChiTieu.Value - startDate).Days;

                        totalIncome[dayIndex] += Math.Abs(chiTieu.SoTienChitieu.GetValueOrDefault());
                    }
                }

                // Thêm các điểm dữ liệu vào loạt dữ liệu của biểu đồ
                for (int i = 0; i < 7; i++)
                {
                    DataPoint dataPoint = new DataPoint(i, totalIncome[i]);
                    dataPoint.AxisLabel = fromDate.AddDays(i).ToString("dd/MM");
                    dataPoint.IsValueShownAsLabel = false; // Không hiển thị giá trị làm nhãn
                    dataPoint.Color = Color.Red;
                    series.Points.Add(dataPoint);
                }
            }

            else if (checkTG == "Tháng")
            {
                DateTime currentDate = DateTime.Today;

                if (fromDate.Year == currentDate.Year && fromDate.Month == currentDate.Month)
                {
                    int currentDay = currentDate.Day;
                    int daysInCurrentMonth = DateTime.DaysInMonth(fromDate.Year, fromDate.Month);

                    for (int i = 1; i <= currentDay; i++)
                    {
                        double totalExpenseOfDay = 0;

                        foreach (ChiTieu chiTieu in chiTieuList)
                        {
                            if (chiTieu.NgayChiTieu.HasValue && chiTieu.NgayChiTieu.Value.Day == i && chiTieu.NgayChiTieu.Value.Month == fromDate.Month && chiTieu.NgayChiTieu.Value.Year == fromDate.Year)
                            {
                                totalExpenseOfDay += Math.Abs(chiTieu.SoTienChitieu.GetValueOrDefault());
                            }
                        }

                        DataPoint dataPoint = new DataPoint(i, totalExpenseOfDay);
                        dataPoint.AxisLabel = i.ToString();
                        dataPoint.IsValueShownAsLabel = false; // Không hiển thị giá trị làm nhãn
                        dataPoint.Color = Color.Red;
                        series.Points.Add(dataPoint);
                    }
                }
            }
            if (checkTG == "Năm")
            {
                DateTime currentDate = DateTime.Today;

                // Lặp qua các tháng từ tháng đầu tiên đến tháng hiện tại
                for (int month = 1; month <= currentDate.Month; month++)
                {
                    double totalExpenseOfMonth = 0;

                    foreach (ChiTieu chiTieu in chiTieuList)
                    {
                        if (chiTieu.NgayChiTieu.HasValue && chiTieu.NgayChiTieu.Value.Month == month && chiTieu.NgayChiTieu.Value.Year == fromDate.Year)
                        {
                            totalExpenseOfMonth += Math.Abs(chiTieu.SoTienChitieu.GetValueOrDefault());
                        }
                    }

                    DataPoint dataPoint = new DataPoint(month, totalExpenseOfMonth);
                    dataPoint.AxisLabel = new DateTime(fromDate.Year, month, 1).ToString("MM/yyyy");
                    dataPoint.IsValueShownAsLabel = false; // Không hiển thị giá trị làm nhãn
                    dataPoint.Color = Color.Red;
                    series.Points.Add(dataPoint);
                }
            }

            chartChiTieu.Series.Add(series);
        }

        private void SetButtonColor(Button button)
        {
            btnTuan.BackColor = SystemColors.ControlDark;
            btnTuan.ForeColor = SystemColors.ControlText;
            btnThang.BackColor = SystemColors.ControlDark;
            btnThang.ForeColor = SystemColors.ControlText;
            btnNam.BackColor = SystemColors.ControlDark;
            btnNam.ForeColor = SystemColors.ControlText;
            // Đặt màu cho nút được click
            button.BackColor = Color.FromArgb(25, 25, 27);
            button.ForeColor = SystemColors.Control;
        }

        private void btnTuan_Click_1(object sender, EventArgs e)
        {
            checkTG = "Tuần";
            fromDate = DateTime.Now.AddDays(-6);
            toDate = DateTime.Now;
            UpdateChart();
            SetButtonColor(btnTuan);
        }

        private void btnThang_Click_1(object sender, EventArgs e)
        {
            checkTG = "Tháng";
            fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            toDate = DateTime.Now;
            UpdateChart();
            SetButtonColor(btnThang);
        }

        private void btnNam_Click(object sender, EventArgs e)
        {
            checkTG = "Năm";
            fromDate = new DateTime(DateTime.Now.Year, 1, 1);
            toDate = DateTime.Now;
            UpdateChart();
            SetButtonColor(btnNam);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSoTienChiTieu.Text == "vui lòng chọn chi tiêu")
            {
                MessageBox.Show("Vui lòng chọn chi tiêu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            string maLoaiCT = maloaiCt;

            // Lấy thông tin từ các control trên giao diện
            int maChiTieu = chiTieu2.MaChiTieu;
            int soTienChiTieu = int.Parse(txtSoTienChiTieu.Text);
            DateTime ngayChiTieu = dateNgayCT.Value;

            // Gọi phương thức cập nhật chi tiêu từ BLL
            ChiTieuBLL chiTieuBLL = new ChiTieuBLL();
            chiTieuBLL.UpdateChiTieu(maChiTieu, soTienChiTieu, ngayChiTieu, maloaiCt,selectedMaVi);
            
            // Hiển thị thông báo cập nhật thành công hoặc thất bại
            MessageBox.Show("Cập nhật chi tiêu thành công!");

            this.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtSoTienChiTieu.Text == "vui lòng chọn chi tiêu")
            {
                MessageBox.Show("Vui lòng chọn chi tiêu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            chiTieuBLL.DeleteChiTieu(chiTieu2.MaChiTieu);
            Update();
        }

        private void cbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lưu giá trị mã loại chi tiêu khi chọn từ ComboBox
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox.SelectedItem as DataRowView;
                // Gán giá trị MaLoaiCT cho selectedLoaiCTMa
                maloaiCt = selectedRow["MaLoaiCT"].ToString();
            }
        }

        private void cbVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lưu giá trị mã ví khi chọn từ ComboBox
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                DataRowView selectedRow = comboBox.SelectedItem as DataRowView;
                // Gán giá trị MaVi cho selectedMaVi
                selectedMaVi = selectedRow["MaVi"].ToString();
            }
            else
            {
                selectedMaVi = string.Empty;
            }
        }

        private DateTime LayGiaTriNgay(object dateTK)
        {
            if (dateTK is DateTime)
            {
                return (DateTime)dateTK;
            }
            else if (dateTK is DateTime?)
            {
                return ((DateTime?)dateTK).GetValueOrDefault(DateTime.MinValue);
            }
            else
            {
                // Xử lý trường hợp không mong muốn hoặc gán giá trị mặc định
                return DateTime.MinValue; // Hoặc giá trị mặc định khác
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Document baoCao = new Document("template\\danhsachthuchi.docx");

            DateTime dateTK = LayGiaTriNgay(taiKhoan.DateTK);

            string stringDateTK = dateTK.ToString("dd / MM / yyyy");

            baoCao.MailMerge.Execute(new[] { "Thu_Chi" }, new[] { "CHI TIÊU" });
            baoCao.MailMerge.Execute(new[] { "TenTK" }, new[] { taiKhoan.TenTK });
            baoCao.MailMerge.Execute(new[] { "SDT" }, new[] { taiKhoan.SDT.ToString() });
            baoCao.MailMerge.Execute(new[] { "DateTK" }, new[] { stringDateTK });
            baoCao.MailMerge.Execute(new[] { "ThanhPho" }, new[] { taiKhoan.ThanhPho });
            baoCao.MailMerge.Execute(new[] { "SLVi" }, new[] { taiKhoanBLL.LaySoLuongVi(taiKhoan).ToString() });

            Table bangtaikhoan = baoCao.GetChild(NodeType.Table, 0, true) as Table;
            int Stt = 1;

            // Chèn vào hàng cuối cùng
            bangtaikhoan.InsertRows(bangtaikhoan.Rows.Count - 1, 1, chiTieuList.Count);

            int hangHienTai = bangtaikhoan.Rows.Count - chiTieuList.Count; // Cập nhật lại chỉ số của hàng hiện tại

            foreach (var chiTieu3 in chiTieuList)
            {
                DateTime dateValue = LayGiaTriNgay(chiTieu3.NgayChiTieu);

                string formattedDate = dateValue.ToString("dd / MM / yyyy");

                bangtaikhoan.PutValue(hangHienTai, 0, Stt.ToString());
                bangtaikhoan.PutValue(hangHienTai, 1, loaiCTBLL.GetTenCTByMaCT(chiTieu3));
                bangtaikhoan.PutValue(hangHienTai, 2, chiTieu3.SoTienChitieu.ToString());
                bangtaikhoan.PutValue(hangHienTai, 3, viBLL.GetTenViByMaVi(chiTieu3.MaVi));
                bangtaikhoan.PutValue(hangHienTai, 4, formattedDate);

                hangHienTai++;
                Stt++;
            }

            baoCao.SaveAndOpenFile("DanhSachThuNhap" + taiKhoan.TenTK + ".doc");
        }
    }
}
