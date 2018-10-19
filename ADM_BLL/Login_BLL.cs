using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM_DTO;
using ADM_DAL;

namespace ADM_BLL
{
    public class Login_BLL
    {
        public static string Login(Login_DTO obj)
        {
                if (string.IsNullOrWhiteSpace(obj.user))
                {
                    throw new Exception("User Empty");
                } if (string.IsNullOrWhiteSpace(obj.senha))
                {
                    throw new Exception("Password Empty");
                }
                string msg = Login_DAL.login(obj);
                return msg;
            
        }
    }
}
