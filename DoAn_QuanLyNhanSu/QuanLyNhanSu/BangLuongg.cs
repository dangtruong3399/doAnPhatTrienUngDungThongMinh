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
using System.Text.RegularExpressions;
using DALL_BALL;

namespace QuanLyNhanSu
{
    public partial class BangLuongg : DevExpress.XtraEditors.XtraUserControl
    {
        BangLuong_DAL_BLL bl_bll_dal = new BangLuong_DAL_BLL();
        public BangLuongg()
        {
            InitializeComponent();
        }

        private void BangLuongg_Load(object sender, EventArgs e)
        {
            loadNV_Luong();
            loadDatagridView_BangLuong();
            gvBangLuong.Columns[0].OptionsColumn.AllowEdit = false;
            bind();
        }
        public void loadDatagridView_BangLuong()
        {
            dgvBangLuong.DataSource = bl_bll_dal.load_BangLuong();
        }
        public void loadNV_Luong()
        {
            dgvNV_Luong.DataSource = bl_bll_dal.loadNhanVien_BangLuong();
        }

        private int rowSelected;

        private void tinhCong_Click(object sender, EventArgs e)
        {
            if (rowSelected < 0)
                return;
            string maNV = gvBangLuong.GetRowCellValue(rowSelected, gvBangLuong.Columns[0]).ToString();
            int ngaycong = bl_bll_dal.GetCountByID(maNV);
            lbSoNgayCong.Text = ngaycong.ToString();
        }

        private void gvBangLuong_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowSelected = e.RowHandle;
            bind();
        }
        public void bind()
        {
            Binding bdMaNhanVien = new Binding("Text", dgvNV_Luong.DataSource, "MaNhanVien");
            lbMaNV.DataBindings.Clear();
            lbMaNV.DataBindings.Add(bdMaNhanVien);

            Binding bdNhanVien = new Binding("Text", dgvNV_Luong.DataSource, "TenNV");
            lbTenNV.DataBindings.Clear();
            lbTenNV.DataBindings.Add(bdNhanVien);

            Binding bdHSL = new Binding("Text", dgvNV_Luong.DataSource, "HeSoLuong");
            txtHeSoLuong.DataBindings.Clear();
            txtHeSoLuong.DataBindings.Add(bdHSL);

            Binding bdLuongCB = new Binding("Text", dgvNV_Luong.DataSource, "LuongCB");
            txtLuongCB.DataBindings.Clear();
            txtLuongCB.DataBindings.Add(bdLuongCB);
        }
        //validate
        public bool validate_tienTroCap(string trocap)
        {
            Regex regex = new Regex(@"[0-9]$");
            if (!regex.IsMatch(trocap))
            {
                return false;
            }
            return true;
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (lbSoNgayCong.Text == string.Empty)
            {
                MessageBox.Show("Chưa tính số ngày công!");
                return;
            }
            if (txtTroCap.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập tiền trợ cấp!");
                txtTroCap.Focus();
                return;
            }
            if (!validate_tienTroCap(txtTroCap.Text))
            {
                MessageBox.Show("Tiền trợ cấp phải là số!");
                txtTroCap.Focus();
                return;
            }

            tinhTienLuong();
            int hesl = Int32.Parse(txtHeSoLuong.Text);
            int ngaycong = Int32.Parse(lbSoNgayCong.Text);
            int trocap = Int32.Parse(txtTroCap.Text);
            int thuclinh = Int32.Parse(lbThucLinh.Text);
            bl_bll_dal.Them1DongBangLuong(lbMaNV.Text, hesl, ngaycong, trocap, thuclinh);
            loaddgv_BangLuong();
            MessageBox.Show("Them 1 dong bang luong thanh cong!");
            lbSoNgayCong.Text = string.Empty;
        }
        public void tinhTienLuong()
        {
            if (lbSoNgayCong.Text == String.Empty)
            {
                MessageBox.Show("Tính số ngày công!");
            }
            int ingaycong = int.Parse(lbSoNgayCong.Text);
            float luongcb = float.Parse(txtLuongCB.Text);
            float trocap = float.Parse(txtTroCap.Text);
            float tongLuong = ingaycong * luongcb / 26 + trocap;
            lbThucLinh.Text = tongLuong.ToString();
        }
        public void loaddgv_BangLuong()
        {
            dgvBangLuong.DataSource = bl_bll_dal.load_BangLuong();
        }
    }
}
