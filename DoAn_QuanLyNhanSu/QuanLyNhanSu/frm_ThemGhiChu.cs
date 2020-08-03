using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyNhanSu
{
    public partial class frm_ThemGhiChu : DevExpress.XtraEditors.XtraForm
    {
        public string GHICHU;
        public frm_ThemGhiChu()
        {
            InitializeComponent();
        }
        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            GHICHU = tbThemGhiChu.Text;
            DialogResult = DialogResult.Yes;
            Dispose();
            Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Dispose();
            Close();
        }
    }
}