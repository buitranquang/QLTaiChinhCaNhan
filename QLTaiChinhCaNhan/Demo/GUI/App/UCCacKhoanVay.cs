using BLL;
using DTO;
using GUI.MiniForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.App
{
    public partial class UCCacKhoanVay : UserControl
    {
        private string MaKV;
        TaiKhoan taiKhoan;
        List<KhoanVay> khoanVayList;

        KhoanVayBLL khoanVayBLL = new KhoanVayBLL();

        public UCCacKhoanVay(TaiKhoan tk)
        {
            this.taiKhoan = tk;
            InitializeComponent();
        }

        private void UCCacKhoanVay_Load(object sender, EventArgs e)
        {
            khoanVayList = khoanVayBLL.LayDanhSachKhoanVay(taiKhoan);
            LoadDanhSachKhoanVay();
        }

        public void Update(TaiKhoan tk)
        {
            
            UCCacKhoanVay_Load(null, null);
            LoadDanhSachKhoanVay();
        }

        private Button currentSelectedButton;

        private void LoadDanhSachKhoanVay()
        {
            try
            {
                flpnDaThanhToan.Controls.Clear();
                flpnChuaThanhToan.Controls.Clear();
                flpnHetHan.Controls.Clear();

                // Lấy danh sách các khoản vay từ BLL
                List<KhoanVay> danhSachKhoanVay = khoanVayBLL.LayDanhSachKhoanVay(taiKhoan);

                // Duyệt danh sách và hiển thị trên giao diện
                foreach (var khoanVay in danhSachKhoanVay)
                {
                    // Tạo button để hiển thị thông tin của từng khoản vay
                    Button btnKhoanVay = new Button();
                    btnKhoanVay.Text = $"{khoanVay.TenKV}      {khoanVay.NgayHan?.ToString("dd-MM-yyyy")}\n{string.Format("{0:N0}đ", khoanVay.SoTienTra)}";
                    btnKhoanVay.Tag = khoanVay.MaKV; // Gán ID của khoản vay vào thuộc tính Tag của button

                    // Tùy chỉnh các thuộc tính của button
                    btnKhoanVay.Size = new Size(332, 46);
                    btnKhoanVay.ForeColor = SystemColors.Control;
                    btnKhoanVay.BackColor = SystemColors.ControlDarkDark;
                    btnKhoanVay.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                    btnKhoanVay.TextAlign = ContentAlignment.MiddleCenter;
                    btnKhoanVay.FlatStyle = FlatStyle.Flat;

                    // Kiểm tra nếu khoản vay đã thanh toán
                    if (khoanVay.TrangThai == "Đã Thanh Toán")
                    {
                        flpnDaThanhToan.Controls.Add(btnKhoanVay);
                    }
                    // Kiểm tra nếu ngày thanh toán đã qua so với hôm nay và chưa thanh toán
                    else if (khoanVay.NgayHan < DateTime.Today && khoanVay.TrangThai == "Chưa Thanh Toán")
                    {
                        flpnHetHan.Controls.Add(btnKhoanVay);
                        btnKhoanVay.Click += (sender, e) => HandleButtonKhoanVayClick(sender, khoanVay);
                    }
                    // Nếu không thỏa mãn cả hai điều kiện trên, hiển thị trong flpnChuaThanhToan
                    else
                    {
                        flpnChuaThanhToan.Controls.Add(btnKhoanVay);
                        btnKhoanVay.Click += (sender, e) => HandleButtonKhoanVayClick(sender, khoanVay);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (nếu có)
                MessageBox.Show("Lỗi khi load danh sách khoản vay: " + ex.Message);
            }
        }

        private void HandleButtonKhoanVayClick(object sender, KhoanVay khoanVay)
        {
            // Gán giá trị của khoản vay vào các textbox tương ứng
            MaKV = khoanVay.MaKV;
            txtTenKV.Text = khoanVay.TenKV;
            txtSoTienTra.Text = khoanVay.SoTienTra.ToString();
            txtNgayHan.Text = khoanVay.NgayHan?.ToString("dd-MM-yyyy");
            txtTrangThai.Text = khoanVay.TrangThai.ToString();

            // Đổi màu cho button hiện tại và button mới
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = SystemColors.ControlDarkDark;
            }

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.BackColor = Color.FromArgb(25, 25, 27);
                currentSelectedButton = clickedButton;
            }
        }


        private void btnUDTenVi_Click(object sender, EventArgs e)
        {
            if(MaKV == null)
            {
                MessageBox.Show("Vui lòng chọn khoản vay để thanh toán", "thông báo", MessageBoxButtons.OK);
                return;
            }

            ChonVi chonVi = new ChonVi(taiKhoan, MaKV);
            chonVi.Show();

           /* if (currentSelectedButton != null)
            {
                string khoanVayId = currentSelectedButton.Tag.ToString();
                khoanVayBLL.CapNhatTrangThai(khoanVayId, "Đã Thanh Toán");
                LoadDanhSachKhoanVay();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khoản vay để cập nhật trạng thái.");
            }*/
        }

        private void btnAddKV_Click(object sender, EventArgs e)
        {
            AddKhoanVay form = new AddKhoanVay(taiKhoan,this);
            form.ShowDialog();
        }

        private void btnXoaVi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(taiKhoan.MaTK))
                {
                    // Kiểm tra xem người dùng có muốn xóa không
                    DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa các khoản vay đã thanh toán?", "Xác nhận xóa", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        // Xác nhận xóa
                        khoanVayBLL.XoaKhoanVayTheoTaiKhoanVaTrangThai(taiKhoan);
                        LoadDanhSachKhoanVay();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập vào mã tài khoản.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa các khoản vay: " + ex.Message);
            }
        }

    }
}
