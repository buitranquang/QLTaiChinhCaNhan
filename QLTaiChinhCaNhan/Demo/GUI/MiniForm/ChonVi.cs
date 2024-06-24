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
    public partial class ChonVi : Form
    {
        private string MaKV = null;
        private string MaVi = null;
        private long checkSoTien;

        private ViBLL viBLL = new ViBLL();
        private TaiKhoan taiKhoan = new TaiKhoan();
        private ChiTieuBLL chiTieuBLL = new ChiTieuBLL();
        KhoanVayBLL khoanVayBLL = new KhoanVayBLL();

        public ChonVi(TaiKhoan tk, string MaKV)
        {
            this.MaKV = MaKV;
            this.taiKhoan = tk;
            InitializeComponent();
        }

        private void ChonVi_Load(object sender, EventArgs e)
        {
            lbTenKV.Text = khoanVayBLL.GetTenKVByMaKV(MaKV);
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
        
    }
}
