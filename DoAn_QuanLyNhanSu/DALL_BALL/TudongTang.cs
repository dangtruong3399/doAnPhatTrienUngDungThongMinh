using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
 public   class TudongTang
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();
        public List<string> matudongtangs()
        {
            // List<PhongBan>

            var ds = (from PhongBans in data.PhongBans
                      orderby
                        PhongBans.MaPB descending
                      select new
                      {
                          PhongBans.MaPB
                      }).Take(1).ToList();

            var ds1 = from a in data.PhongBans select a;
            List<string> lst = new List<string>();
            
            return lst = ds;

                   

           

            
           
            
            }

    }
}
