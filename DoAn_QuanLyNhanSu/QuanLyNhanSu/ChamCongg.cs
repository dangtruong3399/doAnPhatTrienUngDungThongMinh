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
    public partial class ChamCongg : DevExpress.XtraEditors.XtraUserControl
    {
        ChamCong_BLL_DAL cc_bll_dal = new ChamCong_BLL_DAL();
        public ChamCongg()
        {
            InitializeComponent();
        }

        private void ChamCongg_Load(object sender, EventArgs e)
        {

        }
        public void loadDataGridView_ChamCong()
        {

        }
    }
}
