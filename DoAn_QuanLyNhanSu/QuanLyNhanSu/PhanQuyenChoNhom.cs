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
using DTO;
using System.Drawing.Text;
using DevExpress.ClipboardSource.SpreadsheetML;
using Library;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLyNhanSu
{
    public partial class PhanQuyenChoNhom : DevExpress.XtraEditors.XtraUserControl
    {
        private NhomQuyen_DAL_BLL nQuyen_DAL_BAL;
        private PhanQuyen_DAL_BLL pQuyen_DAL_BAL;
        private int rowNhomQuyenSelected;
        private int rowQuyenNhomCoSelected;
        private int rowQuyenNhomChuaCoSelected;
        public PhanQuyenChoNhom()
        {
            InitializeComponent();
        }

        private void frmPhanQuyenChoNhom_Load(object sender, EventArgs e)
        {
            nQuyen_DAL_BAL = new NhomQuyen_DAL_BLL();
            pQuyen_DAL_BAL = new PhanQuyen_DAL_BLL();
            rowNhomQuyenSelected = -1;
            rowQuyenNhomChuaCoSelected = rowQuyenNhomChuaCoSelected = -1;

            nQuyen_DAL_BAL.lamMoiTaiTatCaQuyen_choNhom();
            loadNhomQuyen();
            loadQuyenChoNhom();

            gvNhomQuyen.RowClick += GvNhomQuyen_RowClick;
            btnThemQuyenChoNhom.Click += BtnThemQuyenChoNhom_Click;
            btnBoQuyenChoNhom.Click += BtnBoQuyenChoNhom_Click;
            gvQuyenNhomCo.RowClick += GvQuyenNhomCo_RowClick;
            gvQuyenNhomChuaCo.RowClick += GvQuyenNhomChuaCo_RowClick;
        }
        private void GvQuyenNhomChuaCo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowQuyenNhomChuaCoSelected = e.RowHandle;
        }

        private void GvQuyenNhomCo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowQuyenNhomCoSelected = e.RowHandle;
        }

        public static string layTextGridView(GridView gridView, int row, int col)
        {
            if (row < 0 || row >= gridView.RowCount)
                return null;
            var text = gridView.GetRowCellValue(row, gridView.Columns[col]);
            return text == null ? null : text.ToString();
        }
        public static DialogResult hienThiCauHoiYesNo(string mess)
        {
            return MessageBox.Show(mess, "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void BtnBoQuyenChoNhom_Click(object sender, EventArgs e)
        {
            if (rowNhomQuyenSelected < 0 || rowQuyenNhomCoSelected < 0)
                return;

            string maNhom = layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_MANHOM),
                maQuyen = layTextGridView(gvQuyenNhomCo, rowQuyenNhomCoSelected, Quyen_DTO.COL_MAQUYEN),
                tenNhom = layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_TENNHOM),
                tenQuyen = layTextGridView(gvQuyenNhomCo, rowQuyenNhomCoSelected, Quyen_DTO.COL_TENQUYEN);

            string mess = string.Format("Chuẩn bị tước quyền [{0}] cho nhóm [{1}]", tenQuyen, tenNhom);
            DialogResult dRest = hienThiCauHoiYesNo(mess);
            if (dRest == DialogResult.No)
                return;

            PhanQuyen_DTO pQuyen = new PhanQuyen_DTO
            {
                MaNhom = maNhom,
                MaQuyen = maQuyen,
                CoQuyen = false
            };

            EStatus status = pQuyen_DAL_BAL.capNhat(pQuyen);
            if (status != EStatus.THANH_CONG)
            {
                hienThiThongBaoLoi("Tước quyền cho nhóm thất bại!");
                return;
            }

            hienThiThongBaoThanhCong("Tước quyền cho nhóm thành công");
            loadQuyenChoNhom();
        }
        public static void hienThiThongBaoLoi(string mess)
        {
            MessageBox.Show(mess, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void hienThiThongBaoThanhCong(string mess)
        {
            MessageBox.Show(mess, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnThemQuyenChoNhom_Click(object sender, EventArgs e)
        {
            if (rowNhomQuyenSelected < 0 || rowQuyenNhomChuaCoSelected < 0)
                return;

            string maNhom = layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_MANHOM),
                maQuyen =layTextGridView(gvQuyenNhomChuaCo, rowQuyenNhomChuaCoSelected, Quyen_DTO.COL_MAQUYEN),
                tenNhom = layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_TENNHOM),
                tenQuyen = layTextGridView(gvQuyenNhomChuaCo, rowQuyenNhomChuaCoSelected, Quyen_DTO.COL_TENQUYEN);

            string mess = string.Format("Chuẩn bị thêm quyền [{0}] cho nhóm [{1}]", tenQuyen, tenNhom);
            DialogResult dRest = hienThiCauHoiYesNo(mess);
            if (dRest == DialogResult.No)
                return;

            PhanQuyen_DTO pQuyen = new PhanQuyen_DTO
            {
                MaNhom = maNhom,
                MaQuyen = maQuyen,
                CoQuyen = true
            };

            EStatus status = pQuyen_DAL_BAL.capNhat(pQuyen);
            if (status != EStatus.THANH_CONG)
            {
                hienThiThongBaoLoi("Thêm quyền cho nhóm thất bại!");
                return;
            }

            hienThiThongBaoThanhCong("Thêm quyền cho nhóm thành công");
            loadQuyenChoNhom();
        }

        private void GvNhomQuyen_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowNhomQuyenSelected = e.RowHandle;
            loadQuyenChoNhom();
        }

        private void loadNhomQuyen()
        {
            var source = nQuyen_DAL_BAL.layTatCa();
            dgvNhomQuyens.DataSource = source;
        }

        private void loadQuyenChoNhom()
        {
            if (rowNhomQuyenSelected < 0)
                return;
            string maNhom = layTextGridView(gvNhomQuyen, rowNhomQuyenSelected, NhomQuyen_DTO.COL_MANHOM);
            dgvQuenNhomCo.DataSource = nQuyen_DAL_BAL.layQuyenChoNhom(maNhom, true);
            dgvQuyenNhomChuaCo.DataSource = nQuyen_DAL_BAL.layQuyenChoNhom(maNhom, false);
        }
    }
}
