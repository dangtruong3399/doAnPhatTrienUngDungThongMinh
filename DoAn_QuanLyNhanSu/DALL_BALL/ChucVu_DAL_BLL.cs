using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
  public  class ChucVu_DAL_BLL
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();
        TudongTang tt = new TudongTang();
        public IQueryable<ChucVu> loadcv()
        {
            return data.ChucVus.Select(t => t);
        }

        public string getmaCVauto()
        {

            string IdMax = data.ChucVus.Max(w => w.MaCV);
            return "CV0" + tt.laymatudongtang(IdMax, "CV0");


        }
        public bool them1phongcv(string macv, string tencv)
        {
            ChucVu cv = new ChucVu();
            cv.MaCV = macv;
            cv.TenCv = tencv;
            data.ChucVus.InsertOnSubmit(cv);
            data.SubmitChanges();
            if (cv.MaCV.Length > 0)
            {
                return true;

            }
            else
                return false;
        }
        public void suacv(string macv, string tencv)
        {

            ChucVu cv = new ChucVu();
            cv = data.ChucVus.Where(c => c.MaCV == macv.Trim()).Single();
            cv.TenCv = tencv;

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
