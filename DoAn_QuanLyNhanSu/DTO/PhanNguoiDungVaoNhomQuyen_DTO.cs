using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DTO
{
    public class PhanNguoiDungVaoNhomQuyen_DTO
    {
        public const int COL_USERNAME = 0;

        private string userName,
            maNhom,
            ghiChu;

        [DisplayName("Tên Đăng Nhập")]
        public string UserName { get => userName; set => userName = value; }
        [DisplayName("Mã Nhóm")]
        public string MaNhom { get => maNhom; set => maNhom = value; }
        [DisplayName("Ghi Chú")]
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
