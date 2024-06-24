using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Words;
using ThuVienWinform.Report.AsposeWordExtension;
using BLL;
using GUI.MiniForm;
using Aspose.Words.Tables;
using System.Runtime.InteropServices.ComTypes;


namespace GUI.App
{
    public partial class UCNguoiDung : UserControl
    {


        ChiTieuBLL chiTieuBLL = new ChiTieuBLL();
        LoaiCTBLL loaict = new LoaiCTBLL();
        TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        ViBLL viBLL = new ViBLL();
        List<Vi> viList = new List<Vi>();
        List<ChiTieu> chiTieuList = new List<ChiTieu>();
        LoaiCTBLL loaiCTBLL = new LoaiCTBLL();

        List<LoaiCT> listLoaiCT;
        List<LoaiCT> listLoaiCT2;

        MainForm mainForm;
        TaiKhoan taikhoan;


        private string loai = null;
        private string maLoaiCTInButton;
        private List<System.Windows.Forms.Button> buttons;

        public UCNguoiDung()
        {
            InitializeComponent();
        }


        public UCNguoiDung(MainForm mainform,TaiKhoan taikhoan)
        {
            InitializeComponent();
            this.mainForm = mainform;
            this.taikhoan = taikhoan;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mainForm.Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
            this.mainForm.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã đổi ảnh đại diện","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void UCNguoiDung_Load(object sender, EventArgs e)
        {

             listLoaiCT = loaict.GetLoaiCTList(taikhoan.MaTK.Length + 3, "Thu" + taikhoan.MaTK, taikhoan);
            listLoaiCT2 = loaict.GetLoaiCTList(taikhoan.MaTK.Length + 3, "Chi" + taikhoan.MaTK, taikhoan);

            DateTime dateValue = LayGiaTriNgay(taikhoan.DateTK);

            string formattedDate = dateValue.ToString("dd / MM / yyyy");

            lbTenUser.Text = taikhoan.TenUser;
            lbTenTK.Text = taikhoan.TenTK;
            lbSDT.Text = taikhoan.SDT.ToString();
            lbDate.Text = formattedDate;
            lbDiaChi.Text = taikhoan.ThanhPho;
            lbSLVi.Text = "Hiện có " + taiKhoanBLL.LaySoLuongVi(taikhoan).ToString() + " tài khoản";
            LoadViPanels(flpnVi);
            LoadLoaiCT(listLoaiCT, listLoaiCT2);

            flpnVi.AutoScroll = true;
            flpnVi.AutoScroll = true;
        }

        public void UpdateData(TaiKhoan tk)
        {
            this.taikhoan = tk;
            UCNguoiDung_Load(null, null);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DateTime dateValue = LayGiaTriNgay(taikhoan.DateTK);

            string formattedDate = dateValue.ToString("dd / MM / yyyy");

            Document baoCao = new Document("template\\MauThongTinUser.doc");
            baoCao.MailMerge.Execute(new[] { "TenTK" }, new[] { taikhoan.TenTK });
            baoCao.MailMerge.Execute(new[] { "SDT" }, new[] { taikhoan.SDT.ToString() });
            baoCao.MailMerge.Execute(new[] { "DateTK" }, new[] { formattedDate });
            baoCao.MailMerge.Execute(new[] { "ThanhPho" }, new[] { taikhoan.ThanhPho });
            baoCao.MailMerge.Execute(new[] { "SLVi" }, new[] { taiKhoanBLL.LaySoLuongVi(taikhoan).ToString() });

            Table bangtaikhoan = baoCao.GetChild(NodeType.Table, 1, true) as Table;
            int Stt = 1;

            // Chèn vào hàng cuối cùng
            bangtaikhoan.InsertRows(bangtaikhoan.Rows.Count - 1, 1, viList.Count);

            int hangHienTai = bangtaikhoan.Rows.Count - viList.Count; // Cập nhật lại chỉ số của hàng hiện tại

            foreach (var Vi in viList)
            {
                bangtaikhoan.PutValue(hangHienTai, 0, Stt.ToString());
                bangtaikhoan.PutValue(hangHienTai, 1, Vi.MaVi);
                bangtaikhoan.PutValue(hangHienTai, 2, Vi.TenVi);
                bangtaikhoan.PutValue(hangHienTai, 3, chiTieuBLL.TinhTongSoTien(Vi.MaVi).ToString());

                hangHienTai++;
                Stt++;
            }

            chiTieuList = chiTieuBLL.GetChiTieuByMaTK(taikhoan.MaTK);

            Table bangthuchi = baoCao.GetChild(NodeType.Table, 2, true) as Table;
            int Stt2 = 1;

            // Chèn vào hàng cuối cùng
            bangthuchi.InsertRows(bangthuchi.Rows.Count - 1, 1, chiTieuList.Count);

            int hangHienTai2 = bangthuchi.Rows.Count - chiTieuList.Count; // Cập nhật lại chỉ số của hàng hiện tại

            foreach (var chiTieu3 in chiTieuList)
            {
                DateTime chiTieuDate = LayGiaTriNgay(chiTieu3.NgayChiTieu); // Đã đổi tên biến

                string formattedDate2 = chiTieuDate.ToString("dd / MM / yyyy");

                bangthuchi.PutValue(hangHienTai2, 0, Stt2.ToString());
                bangthuchi.PutValue(hangHienTai2, 1, loaiCTBLL.GetTenCTByMaCT(chiTieu3));
                bangthuchi.PutValue(hangHienTai2, 2, chiTieu3.SoTienChitieu.ToString());
                bangthuchi.PutValue(hangHienTai2, 3, viBLL.GetTenViByMaVi(chiTieu3.MaVi));
                bangthuchi.PutValue(hangHienTai2, 4, formattedDate2);

                hangHienTai2++;
                Stt2++;
            }


            listLoaiCT = loaict.GetLoaiCTList(taikhoan.MaTK.Length + 3, "Thu" + taikhoan.MaTK, taikhoan);
            listLoaiCT2 = loaict.GetLoaiCTList(taikhoan.MaTK.Length + 3, "Chi" + taikhoan.MaTK, taikhoan);

            List<LoaiCT> allLoaiCT = new List<LoaiCT>();
            allLoaiCT.AddRange(listLoaiCT);
            allLoaiCT.AddRange(listLoaiCT2);

            Table bangLoaiCT = baoCao.GetChild(NodeType.Table, 0, true) as Table;
            int Stt3 = 1;

            // Chèn vào hàng cuối cùng
            bangLoaiCT.InsertRows(bangLoaiCT.Rows.Count - 1, 1, allLoaiCT.Count);

            int hangHienTai3 = bangLoaiCT.Rows.Count - allLoaiCT.Count;

            foreach (LoaiCT loaiCT in allLoaiCT)
            {
                bangLoaiCT.PutValue(hangHienTai3, 0, Stt3.ToString());
                bangLoaiCT.PutValue(hangHienTai3, 1, loaiCT.TenLoaiCT);
                hangHienTai3++;
                Stt3++;
            }

            baoCao.SaveAndOpenFile("ThongTinUser" + taikhoan.TenTK + ".doc");
        }


        private void LoadViPanels(FlowLayoutPanel abc)
        {
            abc.Controls.Clear();

            viList = viBLL.GetViByMaTK(taikhoan);
            // Lấy danh sách các ví
            foreach (var vi in viList)
            {
                // Tạo panel mới
                Panel panel = new Panel();
                panel.BackColor = SystemColors.ControlDark;
                panel.Size = new Size(160, 40);

                // Tạo Label để hiển thị tên Ví
                Label lbtenVi = new Label();
                lbtenVi.Text = vi.TenVi;
                lbtenVi.Location = new Point((panel.Width - TextRenderer.MeasureText(lbtenVi.Text, lbtenVi.Font).Width)/2, 10);
                lbtenVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Regular);

                // Thêm các control vào panel
                panel.Controls.Add(lbtenVi);

                // Thêm panel vào flowLayoutPanel
                abc.Controls.Add(panel);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUDTenTK.Text) || string.IsNullOrEmpty(txtUDSDT.Text) || string.IsNullOrEmpty(txtUDThanhPho.Text))
            {
                MessageBox.Show("Vui lòng bấm nút cập nhật thông tin để bắt đầu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenTK = txtUDTenTK.Text;
            long sdt;
            if (!long.TryParse(txtUDSDT.Text, out sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string thanhPho = txtUDThanhPho.Text;

            try
            {
                bool isUpdated = taiKhoanBLL.UpdateTaiKhoan(taikhoan.MaTK, tenTK, sdt, thanhPho, txtTenUser.Text);

                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cập nhật lại thông tin của đối tượng taikhoan
                    taikhoan.TenTK = tenTK;
                    taikhoan.SDT = sdt;
                    taikhoan.ThanhPho = thanhPho;

                    txtUDTenTK.Text = null;
                    txtUDSDT.Text = null;
                    txtUDThanhPho.Text = null;

                    // Cập nhật lại danh sách các ví
                    LoadViPanels(flpnVi);
                    UpdateData(taikhoan);
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLoaiCT(List<LoaiCT> listLoaiCT, List<LoaiCT> listLoaiCT2)
        { 

            flpnLoaiCT.Controls.Clear();

            foreach (LoaiCT loaiCT in listLoaiCT)
            {
                CreatButton(loaiCT);
            }
            foreach (LoaiCT loaiCT2 in listLoaiCT2)
            {
                CreatButton(loaiCT2);
            }

        }

        private void CreatButton(LoaiCT loaiCT)
        {
            Panel panel = new Panel();
            panel.Size = new Size(250, 30);
            panel.BackColor = SystemColors.ControlDark;

            Label label = new Label();
            label.Text = loaiCT.TenLoaiCT;
            label.AutoSize = true;
            label.Location = new Point(10, 5);

            // Tạo nút "X"
            Button deleteButton = new Button();
            deleteButton.Text = "X";
            deleteButton.ForeColor = Color.FromArgb(25, 25, 27);
            deleteButton.Size = new Size(25, 25);
            deleteButton.Location = new Point(panel.Width - deleteButton.Width - 10, 2); 

            deleteButton.Click += (sender, e) => DeleteLoaiCTHandler(loaiCT);

            // Thêm label và nút vào panel
            panel.Controls.Add(label);
            panel.Controls.Add(deleteButton);

            // Thêm panel vào FlowLayoutPanel
            flpnLoaiCT.Controls.Add(panel);
        }

        private void DeleteLoaiCTHandler(LoaiCT loaiCT)
        {
            var result = MessageBox.Show($"Xác nhận khi xóa {loaiCT.TenLoaiCT} sẽ kéo theo các chi tiêu liên quan ?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                try
                {
                    loaiCTBLL.DeleteLoaiCT(loaiCT);
                    UpdateData(taikhoan);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xóa loại chi tiêu thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtUDTenTK.Text = taikhoan.TenTK.ToString();
            txtUDSDT.Text = taikhoan.SDT.ToString();
            txtUDThanhPho.Text = taikhoan.ThanhPho.ToString();
            txtTenUser.Text = taikhoan.TenUser.ToString();

            btnSua.Visible = true;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            UpdateMatKhau mk = new UpdateMatKhau(taikhoan);
            mk.ShowDialog();
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            mainForm.Hide();
            taiKhoanBLL.XoaTaiKhoan(taikhoan.MaTK);
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
            mainForm.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
