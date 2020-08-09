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

namespace QuanLyNhanSu
{
    public partial class QuanLyQuyen : DevExpress.XtraEditors.XtraUserControl
    {
        private Quyen_DTO _tmpDTO;
        private readonly Quyen_DAL_BLL _dataQuyen;
        private readonly PhanQuyen_DAL_BLL _dataPhanQuyen;
        public QuanLyQuyen()
        {
            _dataQuyen = new Quyen_DAL_BLL();
            _dataPhanQuyen = new PhanQuyen_DAL_BLL();
            InitializeComponent();
        }

        

        private void frmQuanLyQuyen_Load(object sender, EventArgs e)
        {
            LoadGridViewQuyen();

        }
        private void LoadGridViewQuyen()
        {
            dgvQuyen.DataSource = _dataQuyen.layTatCa();
            gvQuyen.Columns["MaQuyen"].OptionsColumn.AllowEdit = false;
            gvQuyen.Columns["MaQuyen"].OptionsColumn.ReadOnly = true;
        }

        private void gvQuyen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var kq = _dataQuyen.UpdateQuyen(new Quyen_DTO()
            {
                TenQuyen = gvQuyen.GetRowCellValue(e.RowHandle, "TenQuyen").ToString(),
                MaQuyen = gvQuyen.GetRowCellValue(e.RowHandle, "MaQuyen").ToString(),
                GhiChu = gvQuyen.GetRowCellValue(e.RowHandle, "GhiChu") != null ? gvQuyen.GetRowCellValue(e.RowHandle, "GhiChu").ToString() : null
            });
            MessageBox.Show("Update " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gvQuyen_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtMaQuyen.Text = gvQuyen.GetRowCellValue(e.RowHandle, "MaQuyen").ToString();
            if (gvQuyen.GetRowCellValue(e.RowHandle, "GhiChu") != null)
            {
                txtGhiChu.Text = gvQuyen.GetRowCellValue(e.RowHandle, "GhiChu").ToString();
            }
            else
            {
                txtGhiChu.ResetText();
            }
            txtTenQuyen.Text = gvQuyen.GetRowCellValue(e.RowHandle, "TenQuyen").ToString();
        }
        public void ResetControl()
        {
            txtGhiChu.ResetText();
            txtMaQuyen.ResetText();
            txtTenQuyen.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Thêm"))
            {
                _tmpDTO = new Quyen_DTO()
                {
                    MaQuyen = txtMaQuyen.Text,
                    TenQuyen = txtTenQuyen.Text,
                    GhiChu = txtGhiChu.Text,
                };
                btnThem.Text = "Cancel";

                ResetControl();

                txtMaQuyen.Enabled = !txtMaQuyen.Enabled;
                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;


                btnSua.Enabled = !btnSua.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;

                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
            else
            {
                btnThem.Text = "Thêm";

                txtMaQuyen.Text = _tmpDTO.MaQuyen;
                txtTenQuyen.Text = _tmpDTO.TenQuyen;
                txtGhiChu.Text = _tmpDTO.GhiChu;



                txtMaQuyen.Enabled = !txtMaQuyen.Enabled;
                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;



                btnSua.Enabled = !btnSua.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;


                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.Equals("Sửa"))
            {
                _tmpDTO = new Quyen_DTO()
                {
                    MaQuyen = txtMaQuyen.Text,
                    TenQuyen = txtTenQuyen.Text,
                    GhiChu = txtGhiChu.Text
                };
                btnSua.Text = "Cancel";

                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;



                btnThem.Enabled = !btnThem.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;


                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
            else
            {
                btnSua.Text = "Sửa";

                txtTenQuyen.Text = _tmpDTO.TenQuyen;
                txtGhiChu.Text = _tmpDTO.GhiChu;

                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;

                btnThem.Enabled = !btnThem.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;

                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text.Equals("Xóa"))
            {
                btnXoa.Text = "Cancel";
                btnThem.Enabled = !btnThem.Enabled;
                btnSua.Enabled = !btnSua.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;
                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
            else
            {
                btnXoa.Text = "Xóa";
                btnSua.Enabled = !btnSua.Enabled;
                btnThem.Enabled = !btnThem.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;
                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Cancel"))
            {
                if (string.IsNullOrEmpty(txtMaQuyen.Text) &&
                    string.IsNullOrEmpty(txtTenQuyen.Text))
                {
                    MessageBox.Show("Tên Quyền Và Mã Quyền Phải Điền Đầy Đủ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!_dataQuyen.GetById(txtMaQuyen.Text))
                {

                    var kq = _dataQuyen.AddQuyen(new Quyen_DTO()
                    {
                        TenQuyen = txtTenQuyen.Text,
                        MaQuyen = txtMaQuyen.Text,
                        GhiChu = txtGhiChu.Text
                    });

                    MessageBox.Show("Them " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnThem.Text = "Thêm";
                    ResetControl();
                    btnThem.Text = "Thêm";

                    txtMaQuyen.Text = _tmpDTO.MaQuyen;
                    txtTenQuyen.Text = _tmpDTO.TenQuyen;
                    txtGhiChu.Text = _tmpDTO.GhiChu;



                    txtMaQuyen.Enabled = !txtMaQuyen.Enabled;
                    txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                    txtGhiChu.Enabled = !txtGhiChu.Enabled;



                    btnSua.Enabled = !btnSua.Enabled;
                    btnXoa.Enabled = !btnXoa.Enabled;
                    btnLuu.Enabled = !btnLuu.Enabled;


                    dgvQuyen.Enabled = !dgvQuyen.Enabled;
                }
                else
                {
                    MessageBox.Show("Đã Có Tên Quyền Này Rồi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (btnSua.Text.Equals("Cancel"))
            {
                if (!_dataQuyen.GetById(txtMaQuyen.Text)) return;
                var kq = _dataQuyen.UpdateQuyen(new Quyen_DTO()
                {
                    TenQuyen = txtTenQuyen.Text,
                    MaQuyen = txtMaQuyen.Text,
                    GhiChu = txtGhiChu.Text
                });
                MessageBox.Show("Sua " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSua.Text = "Sửa";

                txtTenQuyen.Text = _tmpDTO.TenQuyen;
                txtGhiChu.Text = _tmpDTO.GhiChu;

                txtTenQuyen.Enabled = !txtTenQuyen.Enabled;
                txtGhiChu.Enabled = !txtGhiChu.Enabled;

                btnThem.Enabled = !btnThem.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;

                dgvQuyen.Enabled = !dgvQuyen.Enabled;
            }
            else
            {
                if (!_dataQuyen.GetById(txtMaQuyen.Text))
                {
                    return;
                }
                var kq = _dataQuyen.XoaQuyen(txtMaQuyen.Text);
                MessageBox.Show("Xoa " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnXoa.Text = "Xóa";
                btnSua.Enabled = !btnSua.Enabled;
                btnThem.Enabled = !btnThem.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;
                dgvQuyen.Enabled = !dgvQuyen.Enabled;

            }
            _dataQuyen.SaveChanged();
            LoadGridViewQuyen();
        }
    }
}
