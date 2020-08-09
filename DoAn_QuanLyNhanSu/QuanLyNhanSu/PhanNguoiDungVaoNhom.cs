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
using DevExpress.Utils;
using Library;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLyNhanSu
{
    public partial class PhanNguoiDungVaoNhom : DevExpress.XtraEditors.XtraUserControl
    {
        private NhomQuyen_DAL_BLL nQuyen_DAL_BLL;
        private NguoiDung_DAL_BLL nDung_DAL_BLL;
        private PhanNguoiDungVaoNhomQuyen_DAL_BLL pND_NQ_DAL_BLL;
        private int rowNhanVienSelected;
        private int rowPhanQuyenSelected;
        public PhanNguoiDungVaoNhom()
        {
            InitializeComponent();
        }

        private void frmPhanNguoiDungVaoNhom_Load(object sender, EventArgs e)
        {
            //khởi tạo biến tại đây
            nQuyen_DAL_BLL = new NhomQuyen_DAL_BLL();
            nDung_DAL_BLL = new NguoiDung_DAL_BLL();
            pND_NQ_DAL_BLL = new PhanNguoiDungVaoNhomQuyen_DAL_BLL();
            rowNhanVienSelected = -1;
            rowPhanQuyenSelected = -1;

            //load mới tại đây
            loadNhomQuyens();
            loadNguoiDungs();
            loadNhanVienTheoNhom();

            //sự kiên tại đây
            gvNhanViens.RowClick += GvNhanViens_RowClick;
            gvPhanNhanVienVaoNhomQuyen.RowClick += GvPhanNhanVienVaoNhomQuyen_RowClick;
            btnThemNhanVien_QuaPhai.Click += btnThemNhanVien_QuaPhai_Click;
            btnXoaNhanVienQuaTrai.Click += btnXoaNhanVienQuaTrai_Click;

        }
        private void GvPhanNhanVienVaoNhomQuyen_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowPhanQuyenSelected = e.RowHandle;
        }
        private void GvNhanViens_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            rowNhanVienSelected = e.RowHandle;
        }
        private void loadNhomQuyens()
        {
            cboxNhomQuyen.DataSource = nQuyen_DAL_BLL.layTatCa();
            cboxNhomQuyen.DisplayMember = "TenNhom";
            cboxNhomQuyen.ValueMember = "MaNhom";
        }

        private void loadNguoiDungs()
        {
            dgvNhanViens.DataSource = nDung_DAL_BLL.layTatCa();
        }

        private void loadNhanVienTheoNhom()
        {
            var maNhom = cboxNhomQuyen.SelectedValue;
            if (maNhom == null)
                return;
            dgvPhanNhanVienVaoNhoms.DataSource = nDung_DAL_BLL.layNguoiDungTheoMaNhom(maNhom.ToString());
        }

        private void cboxNhomQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadNhanVienTheoNhom();
        }
        public static void hienThiThongBaoLoi(string mess)
        {
            MessageBox.Show(mess, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnThemNhanVien_QuaPhai_Click(object sender, EventArgs e)
        {
            if (rowNhanVienSelected == -1)
            {
                hienThiThongBaoLoi("Chưa chọn ngừoi dùng để thêm");
                return;
            }

            string uName = layTextGridView(gvNhanViens, rowNhanVienSelected, NguoiDung_DTO.COL_USERNAME);
            if (string.IsNullOrEmpty(uName))
            {
                hienThiThongBaoLoi("Chọn người dùng để thêm bị lỗi");
                return;
            }

            var maNhom = cboxNhomQuyen.SelectedValue;
            if (maNhom == null)
            {
                hienThiThongBaoLoi("Chưa chọn nhóm quyền!");
                return;
            }
            
            //Chắc chắn?
            string mess = string.Format("Sắp phân cho {0} có quyền {1}", uName, cboxNhomQuyen.SelectedItem);
            DialogResult res = hienThiCauHoiYesNo(mess);
            if (res == DialogResult.No)
                return;

            string ghiChu = layGhiChuTuNguoiDung();

            //Thêm Nhan viên vào nhóm.
            PhanNguoiDungVaoNhomQuyen_DTO pNV_NQ = new PhanNguoiDungVaoNhomQuyen_DTO();
            pNV_NQ.UserName = uName;
            pNV_NQ.MaNhom = maNhom.ToString();
            pNV_NQ.GhiChu = ghiChu;

            EStatus status = pND_NQ_DAL_BLL.them(pNV_NQ);
            if (status == EStatus.THANH_CONG)
            {
                hienThiThongBaoThanhCong("Phân nguời dùng thành công!");
                loadNhanVienTheoNhom();
            }
            else
                hienThiThongBaoLoi("Phân người dùng thất bại!");
        }
        public static string layGhiChuTuNguoiDung()
        {
            string ghiChu = null;
            frm_ThemGhiChu frmThemGhiChu = new frm_ThemGhiChu();
            DialogResult result = frmThemGhiChu.ShowDialog();
            if (result == DialogResult.Yes)
                ghiChu = frmThemGhiChu.GHICHU;

            return ghiChu;
        }
        public static void hienThiThongBaoThanhCong(string mess)
        {
            MessageBox.Show(mess, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoaNhanVienQuaTrai_Click(object sender, EventArgs e)
        {
            if (rowPhanQuyenSelected == -1)
                return;

            string uName = layTextGridView(gvPhanNhanVienVaoNhomQuyen, rowPhanQuyenSelected, PhanNguoiDungVaoNhomQuyen_DTO.COL_USERNAME);
            if (string.IsNullOrEmpty(uName))
            {
                hienThiThongBaoLoi("Chọn ngừoi dùng để xoá bị lỗi");
                return;
            }

            var maNhom = cboxNhomQuyen.SelectedValue;
            if (maNhom == null)
            {
                hienThiThongBaoLoi("Chưa chọn nhóm quyền!");
                return;
            }

            //Chắc chắn?
            string mess = string.Format("Sắp xóa ngừoi dùng {0} tại nhóm {1}", uName, cboxNhomQuyen.SelectedItem);
            DialogResult res = hienThiCauHoiYesNo(mess);
            if (res == DialogResult.No)
                return;

            EStatus status = pND_NQ_DAL_BLL.xoa(uName, maNhom.ToString());
            if (status == EStatus.THANH_CONG)
            {
                hienThiThongBaoThanhCong("Xóa Người Dùng thành công");
                loadNhanVienTheoNhom();
            }
            else
                hienThiThongBaoLoi("Đã Gặp lỗi xóa ngừoi dùng khỏi nhóm!");
        }
    }
}
