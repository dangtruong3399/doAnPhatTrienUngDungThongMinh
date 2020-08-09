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
    public partial class ThuongPhat : DevExpress.XtraEditors.XtraUserControl
    {
        ThuongPhat_DAL_BLL tp_bll_dal = new ThuongPhat_DAL_BLL();
        public ThuongPhat()
        {
            InitializeComponent();
        }

        private void ThuongPhat_Load(object sender, EventArgs e)
        {
            loadPhongBan();
            loadDataGridView_ThuongPhat();
        }
        public void loadPhongBan()
        {
            cboxPB.DataSource = tp_bll_dal.GetPhongBans();
            cboxPB.DisplayMember = "TenPB";
            cboxPB.ValueMember = "MaPB";
        }
        public void loadDataGridView_ThuongPhat()
        {
            dgvThuongPhat.DataSource = tp_bll_dal.loadDataGridView_ThuongPhat();
        }
    }
}
