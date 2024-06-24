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
    public partial class AddLoaiCT : Form
    {
        bool define;
        AddChiTieu addformChild;
        LoaiCTBLL loaiBLL = new LoaiCTBLL();
        TaiKhoan taikhoan;
        private static Random random = new Random();
        MainForm mainForm;

        public AddLoaiCT()
        {
            InitializeComponent();
        }

        public AddLoaiCT(bool define, AddChiTieu addformChild, TaiKhoan taikhoan, MainForm mainForm)
        {
            InitializeComponent();
            this.define = define;
            this.addformChild = addformChild;
            this.taikhoan = taikhoan;
            this.mainForm = mainForm;
        }

        private void AddLoaiCTForm_Load(object sender, EventArgs e)
        {

            title.Text = define == true ? "Thêm Khoản Thu" : "Thêm Khoản Chi";
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

        private bool checkNull(TextBox tb)
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show("Vui lòng nhập tên ví", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (!checkNull(txtTenLoaiCT))
            {
                return;
            }

            if (loaiBLL.newLoaiCT(taikhoan, txtTenLoaiCT.Text, GetRDString(5), define) == false)
            {
                string loai = define == true ? " Thu" : " Chi";
                MessageBox.Show("Tạo khoản" + loai + " thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            mainForm.UpdateDataAndUI(taikhoan);
            addformChild.upDateUI();
            this.Close();

        }
    }
}
