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
using System.Globalization;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanSu
{
    public partial class ThuongPhatt : DevExpress.XtraEditors.XtraUserControl
    {
        ThuongPhat_DAL_BLL tp_bll_dal = new ThuongPhat_DAL_BLL();
  
        public ThuongPhatt()
        {
            InitializeComponent();
        }

        private void ThuongPhat_Load(object sender, EventArgs e)
        {
            cboxPhongBan.Enabled = cboxTenNhanVien.Enabled = txtMaNV.Enabled = txtLyDo.Enabled = txtEdtTien.Enabled = btnSimpleLuu.Enabled = BtnSimpleXoa.Enabled = false;
            cboxPhongBan.Focus();

            loadThang(); loadNam();
            loadPhongBan();
            loadDataGridView_ThuongPhat();
            if (dgvThuongPhat.DataSource != null)
            {
                bind();
            }
        }
        public void loadPhongBan()
        {
            var dt = tp_bll_dal.GetPhongBans();
            cboxPhongBan.DataSource = dt;
            cboxPhongBan.DisplayMember = "TenPB";
            cboxPhongBan.ValueMember = "MaPB";
        }
        
        public void loadDataGridView_ThuongPhat()
        {
            dgvThuongPhat.DataSource = tp_bll_dal.loadDataGridView_ThuongPhat();
        }
        public void loadThang()
        {
            cboxThang.DataSource = CultureInfo.InvariantCulture.DateTimeFormat.MonthNames.Take(12).ToList();
            cboxThang.SelectedItem = CultureInfo.InvariantCulture.DateTimeFormat
                                        .MonthNames[DateTime.Now.AddMonths(-1).Month - 1];
        }
        public void loadNam()
        {
            cboxNam.DataSource = Enumerable.Range(1983, DateTime.Now.Year - 1983 + 1).ToList();
            cboxNam.SelectedItem = DateTime.Now.Year;


        }
        public void bind()
        {
            BtnSimpleXoa.Enabled = true;
            Binding bdPhongBan = new Binding("Text", dgvThuongPhat.DataSource, "TenPB");
            cboxPhongBan.DataBindings.Clear();
            cboxPhongBan.DataBindings.Add(bdPhongBan);

            Binding bdNhanVien = new Binding("Text", dgvThuongPhat.DataSource, "TenNV");
            cboxTenNhanVien.DataBindings.Clear();
            cboxTenNhanVien.DataBindings.Add(bdNhanVien);

            Binding bdKhenThuong = new Binding("Text", dgvThuongPhat.DataSource, "Loai");
            radioBtnKhenThuong.DataBindings.Clear();
            radioBtnKhenThuong.DataBindings.Add(bdKhenThuong);

            txtLyDo.DataBindings.Clear();
            txtLyDo.DataBindings.Add("Text", dgvThuongPhat.DataSource, "LyDo");

            txtEdtTien.DataBindings.Clear();
            txtEdtTien.DataBindings.Add("Text", dgvThuongPhat.DataSource, "Tien");

            txtMaTP.DataBindings.Clear();
            txtMaTP.DataBindings.Add("Text", dgvThuongPhat.DataSource, "MaThuongPhat");

            dtpNgay.DataBindings.Clear();
            dtpNgay.DataBindings.Add("Text", dgvThuongPhat.DataSource, "Ngay");


        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int row = e.RowHandle;
            string thuongOrPhat = gridView1.GetRowCellValue(row, "Loai").ToString();
            if (thuongOrPhat == "Thưởng")
            {
                radioBtnKhenThuong.Checked = true;
                radioBtnPhat.Checked = false;
            }
            else
            {
                radioBtnKhenThuong.Checked = false;
                radioBtnPhat.Checked = true;
            }
        }

        private void btnSimpleThem_Click(object sender, EventArgs e)
        {
            cboxPhongBan.Enabled = cboxTenNhanVien.Enabled = txtMaNV.Enabled = txtLyDo.Enabled = txtEdtTien.Enabled = btnSimpleLuu.Enabled = BtnSimpleXoa.Enabled = true;
            txtLyDo.Text = "";
            txtMaNV.Text = "";
            txtEdtTien.Text = "";
        }

        private void cboxPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxPhongBan.SelectedValue != null)
            {
                cboxTenNhanVien.DisplayMember = "TenNV";
                cboxTenNhanVien.ValueMember = "MaNhanVien";
                cboxTenNhanVien.DataSource = tp_bll_dal.LoadTenNVByPhongBan(cboxPhongBan.SelectedValue.ToString());
            }
        }
        public bool validate_Tien(string tien)
        {
            Regex regex = new Regex(@"[0-9]$");
            if (!regex.IsMatch(tien))
            {
                return false;
            }
            return true;
        }

        private void btnSimpleLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng click tên nhân viên trên combobox Tên Nhân Viên!");
                return;
            }
            if (txtLyDo.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập lý do khen thưởng!");
                txtLyDo.Focus();
                return;
            }
            if (txtEdtTien.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập tiền trợ cấp!");
                txtEdtTien.Focus();
                return;
            }
            if (!validate_Tien(txtEdtTien.Text))
            {
                MessageBox.Show("Tiền trợ cấp phải là số!");
                txtEdtTien.Focus();
                return;
            }

            string thuongOrPhat = string.Empty;
            if (radioBtnKhenThuong.Checked)
            {
                thuongOrPhat = "Thưởng";
            }
            else
            {
                thuongOrPhat = "Phạt";
            }

            int tien = Int32.Parse(txtEdtTien.Text);
            DateTime ngay = DateTime.Parse(dtpNgay.Text);
            tp_bll_dal.Them1ThuongPhat(thuongOrPhat, tien, txtLyDo.Text, ngay, txtMaNV.Text);
            cboxPhongBan.Enabled = cboxTenNhanVien.Enabled = cboxPhongBan.Enabled = cboxTenNhanVien.Enabled = txtMaNV.Enabled = txtLyDo.Enabled = txtEdtTien.Enabled = btnSimpleLuu.Enabled = BtnSimpleXoa.Enabled = false;
            loadDataGridView_ThuongPhat();
            bind();
            MessageBox.Show("Them thanh cong 1 records thuong phat");
        }

        private void cboxTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxTenNhanVien.SelectedValue != null)
            {
                txtMaNV.Text = cboxTenNhanVien.SelectedValue.ToString();
            }
        }

        private void BtnSimpleXoa_Click(object sender, EventArgs e)
        {
            int matp = Int32.Parse(txtMaTP.Text);
            tp_bll_dal.Xoa1ThuongPhat(matp);
            loadDataGridView_ThuongPhat();
            bind();
            cboxPhongBan.Enabled = cboxTenNhanVien.Enabled = txtMaNV.Enabled = txtLyDo.Enabled = txtEdtTien.Enabled = btnSimpleLuu.Enabled = BtnSimpleXoa.Enabled = false;
            MessageBox.Show("Xóa thành công!");
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
            worksheet.Cells[1, 1] = "Dach sách thưởng phạt";
            worksheet.Cells[3, 1] = "STT";
           
            worksheet.Cells[3, 2] = "Mã Nhân Viên";
            worksheet.Cells[3, 3] = "Tên Nhân Viên";
            worksheet.Cells[3, 4] = "Tên Phòng Ban";
            worksheet.Cells[3, 5] = "Loại";
            worksheet.Cells[3, 6] = "Tiền";
            worksheet.Cells[3, 7] = "Lý Do";
            worksheet.Cells[3, 8] = "Ngày";
           

            /// int j = 1;
            List<ThuongPhat> lst = new List<ThuongPhat>();
            lst = tp_bll_dal.dsThuongPhat();
            for (int i = 0; i < lst.Count; i++)
            {


                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = lst[i].NhanVien.MaNhanVien;
                worksheet.Cells[i + 4, 3] = lst[i].NhanVien.TenNV;
                worksheet.Cells[i + 4, 4] = lst[i].NhanVien.PhongBan.TenPB; ;
                worksheet.Cells[i + 4, 5] = lst[i].Loai;
                worksheet.Cells[i + 4, 6] = lst[i].Tien;
                worksheet.Cells[i + 4, 7] = lst[i].LyDo;
                worksheet.Cells[i + 4, 8] = lst[i].Ngay;
            

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
