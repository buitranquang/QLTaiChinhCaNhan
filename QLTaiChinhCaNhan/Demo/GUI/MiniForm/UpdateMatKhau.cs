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

namespace GUI.MiniForm
{
    public partial class UpdateMatKhau : Form
    {
        TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        TaiKhoan taikhoan;

        public UpdateMatKhau(TaiKhoan tk)
        {
            this.taikhoan = tk;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string oldPassword = txtMatKhauCu.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                bool isUpdated = taiKhoanBLL.UpdatePassword(taikhoan.MaTK, oldPassword, newPassword);

                if (isUpdated)
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhauCu.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
