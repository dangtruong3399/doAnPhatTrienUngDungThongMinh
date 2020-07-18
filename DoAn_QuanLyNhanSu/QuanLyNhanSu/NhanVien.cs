using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALL_BALL;

namespace QuanLyNhanSu
{
    public partial class NhanVien : UserControl
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        NhanVien_DALL_BALL nv = new NhanVien_DALL_BALL();
        PhongBan_DALL_BALL pb = new PhongBan_DALL_BALL();
        ChucVu_DALL_BALL cv = new ChucVu_DALL_BALL();

        private void NhanVien_Load(object sender, EventArgs e)
        {
            loadpb();
            loadnv();
            loadcv();
           
        }
        public void loadnv()
        {
            dsNhanVien.DataSource =nv.loaddsnhanvien();
        }
        public void loadpb()
        {
            cboPhongBan.DataSource = pb.loadphongbancombox();
            cboPhongBan.DisplayMember = "TenPB";
            cboPhongBan.ValueMember = "MaPb";
        }
        public void loadcv()
        {
            cboChucVu.DataSource = cv.loadcvcombox();
            cboChucVu.DisplayMember = "TenCv";
            cboChucVu.ValueMember = "MaCV";
               
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
            nv.xoanhanvien(lblMaNV.Text);
        }
    }
}
