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
                             nv.TenNV,
                             tp.Loai,
                             tp.Tien,
                             tp.LyDo
                         };
            return result;
        }
    }
}
