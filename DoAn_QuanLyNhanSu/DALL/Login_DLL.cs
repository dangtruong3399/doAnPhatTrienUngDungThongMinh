using DALL.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class Login_DLL
    {
        TaikhoanTableAdapter da = new TaikhoanTableAdapter();
        public  bool CheckLogin(string taikhoan,string matkhau)
        {
            DataTable dt = new DataTable();
            
            DataSet1 data = new DataSet1();
            dt = da.checklogin(taikhoan, matkhau);
            if (dt.Rows.Count>0)
            {
                return true;
            }
            else
                return false;
        }

    }
}
