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
using Excel = Microsoft.Office.Interop.Excel;

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
            worksheet.Cells[1, 1] = "Dach sách bảng lương nhân viên";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã Nhân Viên";
            worksheet.Cells[3, 3] = "Tên Nhân Viên";
            worksheet.Cells[3, 4] = "Số Ngày Công";
            worksheet.Cells[3, 5] = "Hệ Số Lương";
            worksheet.Cells[3, 6] = "Lương Cơ Bản";
            worksheet.Cells[3, 7] = "Trợ Cấp";
            worksheet.Cells[3, 8] = "Thực Lĩnh";
          

            /// int j = 1;
            List<TinhLuong> lst = new List<TinhLuong>();
            lst = bl_bll_dal.dstinhluong();
            for (int i = 0; i < lst.Count; i++)
            {


                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = lst[i].MaNhanVien;
                worksheet.Cells[i + 4, 3] = lst[i].NhanVien.TenNV;
                worksheet.Cells[i + 4, 4] = lst[i].SoNgayCong;
                worksheet.Cells[i + 4, 5] = lst[i].HeSoLuong;
                worksheet.Cells[i + 4, 6] = lst[i].Luong.LuongCB;
                worksheet.Cells[i + 4, 7] = lst[i].TroCap;
                worksheet.Cells[i + 4, 8] = lst[i].ThucLinh;
                

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
    }
}
