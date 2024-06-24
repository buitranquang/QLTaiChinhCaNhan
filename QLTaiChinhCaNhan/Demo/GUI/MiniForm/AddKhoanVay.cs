using Aspose.Words.Drawing;
using BLL;
using DTO;
using GUI.App;
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
    public partial class AddKhoanVay : Form
    {
        TaiKhoan taiKhoan;

        KhoanVayBLL khoanVayBLL = new KhoanVayBLL();
        ChiTieuBLL chiTieuBLL = new ChiTieuBLL();
        ViBLL viBLL = new ViBLL();
        private string MaVi = null;
        private int checkSoTien;

        UCCacKhoanVay ucckv;

        public AddKhoanVay(TaiKhoan tk, UCCacKhoanVay kv)
        {
            this.ucckv = kv;
            this.taiKhoan = tk;
            InitializeComponent();
        }

        private void AddKhoanVay_Load(object sender, EventArgs e)
        {
            LoadVi();
        }

        private void LoadVi()
        {
            List<Vi> viList = viBLL.GetViByMaTK(taiKhoan);

            foreach (var vi in viList)
            {
                System.Windows.Forms.Button button = new System.Windows.Forms.Button();
                button.BackColor = SystemColors.ControlDarkDark;
                button.Size = new Size(200, 37);
                button.Name = "btn" + vi.MaVi;
                button.Tag = vi.MaVi;
                button.Click += new EventHandler(ButtonVi_Click);
                button.Text = vi.TenVi + "      " + chiTieuBLL.TinhTongSoTien(vi.MaVi) + "đ";
                button.ForeColor = SystemColors.ControlLightLight;
                button.FlatStyle = FlatStyle.Flat;

                flpnVi.Controls.Add(button);
            }
        }

        private void ButtonVi_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                this.MaVi = clickedButton.Tag.ToString();
                checkSoTien = chiTieuBLL.TinhTongSoTien(this.MaVi); // Cập nhật giá trị checkSoTien

                foreach (Control control in flpnVi.Controls)
                {
                    if (control is System.Windows.Forms.Button btn)
                    {
                        if (btn == clickedButton)
                        {
                            btn.BackColor = Color.FromArgb(25, 25, 27);
                        }
                        else
                        {
                            btn.BackColor = SystemColors.ControlDark;
                        }
                    }
                }
            }
        }

        public string RanDum3KyTu()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] stringChars = new char[3];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                KhoanVay khoanVayMoi = new KhoanVay
                {
                    MaKV = taiKhoan.MaTK.ToString() + "Vay" + RanDum3KyTu(),
                    MaTK = taiKhoan.MaTK,
                    TenKV = txtTenKVMoi.Text,
                    SoTienTra = long.Parse(txtSoTienTraMoi.Text),
                    NgayHan = DateNgayHan.Value,
                    TrangThai = "Chưa Thanh Toán"
                };

                khoanVayBLL.ThemKhoanVay(khoanVayMoi);
                ucckv.Update(taiKhoan);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khoản vay: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
