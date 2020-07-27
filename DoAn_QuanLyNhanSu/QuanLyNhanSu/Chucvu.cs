using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DALL_BALL;
     

namespace QuanLyNhanSu
{
    public partial class Chucvu : DevExpress.XtraEditors.XtraUserControl
    {
        bool add, update = false;
        ChucVu_DALL_BALL cv = new ChucVu_DALL_BALL();
        TudongTang tt = new TudongTang();
        public Chucvu()
        {
            InitializeComponent();
        }

        private void Chucvu_Load(object sender, EventArgs e)
        {
            loadcv();
            txtMacv.Enabled = false;
            hienthi(false);
            bind();
        }
        public void hienthi(bool t)
        {
            txtTenCv.Enabled = t;
        }

        public void loadcv()
        {

            dsChucVu.DataSource = cv.loadcv();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (add)
            {
                bool kq = cv.them1phongcv(txtMacv.Text, txtTenCv.Text);
                if (kq)
                {
                    XtraMessageBox.Show("Thành công");
                    Chucvu_Load(sender, e);
                }
                else
                {
                    XtraMessageBox.Show("Error");

                }
            }
            if (update)
            {
                cv.suacv(txtMacv.Text, txtTenCv.Text);
                Chucvu_Load(sender, e);
                XtraMessageBox.Show("Thành công");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            hienthi(true);
            add = false;
            update = true;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (cv.xoapb(txtMacv.Text))
            {
                XtraMessageBox.Show("Thành Công");
                Chucvu_Load(sender, e);
            }
            else
            {
                XtraMessageBox.Show("Thất bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMacv.Text = cv.getmaCVauto();
            txtTenCv.Text = "";
            hienthi(true);
            add = true;
            update = false;
        }

        public void bind()
        {
            txtMacv.DataBindings.Clear();
            txtMacv.DataBindings.Add("Text", dsChucVu.DataSource, "MaCV");
            txtTenCv.DataBindings.Clear();
            txtTenCv.DataBindings.Add("Text", dsChucVu.DataSource, "TenCV");

        }
    }
}
