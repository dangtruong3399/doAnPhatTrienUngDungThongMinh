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
    public partial class BaoHiem : DevExpress.XtraEditors.XtraUserControl
    {
        BaoHiem_DAL_BLL bh = new BaoHiem_DAL_BLL();
        bool add = false, update = false;
        string mabaohiem = "", manv = "";

        private void BaoHiem_Load(object sender, EventArgs e)
        {
            loadbaohiem();
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            databinds(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            databinds(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            add = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
        }

        public BaoHiem()
        {
            InitializeComponent();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bh.xoa1baohiem(mabaohiem);
            BaoHiem_Load(sender, e);
            XtraMessageBox.Show("Thành công");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            mabaohiem = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaBaoHiem").ToString();
            manv = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaNhanVien").ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (add)
            {
                bh.sua1hiem(mabaohiem, manv, DateTime.Parse(dateNgayCap.EditValue.ToString()), DateTime.Parse(dateNgayHetHan.EditValue.ToString()), txtNoiCap.Text, txtMaSoThe.Text, cboLoai.SelectedItem.ToString());
                BaoHiem_Load(sender, e);
                XtraMessageBox.Show("Thành công");

            }
            if (update)
            {
                bh.sua1hiem(mabaohiem, manv, DateTime.Parse(dateNgayCap.EditValue.ToString()), DateTime.Parse(dateNgayHetHan.EditValue.ToString()), txtNoiCap.Text, txtMaSoThe.Text, cboLoai.SelectedItem.ToString());
                BaoHiem_Load(sender, e);
                XtraMessageBox.Show("Thành công");
            }
        }

        public void loadbaohiem()
        {
            gridControl1.DataSource = bh.laybaobaohiem();

        }

        public void databinds(bool t)
        {
            if (t)
            {
                txtTenNV.DataBindings.Clear();
                txtTenNV.DataBindings.Add("Text", gridControl1.DataSource, "TenNV");
                txtMaSoThe.DataBindings.Clear();
                txtMaSoThe.DataBindings.Add("Text", gridControl1.DataSource, "SoThe");
                txtNoiCap.DataBindings.Clear();
                txtNoiCap.DataBindings.Add("Text", gridControl1.DataSource, "NoiCap");
                dateNgayCap.DataBindings.Clear();
                dateNgayCap.DataBindings.Add("Text", gridControl1.DataSource, "NgayCap");
                dateNgayHetHan.DataBindings.Clear();
                dateNgayHetHan.DataBindings.Add("Text", gridControl1.DataSource, "NgayHetHan");
                cboLoai.DataBindings.Clear();
                cboLoai.DataBindings.Add("Text", gridControl1.DataSource, "LoaiBaoHiem");

            }
            else
            {
                txtTenNV.DataBindings.Clear();
                txtMaSoThe.DataBindings.Clear();
                txtNoiCap.DataBindings.Clear();
                dateNgayCap.DataBindings.Clear();
                dateNgayHetHan.DataBindings.Clear();
            }
        }
    }
}
