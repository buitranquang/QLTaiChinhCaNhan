using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{

    public partial class DangKy : Form
    {
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        ViBLL vibll = new ViBLL();
        private DateTimePicker dateTimePickerDate;

        public DangKy()
        {
            InitializeComponent();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(DangKy_Paint);
        }

        private void DangKy_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(25, 25, 27), 2);
            SolidBrush brush = new SolidBrush(Color.FromArgb(25, 25, 27)); // Màu tô

            // Tạo mảng các điểm để vẽ tam giác
            Point[] points = new Point[]
            {
                new Point(0, 0), // Điểm trên cùng
                new Point(300, 0), // Điểm dưới bên phải
                new Point(100, 478),   // Điểm dưới bên trái
                new Point(0, 478),
            };

            // Vẽ tam giác
            g.DrawPolygon(pen, points);
            //tô
            g.FillPolygon(brush, points);

        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            DangNhap dangNhapf = new DangNhap();
            this.Hide();
            dangNhapf.ShowDialog();
            this.Close();
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            dateTimePickerDate = new DateTimePicker();
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Value = DateTime.Now;
            DateTime selectedDate = dateTimePickerDate.Value;
            if (CheckInput() == false)
            {
                return;
            }
            if (!IsValidPhoneNumber(txtSDT.Text))
            {
                MessageBox.Show("số điện thoại phải đủ 10 số","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sdt = xoa0DauChuoi(txtSDT.Text);
            // Chuyển đổi số điện thoại sang kiểu int
            long IntSDT = long.Parse(sdt);

            TaiKhoan taiKhoan = new TaiKhoan
            {
                MaTK = txtTK.Text + sdt,    
                TenTK = txtTK.Text,
                MatKhau = txtMK.Text,
                SDT = IntSDT,
                ThanhPho = txtThanhPho.Text,
                DateTK = selectedDate,
                TenUser = txtTenUser.Text
            };

            // Thực hiện thêm mới bản ghi vào bảng TaiKhoan
            bool kqtk = tkBLL.NewTaiKhoan(taiKhoan);
            bool kqvi = vibll.newVi(taiKhoan);

            // Hiển thị thông báo dựa trên kết quả và quay vè form đăng nhập
            if (kqtk)
            {
                MessageBox.Show("Đăng ký thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (kqvi)
                {
                    // Hiển thị lại form đăng nhập
                    DangNhap formDangNhap = new DangNhap();
                    this.Hide();
                    formDangNhap.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký Ví thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Đăng ký tài khoản thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool IsValidPhoneNumber(string sdt)
        {
            long parsedValue;
            return sdt.Length == 10 && long.TryParse(sdt, out parsedValue);

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtTK.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtThanhPho.Text) ||
                string.IsNullOrWhiteSpace(txtMK.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!tkBLL.CheckUsernameAvailability(txtTK.Text))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        
        private string xoa0DauChuoi(string phoneNumber)
        {
            // Kiểm tra xem số đầu tiên có phải là '0' không
            if (phoneNumber.StartsWith("0"))
            {
                // Xóa ký tự đầu tiên nếu là '0'
                phoneNumber = phoneNumber.Substring(1);
            }
            return phoneNumber;
        }

        private void DangKy_Load_1(object sender, EventArgs e)
        {

        }
    }
}
