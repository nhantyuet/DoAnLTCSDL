using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class LoginBL
    {
        private LoginDL loginDL;
        public LoginBL()
        {
            loginDL = new LoginDL();
        }
        public string CheckLoginBL(TaiKhoan taiKhoan)
        {
            try
            {
                if (loginDL.CheckLoginDL(taiKhoan) != null && loginDL.CheckLoginDL(taiKhoan) != "")
                    return loginDL.CheckLoginDL(taiKhoan);
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
