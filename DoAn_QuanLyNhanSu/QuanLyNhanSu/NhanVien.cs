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

namespace QuanLyNhanSu
{
    public partial class NhanVien : UserControl
    {
        bool add, update;
        public NhanVien()
        {
            InitializeComponent();
        }

        NhanVien_DALL_BALL nv = new NhanVien_DALL_BALL();
        PhongBan_DALL_BALL pb = new PhongBan_DALL_BALL();
        ChucVu_DALL_BALL cv = new ChucVu_DALL_BALL();
        HopDong_DALL_BALL hd = new HopDong_DALL_BALL();
        Chitietcv_DALL_BALL ctcv = new Chitietcv_DALL_BALL();

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
            string GioiTinh; 

            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dsNhanVien.DataSource, "MaNhanVien");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", dsNhanVien.DataSource, "TenNV");
            cboChucVu.DataBindings.Clear();
            cboChucVu.DataBindings.Add("Text", dsNhanVien.DataSource, "Tencv");
            cboPhongBan.DataBindings.Clear();
            cboPhongBan.DataBindings.Add("Text", dsNhanVien.DataSource, "TenPB");

            //rdNam.DataBindings.Clear();
            //rdNam.DataBindings.Add("Checked", dsNhanVien.DataSource, "GioiTinh");
            //rdNu.DataBindings.Clear();
            //rdNu.DataBindings.Add("Checked", dsNhanVien.DataSource, "GioiTinh");

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
            cboPhongBan.ValueMember = "MaPb";
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
            // string tinhtranhn = txtTTHN.Text;
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

                //string manv = txtMaNV.Text.Trim();
                //string tennv = txtTenNV.Text.Trim();
                //string mapb = cboPhongBan.SelectedValue.ToString();
                //string macv = cboChucVu.SelectedValue.ToString();
                //int hesoluong = int.Parse(cboHeSoLuong.SelectedValue.ToString());
                //string dienthoai = txtDienThoai.Text;
                //string socm = txtSoCM.Text;
                //string diachi = txtDiaChi.Text;
                //string email = txtEmail.Text;
                //string gioitinh = "";
                //string tinhtranhn = txtTTHN.Text;
                //string tinhtranghonnhan = txtTTHN.Text;
                //DateTime ngaysinh = DateTime.Parse(dateNgaySinh.EditValue.ToString());
                //DateTime ngayvaolam = DateTime.Parse(dateNgaySinh.EditValue.ToString());
                //if (rdNam.Checked)
                //    gioitinh = "Nam";
                //else
                //    gioitinh = "Nữ";
                //string hinh = "Hinh" + txtTenNV.Text;

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


                //if(ngayvaolam!=ngayvaolam2)
                //{

                //}

                string mh1 = hd.mahdtheonhanvien(manv);
                hd.sua1hopdong(mh1, ngayvaolam, hesoluong, macv, mapb);

                string ctcv1 = ctcv.getlaymacvtheonv(manv);

                ctcv.sua1chitietcv(ctcv1, macv, ngayvaolam);



                //if(macv!=macv2 && mapb==mapb2) // cv giống nhau macv==macv2 -> sua 
                // {
                //     //  lấy mã cv ban đầu để sữa
                //     if(macv==macv2)
                //     ctcv.sua1chitietcv(manv, macv2, ngayvaolam); // sửa cv cầm theo cv cũ đưa vào

                //     ctcv.them1chitietcv(manv, macv,DateTime.Now, "Thay Đổi Chức Vụ");
                // }
                //else if(macv==macv2 && mapb!=mapb2)
                // {

                //     ctcv.sua1chitietcv(manv, macv, ngayvaolam);
                //     ctcv.them1chitietcv(manv, macv2, DateTime.Now, "Chuyển phòng ban");
                // }
                //else if(macv!=macv2 && mapb!=mapb2)
                // {

                //     ctcv.sua1chitietcv(manv, macv, ngayvaolam);
                //     ctcv.them1chitietcv(manv, macv2, DateTime.Now, "Chuyển chức vụ, Thay đổi chức vụ");
                // }



            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
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
