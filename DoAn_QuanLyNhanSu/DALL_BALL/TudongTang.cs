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
      

        public string laymatudongtang(string x,string intput)
        {
            string z = x.Substring(x.Length - 1, 1);
            return (int.Parse(z) + 1).ToString();
                
        
        }
    }
}
