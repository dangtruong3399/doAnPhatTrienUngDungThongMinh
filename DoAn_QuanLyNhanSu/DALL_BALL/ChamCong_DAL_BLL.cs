using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class ChamCong_DAL_BLL
    {
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        public ChamCong_DAL_BLL() { }

        public IQueryable layDSChamCong()
        {
            var result = from cc in db.ChamCongs
                         select new
                         {
                             cc.MaNhanVien,
                             cc.Ngay,
                             cc.TinhTrang
                         };
            return result;
        }

        public IQueryable loadNhanVien()
        {
            var result = from nv in db.NhanViens
                         join pb in db.PhongBans on nv.MaPB equals pb.MaPB
                         select new
                         {
                             nv.MaNhanVien,
                             nv.TenNV,
                             pb.TenPB
                         };
            return result;
        }

        public bool Them1DongChamCong(string manv, DateTime ngay, string tinhtrang)
        {
            try
            {
                ChamCong cc = new ChamCong();
                cc.MaNhanVien = manv;
                cc.Ngay = ngay;
                cc.TinhTrang = tinhtrang;
                db.ChamCongs.InsertOnSubmit(cc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
