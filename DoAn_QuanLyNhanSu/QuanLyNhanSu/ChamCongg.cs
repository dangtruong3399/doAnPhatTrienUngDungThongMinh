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
    public partial class ChamCongg : DevExpress.XtraEditors.XtraUserControl
    {
        ChamCong_DAL_BLL cc_bll_dal = new ChamCong_DAL_BLL();
        public ChamCongg()
        {
            InitializeComponent();
        }

        private void ChamCongg_Load(object sender, EventArgs e)
        {
            loadChamCong();
            loaddgv_NhanVien();
            if (dgvloadNV.DataSource != null)
            {
                bind();
            }
            if (dgvChamCong.DataSource != null)
            {
                bindChamCong();
            }
        }
        public void bind()
        {
            Binding bdNhanVien = new Binding("Text", dgvloadNV.DataSource, "TenNV");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add(bdNhanVien);

            Binding bdMaNhanVien = new Binding("Text", dgvloadNV.DataSource, "MaNhanVien");
            txtMaNVChamCong.DataBindings.Clear();
            txtMaNVChamCong.DataBindings.Add(bdMaNhanVien);
        }

        public void bindChamCong()
        {
            //Binding bdMaNhanVien = new Binding("Text", dgvChamCong.DataSource, "MaNhanVien");
            //txtMaNVChamCong.DataBindings.Clear();
            //txtMaNVChamCong.DataBindings.Add(bdMaNhanVien);

            //dtpNgayChamCong.DataBindings.Clear();
            //dtpNgayChamCong.DataBindings.Add("Text", dgvChamCong.DataSource, "Ngay");

            //Binding bdTinhTrang = new Binding("Text", dgvloadNV.DataSource, "TinhTrang");
            //if (rdbtnDiLam.Checked)
            //{
            //    rdbtnDiLam.DataBindings.Add(bdTinhTrang);
            //}
            //else if (rdbtnNghiCoP.Checked)
            //{
            //    rdbtnNghiCoP.DataBindings.Add(bdTinhTrang);
            //}
            //else
            //{
            //    rdbtnNghiKP.DataBindings.Add(bdTinhTrang);
            //}

        }
        public void loadChamCong()
        {
            dgvChamCong.DataSource = cc_bll_dal.layDSChamCong();
        }

        public void loaddgv_NhanVien()
        {
            dgvloadNV.DataSource = cc_bll_dal.loadNhanVien();
        }
        public void loadDataGridView_ChamCong()
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string LamOrNghi = string.Empty;
            if (rdbtnDiLam.Checked)
            {
                LamOrNghi = "Đi làm";
            }
            else if (rdbtnNghiCoP.Checked)
            {
                LamOrNghi = "Nghỉ có phép";
            }
            else
            {
                LamOrNghi = "Nghỉ không phép";
            }

            DateTime datee = DateTime.Parse(dtpNgayChamCong.Text);
            cc_bll_dal.Them1DongChamCong(txtMaNVChamCong.Text, datee, LamOrNghi);
            loadChamCong();
            MessageBox.Show("Them thanh cong 1 records chấm công!");
        }
    }
}
