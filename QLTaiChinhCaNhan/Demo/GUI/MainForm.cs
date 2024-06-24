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
using System.Threading;
using GUI.MiniForm;
using Aspose.Words.Drawing;

namespace GUI
{
    public partial class MainForm : Form
    {
        //tao bien chua UC  
        private UCNguoiDung ucnd;
        private UCThuNhap ucthu;
        private UCChiTieu ucct;
        private UCCacKhoanVay ucckv;
        private UCTongQuan tongquan;
        private UCCacTaiKhoan ucctk;
        private string mataikhoan;
        private TaiKhoan taikhoan;




        //khởi tạo đối tượng chi tiêu trong BLL
        ChiTieuBLL chiTieuBLL = new ChiTieuBLL();
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();

        //khởi tạo giá trị chi tiêu để truyền vào các usercontrol
        int tongThu = 0;
        int tongChi = 0;
        int tong = 0;


        public MainForm()
        {
            InitializeComponent();
        }


        public MainForm(string matk)
        {
            InitializeComponent();
            this.mataikhoan = matk;
            
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            
            taikhoan = TKBLL.GetTaiKhoanByMaTK(mataikhoan);

            LoadData();// hàm tính các giá trị chi tiêu
            togglepanelMain("tq");
            
            txtUserName.Text = taikhoan.TenUser.ToString();
            Thread.Sleep(500);
            checkNewTK();
        }


        public void UpdateDataAndUI(TaiKhoan taiKhoan)
        {
            this.taikhoan = taiKhoan;
            //Cập nhật UCNguoiDung
            if (this.ucctk != null)
            {
                this.ucctk.Update(taiKhoan);
            }
            tongThu = 0;
            tongChi = 0;
            tong = 0;
            LoadData();
            // Cập nhật UCTongQuan
            if (this.tongquan != null)
            {
                this.tongquan.UpdateData(tongThu, tongChi, tong);
            }
            if (this.ucct != null)
            {
                this.ucct.Update();
            }
            if (this.ucthu != null)
            {
                this.ucthu.Update();
            }
            if (this.ucnd != null)
            {
                this.ucnd.UpdateData(taiKhoan);
            }
        }

        public void LoadData()// hàm tính tổng thu, tổng chi, tổng cộng
        {
            DataTable dataTable = chiTieuBLL.ThongKeChiTieu(taikhoan.MaTK);

            foreach (DataRow row in dataTable.Rows)
            {
                int soTien = Convert.ToInt32(row["SoTienChiTieu"]);
                if (soTien > 0)
                {
                    tongThu += soTien;
                }
                else
                {
                    tongChi += soTien;
                }
                tong += soTien;
            }
        }

        public void UpdateUI()
        {
            tongThu = 0;
            tongChi = 0;
            tong = 0;
            LoadData();
            // Cập nhật UCTongQuan
            if (this.tongquan != null)
            {
                this.tongquan.UpdateData(tongThu, tongChi, tong);
            }
        }

        private void checkNewTK()
        {
            if(tongThu == 0 && tongChi == 0)
            {
                AddChiTieu addChiTieu = new AddChiTieu(this,taikhoan,true, true);
                addChiTieu.ShowDialog();
            }
        }


        // ham dua form vao master
        internal void togglepanelMain(string panelname)
        {
            this.panelMain.Controls.Clear();
            switch (panelname)
            {
                case "tq":
                    if (this.tongquan == null)
                    {
                        this.tongquan = new UCTongQuan(taikhoan, tongThu, tongChi, tong, this);
                        this.panelMain.Controls.Add(tongquan);
                        this.tongquan.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tongquan.Location = new System.Drawing.Point(0, 0);
                        this.tongquan.Name = "tongquan";
                        this.tongquan.Size = new System.Drawing.Size(894, 595);
                        this.tongquan.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(tongquan);
                        this.tongquan.UpdateData(tongThu, tongChi, tong); // Cập nhật dữ liệu khi gọi lại
                    }
                    break;
                case "ctk":
                    if (this.ucctk == null)
                    {
                        this.ucctk = new UCCacTaiKhoan( taikhoan, this);
                        this.panelMain.Controls.Add(ucctk);
                        this.ucctk.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucctk.Location = new System.Drawing.Point(0, 0);
                        this.ucctk.Name = "ucctk";
                        this.ucctk.Size = new System.Drawing.Size(894, 595);
                        this.ucctk.TabIndex = 0;
                    }
                    else
                    { 
                        this.panelMain.Controls.Add(ucctk);
                        this.ucctk.Update(taikhoan);
                    }
                    break;

                case "thu":
                    if (this.ucthu == null)
                    {
                        this.ucthu = new UCThuNhap(taikhoan);
                        this.panelMain.Controls.Add(ucthu);
                        this.ucthu.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucthu.Location = new System.Drawing.Point(0, 0);
                        this.ucthu.Name = "ucthu";
                        this.ucthu.Size = new System.Drawing.Size(894, 595);
                        this.ucthu.TabIndex = 0;
                    }
                    else
                    { this.panelMain.Controls.Add(ucthu);
                    this.ucthu.Update();
                    }
                    break;
                case "chi":
                    if (this.ucct == null)
                    {
                        this.ucct = new UCChiTieu(taikhoan);
                        this.panelMain.Controls.Add(ucct);
                        this.ucct.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucct.Location = new System.Drawing.Point(0, 0);
                        this.ucct.Name = "ucct";
                        this.ucct.Size = new System.Drawing.Size(894, 595);
                        this.ucct.TabIndex = 0;
                    }
                    else
                    { this.panelMain.Controls.Add(ucct);
                        this.ucct.Update();
                    }
                    break;
                case "vay":
                    if (this.ucckv == null)
                    {
                        this.ucckv = new UCCacKhoanVay(taikhoan);
                        this.panelMain.Controls.Add(ucckv);
                        this.ucckv.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucckv.Location = new System.Drawing.Point(0, 0);
                        this.ucckv.Name = "ucckv";
                        this.ucckv.Size = new System.Drawing.Size(894, 595);
                        this.ucckv.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucckv);
                        this.ucckv.Update(taikhoan);
                    }
                    break;
                case "nv":
                    if (this.ucthu == null)
                    {
                        this.ucthu = new UCThuNhap(taikhoan);
                        this.panelMain.Controls.Add(ucthu);
                        this.ucthu.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucthu.Location = new System.Drawing.Point(0, 0);
                        this.ucthu.Name = "ucthu";
                        this.ucthu.Size = new System.Drawing.Size(894, 595);
                        this.ucthu.TabIndex = 0;
                    }
                    else
                    { this.panelMain.Controls.Add(ucthu); }
                    break;
                case "ng":
                    if (this.ucnd == null)
                    {
                        this.ucnd = new UCNguoiDung(this,taikhoan);
                        this.panelMain.Controls.Add(ucnd);
                        this.ucnd.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucnd.Location = new System.Drawing.Point(0, 0);
                        this.ucnd.Name = "ucnd";
                        this.ucnd.Size = new System.Drawing.Size(894, 595);
                        this.ucnd.TabIndex = 0;
                    }
                    else
                    { this.panelMain.Controls.Add(ucnd);
                        this.ucnd.UpdateData(taikhoan);
                    }
                    break;

                default:
                    break;
            }

        }


        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            togglepanelMain("tq");

            //check
            this.checkMenu1.Location = new Point(290, 0);
        }

        private void btnCacTaiKhoan_Click(object sender, EventArgs e)
        {
            togglepanelMain("ctk");

            //check
            this.checkMenu1.Location = new Point(290, 57);

        }

        private void btnThuNhap_Click(object sender, EventArgs e)
        {

            //check
            this.checkMenu1.Location = new Point(290, 114);

            togglepanelMain("thu");
        }

        private void btnCacKhoanVay_Click(object sender, EventArgs e)
        {


            //check
            this.checkMenu1.Location = new Point(290, 228);

            togglepanelMain("vay");
        }

        private void btnChiTieu_Click(object sender, EventArgs e)
        {


            //check
            this.checkMenu1.Location = new Point(290, 171);

            togglepanelMain("chi");
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {

            togglepanelMain("ng");

            //check
            this.checkMenu1.Location = new Point(290, 285);
        }

        private void btnThu_Click(object sender, EventArgs e)
        {
            AddChiTieu addLoaiCTForm = new AddChiTieu(this, taikhoan, true);
            addLoaiCTForm.ShowDialog();
        }

        private void btnChi_Click(object sender, EventArgs e)
        {
            AddChiTieu addLoaiCTForm = new AddChiTieu(this, taikhoan, false);
            addLoaiCTForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            togglepanelMain("ng");

            //check
            this.checkMenu1.Location = new Point(290, 285);
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            togglepanelMain("ng");

            //check
            this.checkMenu1.Location = new Point(290, 285);
        }
    }
}
