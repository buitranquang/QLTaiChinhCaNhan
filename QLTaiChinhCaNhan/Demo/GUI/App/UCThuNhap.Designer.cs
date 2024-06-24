namespace GUI.App
{
    partial class UCThuNhap
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartChiTieu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnNam = new System.Windows.Forms.Button();
            this.flpnThu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnThang = new System.Windows.Forms.Button();
            this.btnTuan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbVi = new System.Windows.Forms.ComboBox();
            this.cbLoaiCT = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateNgayCT = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoTienChiTieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartChiTieu)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartChiTieu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartChiTieu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartChiTieu.Legends.Add(legend1);
            this.chartChiTieu.Location = new System.Drawing.Point(-18, 2);
            this.chartChiTieu.Name = "chartChiTieu";
            this.chartChiTieu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartChiTieu.Series.Add(series1);
            this.chartChiTieu.Size = new System.Drawing.Size(689, 208);
            this.chartChiTieu.TabIndex = 0;
            this.chartChiTieu.Text = "chartChiTieu";
            // 
            // btnNam
            // 
            this.btnNam.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNam.Location = new System.Drawing.Point(601, 38);
            this.btnNam.Name = "btnNam";
            this.btnNam.Size = new System.Drawing.Size(92, 32);
            this.btnNam.TabIndex = 1;
            this.btnNam.Text = "Năm";
            this.btnNam.UseVisualStyleBackColor = false;
            this.btnNam.Click += new System.EventHandler(this.btnNam_Click);
            // 
            // flpnThu
            // 
            this.flpnThu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flpnThu.Location = new System.Drawing.Point(19, 80);
            this.flpnThu.Name = "flpnThu";
            this.flpnThu.Size = new System.Drawing.Size(254, 399);
            this.flpnThu.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Location = new System.Drawing.Point(19, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 43);
            this.panel1.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbTitle.Location = new System.Drawing.Point(56, 15);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(104, 13);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Danh sách thu nhập";
            // 
            // btnThang
            // 
            this.btnThang.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThang.Location = new System.Drawing.Point(509, 38);
            this.btnThang.Name = "btnThang";
            this.btnThang.Size = new System.Drawing.Size(92, 32);
            this.btnThang.TabIndex = 5;
            this.btnThang.Text = "Tháng";
            this.btnThang.UseVisualStyleBackColor = false;
            this.btnThang.Click += new System.EventHandler(this.btnThang_Click);
            // 
            // btnTuan
            // 
            this.btnTuan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this.btnTuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuan.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTuan.Location = new System.Drawing.Point(394, 38);
            this.btnTuan.Name = "btnTuan";
            this.btnTuan.Size = new System.Drawing.Size(116, 32);
            this.btnTuan.TabIndex = 6;
            this.btnTuan.Text = "Trong 7 ngày";
            this.btnTuan.UseVisualStyleBackColor = false;
            this.btnTuan.Click += new System.EventHandler(this.btnTuan_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chartChiTieu);
            this.panel2.Location = new System.Drawing.Point(301, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 211);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.cbVi);
            this.panel3.Controls.Add(this.cbLoaiCT);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dateNgayCT);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtSoTienChiTieu);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnSua);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Location = new System.Drawing.Point(315, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(514, 224);
            this.panel3.TabIndex = 8;
            // 
            // cbVi
            // 
            this.cbVi.FormattingEnabled = true;
            this.cbVi.Location = new System.Drawing.Point(346, 52);
            this.cbVi.Name = "cbVi";
            this.cbVi.Size = new System.Drawing.Size(154, 21);
            this.cbVi.TabIndex = 12;
            this.cbVi.Text = "vui lòng chọn chi tiêu";
            this.cbVi.SelectedIndexChanged += new System.EventHandler(this.cbVi_SelectedIndexChanged);
            // 
            // cbLoaiCT
            // 
            this.cbLoaiCT.FormattingEnabled = true;
            this.cbLoaiCT.Location = new System.Drawing.Point(86, 52);
            this.cbLoaiCT.Name = "cbLoaiCT";
            this.cbLoaiCT.Size = new System.Drawing.Size(144, 21);
            this.cbLoaiCT.TabIndex = 11;
            this.cbLoaiCT.Text = "vui lòng chọn chi tiêu";
            this.cbLoaiCT.SelectedIndexChanged += new System.EventHandler(this.cbLoaiCT_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(176, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "tùy chỉnh thu nhập";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(270, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nguồn: ";
            // 
            // dateNgayCT
            // 
            this.dateNgayCT.Location = new System.Drawing.Point(346, 94);
            this.dateNgayCT.Name = "dateNgayCT";
            this.dateNgayCT.Size = new System.Drawing.Size(154, 20);
            this.dateNgayCT.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(246, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngày chi tiêu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(15, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số tiền:";
            // 
            // txtSoTienChiTieu
            // 
            this.txtSoTienChiTieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTienChiTieu.Location = new System.Drawing.Point(88, 92);
            this.txtSoTienChiTieu.Multiline = true;
            this.txtSoTienChiTieu.Name = "txtSoTienChiTieu";
            this.txtSoTienChiTieu.Size = new System.Drawing.Size(144, 23);
            this.txtSoTienChiTieu.TabIndex = 3;
            this.txtSoTienChiTieu.Text = "vui lòng chọn thu nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại : ";
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSua.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSua.Location = new System.Drawing.Point(286, 173);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(124, 36);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sủa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoa.ForeColor = System.Drawing.SystemColors.Control;
            this.btnXoa.Location = new System.Drawing.Point(90, 173);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(124, 36);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIn.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIn.Location = new System.Drawing.Point(19, 485);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(254, 36);
            this.btnIn.TabIndex = 9;
            this.btnIn.Text = "In Danh sách thu nhập";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // UCThuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnTuan);
            this.Controls.Add(this.btnThang);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpnThu);
            this.Controls.Add(this.btnNam);
            this.Name = "UCThuNhap";
            this.Size = new System.Drawing.Size(894, 595);
            this.Load += new System.EventHandler(this.UCThuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartChiTieu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartChiTieu;
        private System.Windows.Forms.Button btnNam;
        private System.Windows.Forms.FlowLayoutPanel flpnThu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThang;
        private System.Windows.Forms.Button btnTuan;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.TextBox txtSoTienChiTieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateNgayCT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbLoaiCT;
        private System.Windows.Forms.ComboBox cbVi;
    }
}
