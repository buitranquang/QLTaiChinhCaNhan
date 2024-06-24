namespace GUI.MiniForm
{
    partial class AddVi
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenVi = new System.Windows.Forms.TextBox();
            this.btnAddVi = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(94, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tạo ví mới";
            // 
            // txtTenVi
            // 
            this.txtTenVi.Location = new System.Drawing.Point(69, 50);
            this.txtTenVi.MaxLength = 30;
            this.txtTenVi.Multiline = true;
            this.txtTenVi.Name = "txtTenVi";
            this.txtTenVi.Size = new System.Drawing.Size(123, 32);
            this.txtTenVi.TabIndex = 1;
            this.txtTenVi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenVi_KeyDown);
            this.txtTenVi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenVi_KeyPress);
            // 
            // btnAddVi
            // 
            this.btnAddVi.Location = new System.Drawing.Point(70, 95);
            this.btnAddVi.Name = "btnAddVi";
            this.btnAddVi.Size = new System.Drawing.Size(121, 32);
            this.btnAddVi.TabIndex = 2;
            this.btnAddVi.Text = "Thêm";
            this.btnAddVi.UseVisualStyleBackColor = true;
            this.btnAddVi.Click += new System.EventHandler(this.btnAddVi_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 40);
            this.panel1.TabIndex = 3;
            // 
            // AddVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 141);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddVi);
            this.Controls.Add(this.txtTenVi);
            this.Name = "AddVi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddViForm";
            this.Load += new System.EventHandler(this.AddVi_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddVi_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenVi;
        private System.Windows.Forms.Button btnAddVi;
        private System.Windows.Forms.Panel panel1;
    }
}