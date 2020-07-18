using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
  public  class ChucVu_DALL_BALL
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();

        public IQueryable loadcvcombox()
        {
            var ds = from k in data.ChucVus select new { k.MaCV,k.TenCv};
            return ds;
        }
        public void them1phongcv(string macv, string tencv)
        {
            ChucVu cv = new ChucVu();
            cv.MaCV = macv;
            cv.TenCv = tencv;
            data.ChucVus.InsertOnSubmit(cv);
            data.SubmitChanges();
        }
        public void suacv(string macv, string tencv)
        {

           ChucVu cv = new ChucVu();
            cv = data.ChucVus.Where(c => c.MaCV == macv).FirstOrDefault();


            data.SubmitChanges();
        }
        public bool xoapb(string macv)
        {
            ChucVu cv = new ChucVu();
            cv = data.ChucVus.Where(m => m.MaCV == macv).FirstOrDefault();
            if (cv != null)
            {
                data.ChucVus.DeleteOnSubmit(cv);
                data.SubmitChanges();
                return true;
            }
            else
                return false;
        }
    }
}
