using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
 public class TudongTang
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();


        public string laymatudongtang(string x, string intput)
        {
            string z = x.Substring(x.Length - 3, 3);
            int a = int.Parse(z);
            if (a >= 0 && a < 9)
            {
                return intput + (int.Parse(z) + 1).ToString();
            }
            else
            {
                return intput.Substring(0, 3) + (int.Parse(z) + 1).ToString();

            }
            //  return intput+(int.Parse(z) + 1).ToString();


        }
    }
}
