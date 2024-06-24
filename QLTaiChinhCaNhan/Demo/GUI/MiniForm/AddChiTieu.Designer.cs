namespace GUI.MiniForm
{
    partial class AddChiTieu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lbTien = new System.Windows.Forms.Label();
            this.txtSoTienChiTieu = new System.Windows.Forms.TextBox();
            this.NameForm = new System.Windows.Forms.Label();
            this.flpnLoaiCT = new System.Windows.Forms.FlowLayoutPanel();
            this.flpnVi = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(307, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Hoàn Thành\r\n";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbTien
            // 
            this.lbTien.AutoSize = true;
            this.lbTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTien.ForeColor = System.Drawing.SystemColors.Control;
            this.lbTien.Location = new System.Drawing.Point(318, 48);
            this.lbTien.Name = "lbTien";
            this.lbTien.Size = new System.Drawing.Size(50, 13);
            this.lbTien.TabIndex = 4;
            this.lbTien.Text = "Số Tiền :";
            // 
            // txtSoTienChiTieu
            // 
            this.txtSoTienChiTieu.Location = new System.Drawing.Point(317, 61);
            this.txtSoTienChiTieu.Multiline = true;
            this.txtSoTienChiTieu.Name = "txtSoTienChiTieu";
            this.txtSoTienChiTieu.Size = new System.Drawing.Size(160, 23);
            this.txtSoTienChiTieu.TabIndex = 3;
            this.txtSoTienChiTieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTienChiTieu_KeyPress);
            // 
            // NameForm
            // 
            this.NameForm.AutoSize = true;
            this.NameForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameForm.Location = new System.Drawing.Point(183, 12);
            this.NameForm.Name = "NameForm";
            this.NameForm.Size = new System.Drawing.Size(83, 16);
            this.NameForm.TabIndex = 11;
            this.NameForm.Text = "NameForm";
            // 
            // flpnLoaiCT
            // 
            this.flpnLoaiCT.BackColor = System.Drawing.SystemColors.Control;
            this.flpnLoaiCT.Location = new System.Drawing.Point(252, 97);
            this.flpnLoaiCT.Name = "flpnLoaiCT";
            this.flpnLoaiCT.Size = new System.Drawing.Size(308, 155);
            this.flpnLoaiCT.TabIndex = 16;
            this.flpnLoaiCT.Paint += new System.Windows.Forms.PaintEventHandler(this.flpnLoaiCT_Paint);
            // 
            // flpnVi
            // 
            this.flpnVi.BackColor = System.Drawing.SystemColors.Control;
            this.flpnVi.Location = new System.Drawing.Point(23, 86);
            this.flpnVi.Name = "flpnVi";
            this.flpnVi.Size = new System.Drawing.Size(223, 233);
            this.flpnVi.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(23, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 95);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn tài khoản";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.NameForm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(572, 40);
            this.panel2.TabIndex = 17;
            // 
            // AddChiTieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 331);
            this.Controls.Add(this.flpnVi);
            this.Controls.Add(this.txtSoTienChiTieu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpnLoaiCT);
            this.Controls.Add(this.lbTien);
            this.Controls.Add(this.button1);
            this.Name = "AddChiTieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Thu Chi";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpnVi;
        private System.Windows.Forms.FlowLayoutPanel flpnLoaiCT;
        private System.Windows.Forms.Label NameForm;
        private System.Windows.Forms.Label lbTien;
        private System.Windows.Forms.TextBox txtSoTienChiTieu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
    }
}