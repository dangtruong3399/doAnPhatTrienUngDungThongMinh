using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class BaoHiem_DALL_BALL
    {
        TudongTang tt = new TudongTang();
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();

        public IQueryable loadBaoHiem()
        {
            var bh = from NhanViens in data.NhanViens
                     join BaoHiems in data.BaoHiems on NhanViens.MaNhanVien equals BaoHiems.MaNhanVien into BaoHiems_join
                     from BaoHiems in BaoHiems_join.DefaultIfEmpty()
                     select new
                     {
                         NhanViens.MaNhanVien,
                         NhanViens.TenNV,
                         LoaiBaoHiem = BaoHiems.LoaiBaoHiem,
                         NgayHetHan = (DateTime?)BaoHiems.NgayHetHan
                     };
            return bh;
        }

        public IQueryable loadcboLoaiBaoHiem()
        {
            var bhiem = from bh in data.BaoHiems select new { bh.LoaiBaoHiem };
            return bhiem;
        }
       
    }
}
