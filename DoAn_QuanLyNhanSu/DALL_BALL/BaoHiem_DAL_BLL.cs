using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
   public class BaoHiem_DAL_BLL
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();

        public List<BaoHiem> dsbaohiem()
        {
            return data.BaoHiems.ToList();
        }
        public IQueryable laybaobaohiem()
        {
            var ds = from k in data.BaoHiems
                     select new
                     {
                         k.MaBaoHiem,
                         k.MaNhanVien,
                         k.NhanVien.TenNV,
                         k.LoaiBaoHiem,
                         k.NgayHetHan,
                         k.NgayCap,
                         k.SoThe,
                         k.NoiCap,




                     };
            return ds;

        }

        public void sua1hiem(string mabaohiem, string manhanvien, DateTime ngaycapp, DateTime ngayhethan, string noicap, string sothe, string loaibaohiem)
        {

            BaoHiem bh = new BaoHiem();


            bh = data.BaoHiems.Where(t => t.MaBaoHiem == mabaohiem).FirstOrDefault();
            if (bh != null)
            {


                bh.NgayCap = ngaycapp;
                bh.NgayHetHan = ngayhethan;
                bh.NoiCap = noicap;
                bh.SoThe = sothe;
                bh.LoaiBaoHiem = loaibaohiem;
                data.SubmitChanges();
            }
        }



        public void xoa1baohiem(string mabaohiem)
        {
            BaoHiem bh = new BaoHiem();
            bh = data.BaoHiems.Where(t => t.MaBaoHiem == mabaohiem).FirstOrDefault();

            if (bh != null)
            {
                data.BaoHiems.DeleteOnSubmit(bh);
                data.SubmitChanges();
            }


        }
    }
}
