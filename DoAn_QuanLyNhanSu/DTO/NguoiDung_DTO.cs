using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DTO
{
    public class NguoiDung_DTO
    {
        public const int COL_USERNAME = 0;

        private string userName,
            pass,
            tenNguoiDung,
            email;
        private bool? hoatDong;

        [DisplayName("Tên Đăng Nhập")]
        public string UserName { get => userName; set => userName = value; }
        [DisplayName("Mật Khẩu")]
        public string Pass { get => pass; set => pass = value; }
        [DisplayName("Tên Người Dùng")]
        public string TenNguoiDung { get => tenNguoiDung; set => tenNguoiDung = value; }
        [DisplayName("Email")]
        public string Email { get => email; set => email = value; }
        [DisplayName("Hoạt Động")]
        public bool? HoatDong { get => hoatDong; set => hoatDong = value; }
    }
}
