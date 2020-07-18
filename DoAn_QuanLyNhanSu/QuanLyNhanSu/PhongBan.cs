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
    public partial class PhongBan : System.Windows.Forms.UserControl
    {
        bool add, update;
        PhongBan_DALL_BALL pb = new PhongBan_DALL_BALL();
        TudongTang tudong = new TudongTang();
        public PhongBan()
        {
            InitializeComponent();
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {

            loadpb();
            txtMapb.Enabled = false;
            hienthi(false);
            bind();



        }
        public void hienthi(bool t)
        {

            txtTenPb.Enabled = t;
        }

        public void  loadpb()
        {
            dsphongban.DataSource = pb.loadphongban();

            }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //txtMapb.Text = tudong.matudongtangs();
              }

       

       

        private void dsphongban_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void groupControlPhongBan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            txtMapb.Text = pb.getmapbauto();
            txtTenPb.Text = "";
            hienthi(true);
            add = true;
            update = false;
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            hienthi(true);
            add = false;
            update = true;
        }

        public void bind()
        {
            txtMapb.DataBindings.Clear();
            txtMapb.DataBindings.Add("Text",dsphongban.DataSource,"MaPB");
            txtTenPb.DataBindings.Clear();
            txtTenPb.DataBindings.Add("Text",dsphongban.DataSource,"TenPB");
            lbSoNV.DataBindings.Clear();
            lbSoNV.DataBindings.Add("Text", dsphongban.DataSource, "SoNV");


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (pb.xoapb(txtMapb.Text))
            {
                XtraMessageBox.Show("Thành Công");
                PhongBan_Load(sender, e);
            }
            else
            {
                XtraMessageBox.Show("Thất bại");
                     }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

         if(add)
            {
                bool kq = pb.them1phongbannew(txtMapb.Text, txtTenPb.Text, 0);
                if (kq)
                {
                    XtraMessageBox.Show("Thanh Cong");
                    PhongBan_Load(sender, e);
                }
                else
                {
                    XtraMessageBox.Show("Error");

                }
            }
         if(update)
            {
                pb.suaphongban(txtMapb.Text,txtTenPb.Text);
                PhongBan_Load(sender, e);
                XtraMessageBox.Show("Thanh Cong");
            }

        }
                
                   
        
    }
}
