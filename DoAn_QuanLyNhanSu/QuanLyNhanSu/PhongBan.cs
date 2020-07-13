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
        PhongBan_DALL_BALL pb = new PhongBan_DALL_BALL();
        TudongTang tudong = new TudongTang();
        public PhongBan()
        {
            InitializeComponent();
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {

            loadpb();



        }

        public void  loadpb()
        {
           // dsphongban.DataSource = tudong.matudongtangs();

            }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            txtMapb.Text = tudong.matudongtangs();
              }

        private void btnThem_Click(object sender, EventArgs e)
        {
           bool kq= pb.them1phongbannew(txtMapb.Text, txtTenPb.Text,0);
            if(kq)
            {
                XtraMessageBox.Show("Thanh Cong");
            }
            else
            {
                XtraMessageBox.Show("Error");

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void dsphongban_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }
    }
}
