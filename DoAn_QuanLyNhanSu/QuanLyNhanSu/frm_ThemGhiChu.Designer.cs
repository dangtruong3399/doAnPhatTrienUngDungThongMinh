namespace QuanLyNhanSu
{
    partial class frm_ThemGhiChu
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
            this.btnHuyBo = new DevExpress.XtraEditors.SimpleButton();
            this.btnChapNhan = new DevExpress.XtraEditors.SimpleButton();
            this.tbThemGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(249, 224);
            this.btnHuyBo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(87, 28);
            this.btnHuyBo.TabIndex = 9;
            this.btnHuyBo.Text = "Hủy Bỏ";
            // 
            // btnChapNhan
            // 
            this.btnChapNhan.Location = new System.Drawing.Point(44, 224);
            this.btnChapNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChapNhan.Name = "btnChapNhan";
            this.btnChapNhan.Size = new System.Drawing.Size(87, 28);
            this.btnChapNhan.TabIndex = 10;
            this.btnChapNhan.Text = "Chấp Nhận";
            // 
            // tbThemGhiChu
            // 
            this.tbThemGhiChu.Location = new System.Drawing.Point(44, 82);
            this.tbThemGhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbThemGhiChu.Multiline = true;
            this.tbThemGhiChu.Name = "tbThemGhiChu";
            this.tbThemGhiChu.Size = new System.Drawing.Size(292, 120);
            this.tbThemGhiChu.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thêm ghi chú cho nhân viên khi thêm vào nhóm này";
            // 
            // frm_ThemGhiChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 294);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnChapNhan);
            this.Controls.Add(this.tbThemGhiChu);
            this.Controls.Add(this.label1);
            this.Name = "frm_ThemGhiChu";
            this.Text = "frm_ThemGhiChu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnHuyBo;
        private DevExpress.XtraEditors.SimpleButton btnChapNhan;
        private System.Windows.Forms.TextBox tbThemGhiChu;
        private System.Windows.Forms.Label label1;
    }
}