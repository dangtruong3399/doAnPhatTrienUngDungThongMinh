using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class Kiemtrakhoacs
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();



        public bool kiemtrakhoanv(string manv)
        {
            Taikhoan taikhoan = new Taikhoan();
            taikhoan = data.Taikhoans.Where(m => m.MaNhanVien == manv).FirstOrDefault();
            if (taikhoan != null)
            {
                return true;
            }
            else
                return false;

        }
    }
}
