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
    public partial class Chucvu : DevExpress.XtraEditors.XtraUserControl
    {

        ChucVu_DALL_BALL cv = new ChucVu_DALL_BALL();
        
        public Chucvu()
        {
            InitializeComponent();
        }

        private void Chucvu_Load(object sender, EventArgs e)
        {
            loadcv();

        }

        public void loadcv()
        {

            dsChucVu.DataSource = cv.loadcvcombox();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
