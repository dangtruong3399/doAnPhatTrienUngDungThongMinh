using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Net;
using DALL_BALL;
using Library;

namespace QuanLyNhanSu
{
    public partial class frmlogin : DevExpress.XtraEditors.XtraForm
    {
        private NguoiDung_DAL_BLL ndDAL_BLL;
        public frmlogin()
        {
            InitializeComponent();
            ndDAL_BLL = new NguoiDung_DAL_BLL();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            
        }

        private void hien()
        {
           
        }


        public void thoat1()
        {

        }
        #region dang nhap
        

        public static void hienThiThongBaoLoi(string mess)
        {
            MessageBox.Show(mess, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void hienThiThongBaoThanhCong(string mess)
        {
            MessageBox.Show(mess, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_Dangnhap_Click(object sender, EventArgs e)
        {
            
            string uName = tbTenDangNhap.Text,
                pass = tbMatKhau.Text;
            NGUOIDUNG nd = ndDAL_BLL.layNguoiDung(uName);
            if (nd == null)
            {
                hienThiThongBaoLoi("Sai Tên Đăng Nhập!!!");
                return;
            }

            if (!nd.PASS.Equals(pass))
            {
                hienThiThongBaoLoi("Sai mật khẩu");
                return;
            }

            frmMain frmM = new frmMain();
            this.Hide();
            frmM.ShowDialog();
            this.Close();
        }
        #endregion
        
        
        #region moveMouse_From
        private void frmlogin_Move(object sender, EventArgs e)
        {
            this.Text = "Form screen position = " + this.Location.ToString();
        }
        public Point mouse_offset;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }
        private void frmlogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
            }
        } 
        #endregion
        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void thoat()
        {
           
        }
        private void txtServer_EditValueChanged(object sender, EventArgs e)
        {

        }

        

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void txtUser_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiMatKhau.Checked)
                tbMatKhau.PasswordChar = '\0';
            else
                tbMatKhau.PasswordChar = '*';
        }
    }
}