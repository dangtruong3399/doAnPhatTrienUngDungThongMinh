using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class ChamCong_BLL_DAL
    {
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        public ChamCong_BLL_DAL() { }
        public IQueryable loadDataGridView_ChamCong()
        {
            var result = from nv in db.NhanViens
                         join cc in db.ChamCongs on nv.MaNhanVien equals cc.MaNhanVien
                         select new
                         {
                             nv.MaNhanVien,
                             nv.TenNV,
                             cc.Ngay,
                             cc.TinhTrang
                         };
            return result;
        }
    }
}
