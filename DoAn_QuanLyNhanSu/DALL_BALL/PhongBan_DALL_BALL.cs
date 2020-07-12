using DALL_BALL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
    public class PhongBan_DALL_BALL
    {

        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();
        PhongBanTableAdapter data1 = new PhongBanTableAdapter();
        //public DataTable loadPhongBanall()
        //{
        //   return  data1.GetPhongBan();
        //   }
        public IQueryable loadphongban()
        {
          var ds=  from PhongBans in data.PhongBans
            join NhanViens in data.NhanViens on PhongBans.MaPB equals NhanViens.MaPB into NhanViens_join
            from NhanViens in NhanViens_join.DefaultIfEmpty()
            group new { PhongBans, NhanViens } by new
            {
                PhongBans.MaPB,
                PhongBans.TenPB
            } into g
            select new
            {
                g.Key.MaPB,
                g.Key.TenPB,
                SoNV = g.Count(p => p.NhanViens.MaPB != null)
            }
            ;
            return ds;
        }

        public bool them1phongbannew(string mapb,string tenpb,int i)
        {
            PhongBan pb = new PhongBan();
            pb.MaPB = mapb;
            pb.TenPB = tenpb;


            data.PhongBans.InsertOnSubmit(pb);
            data.SubmitChanges();
            if (pb.MaPB.Length > 0)
            {
                return true;

            }
            else
                return false;
            
          

            }
        

    }
}
