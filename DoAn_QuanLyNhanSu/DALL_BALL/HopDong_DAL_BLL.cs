using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
   public class HopDong_DAL_BLL
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();
        public void them1hopdong(string mahd, DateTime ngayvaolam, int hsl, string macv, string mapb)
        {
            HopDong hd = new HopDong();
            hd.MaHD = mahd;
            hd.NgayVaoLam = ngayvaolam;
            hd.HeSoLuong = hsl;
            hd.MaCV = macv;
            hd.MaPB = mapb;

            data.HopDongs.InsertOnSubmit(hd);
            data.SubmitChanges();
        }


        public void sua1hopdong(string mahd, DateTime ngayvaolam, int hsl, string macv, string mapb)
        {
            HopDong hd = new HopDong();


            hd = data.HopDongs.Where(t => t.MaHD == mahd).FirstOrDefault();
            hd.MaHD = mahd;
            hd.NgayVaoLam = ngayvaolam;
            hd.HeSoLuong = hsl;
            hd.MaCV = macv;
            hd.MaPB = mapb;

            data.SubmitChanges();
        }

        public string mahdtheonhanvien(string manv)
        {

            string x = (from vnd in data.NhanViens
                        where vnd.MaNhanVien == manv
                        select vnd.MaHD).First();
            return x;
        }

        public string getmahd()
        {
            return data.HopDongs.Max(t => t.MaHD);


        }
    }
}
