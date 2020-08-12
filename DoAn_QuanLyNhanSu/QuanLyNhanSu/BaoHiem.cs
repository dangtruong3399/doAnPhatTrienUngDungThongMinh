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
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanSu
{
    public partial class Baohiem : DevExpress.XtraEditors.XtraUserControl
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
        public void hienthi(bool t)
        {
            txtTenNV.Enabled = t;
            txtMaSoThe.Enabled = t;
            txtNoiCap.Enabled = t;
            dateNgayCap.Enabled = t;
           
            dateNgayHetHan.Enabled = t;
           

        }
        public void resetvalues()
        {
            txtTenNV.Text = "";
            txtMaSoThe.Text = "";
            txtNoiCap.Text = "";
            dateNgayCap.Text = "";
            dateNgayHetHan.Text = "";
            cboLoai.Text = "";
            

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            add = true;
            update = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            databinds(false);
            resetvalues();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            add = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
        }

        public Baohiem()
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

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BaoHiem_Load(sender, e);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;



            workbook = application.Workbooks.Add(Type.Missing);
            application.Visible = true;
            application.WindowState = Excel.XlWindowState.xlMaximized;
            //getdatabase   
            workbook.Worksheets.Add();
            worksheet = workbook.Sheets[1];
            worksheet.Cells[1, 1] = "Dach sách bảo hiểm nhân viên";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã Bảo Hiểm";
            worksheet.Cells[3, 3] = "Mã Nhân Viên";
            worksheet.Cells[3, 4] = "Tên Nhân Viên";
            worksheet.Cells[3, 5] = "Loại Bảo Hiểm";
            worksheet.Cells[3, 6] = "Ngày Hết Hạn";
            worksheet.Cells[3, 7] = "Ngày Cấp";
            worksheet.Cells[3, 8] = "Số Thẻ";
            worksheet.Cells[3, 9] = "Nơi Cấp";

            /// int j = 1;
            List<BaoHiem> lst = new List<BaoHiem>();
            lst = bh.dsbaohiem();
            for (int i = 0; i < lst.Count; i++)
            {


                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = lst[i].MaBaoHiem;
                worksheet.Cells[i + 4, 3] = lst[i].MaNhanVien;
                worksheet.Cells[i + 4, 4] = lst[i].NhanVien.TenNV;
                worksheet.Cells[i + 4, 5] = lst[i].LoaiBaoHiem;
                worksheet.Cells[i + 4, 6] = lst[i].NgayHetHan;
                worksheet.Cells[i + 4, 7] = lst[i].NgayCap;
                worksheet.Cells[i + 4, 8] = lst[i].SoThe;
                worksheet.Cells[i + 4, 9] = lst[i].NoiCap;

            }

            // định dạng trang
            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            worksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;
            worksheet.PageSetup.TopMargin = 0;

            
            worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "E100"].Font.Size = 12;
            worksheet.Range["A1", "H1"].MergeCells = true;
            worksheet.Range["A1", "K3"].Font.Bold = true;

            // kẻ bảng bảo hiểm
            worksheet.Range["A3", "I" + (lst.Count + 3)].Borders.LineStyle = 1;
            // định dạng các dòng
            worksheet.Range["A1", "G1"].HorizontalAlignment = 3;
            worksheet.Range["A3", "K3"].HorizontalAlignment = 3;
            worksheet.Range["A4", "K" + (lst.Count - 1 + 4)].HorizontalAlignment = 3;
            worksheet.Columns.AutoFit();
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
