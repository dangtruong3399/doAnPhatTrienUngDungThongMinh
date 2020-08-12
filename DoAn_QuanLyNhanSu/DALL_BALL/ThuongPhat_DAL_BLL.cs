using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class ThuongPhat_DAL_BLL
    {
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        public ThuongPhat_DAL_BLL() { }
        public IQueryable<NhanVien> LoadMaNVByTenNV(string mannv)
        {
            return db.NhanViens.Where(nv => nv.MaNhanVien == mannv);
        }
        public IQueryable<NhanVien> LoadTenNVByPhongBan(string mapb)
        {
            return db.NhanViens.Where(nv => nv.MaPB == mapb);
        }
        public IQueryable<PhongBan> GetPhongBans()
        {
            return db.PhongBans;
        }
        public IQueryable loadDataGridView_ThuongPhat()
        {
            var result = from nv in db.NhanViens
                         join pb in db.PhongBans on nv.MaPB equals pb.MaPB
                         join tp in db.ThuongPhats on nv.MaNhanVien equals tp.MaNhanVien
                         select new
                         {
                             tp.MaThuongPhat,
                             pb.TenPB,
                             nv.TenNV,
                             tp.Loai,
                             tp.Tien,
                             tp.LyDo,
                             tp.Ngay,
                             nv.MaNhanVien
                         };
            return result;
        }
        public bool Them1ThuongPhat(string loai, int tien, string lydo, DateTime ngay, string manv)
        {
            try
            {
                ThuongPhat tp = new ThuongPhat();
                tp.Loai = loai;
                tp.Tien = tien;
                tp.LyDo = lydo;
                tp.Ngay = ngay;
                tp.MaNhanVien = manv;
                db.ThuongPhats.InsertOnSubmit(tp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Xoa1ThuongPhat(int matp)
        {
            try
            {
                ThuongPhat tp = db.ThuongPhats.Where(t => t.MaThuongPhat == matp).FirstOrDefault();
                db.ThuongPhats.DeleteOnSubmit(tp);
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
