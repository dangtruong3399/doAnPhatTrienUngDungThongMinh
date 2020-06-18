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
using BALL;
namespace QuanLyNhanSu
{
    public partial class frmlogin : DevExpress.XtraEditors.XtraForm
    {
        Login_BLL da = new Login_BLL();
        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            
        }

        private void hien()
        {
            this.WindowState = FormWindowState.Normal;
        }


        public void thoat1()
        {

        }
        #region dang nhap
        public void Dangnhap()
        {

            if(txtUser.Text==string.Empty)
            {
                MessageBox.Show("Không được bỏ trống tên đăng nhập");
                return;
            }
            if(txtPass.Text==string.Empty)
            {
                MessageBox.Show("Không được bỏ trống mật khẩu");
                return;
            }
            if(da.Checklogin(txtUser.Text,txtPass.Text))
            {
                MessageBox.Show("Thành Công");
                Hide();
                frmMainForm frm = new frmMainForm();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Mật khẩu hoặc tài khoản sai");
            }
        }

        private void bt_Dangnhap_Click(object sender, EventArgs e)
        {
            Dangnhap();
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
            this.Close();
        }
        private void txtServer_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Dangnhap();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Dangnhap();
            }
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}