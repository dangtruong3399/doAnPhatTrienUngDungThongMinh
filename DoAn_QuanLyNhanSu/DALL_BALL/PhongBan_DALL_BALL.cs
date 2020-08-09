
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class PhongBan_DALL_BALL
    {

        TudongTang tt = new TudongTang();
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();
        
        public IQueryable loadphongban()
        {
            var ds = from PhongBans in data.PhongBans
                     join NhanViens in data.NhanViens on PhongBans.MaPB equals NhanViens.MaPB into NhanViens_join
                     from NhanViens in NhanViens_join.DefaultIfEmpty()
                     group new { PhongBans, NhanViens } by new
                     {
                         PhongBans.MaPB,
                         PhongBans.TenPB
                     } into g
                     select new
                     {
                         g.Key.MaPB,
                         g.Key.TenPB,
                         SoNV = g.Count(p => p.NhanViens.MaPB != null)
                     }
              ;
            return ds;
        }
        public IQueryable loadphongbancombox()
        {

            var ds = from k in data.PhongBans select k;
            return ds;
        }
        public bool them1phongbannew(string mapb, string tenpb, int i)
        {
            PhongBan pb = new PhongBan();
            pb.MaPB = mapb;
            pb.TenPB = tenpb;


            data.PhongBans.InsertOnSubmit(pb);
            data.SubmitChanges();
            if (pb.MaPB.Length > 0)
            {
                return true;

            }
            else
                return false;



        }

        public bool xoapb(string mapb)
        {
            PhongBan pb = new PhongBan();
            pb = data.PhongBans.Where(m => m.MaPB == mapb).FirstOrDefault();

            if (pb != null)
            {
                data.PhongBans.DeleteOnSubmit(pb);
                data.SubmitChanges();
                return true;
            }
            else
                return false;

        }
        public string getmapbauto()
        {

            string IdMax = data.PhongBans.Max(w => w.MaPB);
            return tt.laymatudongtang(IdMax, "PB00");


        }
        public void suaphongban(string mapb, string tenpb)
        {
            PhongBan pb = new PhongBan();
            pb = data.PhongBans.Where(m => m.MaPB == mapb).FirstOrDefault();
            pb.TenPB = tenpb;


            data.SubmitChanges();
        }
        public string mapbtheonhanvien(string manv)
        {
            string x = (from vnd in data.NhanViens
                        where vnd.MaNhanVien == manv
                        select vnd.MaPB).First();
            return x;
        }

    }
}
