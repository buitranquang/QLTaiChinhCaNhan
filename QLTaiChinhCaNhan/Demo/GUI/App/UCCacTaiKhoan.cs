using Aspose.Words.Drawing;
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
    public partial class UCCacTaiKhoan : UserControl
    {
        private TaiKhoan taiKhoan;
        private Vi taggetVi = new Vi();
        private TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        private ChiTieuBLL chiTieuBLL = new ChiTieuBLL();
        private ViBLL viBLL = new ViBLL();
        private MainForm mainForm;

        public UCCacTaiKhoan(TaiKhoan taiKhoan, MainForm mainForm)
        {
            this.taiKhoan = taiKhoan;
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void LoadVi()
        {
            flpnVi.Controls.Clear();

            List<Vi> viList = viBLL.GetViByMaTK(taiKhoan);

            foreach (var vi in viList)
            {
                System.Windows.Forms.Button button = new System.Windows.Forms.Button();
                button.BackColor = SystemColors.ControlDarkDark;
                button.Size = new Size(332, 50);
                button.Name = "btn" + vi.MaVi;
                button.Tag = vi;
                button.Click += new EventHandler(ButtonVi_Click);
                button.Text = vi.TenVi + "\n" + string.Format("{0:N0}đ", chiTieuBLL.TinhTongSoTien(vi.MaVi));
                button.ForeColor = SystemColors.ControlLightLight;
                button.Font = new Font("Microsoft Sans Serif", 9F);
                button.FlatStyle = FlatStyle.Flat;

                flpnVi.Controls.Add(button);
            }
        }

        private void ButtonVi_Click(object sender, EventArgs e)
        {
            // Đặt màu sắc mặc định cho tất cả các button
            foreach (Control control in flpnVi.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = SystemColors.ControlDark;
                }
            }

            System.Windows.Forms.Button clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                // Lấy giá trị từ thuộc tính Tag của nút
                taggetVi = (Vi)clickedButton.Tag;
                lbMaVi.Text = taggetVi.MaVi;
                txtTenVi.Text = taggetVi.TenVi;
                lbSoDu.Text = chiTieuBLL.TinhTongSoTien(taggetVi.MaVi) + "đ";

                // Đặt màu sắc cho button được click
                clickedButton.BackColor = Color.FromArgb(25, 25, 27);
            }
        }

        private void UCCacTaiKhoan_Load(object sender, EventArgs e)
        {
            mainForm.Update();
            flpnVi.AutoScroll = true;
            LoadVi();
            lbSLVi.Text = taiKhoanBLL.LaySoLuongVi(taiKhoan).ToString();
        }

        public void Update(TaiKhoan tk)
        {
            this.taiKhoan = tk;
            txtTenVi.Text = null;
            UCCacTaiKhoan_Load(null,null);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddVi addViForm = new AddVi(taiKhoan, mainForm);
            addViForm.ShowDialog();
        }

        private void btnUDTenVi_Click(object sender, EventArgs e)
        {
            string newTenVi = txtTenVi.Text.Trim();

            if (string.IsNullOrEmpty(newTenVi))
            {
                MessageBox.Show("Tên ví không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(taggetVi.MaVi))
            {
                MessageBox.Show("Vui lòng chọn ví muốn cập nhật", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool isUpdated = viBLL.UpdateTenVi(taggetVi.MaVi, newTenVi);
                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật tên ví thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update(taiKhoan);
                }
                else
                {
                    MessageBox.Show("Cập nhật tên ví thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaVi_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taggetVi.MaVi))
            {
                MessageBox.Show("Vui lòng chọn ví muốn xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ví này không? xóa ví sẽ dẫn theo các chi tiêu liên quan", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = viBLL.DeleteVi(taggetVi.MaVi,taiKhoan);
                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa ví thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Update(taiKhoan);
                    }
                    else
                    {
                        MessageBox.Show("Xóa ví thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
