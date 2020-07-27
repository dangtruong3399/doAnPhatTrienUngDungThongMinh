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
        BaoHiem_DALL_BALL bh = new BaoHiem_DALL_BALL();
        
        public BaoHiem()
        {
            InitializeComponent();
        }

        private void BaoHiem_Load(object sender, EventArgs e)
        {
            //loadbh();
            loadLoaiBH();
        }

        public void loadbh()
        {
            dsBaoHiem.DataSource = bh.loadBaoHiem();
        }

        public void loadLoaiBH()
        {
            cboLoaiBaoHiem.DataSource = bh.loadcboLoaiBaoHiem();
            cboLoaiBaoHiem.DisplayMember = "LoaiBaoHiem";
            //cboLoaiBaoHiem.ValueMember = "SoThe";

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
