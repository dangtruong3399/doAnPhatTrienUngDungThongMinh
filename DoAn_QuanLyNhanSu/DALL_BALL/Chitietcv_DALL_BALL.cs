using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class Chitietcv_DALL_BALL
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();


        public void them1chitietcv(string mactcv, string manv, string macv, DateTime ngaybatdau)
        {
            ctChucVu ctcv = new ctChucVu();
            ctcv.Mactcv = mactcv;
            ctcv.MaNhanVien = manv;
            ctcv.MaCV = macv;
            ctcv.NgayBatDau = ngaybatdau;
            //   ctcv.LyDo = lydo;
            ctcv.NgayKetThuc = null;

            data.ctChucVus.InsertOnSubmit(ctcv);
            data.SubmitChanges();
        }

        public void sua1chitietcv(string mactcv, string macv, DateTime ngaybatdau)
        {
            ctChucVu ctcv = new ctChucVu();


            ctcv = data.ctChucVus.Where(t => t.Mactcv == mactcv).FirstOrDefault();
            // ctcv.MaNhanVien = manv;
            ctcv.MaCV = macv;
            ctcv.NgayBatDau = ngaybatdau;
            // ctcv.NgayKetThuc=
            //  ctcv.LyDo = lydo;
            ctcv.NgayKetThuc = null;
            data.SubmitChanges();
        }

        public string getlaymacvtheonv(string manv)
        {

            string x = (from vnd in data.ctChucVus
                        where vnd.MaNhanVien == manv
                        select vnd.Mactcv).FirstOrDefault();
            return x;



        }

        public String getlayngayvaolam(string manv)
        {


            string x = (from vnd in data.ctChucVus
                        where vnd.MaNhanVien == manv
                        select vnd.NgayBatDau.ToString()).First();
            return x;

        }
    }
}
