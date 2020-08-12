using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class BangLuong_DAL_BLL
    {
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        public BangLuong_DAL_BLL() { }

        public List<TinhLuong> dstinhluong()
        {
            return db.TinhLuongs.ToList();
        }
        public IQueryable<Luong> GetLuongs()
        {
            return db.Luongs;
        }
        public IQueryable loadNhanVien_BangLuong()
        {
            var result = from nv in db.NhanViens
                         join l in db.Luongs on nv.HeSoLuong equals l.HeSoLuong
                         join pb in db.PhongBans on nv.MaPB equals pb.MaPB
                         select new
                         {
                             nv.MaNhanVien,
                             nv.TenNV,
                             pb.TenPB,
                             l.HeSoLuong,
                             l.LuongCB
                         };
            return result;
        }

        public IQueryable load_BangLuong()
        {
            var result = from nv in db.NhanViens
                         join l in db.Luongs on nv.HeSoLuong equals l.HeSoLuong
                         join tl in db.TinhLuongs on nv.MaNhanVien equals tl.MaNhanVien
                         select new
                         {
                             nv.MaNhanVien,
                             nv.TenNV,
                             tl.SoNgayCong,
                             l.HeSoLuong,
                             l.LuongCB,
                             tl.TroCap,
                             tl.ThucLinh
                         };
            return result;
        }

        public int GetCountByID(string manv)
        {
            IQueryable<ChamCong> result = (from q in db.ChamCongs
                                           where q.MaNhanVien.Equals(manv)
                                           select q);
            return result.Count();
        }

        public bool Them1DongBangLuong(string manv, int hesoluong, int ngaycong, int trocap, int thuclinh)
        {
            try
            {
                TinhLuong tl = new TinhLuong();
                tl.MaNhanVien = manv;
                tl.HeSoLuong = hesoluong;
                tl.SoNgayCong = ngaycong;
                tl.TroCap = trocap;
                tl.ThucLinh = thuclinh;
                db.TinhLuongs.InsertOnSubmit(tl);
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
