using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Aspose.Words.Drawing;
using GUI.App;

namespace GUI.MiniForm
{
    public partial class AddVi : Form
    {

        public event EventHandler<Vi> ViAdded;
        private static Random random = new Random();

        ViBLL viBLL = new ViBLL();
        TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

        TaiKhoan taiKhoan;
        MainForm mainForm;

        public AddVi()
        {
            InitializeComponent();
        }
        public AddVi(TaiKhoan taiKhoan, MainForm mainForm)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
            this.mainForm = mainForm;
        }

        public static string GetRDString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }

        private void btnAddVi_Click(object sender, EventArgs e)
        {

            // Kiểm tra xem txtTenVi có rỗng không
            if (string.IsNullOrWhiteSpace(txtTenVi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên ví.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Không thực hiện các thao tác tiếp theo nếu tên ví rỗng
            }

            // Tiếp tục thêm ví nếu tên ví không rỗng
            bool newVi = viBLL.newVi(taiKhoan, txtTenVi.Text, GetRDString(3));
            if (newVi)
            {
                taiKhoanBLL.UpdateSLVi(taiKhoan);
                txtTenVi.Text = null;

                // Truy cập MainForm từ UCCacTaiKhoan
                MainForm mainForm = this.mainForm as MainForm;
                if (mainForm != null)
                {
                    // Gọi phương thức UpdateDataAndUI của MainForm để cập nhật dữ liệu và giao diện
                    mainForm.UpdateDataAndUI(taiKhoan);
                }

                this.Close(); // Đóng form sau khi thêm ví thành công
            }
        }



        private void AddVi_Load(object sender, EventArgs e)
        {

        }

        private void AddVi_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTenVi_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtTenVi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAddVi_Click(sender, e);
               
            }
        }
    }
}
