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
    public partial class AddChiTieu : Form
    {
        ChiTieuBLL chitieu = new ChiTieuBLL();
        LoaiCTBLL loaict = new LoaiCTBLL();
        ChiTieuBLL chiTieuBLL = new ChiTieuBLL();
        ViBLL viBLL = new ViBLL();

        private DateTimePicker dateTimePickerDate;

        bool define;
        private TaiKhoan taikhoan = new TaiKhoan();
        MainForm mainform;
        private string MaVi = null;
        private bool checkNewTK;
        private string loai = null;
        private string maLoaiCTInButton;
        private int checkSoTien;
        private List<System.Windows.Forms.Button> buttons;

        public AddChiTieu()
        {
            InitializeComponent();
        }

        public AddChiTieu(MainForm mf, TaiKhoan tk, bool a, bool checkNewTK = false)
        {
            InitializeComponent();
            this.taikhoan = tk;
            this.mainform = mf;
            this.define = a;
            this.checkNewTK = checkNewTK;

            dateTimePickerDate = new DateTimePicker();
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn ví chưa
            if (string.IsNullOrEmpty(MaVi))
            {
                MessageBox.Show("Vui lòng chọn ví trước khi tạo chi tiêu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem người dùng đã nhập số tiền hợp lệ chưa
            int soTienChiTieu;
            if (!int.TryParse(txtSoTienChiTieu.Text, out soTienChiTieu) || soTienChiTieu <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền chi tiêu hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            checktxtSoTienChiTieu();

            // Chỉ kiểm tra số tiền trong ví và số tiền chi tiêu nếu đang thêm chi tiêu (define == false)
            if (!define)
            {
                int soTienTrongVi = chiTieuBLL.TinhTongSoTien(MaVi);
                if (soTienTrongVi < soTienChiTieu)
                {
                    MessageBox.Show("Số dư trong ví không đủ để thực hiện giao dịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Thực hiện tạo chi tiêu hoặc thu nhập
            bool result = chiTieuBLL.NewChiTieu(checktxtSoTienChiTieu(), dateTimePickerDate.Value, maLoaiCTInButton, MaVi, taikhoan.MaTK);
          

            if (result)
            {
                // Cập nhật dữ liệu và giao diện chính
                mainform.UpdateDataAndUI(taikhoan);

                this.Close();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi tạo chi tiêu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtSoTienChiTieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int checktxtSoTienChiTieu()
        {
            int intSoTienChiTieu = 0;

                intSoTienChiTieu = int.Parse(txtSoTienChiTieu.Text);

                if (define == true)
                {
                    return intSoTienChiTieu;
                }
                else{
                    return intSoTienChiTieu - intSoTienChiTieu *2;
                }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            LoadText();
            loadLoaiCT();
            LoadVi();
            flpnLoaiCT.AutoScroll = true;
            flpnVi.AutoScroll = true;

            if (checkNewTK == true)
            {
                MessageBox.Show("Vui lòng nhập số dư để bắt đầu sử dụng phần mềm", "thông báo", MessageBoxButtons.OK);
            }
        }

        private void LoadVi()
        {
            List<Vi> viList = viBLL.GetViByMaTK(taikhoan);

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

        private void LoadText()
        {
            if (define == true)
            {
                NameForm.Text = "Thêm Thu Nhập Hôm Nay";
                lbTien.Text = "Số Tiền Thu Nhập :";
                loai = "Thu";
            }
            else
            {
                NameForm.Text = "Thêm Chi Tiêu Hôm Nay";
                lbTien.Text = "Số Tiền Chi Tiêu :";
                loai = "chi";
            }

            NameForm.Location = new Point(
                (this.Width - NameForm.Width) / 2,
                NameForm.Location.Y
            );
        }

        private void loadLoaiCT()
        {
            buttons = new List<System.Windows.Forms.Button>();
            List<LoaiCT> listLoaiCT = loaict.GetLoaiCTList(3, loai, taikhoan);
            List<LoaiCT> listLoaiCT2 = loaict.GetLoaiCTList(taikhoan.MaTK.Length, loai + taikhoan.MaTK, taikhoan);

            foreach (LoaiCT loaiCT in listLoaiCT)
            {
                CreateButton(loaiCT.TenLoaiCT, loaiCT.MaLoaiCT);
            }
            foreach (LoaiCT loaiCT2 in listLoaiCT2)
            {
                CreateButton(loaiCT2.TenLoaiCT, loaiCT2.MaLoaiCT);
            }

            CreateButton("...", "addLoaiCT", addLoaiCT_Click);
        }

        public void upDateUI()
        {
            flpnLoaiCT.Controls.Clear();
            loadLoaiCT();
        }

        private void CreateButton(string buttonText, string buttonName, EventHandler clickHandler = null)
        {
            System.Windows.Forms.Button newButton = new System.Windows.Forms.Button();
            newButton.Size = new Size(95, 40);
            newButton.BackColor = SystemColors.ControlDarkDark;
            newButton.Text = buttonText;
            newButton.Name = buttonName;
            newButton.ForeColor = SystemColors.ControlLightLight;
            newButton.FlatStyle = FlatStyle.Popup;
            newButton.Font = new Font(newButton.Font.FontFamily, 8);
            newButton.Location = new Point(0, 10);

            if (clickHandler != null)
            {
                newButton.Click += clickHandler;
            }
            else
            {
                newButton.Click += ButtonLoaiCT_Click;
            }

            buttons.Add(newButton);
            flpnLoaiCT.Controls.Add(newButton);
        }

        private void addLoaiCT_Click(object sender, EventArgs e)
        {
            AddLoaiCT addLoaiCTForm = new AddLoaiCT(define, this, taikhoan, mainform);
            addLoaiCTForm.ShowDialog();
        }

        private void ButtonLoaiCT_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
            string maLoaiCT = clickedButton.Name;
            maLoaiCTInButton = maLoaiCT;

            foreach (var button in buttons)
            {
                button.BackColor = SystemColors.ControlDark;
            }
            clickedButton.BackColor = Color.FromArgb(25, 25, 27);
        }

        private void flpnLoaiCT_Paint(object sender, PaintEventArgs e)
        {
        }

        private void AddChiTieu_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
