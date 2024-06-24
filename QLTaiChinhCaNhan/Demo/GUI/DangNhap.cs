using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using GUI.App;

namespace GUI
{
    public partial class DangNhap : Form
    {
        TaiKhoan taiKhoan = new TaiKhoan();
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        public string mataikhoan = ""; 

        public DangNhap()
        {
            InitializeComponent();
            
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(DangNhap_Paint);
        }


        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void DangNhap_Paint(object sender, PaintEventArgs e)// vẽ hình tam giác
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
            DangKy dangkyf = new DangKy();
            this.Hide();
            dangkyf.ShowDialog();
            this.Close();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            DangKy dangkyf = new DangKy();
            this.Hide();
            dangkyf.ShowDialog();
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            string tenTK = txtUserName.Text;
            string matKhau = txtPass.Text;

            string result = TKBLL.CheckDangNhap(tenTK, matKhau);

            switch (result)
            {
                case "requeid_taikhoan":
                    MessageBox.Show("Tài khoản không thể để trống","Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case "requeid_matkhau":
                    MessageBox.Show("Mật khẩu không thể để trống", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "tài khoản hoặc mật khẩu không chính xác":
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    // Chuyển Form nếu đăng nhập thành công và kiểu người dùng là 'result'
                    MainForm mainForm = new MainForm(result);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                    break;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (string.IsNullOrEmpty(txtPass.Text))
                {
                    txtPass.Focus();
                }
                else
                {
                    btnDangNhap_Click(sender, e); 
                }
            }

        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    txtUserName.Focus();
                }
                else
                {
                    btnDangNhap_Click(sender, e);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
