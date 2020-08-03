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
    public partial class frm_QLNguoiDung : DevExpress.XtraEditors.XtraUserControl
    {
        private NguoiDung_DTO _tmpDTO;
        private readonly NguoiDung_DAL_BLL _dataND;

        public frm_QLNguoiDung()
        {
            _dataND = new NguoiDung_DAL_BLL();
            InitializeComponent();
        }

        private void frm_QLNguoiDung_Load(object sender, EventArgs e)
        {
            LoadGridViewUser();
        }
        private void LoadGridViewUser()
        {
            dgvUser.DataSource = _dataND.layTatCa();
            gvUser.Columns["UserName"].OptionsColumn.AllowEdit = false;
            gvUser.Columns["UserName"].OptionsColumn.ReadOnly = true;
            gvUser.Columns["Pass"].ColumnEdit = txtPasswordChar;
        }
        public void ResetControl()
        {
            txtUserName.ResetText();
            txtTenND.ResetText();
            txtPassword.ResetText();
            txtEmail.ResetText();
            chkStatus.Checked = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Thêm"))
            {
                _tmpDTO = new NguoiDung_DTO()
                {
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                    HoatDong = chkStatus.Checked,
                    Pass = txtPassword.Text,
                    TenNguoiDung = txtTenND.Text
                };
                btnThem.Text = "Cancel";

                ResetControl();

                txtUserName.Enabled = !txtUserName.Enabled;
                txtEmail.Enabled = !txtEmail.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenND.Enabled = !txtTenND.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;


                btnSua.Enabled = !btnSua.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;

                dgvUser.Enabled = !dgvUser.Enabled;
            }
            else
            {
                btnThem.Text = "Thêm";

                txtEmail.Text = _tmpDTO.Email;
                txtPassword.Text = _tmpDTO.Pass;
                txtTenND.Text = _tmpDTO.TenNguoiDung;
                txtUserName.Text = _tmpDTO.UserName;
                chkStatus.Checked = _tmpDTO.HoatDong.Value;

                txtUserName.Enabled = !txtUserName.Enabled;
                txtEmail.Enabled = !txtEmail.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenND.Enabled = !txtTenND.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;


                btnSua.Enabled = !btnSua.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;


                dgvUser.Enabled = !dgvUser.Enabled;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.Equals("Sửa"))
            {
                _tmpDTO = new NguoiDung_DTO()
                {
                    UserName = txtUserName.Text,
                    Email = txtEmail.Text,
                    HoatDong = chkStatus.Checked,
                    Pass = txtPassword.Text,
                    TenNguoiDung = txtTenND.Text
                };
                btnSua.Text = "Cancel";

                txtEmail.Enabled = !txtEmail.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenND.Enabled = !txtTenND.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;


                btnThem.Enabled = !btnThem.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;


                dgvUser.Enabled = !dgvUser.Enabled;
            }
            else
            {
                btnSua.Text = "Sửa";

                txtEmail.Text = _tmpDTO.Email;
                txtPassword.Text = _tmpDTO.Pass;
                txtTenND.Text = _tmpDTO.TenNguoiDung;
                chkStatus.Checked = _tmpDTO.HoatDong.Value;

                txtEmail.Enabled = !txtEmail.Enabled;
                txtPassword.Enabled = !txtPassword.Enabled;
                txtTenND.Enabled = !txtTenND.Enabled;
                chkStatus.Enabled = !chkStatus.Enabled;

                btnThem.Enabled = !btnThem.Enabled;
                btnXoa.Enabled = !btnXoa.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;

                dgvUser.Enabled = !dgvUser.Enabled;
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
                dgvUser.Enabled = !dgvUser.Enabled;
            }
            else
            {
                btnXoa.Text = "Xóa";
                btnSua.Enabled = !btnSua.Enabled;
                btnThem.Enabled = !btnThem.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;
                dgvUser.Enabled = !dgvUser.Enabled;
            }
        }

        private void gvUser_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Email")
            {
                if (!_dataND.EmailIsValid(gvUser.GetRowCellValue(e.RowHandle, "Email").ToString()))
                {
                    MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            var kq = _dataND.UpdateNguoiDung(new NguoiDung_DTO()
            {
                UserName = gvUser.GetRowCellValue(e.RowHandle, "UserName").ToString(),
                Email = gvUser.GetRowCellValue(e.RowHandle, "Email") != null ? gvUser.GetRowCellValue(e.RowHandle, "Email").ToString() : null,
                HoatDong = bool.Parse(gvUser.GetRowCellValue(e.RowHandle, "HoatDong").ToString()),
                Pass = gvUser.GetRowCellValue(e.RowHandle, "Pass").ToString(),
                TenNguoiDung = gvUser.GetRowCellValue(e.RowHandle, "TenNguoiDung").ToString()
            });
            MessageBox.Show("Update " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gvUser_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtUserName.Text = gvUser.GetRowCellValue(e.RowHandle, "UserName").ToString();
            if (gvUser.GetRowCellValue(e.RowHandle, "Email") != null)
            {
                txtEmail.Text = gvUser.GetRowCellValue(e.RowHandle, "Email").ToString();
            }
            else
            {
                txtEmail.ResetText();
            }
            txtPassword.Text = gvUser.GetRowCellValue(e.RowHandle, "Pass").ToString();
            txtTenND.Text = gvUser.GetRowCellValue(e.RowHandle, "TenNguoiDung").ToString();
            chkStatus.Checked = bool.Parse(gvUser.GetRowCellValue(e.RowHandle, "HoatDong").ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Cancel"))
            {
                if (string.IsNullOrEmpty(txtUserName.Text) && string.IsNullOrEmpty(txtPassword.Text) &&
                    string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtTenND.Text))
                {
                    MessageBox.Show("Thông Tin Phải Được Điền Đầy Đủ", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (!_dataND.GetById(txtUserName.Text))
                {
                    if (_dataND.EmailIsValid(txtEmail.Text))
                    {
                        var kq = _dataND.AddNhanVien(new NguoiDung_DTO()
                        {
                            UserName = txtUserName.Text,
                            Email = txtEmail.Text,
                            HoatDong = chkStatus.Checked,
                            Pass = txtPassword.Text,
                            TenNguoiDung = txtTenND.Text
                        });
                        MessageBox.Show("Thêm " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThem.Text = "Thêm";
                        ResetControl();

                        txtUserName.Enabled = !txtUserName.Enabled;
                        txtEmail.Enabled = !txtEmail.Enabled;
                        txtPassword.Enabled = !txtPassword.Enabled;
                        txtTenND.Enabled = !txtTenND.Enabled;
                        chkStatus.Enabled = !chkStatus.Enabled;


                        btnSua.Enabled = !btnSua.Enabled;
                        btnXoa.Enabled = !btnXoa.Enabled;
                        btnLuu.Enabled = !btnLuu.Enabled;


                        dgvUser.Enabled = !dgvUser.Enabled;
                    }
                    else
                    {
                        MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Đã Có Tài Khoản Này Rồi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (btnSua.Text.Equals("Cancel"))
            {
                if (!_dataND.GetById(txtUserName.Text)) return;
                if (_dataND.EmailIsValid(txtEmail.Text))
                {
                    var kq = _dataND.UpdateNguoiDung(new NguoiDung_DTO()
                    {
                        UserName = txtUserName.Text,
                        Email = txtEmail.Text,
                        HoatDong = chkStatus.Checked,
                        Pass = txtPassword.Text,
                        TenNguoiDung = txtTenND.Text
                    });
                    MessageBox.Show("Cập Nhật " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    btnSua.Text = "Sửa";
                    ResetControl();
                    txtEmail.Enabled = !txtEmail.Enabled;
                    txtPassword.Enabled = !txtPassword.Enabled;
                    txtTenND.Enabled = !txtTenND.Enabled;
                    chkStatus.Enabled = !chkStatus.Enabled;

                    btnThem.Enabled = !btnThem.Enabled;
                    btnXoa.Enabled = !btnXoa.Enabled;
                    btnLuu.Enabled = !btnLuu.Enabled;

                    dgvUser.Enabled = !dgvUser.Enabled;
                }
                else
                {
                    MessageBox.Show("Không Đúng Định Dạng Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!_dataND.GetById(txtUserName.Text)) return;
                var kq = _dataND.XoaNguoiDung(txtUserName.Text);
                ResetControl();
                MessageBox.Show("Xóa " + kq.ToString(), kq.ToString(), MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnXoa.Text = "Xóa";
                btnSua.Enabled = !btnSua.Enabled;
                btnThem.Enabled = !btnThem.Enabled;
                btnLuu.Enabled = !btnLuu.Enabled;
                dgvUser.Enabled = !dgvUser.Enabled;
            }
            _dataND.SaveChanged();
            LoadGridViewUser();
        }
    }
}
