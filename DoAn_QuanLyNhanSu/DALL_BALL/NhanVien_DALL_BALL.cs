using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
  public  class NhanVien_DALL_BALL
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();
        public IQueryable loaddsnhanvien()
        {
            var result = from p in data.NhanViens
                         join c in data.PhongBans on p.MaPB equals c.MaPB
                         select new
                         {
                           p.MaNhanVien,p.TenNV,p.GioiTinh,c.TenPB
                         };
            return result;
        }
        public void xoanhanvien(string manv)
        {
            NhanVien nv = new NhanVien();

            nv = data.NhanViens.Where(m => m.MaNhanVien == manv).FirstOrDefault();

            data.NhanViens.DeleteOnSubmit(nv);
            data.SubmitChanges();
        }

    }
}
