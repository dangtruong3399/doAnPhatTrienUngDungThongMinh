using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class BangLuong_BLL_DAL
    {
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        public BangLuong_BLL_DAL() { }
        public IQueryable<Luong> GetLuongs()
        {
            return db.Luongs;
        }
    }
}
