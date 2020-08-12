using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DALL_BALL;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanSu
{
    public partial class NhanVien1 : UserControl
    {
        bool add, update;
        public NhanVien1()
        {
            InitializeComponent();
        }

        NhanVien_DAL_BLL nv = new NhanVien_DAL_BLL();
        PhongBan_DALL_BALL pb = new PhongBan_DALL_BALL();
        ChucVu_DAL_BLL cv = new ChucVu_DAL_BLL();
        HopDong_DAL_BLL hd = new HopDong_DAL_BLL();
        Chitietcv_DAL_BLL ctcv = new Chitietcv_DAL_BLL();
        BaoHiem_DAL_BLL bh = new BaoHiem_DAL_BLL();

        private void NhanVien_Load(object sender, EventArgs e)
        {
            loadpb();
            loadnv();
            loadcv();
            loadhsl();
            databind();
            hienthi(false);
            txtMaNV.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            dateNgaySinh.EditValue = DateTime.Now;
            dateNgayVaoLam.EditValue = DateTime.Now;
            //loadgt();
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.BestFitMaxRowCount = -1;
            gridView1.BestFitColumns();



        }
        public void loadnv()
        {
            dsNhanVien.DataSource = nv.loaddsnhanvien();
        }

        public void hienthi(bool t)
        {
            txtTenNV.Enabled = t;
            txtEmail.Enabled = t;
            txtTrinhDo.Enabled = t;
            txtTTHN.Enabled = t;
            txtSoCM.Enabled = t;
            txtDiaChi.Enabled = t;
            txtDienThoai.Enabled = t;

        }
        public void databind()
        {
            //string GioiTinh; 

            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dsNhanVien.DataSource, "MaNhanVien");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", dsNhanVien.DataSource, "TenNV");
            cboChucVu.DataBindings.Clear();
            cboChucVu.DataBindings.Add("Text", dsNhanVien.DataSource, "Tencv");
            cboPhongBan.DataBindings.Clear();
            cboPhongBan.DataBindings.Add("Text", dsNhanVien.DataSource, "TenPB");
            
            dateNgaySinh.DataBindings.Clear();
            dateNgaySinh.DataBindings.Add("Text",dsNhanVien.DataSource,"NgaySinh");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text",dsNhanVien.DataSource,"DiaChi");
            txtSoCM.DataBindings.Clear();
            txtSoCM.DataBindings.Add("Text", dsNhanVien.DataSource, "SoCM");
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text",dsNhanVien.DataSource,"DienThoai");
            txtTrinhDo.DataBindings.Clear();
            txtTrinhDo.DataBindings.Add("Text",dsNhanVien.DataSource,"TrinhDoHV");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text",dsNhanVien.DataSource,"Email");
            txtTTHN.DataBindings.Clear();
            txtTTHN.DataBindings.Add("Text",dsNhanVien.DataSource,"TTHonNhan");
            cboHeSoLuong.DataBindings.Clear();
            cboHeSoLuong.DataBindings.Add("Text",dsNhanVien.DataSource,"HeSoLuong");
            dateNgayVaoLam.DataBindings.Clear();
            dateNgayVaoLam.DataBindings.Add("Text",dsNhanVien.DataSource,"NgayBatDau");



        }


       
        public void loadpb()
        {
            cboPhongBan.DataSource = pb.loadphongbancombox();
            cboPhongBan.DisplayMember = "TenPB";
            cboPhongBan.ValueMember = "MaPB";
        }
        public void loadcv()
        {
            cboChucVu.DataSource = cv.loadcv();
            cboChucVu.DisplayMember = "TenCv";
            cboChucVu.ValueMember = "MaCV";
               
        }
        public void loadhsl()
        {
            cboHeSoLuong.DataSource = nv.loadcboHeSoLuong();
            cboHeSoLuong.DisplayMember = "LuongCB";
            cboHeSoLuong.ValueMember = "HeSoLuong";
        }
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //nv.xoanhanvien(lblMaNV.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            hienthi(true);
            if (gridView1.RowCount <= 0)
            {
                txtMaNV.Text = "NV001";
            }
            else
            {
                txtMaNV.Text = nv.getMaNVauto();
            }
            resetvalues();
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text.Trim();
            string tennv = txtTenNV.Text.Trim();
            string mapb = cboPhongBan.SelectedValue.ToString();
            string macv = cboChucVu.SelectedValue.ToString();
            int hesoluong = int.Parse(cboHeSoLuong.SelectedValue.ToString());
            string dienthoai = txtDienThoai.Text;
            string socm = txtSoCM.Text;
            string diachi = txtDiaChi.Text;
            string email = txtEmail.Text;
            string gioitinh = "";
            string tinhtranhn = txtTTHN.Text;
            string tinhtranghonnhan = txtTTHN.Text;
            DateTime ngaysinh = DateTime.Parse(dateNgaySinh.EditValue.ToString());
            DateTime ngayvaolam = DateTime.Parse(dateNgayVaoLam.EditValue.ToString());
            if (rdNam.Checked)
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";
            string hinh = "Hinh" + txtTenNV.Text;
           
           
            

            if (add)
            {
               
                // them  1 hopdong
                hd.them1hopdong("", ngayvaolam, hesoluong, macv, mapb);


                // lấy mã hợp đồng mới mới thêm vô
                string mahd = hd.getmahd();
                // them 1 nhanvien
                nv.them1nhanvien(manv, mapb, mahd, tennv, gioitinh, ngaysinh, socm, dienthoai, txtTrinhDo.Text,
                    diachi, email, hinh, tinhtranghonnhan, hesoluong);

                // them 1  chitietcv
                ctcv.them1chitietcv("", manv, macv, ngayvaolam);

                XtraMessageBox.Show("Thành công");
                NhanVien_Load(sender, e);



            }
            if (update)
            {
                //  List<String> lst = new List<string>();

                string mapb2 = pb.mapbtheonhanvien(manv);

                ///    DateTime ngayvaolam2 = DateTime.Parse(ctcv.getlayngayvaolam(manv));

                nv.sua1nhanvien(manv, mapb, tennv, gioitinh, ngaysinh, socm, dienthoai,
                   txtTrinhDo.Text, diachi, email, hinh, tinhtranghonnhan, hesoluong);

                string mh1 = hd.mahdtheonhanvien(manv);
                hd.sua1hopdong(mh1, ngayvaolam, hesoluong, macv, mapb);

                string ctcv1 = ctcv.getlaymacvtheonv(manv);

                ctcv.sua1chitietcv(ctcv1, macv, ngayvaolam);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ctcv.xoa1chitietcv(txtMaNV.Text);
            nv.xoachamcong(txtMaNV.Text);
            nv.xoatinhluong(txtMaNV.Text);
            nv.xoathuongphat(txtMaNV.Text);
            bh.xoa1baohiem(txtMaNV.Text);


            bool kq = nv.xoanhanvien(txtMaNV.Text);
            if (kq)

                if (XtraMessageBox.Show("Bạn có muốn xóa", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XtraMessageBox.Show("Thành công");
                    NhanVien_Load(sender, e);
                }
                else
                {
                    XtraMessageBox.Show("Thất bại");
                }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            add = false;
            update = true;
            hienthi(true);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            NhanVien_Load(sender, e);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            string gioitinh = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GioiTinh").ToString();
            if (gioitinh == "Nam")
            {
                rdNam.Checked = true;

            }
            else
            {
                rdNu.Checked = true;

            }
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
            worksheet.Cells[1, 1] = "Dach sách nhân viên";
            worksheet.Cells[3, 1] = "STT";
            worksheet.Cells[3, 2] = "Mã nhân viên";
            worksheet.Cells[3, 3] = "Tên Nhân Viên";
            worksheet.Cells[3, 4] = "Giới Tính";
            worksheet.Cells[3, 5] = "Ngày Sinh";
            worksheet.Cells[3, 6] = "Trình Độ";
            worksheet.Cells[3, 7] = "TT Hôn Nhân";
            worksheet.Cells[3, 8] = "Phòng Ban";

            /// int j = 1;
            List<NhanVien>lst = new List<NhanVien>();
            lst = nv.dsnhanvien();
            for (int i = 0; i < lst.Count; i++)
            {


                worksheet.Cells[i + 4, 1] = i + 1;
                worksheet.Cells[i + 4, 2] = lst[i].MaNhanVien;
                worksheet.Cells[i + 4, 3] = lst[i].TenNV;
                worksheet.Cells[i + 4, 4] = lst[i].GioiTinh;
                worksheet.Cells[i + 4, 5] = lst[i].NgaySinh;
                worksheet.Cells[i + 4, 6] = lst[i].TrinhDoHV;
                worksheet.Cells[i + 4, 7] = lst[i].TTHonNhan;
                worksheet.Cells[i + 4, 8] = lst[i].PhongBan.TenPB;

            }

            // định dạng trang
            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
            worksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;
            worksheet.PageSetup.TopMargin = 0;

            //định dạng cột
            //worksheet.Range["A1"].ColumnWidth = 5;
            //worksheet.Range["B1"].ColumnWidth = 15;
            //worksheet.Range["C1"].ColumnWidth = 30;
            //worksheet.Range["D1"].ColumnWidth = 10;
            //worksheet.Range["E1"].ColumnWidth = 20;
            //worksheet.Range["F1"].ColumnWidth = 30;
            //worksheet.Range["G1"].ColumnWidth = 30;
            //worksheet.Range["H1"].ColumnWidth = 30;




            worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "E100"].Font.Size = 12;
            worksheet.Range["A1", "H1"].MergeCells = true;
            worksheet.Range["A1", "K3"].Font.Bold = true;
           
            // kẻ bảng nhân viên
            worksheet.Range["A3", "H" + (lst.Count + 3)].Borders.LineStyle = 1;
            // định dạng các dòng
            worksheet.Range["A1", "G1"].HorizontalAlignment = 3;
            worksheet.Range["A3", "K3"].HorizontalAlignment = 3;
            worksheet.Range["A4", "K" + (lst.Count - 1 + 4)].HorizontalAlignment = 3;
            worksheet.Columns.AutoFit();
        }

        public void resetvalues()
        {
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSoCM.Text = "";
            txtTrinhDo.Text = "";
            txtTTHN.Text = "";
            txtDienThoai.Text = "";

        }

    }
}
