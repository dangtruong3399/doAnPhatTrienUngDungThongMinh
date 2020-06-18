using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;

namespace BALL
{
    public class Login_BLL
    {
        Login_DLL da = new Login_DLL();
        public bool Checklogin(string taikhoan,string matkhau)
        {
            return da.CheckLogin(taikhoan, matkhau);
        }
    }
}
