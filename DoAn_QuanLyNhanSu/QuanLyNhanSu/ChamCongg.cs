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
            worksheet.Cells[1, 1] = "Dach sách Chấm Công";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã Nhân Viên";
            worksheet.Cells[3, 3] = "Tên Nhân Viên";
            worksheet.Cells[3, 4] = "Ngày";
            worksheet.Cells[3, 5] = "Tình Trạng";


            /// int j = 1;
            List<ChamCong> lst = new List<ChamCong>();
            lst = cc_bll_dal.dsChamCong();
            for (int i = 0; i < lst.Count; i++)
            {


                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = lst[i].MaNhanVien;
                worksheet.Cells[i + 4, 3] = lst[i].NhanVien.TenNV;
                worksheet.Cells[i + 4, 4] = lst[i].Ngay;
                worksheet.Cells[i + 4, 5] = lst[i].TinhTrang;
               

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
            worksheet.Range["A3", "E" + (lst.Count + 3)].Borders.LineStyle = 1;
            // định dạng các dòng
            worksheet.Range["A1", "G1"].HorizontalAlignment = 3;
            worksheet.Range["A3", "K3"].HorizontalAlignment = 3;
            worksheet.Range["A4", "K" + (lst.Count - 1 + 4)].HorizontalAlignment = 3;
            worksheet.Columns.AutoFit();
        }
    }
}
