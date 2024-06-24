namespace GUI.App
{
    partial class UCCacTaiKhoan
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
            this.flpnVi = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenVi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbSLVi = new System.Windows.Forms.Label();
            this.btnXoaVi = new System.Windows.Forms.Button();
            this.btnUDTenVi = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMaVi = new System.Windows.Forms.Label();
            this.lbSoDu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpnVi
            // 
            this.flpnVi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flpnVi.Location = new System.Drawing.Point(42, 85);
            this.flpnVi.Name = "flpnVi";
            this.flpnVi.Size = new System.Drawing.Size(340, 380);
            this.flpnVi.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTenVi);
            this.panel1.Location = new System.Drawing.Point(438, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 53);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tên Ví";
            // 
            // txtTenVi
            // 
            this.txtTenVi.Location = new System.Drawing.Point(99, 17);
            this.txtTenVi.Multiline = true;
            this.txtTenVi.Name = "txtTenVi";
            this.txtTenVi.Size = new System.Drawing.Size(133, 30);
            this.txtTenVi.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lượng tài khoản là";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.lbSLVi);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(42, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 53);
            this.panel2.TabIndex = 4;
            // 
            // lbSLVi
            // 
            this.lbSLVi.AutoSize = true;
            this.lbSLVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSLVi.Location = new System.Drawing.Point(200, 23);
            this.lbSLVi.Name = "lbSLVi";
            this.lbSLVi.Size = new System.Drawing.Size(14, 13);
            this.lbSLVi.TabIndex = 1;
            this.lbSLVi.Text = "3";
            // 
            // btnXoaVi
            // 
            this.btnXoaVi.BackColor = System.Drawing.Color.Silver;
            this.btnXoaVi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoaVi.Location = new System.Drawing.Point(454, 273);
            this.btnXoaVi.Name = "btnXoaVi";
            this.btnXoaVi.Size = new System.Drawing.Size(128, 36);
            this.btnXoaVi.TabIndex = 5;
            this.btnXoaVi.Text = "xóa tài khoản";
            this.btnXoaVi.UseVisualStyleBackColor = false;
            this.btnXoaVi.Click += new System.EventHandler(this.btnXoaVi_Click_1);
            // 
            // btnUDTenVi
            // 
            this.btnUDTenVi.BackColor = System.Drawing.Color.Silver;
            this.btnUDTenVi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUDTenVi.Location = new System.Drawing.Point(618, 273);
            this.btnUDTenVi.Name = "btnUDTenVi";
            this.btnUDTenVi.Size = new System.Drawing.Size(128, 36);
            this.btnUDTenVi.TabIndex = 6;
            this.btnUDTenVi.Text = "Sửa tên tài khoản";
            this.btnUDTenVi.UseVisualStyleBackColor = false;
            this.btnUDTenVi.Click += new System.EventHandler(this.btnUDTenVi_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Silver;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThem.Location = new System.Drawing.Point(475, 328);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(235, 39);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm tài khoản";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lbMaVi);
            this.panel3.Location = new System.Drawing.Point(438, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(321, 53);
            this.panel3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Ví:";
            // 
            // lbMaVi
            // 
            this.lbMaVi.AutoSize = true;
            this.lbMaVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaVi.Location = new System.Drawing.Point(96, 22);
            this.lbMaVi.Name = "lbMaVi";
            this.lbMaVi.Size = new System.Drawing.Size(141, 13);
            this.lbMaVi.TabIndex = 0;
            this.lbMaVi.Text = "vui lòng chọn tài khoản";
            // 
            // lbSoDu
            // 
            this.lbSoDu.AutoSize = true;
            this.lbSoDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDu.Location = new System.Drawing.Point(107, 19);
            this.lbSoDu.Name = "lbSoDu";
            this.lbSoDu.Size = new System.Drawing.Size(165, 16);
            this.lbSoDu.TabIndex = 7;
            this.lbSoDu.Text = "vui lòng chọn tài khoản";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số Dư: ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.lbSoDu);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(438, 203);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 53);
            this.panel4.TabIndex = 9;
            // 
            // UCCacTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpnVi);
            this.Controls.Add(this.btnUDTenVi);
            this.Controls.Add(this.btnXoaVi);
            this.Name = "UCCacTaiKhoan";
            this.Size = new System.Drawing.Size(894, 595);
            this.Load += new System.EventHandler(this.UCCacTaiKhoan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpnVi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUDTenVi;
        private System.Windows.Forms.Button btnXoaVi;
        private System.Windows.Forms.Label lbSLVi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMaVi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSoDu;
        private System.Windows.Forms.TextBox txtTenVi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
    }
}
